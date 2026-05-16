
-- --------------------------------------------------------------
-- 1.1  Browse All Available Movies
-- --------------------------------------------------------------
DROP PROCEDURE IF EXISTS sp_GetAllMovies;
GO

CREATE PROCEDURE sp_GetAllMovies
AS
BEGIN
    SELECT  M.movie_id,
            M.title,
            M.description,
            M.duration_min,
            M.language,
            MG.Mgenre
    FROM    MOVIE M
    LEFT JOIN MOVIE_GENRE MG ON M.movie_id = MG.movie_id
    ORDER BY M.title;
END;
GO



-- --------------------------------------------------------------
-- 1.2  Search Movies by Genre
-- --------------------------------------------------------------
DROP PROCEDURE IF EXISTS sp_GetMoviesByGenre;
GO

CREATE PROCEDURE sp_GetMoviesByGenre
    @Genre VARCHAR(50)
AS
BEGIN
    SELECT  M.movie_id,
            M.title,
            M.duration_min,
            M.language,
            MG.Mgenre
    FROM    MOVIE M
    INNER JOIN MOVIE_GENRE MG ON M.movie_id = MG.movie_id
    WHERE   MG.Mgenre = @Genre
    ORDER BY M.title;
END;
GO

--EXEC sp_GetMoviesByGenre @Genre = 'Sci-Fi';


-- --------------------------------------------------------------
-- 1.3  View Showtimes for a Specific Movie
-- --------------------------------------------------------------
DROP PROCEDURE IF EXISTS sp_GetShowtimesByMovie;
GO

CREATE PROCEDURE sp_GetShowtimesByMovie
    @MovieID INT
AS
BEGIN
    SELECT  S.showtime_id,
            M.title,
            C.name          AS cinema_name,
            C.city,
            S.hall_no,
            S.slot,
            S.date,
            SP.slot_price
    FROM    SHOWTIME S
    INNER JOIN MOVIE            M   ON S.movie_id  = M.movie_id
    INNER JOIN CINEMA           C   ON S.cinema_id = C.cinema_id
    INNER JOIN SHOWTIME_SLOT_PRICE SP ON S.slot    = SP.slot
    WHERE   S.movie_id = @MovieID
    ORDER BY S.date, S.slot;
END;
GO

--EXEC sp_GetShowtimesByMovie @MovieID = 1;


-- --------------------------------------------------------------
-- 1.4  View Available Seats for a Showtime
-- --------------------------------------------------------------
DROP PROCEDURE IF EXISTS sp_GetAvailableSeats;
GO

CREATE PROCEDURE sp_GetAvailableSeats
    @ShowtimeID INT
AS
BEGIN
    DECLARE @HallNo   INT;
    DECLARE @CinemaID INT;

    SELECT  @HallNo   = hall_no,
            @CinemaID = cinema_id
    FROM    SHOWTIME
    WHERE   showtime_id = @ShowtimeID;

    SELECT  ST.seat_no,
            ST.seat_type,
            STV.seat_price
    FROM    SEAT ST
    INNER JOIN SEAT_TYPE_VALUE STV ON ST.seat_type = STV.seat_type
    WHERE   ST.hall_no   = @HallNo
      AND   ST.cinema_id = @CinemaID
      AND   ST.seat_no NOT IN (
                SELECT  R.seat_no
                FROM    RESERVATION R
                WHERE   R.showtime_id = @ShowtimeID
                  AND   R.hall_no     = @HallNo
                  AND   R.cinema_id   = @CinemaID
            )
    ORDER BY ST.seat_no;
END;
GO

--EXEC sp_GetAvailableSeats @ShowtimeID = 1;


-- --------------------------------------------------------------
-- 1.5  Make a Booking
-- --------------------------------------------------------------
DROP PROCEDURE IF EXISTS sp_MakeBooking;
GO

CREATE PROCEDURE sp_MakeBooking
    @CustomerID    INT,
    @ShowtimeID    INT,
    @SeatNo        INT,
    @PaymentMethod VARCHAR(50),
    @NewBookingID  INT          OUTPUT,
    @ErrorMessage  VARCHAR(255) OUTPUT
AS
BEGIN
    DECLARE @HallNo      INT;
    DECLARE @CinemaID    INT;
    DECLARE @SeatPrice   MONEY;
    DECLARE @SlotPrice   MONEY;
    DECLARE @TotalPrice  MONEY;
    DECLARE @NewTicketID INT;

    SET @NewBookingID = -1;
    SET @ErrorMessage = '';

    -- Validate Customer
    IF NOT EXISTS (SELECT 1 FROM CUSTOMER WHERE customer_id = @CustomerID)
    BEGIN
        SET @ErrorMessage = 'Customer not found.';
        RETURN;
    END;

    -- Validate Showtime
    SELECT  @HallNo    = S.hall_no,
            @CinemaID  = S.cinema_id,
            @SlotPrice = SP.slot_price
    FROM    SHOWTIME S
    INNER JOIN SHOWTIME_SLOT_PRICE SP ON S.slot = SP.slot
    WHERE   S.showtime_id = @ShowtimeID;

    IF @HallNo IS NULL
    BEGIN
        SET @ErrorMessage = 'Showtime not found.';
        RETURN;
    END;

    -- Validate Seat exists
    SELECT  @SeatPrice = STV.seat_price
    FROM    SEAT ST
    INNER JOIN SEAT_TYPE_VALUE STV ON ST.seat_type = STV.seat_type
    WHERE   ST.seat_no   = @SeatNo
      AND   ST.hall_no   = @HallNo
      AND   ST.cinema_id = @CinemaID;

    IF @SeatPrice IS NULL
    BEGIN
        SET @ErrorMessage = 'Seat not found in this hall.';
        RETURN;
    END;

    -- Validate Seat is not already reserved
    IF EXISTS (
        SELECT 1 FROM RESERVATION
        WHERE  showtime_id = @ShowtimeID
          AND  seat_no     = @SeatNo
          AND  hall_no     = @HallNo
          AND  cinema_id   = @CinemaID
    )
    BEGIN
        SET @ErrorMessage = 'Seat is already reserved for this showtime.';
        RETURN;
    END;

    -- All checks passed — insert
    SET @TotalPrice = @SeatPrice + @SlotPrice;

    INSERT INTO BOOKING (customer_id, booking_date, booking_status)
    VALUES (@CustomerID, CAST(GETDATE() AS DATE), 'pending');
    SET @NewBookingID = SCOPE_IDENTITY();

    INSERT INTO PAYMENT (booking_id, payment_method, payment_date, amount, payment_status)
    VALUES (@NewBookingID, @PaymentMethod, CAST(GETDATE() AS DATE), @TotalPrice, 'pending');

    INSERT INTO TICKET (booking_id)
    VALUES (@NewBookingID);
    SET @NewTicketID = SCOPE_IDENTITY();

    INSERT INTO RESERVATION (ticket_id, seat_no, showtime_id, hall_no, cinema_id, price)
    VALUES (@NewTicketID, @SeatNo, @ShowtimeID, @HallNo, @CinemaID, @TotalPrice);

    -- Return the new booking details to the GUI
    SELECT  B.booking_id,
            B.booking_date,
            B.booking_status,
            P.amount,
            P.payment_method,
            P.payment_status
    FROM    BOOKING B
    INNER JOIN PAYMENT P ON B.booking_id = P.booking_id
    WHERE   B.booking_id = @NewBookingID;
END;
GO

--DECLARE @BookingRef INT; DECLARE @ErrMsg VARCHAR(255);
--EXEC sp_MakeBooking 10, 1, 1, 'Credit Card', @BookingRef OUTPUT, @ErrMsg OUTPUT;
--SELECT @BookingRef AS NewBookingID, @ErrMsg AS ErrorMessage;


-- --------------------------------------------------------------
-- 1.6  View My Bookings
-- --------------------------------------------------------------
DROP PROCEDURE IF EXISTS sp_GetMyBookings;
GO

CREATE PROCEDURE sp_GetMyBookings
    @CustomerID INT
AS
BEGIN
    SELECT  B.booking_id,
            B.booking_date,
            B.booking_status,
            P.payment_method,
            P.payment_status,
            P.amount
    FROM    BOOKING B
    LEFT JOIN PAYMENT P ON B.booking_id = P.booking_id
    WHERE   B.customer_id = @CustomerID
    ORDER BY B.booking_date DESC;
END;
GO

--EXEC sp_GetMyBookings @CustomerID = 2;


-- --------------------------------------------------------------
-- 1.7  View My Ticket Details
-- --------------------------------------------------------------
DROP PROCEDURE IF EXISTS sp_GetMyTickets;
GO

CREATE PROCEDURE sp_GetMyTickets
    @CustomerID INT
AS
BEGIN
    SELECT  T.ticket_id,
            B.booking_id,
            B.booking_date,
            M.title             AS movie_title,
            C.name              AS cinema_name,
            C.city,
            S.slot,
            S.date              AS show_date,
            R.seat_no,
            ST.seat_type,
            R.price             AS ticket_price,
            B.booking_status
    FROM    BOOKING B
    INNER JOIN TICKET       T   ON B.booking_id  = T.booking_id
    INNER JOIN RESERVATION  R   ON T.ticket_id   = R.ticket_id
    INNER JOIN SHOWTIME     S   ON R.showtime_id = S.showtime_id
    INNER JOIN MOVIE        M   ON S.movie_id    = M.movie_id
    INNER JOIN CINEMA       C   ON S.cinema_id   = C.cinema_id
    INNER JOIN SEAT         ST  ON R.seat_no     = ST.seat_no
                                AND R.hall_no    = ST.hall_no
                                AND R.cinema_id  = ST.cinema_id
    WHERE   B.customer_id = @CustomerID
    ORDER BY S.date DESC;
END;
GO

--EXEC sp_GetMyTickets @CustomerID = 2;


-- --------------------------------------------------------------
-- 1.8  Cancel a Booking
-- --------------------------------------------------------------
DROP PROCEDURE IF EXISTS sp_CancelBooking;
GO

CREATE PROCEDURE sp_CancelBooking
    @BookingID    INT,
    @CustomerID   INT,
    @Success      BIT         OUTPUT,
    @ErrorMessage VARCHAR(255) OUTPUT
AS
BEGIN
    SET @Success      = 0;
    SET @ErrorMessage = '';

    -- Validate booking belongs to this customer and is not already cancelled
    IF NOT EXISTS (
        SELECT 1 FROM BOOKING
        WHERE  booking_id   = @BookingID
          AND  customer_id  = @CustomerID
          AND  booking_status <> 'cancelled'
    )
    BEGIN
        SET @ErrorMessage = 'Booking not found or already cancelled.';
        RETURN;
    END;

    UPDATE BOOKING
    SET    booking_status = 'cancelled'
    WHERE  booking_id = @BookingID;

    UPDATE PAYMENT
    SET    payment_status = 'failed'
    WHERE  booking_id = @BookingID;

    SET @Success = 1;

    -- Return updated booking row to the GUI
    SELECT  B.booking_id,
            B.booking_status,
            P.payment_status
    FROM    BOOKING B
    INNER JOIN PAYMENT P ON B.booking_id = P.booking_id
    WHERE   B.booking_id = @BookingID;
END;
GO

-- DECLARE @Ok BIT; DECLARE @Err VARCHAR(255);
-- EXEC sp_CancelBooking 2, 1, @Ok OUTPUT, @Err OUTPUT;
-- SELECT @Ok AS Success, @Err AS ErrorMessage;



-- --------------------------------------------------------------
-- 1.9  Confirm Payment
-- --------------------------------------------------------------
DROP PROCEDURE IF EXISTS sp_ConfirmPayment;
GO

CREATE PROCEDURE sp_ConfirmPayment
    @BookingID    INT,
    @CustomerID   INT,
    @Success      BIT          OUTPUT,
    @ErrorMessage VARCHAR(255) OUTPUT
AS
BEGIN
    SET @Success      = 0;
    SET @ErrorMessage = '';

    -- Validate booking belongs to this customer
    IF NOT EXISTS (
        SELECT 1 FROM BOOKING
        WHERE  booking_id  = @BookingID
          AND  customer_id = @CustomerID
    )
    BEGIN
        SET @ErrorMessage = 'Booking not found for this customer.';
        RETURN;
    END;

    -- Validate not already confirmed
    IF EXISTS (
        SELECT 1 FROM BOOKING
        WHERE  booking_id     = @BookingID
          AND  booking_status = 'confirmed'
    )
    BEGIN
        SET @ErrorMessage = 'Booking is already confirmed.';
        RETURN;
    END;

    UPDATE PAYMENT
    SET    payment_status = 'completed'
    WHERE  booking_id = @BookingID;

    UPDATE BOOKING
    SET    booking_status = 'confirmed'
    WHERE  booking_id = @BookingID;

    SET @Success = 1;

    -- Return updated booking row to the GUI
    SELECT  B.booking_id,
            B.booking_status,
            P.payment_status,
            P.amount
    FROM    BOOKING B
    INNER JOIN PAYMENT P ON B.booking_id = P.booking_id
    WHERE   B.booking_id = @BookingID;
END;
GO

DECLARE @Ok BIT; DECLARE @Err VARCHAR(255);
EXEC sp_ConfirmPayment 1, 1, @Ok OUTPUT, @Err OUTPUT;
SELECT @Ok AS Success, @Err AS ErrorMessage;





-- --------------------------------------------------------------
-- 2.1  Calculate Total Ticket Price  (seat + slot)
-- --------------------------------------------------------------
DROP FUNCTION IF EXISTS dbo.fn_CalcTicketPrice;
GO

CREATE FUNCTION dbo.fn_CalcTicketPrice
(
    @ShowtimeID INT,
    @SeatNo     INT
)
RETURNS MONEY
AS
BEGIN
    DECLARE @SeatPrice MONEY;
    DECLARE @SlotPrice MONEY;
    DECLARE @HallNo    INT;
    DECLARE @CinemaID  INT;

    SELECT  @HallNo   = hall_no,
            @CinemaID = cinema_id
    FROM    SHOWTIME
    WHERE   showtime_id = @ShowtimeID;

    SELECT  @SeatPrice = STV.seat_price
    FROM    SEAT ST
    INNER JOIN SEAT_TYPE_VALUE STV ON ST.seat_type = STV.seat_type
    WHERE   ST.seat_no   = @SeatNo
      AND   ST.hall_no   = @HallNo
      AND   ST.cinema_id = @CinemaID;

    SELECT  @SlotPrice = SP.slot_price
    FROM    SHOWTIME S
    INNER JOIN SHOWTIME_SLOT_PRICE SP ON S.slot = SP.slot
    WHERE   S.showtime_id = @ShowtimeID;

    RETURN ISNULL(@SeatPrice, 0) + ISNULL(@SlotPrice, 0);
END;
GO

SELECT dbo.fn_CalcTicketPrice(1, 1) AS TicketPrice;


-- --------------------------------------------------------------
-- 2.2  Get Total Amount Spent by a Customer
-- --------------------------------------------------------------
DROP FUNCTION IF EXISTS dbo.fn_GetCustomerTotalSpent;
GO

CREATE FUNCTION dbo.fn_GetCustomerTotalSpent
(
    @CustomerID INT
)
RETURNS MONEY
AS
BEGIN
    DECLARE @TotalSpent MONEY;

    SELECT  @TotalSpent = SUM(P.amount)
    FROM    PAYMENT  P
    INNER JOIN BOOKING B ON P.booking_id = B.booking_id
    WHERE   B.customer_id    = @CustomerID
      AND   P.payment_status = 'completed';

    RETURN ISNULL(@TotalSpent, 0);
END;
GO

 SELECT dbo.fn_GetCustomerTotalSpent(1) AS TotalSpent;


-- --------------------------------------------------------------
-- 2.3  Count Bookings for a Customer
-- --------------------------------------------------------------
DROP FUNCTION IF EXISTS dbo.fn_CountCustomerBookings;
GO

CREATE FUNCTION dbo.fn_CountCustomerBookings
(
    @CustomerID INT
)
RETURNS INT
AS
BEGIN
    DECLARE @BookingCount INT;

    SELECT  @BookingCount = COUNT(*)
    FROM    BOOKING
    WHERE   customer_id = @CustomerID;

    RETURN ISNULL(@BookingCount, 0);
END;
GO

-- SELECT dbo.fn_CountCustomerBookings(1) AS BookingCount;


-- --------------------------------------------------------------
-- 2.4  Get Movie Duration Label
-- --------------------------------------------------------------
DROP FUNCTION IF EXISTS dbo.fn_GetMovieDurationLabel;
GO

CREATE FUNCTION dbo.fn_GetMovieDurationLabel
(
    @MovieID INT
)
RETURNS VARCHAR(20)
AS
BEGIN
    DECLARE @Duration INT;
    DECLARE @Label    VARCHAR(20);

    SELECT  @Duration = duration_min
    FROM    MOVIE
    WHERE   movie_id = @MovieID;

    IF @Duration < 90
        SET @Label = 'Short';
    ELSE IF @Duration BETWEEN 90 AND 140
        SET @Label = 'Standard';
    ELSE
        SET @Label = 'Long';

    RETURN ISNULL(@Label, 'Unknown');
END;
GO

-- SELECT title, duration_min,
--        dbo.fn_GetMovieDurationLabel(movie_id) AS DurationLabel
-- FROM MOVIE;



-- --------------------------------------------------------------
-- 3.1  Get Showtimes on a Specific Date
-- --------------------------------------------------------------
DROP FUNCTION IF EXISTS dbo.fn_GetShowtimesByDate;
GO

CREATE FUNCTION dbo.fn_GetShowtimesByDate
(
    @ShowDate DATE
)
RETURNS TABLE
AS
RETURN
(
    SELECT  S.showtime_id,
            M.title         AS movie_title,
            C.name          AS cinema_name,
            C.city,
            S.slot,
            S.date,
            SP.slot_price
    FROM    SHOWTIME S
    INNER JOIN MOVIE            M   ON S.movie_id  = M.movie_id
    INNER JOIN CINEMA           C   ON S.cinema_id = C.cinema_id
    INNER JOIN SHOWTIME_SLOT_PRICE SP ON S.slot    = SP.slot
    WHERE   S.date = @ShowDate
);
GO

-- SELECT * FROM dbo.fn_GetShowtimesByDate('2026-04-25');


-- --------------------------------------------------------------
-- 3.2  Get Movies Showing in a Specific Cinema
-- --------------------------------------------------------------
DROP FUNCTION IF EXISTS dbo.fn_GetMoviesByCinema;
GO

CREATE FUNCTION dbo.fn_GetMoviesByCinema
(
    @CinemaID INT
)
RETURNS TABLE
AS
RETURN
(
    SELECT  DISTINCT
            M.movie_id,
            M.title,
            M.duration_min,
            M.language,
            MG.Mgenre
    FROM    MOVIE M
    INNER JOIN SHOWTIME     S  ON M.movie_id  = S.movie_id
    LEFT  JOIN MOVIE_GENRE  MG ON M.movie_id  = MG.movie_id
    WHERE   S.cinema_id = @CinemaID
);
GO

-- SELECT * FROM dbo.fn_GetMoviesByCinema(1);


-- --------------------------------------------------------------
-- 3.3  Get Full Booking Details for a Customer
-- --------------------------------------------------------------
DROP FUNCTION IF EXISTS dbo.fn_GetCustomerBookingDetails;
GO

CREATE FUNCTION dbo.fn_GetCustomerBookingDetails
(
    @CustomerID INT
)
RETURNS TABLE
AS
RETURN
(
    SELECT  B.booking_id,
            B.booking_date,
            B.booking_status,
            M.title             AS movie_title,
            C.name              AS cinema_name,
            C.city,
            S.slot,
            S.date              AS show_date,
            R.seat_no,
            ST.seat_type,
            P.amount,
            P.payment_method,
            P.payment_status
    FROM    BOOKING B
    INNER JOIN TICKET       T   ON B.booking_id  = T.booking_id
    INNER JOIN RESERVATION  R   ON T.ticket_id   = R.ticket_id
    INNER JOIN SHOWTIME     S   ON R.showtime_id = S.showtime_id
    INNER JOIN MOVIE        M   ON S.movie_id    = M.movie_id
    INNER JOIN CINEMA       C   ON S.cinema_id   = C.cinema_id
    INNER JOIN SEAT         ST  ON R.seat_no     = ST.seat_no
                                AND R.hall_no    = ST.hall_no
                                AND R.cinema_id  = ST.cinema_id
    LEFT  JOIN PAYMENT      P   ON B.booking_id  = P.booking_id
    WHERE   B.customer_id = @CustomerID
);
GO

-- SELECT * FROM dbo.fn_GetCustomerBookingDetails(1);
-- SELECT * FROM dbo.fn_GetCustomerBookingDetails(1)
-- WHERE booking_status = 'confirmed' ORDER BY show_date DESC;



-- --------------------------------------------------------------
-- 4.1  Get Movies Filtered by Slot Type
-- --------------------------------------------------------------
DROP FUNCTION IF EXISTS dbo.fn_GetMoviesBySlotType;
GO

CREATE FUNCTION dbo.fn_GetMoviesBySlotType
(
    @SlotType VARCHAR(10)
)
RETURNS @MovieTable TABLE
(
    showtime_id  INT,
    movie_title  VARCHAR(200),
    cinema_name  VARCHAR(100),
    city         VARCHAR(100),
    slot         VARCHAR(20),
    show_date    DATE,
    slot_price   MONEY
)
AS
BEGIN
    IF @SlotType = 'Today'
    BEGIN
        INSERT INTO @MovieTable
        SELECT  S.showtime_id, M.title, C.name, C.city,
                S.slot, S.date, SP.slot_price
        FROM    SHOWTIME S
        INNER JOIN MOVIE            M   ON S.movie_id  = M.movie_id
        INNER JOIN CINEMA           C   ON S.cinema_id = C.cinema_id
        INNER JOIN SHOWTIME_SLOT_PRICE SP ON S.slot    = SP.slot
        WHERE   S.date = CAST(GETDATE() AS DATE);
    END
    ELSE IF @SlotType = 'Weekend'
    BEGIN
        INSERT INTO @MovieTable
        SELECT  S.showtime_id, M.title, C.name, C.city,
                S.slot, S.date, SP.slot_price
        FROM    SHOWTIME S
        INNER JOIN MOVIE            M   ON S.movie_id  = M.movie_id
        INNER JOIN CINEMA           C   ON S.cinema_id = C.cinema_id
        INNER JOIN SHOWTIME_SLOT_PRICE SP ON S.slot    = SP.slot
        WHERE   DATEPART(weekday, S.date) IN (6, 7, 1);
    END
    ELSE
    BEGIN
        INSERT INTO @MovieTable
        SELECT  S.showtime_id, M.title, C.name, C.city,
                S.slot, S.date, SP.slot_price
        FROM    SHOWTIME S
        INNER JOIN MOVIE            M   ON S.movie_id  = M.movie_id
        INNER JOIN CINEMA           C   ON S.cinema_id = C.cinema_id
        INNER JOIN SHOWTIME_SLOT_PRICE SP ON S.slot    = SP.slot
        WHERE   S.date >= CAST(GETDATE() AS DATE);
    END;

    RETURN;
END;
GO

-- SELECT * FROM dbo.fn_GetMoviesBySlotType('Today');
-- SELECT * FROM dbo.fn_GetMoviesBySlotType('Weekend');
-- SELECT * FROM dbo.fn_GetMoviesBySlotType('All');


-- --------------------------------------------------------------
-- 4.2  Get Customer Booking Summary by Status
-- --------------------------------------------------------------
DROP FUNCTION IF EXISTS dbo.fn_GetCustomerBookingSummary;
GO

CREATE FUNCTION dbo.fn_GetCustomerBookingSummary
(
    @CustomerID  INT,
    @SummaryType VARCHAR(15)
)
RETURNS @SummaryTable TABLE
(
    booking_id      INT,
    booking_date    DATE,
    booking_status  VARCHAR(20),
    movie_title     VARCHAR(200),
    show_date       DATE,
    slot            VARCHAR(20),
    amount          MONEY,
    payment_status  VARCHAR(20)
)
AS
BEGIN
    IF @SummaryType = 'Confirmed'
    BEGIN
        INSERT INTO @SummaryTable
        SELECT  B.booking_id, B.booking_date, B.booking_status,
                M.title, S.date, S.slot, P.amount, P.payment_status
        FROM    BOOKING B
        INNER JOIN TICKET       T   ON B.booking_id  = T.booking_id
        INNER JOIN RESERVATION  R   ON T.ticket_id   = R.ticket_id
        INNER JOIN SHOWTIME     S   ON R.showtime_id = S.showtime_id
        INNER JOIN MOVIE        M   ON S.movie_id    = M.movie_id
        LEFT  JOIN PAYMENT      P   ON B.booking_id  = P.booking_id
        WHERE   B.customer_id    = @CustomerID
          AND   B.booking_status = 'confirmed';
    END
    ELSE IF @SummaryType = 'Cancelled'
    BEGIN
        INSERT INTO @SummaryTable
        SELECT  B.booking_id, B.booking_date, B.booking_status,
                M.title, S.date, S.slot, P.amount, P.payment_status
        FROM    BOOKING B
        INNER JOIN TICKET       T   ON B.booking_id  = T.booking_id
        INNER JOIN RESERVATION  R   ON T.ticket_id   = R.ticket_id
        INNER JOIN SHOWTIME     S   ON R.showtime_id = S.showtime_id
        INNER JOIN MOVIE        M   ON S.movie_id    = M.movie_id
        LEFT  JOIN PAYMENT      P   ON B.booking_id  = P.booking_id
        WHERE   B.customer_id    = @CustomerID
          AND   B.booking_status = 'cancelled';
    END
    ELSE
    BEGIN
        INSERT INTO @SummaryTable
        SELECT  B.booking_id, B.booking_date, B.booking_status,
                M.title, S.date, S.slot, P.amount, P.payment_status
        FROM    BOOKING B
        INNER JOIN TICKET       T   ON B.booking_id  = T.booking_id
        INNER JOIN RESERVATION  R   ON T.ticket_id   = R.ticket_id
        INNER JOIN SHOWTIME     S   ON R.showtime_id = S.showtime_id
        INNER JOIN MOVIE        M   ON S.movie_id    = M.movie_id
        LEFT  JOIN PAYMENT      P   ON B.booking_id  = P.booking_id
        WHERE   B.customer_id = @CustomerID;
    END;

    RETURN;
END;
GO

-- SELECT * FROM dbo.fn_GetCustomerBookingSummary(1, 'Confirmed');
-- SELECT * FROM dbo.fn_GetCustomerBookingSummary(1, 'Cancelled');
-- SELECT * FROM dbo.fn_GetCustomerBookingSummary(1, 'All');


