-- ============================================================
-- Cinema Ticket Booking System — Procedures & Functions
-- CSE244: Database System Design | Team #4
-- Ain Shams University, Faculty of Engineering
-- SQL Server Syntax
-- ============================================================


-- ############################################################
--                        FUNCTIONS
-- ############################################################

-- -------------------------------------------------------
-- 1. fn_CalculateTicketPrice
--    Returns the ticket price for a given seat type and
--    showtime slot.  Price = seat_price + slot_price.
-- -------------------------------------------------------
GO
CREATE FUNCTION fn_CalculateTicketPrice
(
    @seat_type  VARCHAR(20),
    @slot       VARCHAR(20)
)
RETURNS MONEY
AS
BEGIN
    DECLARE @total MONEY;

    SELECT @total = stv.seat_price + ssp.slot_price
    FROM SEAT_TYPE_VALUE stv
    CROSS JOIN SHOWTIME_SLOT_PRICE ssp
    WHERE stv.seat_type = @seat_type
      AND ssp.slot      = @slot;

    RETURN ISNULL(@total, 0);
END;
GO


-- -------------------------------------------------------
-- 2. fn_CalculatePaymentAmount
--    Returns the total amount due for a booking by
--    summing the prices of all its reservations.
-- -------------------------------------------------------
GO
CREATE FUNCTION fn_CalculatePaymentAmount
(
    @booking_id INT
)
RETURNS MONEY
AS
BEGIN
    DECLARE @total MONEY;

    SELECT @total = SUM(R.price)
    FROM RESERVATION R
    INNER JOIN TICKET T ON R.ticket_id = T.ticket_id
    WHERE T.booking_id = @booking_id;

    RETURN ISNULL(@total, 0);
END;
GO


-- ############################################################
--                 CUSTOMER-FACING PROCEDURES
-- ############################################################

-- -------------------------------------------------------
-- 3. sp_ViewCustomerTickets
--    Shows every ticket a customer owns along with the
--    movie title, cinema, hall, seat, showtime, and price.
-- -------------------------------------------------------
GO
CREATE PROCEDURE sp_ViewCustomerTickets
    @customer_id INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        T.ticket_id,
        B.booking_id,
        B.booking_date,
        B.booking_status,
        M.title          AS movie_title,
        C.name           AS cinema_name,
        R.hall_no,
        R.seat_no,
        S.seat_type,
        ST.slot,
        ST.date          AS showtime_date,
        R.price          AS ticket_price
    FROM TICKET T
    INNER JOIN BOOKING     B  ON T.booking_id   = B.booking_id
    INNER JOIN RESERVATION R  ON T.ticket_id    = R.ticket_id
    INNER JOIN SHOWTIME    ST ON R.showtime_id   = ST.showtime_id
                              AND R.hall_no      = ST.hall_no
                              AND R.cinema_id    = ST.cinema_id
    INNER JOIN MOVIE       M  ON ST.movie_id     = M.movie_id
    INNER JOIN CINEMA      C  ON ST.cinema_id    = C.cinema_id
    INNER JOIN SEAT        S  ON R.seat_no       = S.seat_no
                              AND R.hall_no      = S.hall_no
                              AND R.cinema_id    = S.cinema_id
    WHERE B.customer_id = @customer_id
    ORDER BY ST.date, ST.slot;
END;
GO


-- -------------------------------------------------------
-- 4. sp_ViewAvailableMovies
--    Lists every upcoming showtime (date >= today) with
--    movie details, cinema, hall, slot, and slot price.
-- -------------------------------------------------------
GO
CREATE PROCEDURE sp_ViewAvailableMovies
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        M.movie_id,
        M.title,
        M.duration_min,
        M.language,
        C.name           AS cinema_name,
        C.city,
        ST.hall_no,
        ST.slot,
        ST.date          AS showtime_date,
        SSP.slot_price
    FROM SHOWTIME ST
    INNER JOIN MOVIE               M   ON ST.movie_id = M.movie_id
    INNER JOIN CINEMA              C   ON ST.cinema_id = C.cinema_id
    INNER JOIN SHOWTIME_SLOT_PRICE SSP ON ST.slot      = SSP.slot
    WHERE ST.date >= CAST(GETDATE() AS DATE)
    ORDER BY ST.date, ST.slot, M.title;
END;
GO


-- -------------------------------------------------------
-- 5. sp_ViewAvailableSeats
--    For a given showtime, lists every seat in the hall
--    and marks it as 'Available' or 'Booked'.
-- -------------------------------------------------------
GO
CREATE PROCEDURE sp_ViewAvailableSeats
    @showtime_id INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Resolve the hall and cinema for this showtime
    DECLARE @hall_no   INT;
    DECLARE @cinema_id INT;

    SELECT @hall_no = hall_no, @cinema_id = cinema_id
    FROM SHOWTIME
    WHERE showtime_id = @showtime_id;

    -- Return all seats with availability status
    SELECT
        S.seat_no,
        S.hall_no,
        S.cinema_id,
        S.seat_type,
        STV.seat_price,
        CASE
            WHEN R.ticket_id IS NOT NULL THEN 'Booked'
            ELSE 'Available'
        END AS seat_status
    FROM SEAT S
    INNER JOIN SEAT_TYPE_VALUE STV ON S.seat_type = STV.seat_type
    LEFT JOIN RESERVATION R
        ON  R.seat_no     = S.seat_no
        AND R.hall_no     = S.hall_no
        AND R.cinema_id   = S.cinema_id
        AND R.showtime_id = @showtime_id
    WHERE S.hall_no   = @hall_no
      AND S.cinema_id = @cinema_id
    ORDER BY S.seat_no;
END;
GO


-- ############################################################
--              BACKEND / ADMIN CRUD PROCEDURES
-- ############################################################


-- =========================
--        CUSTOMER
-- =========================

-- -------------------------------------------------------
-- 6. sp_InsertCustomer
-- -------------------------------------------------------
GO
CREATE PROCEDURE sp_InsertCustomer
    @first_name  VARCHAR(50),
    @last_name   VARCHAR(50),
    @email       VARCHAR(100),
    @phone       VARCHAR(20),
    @password    VARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO CUSTOMER (first_name, last_name, email, phone, password)
    VALUES (@first_name, @last_name, @email, @phone, @password);

    -- Return the newly created customer ID
    SELECT SCOPE_IDENTITY() AS new_customer_id;
END;
GO

-- -------------------------------------------------------
-- 7. sp_UpdateCustomer
-- -------------------------------------------------------
GO
CREATE PROCEDURE sp_UpdateCustomer
    @customer_id INT,
    @first_name  VARCHAR(50)  = NULL,
    @last_name   VARCHAR(50)  = NULL,
    @email       VARCHAR(100) = NULL,
    @phone       VARCHAR(20)  = NULL,
    @password    VARCHAR(255) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE CUSTOMER
    SET first_name = ISNULL(@first_name, first_name),
        last_name  = ISNULL(@last_name,  last_name),
        email      = ISNULL(@email,      email),
        phone      = ISNULL(@phone,      phone),
        password   = ISNULL(@password,   password)
    WHERE customer_id = @customer_id;
END;
GO

-- -------------------------------------------------------
-- 8. sp_DeleteCustomer
-- -------------------------------------------------------
GO
CREATE PROCEDURE sp_DeleteCustomer
    @customer_id INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Delete in dependency order: reservations → tickets → payments → bookings → customer
    DELETE R
    FROM RESERVATION R
    INNER JOIN TICKET  T ON R.ticket_id  = T.ticket_id
    INNER JOIN BOOKING B ON T.booking_id = B.booking_id
    WHERE B.customer_id = @customer_id;

    DELETE T
    FROM TICKET T
    INNER JOIN BOOKING B ON T.booking_id = B.booking_id
    WHERE B.customer_id = @customer_id;

    DELETE P
    FROM PAYMENT P
    INNER JOIN BOOKING B ON P.booking_id = B.booking_id
    WHERE B.customer_id = @customer_id;

    DELETE FROM BOOKING
    WHERE customer_id = @customer_id;

    DELETE FROM CUSTOMER
    WHERE customer_id = @customer_id;
END;
GO


-- =========================
--          MOVIE
-- =========================

-- -------------------------------------------------------
-- 9. sp_InsertMovie
-- -------------------------------------------------------
GO
CREATE PROCEDURE sp_InsertMovie
    @title        VARCHAR(200),
    @description  VARCHAR(MAX) = NULL,
    @duration_min INT,
    @language     VARCHAR(50)  = NULL
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO MOVIE (title, description, duration_min, language)
    VALUES (@title, @description, @duration_min, @language);

    SELECT SCOPE_IDENTITY() AS new_movie_id;
END;
GO



-- -------------------------------------------------------
-- 10. sp_UpdateMovie
-- -------------------------------------------------------
GO
CREATE PROCEDURE sp_UpdateMovie
    @movie_id     INT,
    @title        VARCHAR(200) = NULL,
    @description  VARCHAR(MAX) = NULL,
    @duration_min INT          = NULL,
    @language     VARCHAR(50)  = NULL
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE MOVIE
    SET title        = ISNULL(@title,        title),
        description  = ISNULL(@description,  description),
        duration_min = ISNULL(@duration_min,  duration_min),
        language     = ISNULL(@language,      language)
    WHERE movie_id = @movie_id;
END;
GO

-- -------------------------------------------------------
-- 11. sp_DeleteMovie
-- -------------------------------------------------------
GO
CREATE PROCEDURE sp_DeleteMovie
    @movie_id INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Delete in dependency order: reservations → tickets → payments → bookings → showtimes → genres → movie
    DELETE R
    FROM RESERVATION R
    INNER JOIN SHOWTIME ST ON R.showtime_id = ST.showtime_id
    WHERE ST.movie_id = @movie_id;

    -- Delete tickets tied to showtimes of this movie
    DELETE T
    FROM TICKET T
    INNER JOIN BOOKING B ON T.booking_id = B.booking_id
    WHERE NOT EXISTS (
        SELECT 1 FROM RESERVATION R WHERE R.ticket_id = T.ticket_id
    )
    AND T.ticket_id IN (
        SELECT T2.ticket_id FROM TICKET T2
        INNER JOIN RESERVATION R2 ON T2.ticket_id = R2.ticket_id
        INNER JOIN SHOWTIME ST2   ON R2.showtime_id = ST2.showtime_id
        WHERE ST2.movie_id = @movie_id
    );

    DELETE FROM SHOWTIME
    WHERE movie_id = @movie_id;

    DELETE FROM MOVIE_GENRE
    WHERE movie_id = @movie_id;

    DELETE FROM MOVIE
    WHERE movie_id = @movie_id;
END;
GO


-- =========================
--         CINEMA
-- =========================

-- -------------------------------------------------------
-- 12. sp_InsertCinema
-- -------------------------------------------------------
GO
CREATE PROCEDURE sp_InsertCinema
    @name    VARCHAR(100),
    @address VARCHAR(200),
    @city    VARCHAR(100),
    @phone   VARCHAR(20) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO CINEMA (name, address, city, phone)
    VALUES (@name, @address, @city, @phone);

    SELECT SCOPE_IDENTITY() AS new_cinema_id;
END;
GO

-- -------------------------------------------------------
-- 13. sp_UpdateCinema
-- -------------------------------------------------------
GO
CREATE PROCEDURE sp_UpdateCinema
    @cinema_id INT,
    @name      VARCHAR(100) = NULL,
    @address   VARCHAR(200) = NULL,
    @city      VARCHAR(100) = NULL,
    @phone     VARCHAR(20)  = NULL
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE CINEMA
    SET name    = ISNULL(@name,    name),
        address = ISNULL(@address, address),
        city    = ISNULL(@city,    city),
        phone   = ISNULL(@phone,   phone)
    WHERE cinema_id = @cinema_id;
END;
GO

-- -------------------------------------------------------
-- 14. sp_DeleteCinema
-- -------------------------------------------------------
GO
CREATE PROCEDURE sp_DeleteCinema
    @cinema_id INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Delete reservations in this cinema
    DELETE FROM RESERVATION
    WHERE cinema_id = @cinema_id;

    -- Delete showtimes in this cinema
    DELETE FROM SHOWTIME
    WHERE cinema_id = @cinema_id;

    -- Delete seats in this cinema
    DELETE FROM SEAT
    WHERE cinema_id = @cinema_id;

    -- Delete halls in this cinema
    DELETE FROM HALL
    WHERE cinema_id = @cinema_id;

    DELETE FROM CINEMA
    WHERE cinema_id = @cinema_id;
END;
GO


-- =========================
--        SHOWTIME
-- =========================

-- -------------------------------------------------------
-- 15. sp_InsertShowtime
-- -------------------------------------------------------
GO
CREATE PROCEDURE sp_InsertShowtime
    @movie_id  INT,
    @hall_no   INT,
    @cinema_id INT,
    @slot      VARCHAR(20),
    @date      DATE
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO SHOWTIME (movie_id, hall_no, cinema_id, slot, date)
    VALUES (@movie_id, @hall_no, @cinema_id, @slot, @date);

    SELECT SCOPE_IDENTITY() AS new_showtime_id;
END;
GO

-- -------------------------------------------------------
-- 16. sp_UpdateShowtime
-- -------------------------------------------------------
GO
CREATE PROCEDURE sp_UpdateShowtime
    @showtime_id INT,
    @movie_id    INT         = NULL,
    @hall_no     INT         = NULL,
    @cinema_id   INT         = NULL,
    @slot        VARCHAR(20) = NULL,
    @date        DATE        = NULL
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE SHOWTIME
    SET movie_id  = ISNULL(@movie_id,  movie_id),
        hall_no   = ISNULL(@hall_no,   hall_no),
        cinema_id = ISNULL(@cinema_id, cinema_id),
        slot      = ISNULL(@slot,      slot),
        date      = ISNULL(@date,      date)
    WHERE showtime_id = @showtime_id;
END;
GO

-- -------------------------------------------------------
-- 17. sp_DeleteShowtime
-- -------------------------------------------------------
GO
CREATE PROCEDURE sp_DeleteShowtime
    @showtime_id INT
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM RESERVATION
    WHERE showtime_id = @showtime_id;

    DELETE FROM SHOWTIME
    WHERE showtime_id = @showtime_id;
END;
GO


-- =========================
--        BOOKING
-- =========================

-- -------------------------------------------------------
-- 18. sp_InsertBooking
-- -------------------------------------------------------
GO
CREATE PROCEDURE sp_InsertBooking
    @customer_id    INT,
    @booking_date   DATE,
    @booking_status VARCHAR(20) = 'pending'
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO BOOKING (customer_id, booking_date, booking_status)
    VALUES (@customer_id, @booking_date, @booking_status);

    SELECT SCOPE_IDENTITY() AS new_booking_id;
END;
GO

-- -------------------------------------------------------
-- 19. sp_UpdateBookingStatus
-- -------------------------------------------------------
GO
CREATE PROCEDURE sp_UpdateBookingStatus
    @booking_id     INT,
    @booking_status VARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE BOOKING
    SET booking_status = @booking_status
    WHERE booking_id = @booking_id;
END;
GO

-- -------------------------------------------------------
-- 20. sp_DeleteBooking
-- -------------------------------------------------------
GO
CREATE PROCEDURE sp_DeleteBooking
    @booking_id INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Delete in dependency order: reservations → tickets → payment → booking
    DELETE R
    FROM RESERVATION R
    INNER JOIN TICKET T ON R.ticket_id = T.ticket_id
    WHERE T.booking_id = @booking_id;

    DELETE FROM TICKET
    WHERE booking_id = @booking_id;

    DELETE FROM PAYMENT
    WHERE booking_id = @booking_id;

    DELETE FROM BOOKING
    WHERE booking_id = @booking_id;
END;
GO

-- ============================================================
-- Drop all Functions and Stored Procedures
-- Cinema Ticket Booking System — Team #4
-- ============================================================

-- Functions
DROP FUNCTION IF EXISTS fn_CalculateTicketPrice;
DROP FUNCTION IF EXISTS fn_CalculatePaymentAmount;

-- Customer Procedures
DROP PROCEDURE IF EXISTS sp_ViewCustomerTickets;
DROP PROCEDURE IF EXISTS sp_InsertCustomer;
DROP PROCEDURE IF EXISTS sp_UpdateCustomer;
DROP PROCEDURE IF EXISTS sp_DeleteCustomer;

-- Movie Procedures
DROP PROCEDURE IF EXISTS sp_ViewAvailableMovies;
DROP PROCEDURE IF EXISTS sp_ViewAvailableSeats;
DROP PROCEDURE IF EXISTS sp_InsertMovie;
DROP PROCEDURE IF EXISTS sp_UpdateMovie;
DROP PROCEDURE IF EXISTS sp_DeleteMovie;

-- Cinema Procedures
DROP PROCEDURE IF EXISTS sp_InsertCinema;
DROP PROCEDURE IF EXISTS sp_UpdateCinema;
DROP PROCEDURE IF EXISTS sp_DeleteCinema;

-- Showtime Procedures
DROP PROCEDURE IF EXISTS sp_InsertShowtime;
DROP PROCEDURE IF EXISTS sp_UpdateShowtime;
DROP PROCEDURE IF EXISTS sp_DeleteShowtime;

-- Booking Procedures
DROP PROCEDURE IF EXISTS sp_InsertBooking;
DROP PROCEDURE IF EXISTS sp_UpdateBookingStatus;
DROP PROCEDURE IF EXISTS sp_DeleteBooking;


-- ============================================================
-- Cinema Ticket Booking System
-- Customer-Side: Stored Procedures & User-Defined Functions
-- CSE244: Database System Design | Team #4
-- Ain Shams University, Faculty of Engineering
-- Following Lab 6 & Lab 7 SQL Server Syntax
-- ============================================================


-- ==============================================================
-- SECTION 1: STORED PROCEDURES  (Lab 6 Syntax)
-- ==============================================================


-- --------------------------------------------------------------
-- 1.1  Browse All Available Movies
--      No parameters — customer views the full movie catalog
-- --------------------------------------------------------------
CREATE PROCEDURE sp_GetAllMovies
AS
BEGIN
    SELECT  M.movie_id,
            M.title,
            M.description,
            M.duration_min,
            M.language,
            MG.Mgenre
    FROM    MOVIE       M
    LEFT JOIN MOVIE_GENRE MG ON M.movie_id = MG.movie_id
    ORDER BY M.title;
END;

-- Call:
-- EXEC sp_GetAllMovies;


-- --------------------------------------------------------------
-- 1.2  Search Movies by Genre
--      Input: @Genre (e.g. 'Sci-Fi', 'Animation')
-- --------------------------------------------------------------
CREATE PROCEDURE sp_GetMoviesByGenre
    @Genre VARCHAR(50)          -- Input Parameter
AS
BEGIN
    SELECT  M.movie_id,
            M.title,
            M.duration_min,
            M.language,
            MG.Mgenre
    FROM    MOVIE       M
    INNER JOIN MOVIE_GENRE MG ON M.movie_id = MG.movie_id
    WHERE   MG.Mgenre = @Genre
    ORDER BY M.title;
END;

-- Call:
-- EXEC sp_GetMoviesByGenre @Genre = 'Sci-Fi';
-- EXEC sp_GetMoviesByGenre 'Animation';


-- --------------------------------------------------------------
-- 1.3  View Showtimes for a Specific Movie
--      Input: @MovieID
-- --------------------------------------------------------------
CREATE PROCEDURE sp_GetShowtimesByMovie
    @MovieID INT                -- Input Parameter
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
    FROM    SHOWTIME            S
    INNER JOIN MOVIE            M   ON S.movie_id  = M.movie_id
    INNER JOIN CINEMA           C   ON S.cinema_id = C.cinema_id
    INNER JOIN SHOWTIME_SLOT_PRICE SP ON S.slot    = SP.slot
    WHERE   S.movie_id = @MovieID
    ORDER BY S.date, S.slot;
END;

-- Call:
-- EXEC sp_GetShowtimesByMovie @MovieID = 1;


-- --------------------------------------------------------------
-- 1.4  View Available Seats for a Showtime
--      Input: @ShowtimeID
-- --------------------------------------------------------------
CREATE PROCEDURE sp_GetAvailableSeats
    @ShowtimeID INT             -- Input Parameter
AS
BEGIN
    -- Retrieve showtime context first
    DECLARE @HallNo   INT;
    DECLARE @CinemaID INT;

    SELECT  @HallNo   = hall_no,
            @CinemaID = cinema_id
    FROM    SHOWTIME
    WHERE   showtime_id = @ShowtimeID;

    -- All seats in that hall minus already reserved ones
    SELECT  ST.seat_no,
            ST.seat_type,
            STV.seat_price
    FROM    SEAT            ST
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

-- Call:
-- EXEC sp_GetAvailableSeats @ShowtimeID = 1;


-- --------------------------------------------------------------
-- 1.5  Make a Booking  (creates Booking + Payment + Ticket + Reservation)
--      Input:  @CustomerID, @ShowtimeID, @SeatNo,
--              @PaymentMethod
--      Output: @NewBookingID  (so the customer gets a reference)
-- --------------------------------------------------------------
CREATE PROCEDURE sp_MakeBooking
    @CustomerID     INT,
    @ShowtimeID     INT,
    @SeatNo         INT,
    @PaymentMethod  VARCHAR(50),
    @NewBookingID   INT OUTPUT  -- Output Parameter
AS
BEGIN
    DECLARE @HallNo        INT;
    DECLARE @CinemaID      INT;
    DECLARE @SeatPrice     MONEY;
    DECLARE @SlotPrice     MONEY;
    DECLARE @TotalPrice    MONEY;
    DECLARE @NewTicketID   INT;

    -- Step 1: Get hall & cinema from the showtime
    SELECT  @HallNo   = S.hall_no,
            @CinemaID = S.cinema_id,
            @SlotPrice = SP.slot_price
    FROM    SHOWTIME            S
    INNER JOIN SHOWTIME_SLOT_PRICE SP ON S.slot = SP.slot
    WHERE   S.showtime_id = @ShowtimeID;

    -- Step 2: Get seat price
    SELECT  @SeatPrice = STV.seat_price
    FROM    SEAT            ST
    INNER JOIN SEAT_TYPE_VALUE STV ON ST.seat_type = STV.seat_type
    WHERE   ST.seat_no   = @SeatNo
      AND   ST.hall_no   = @HallNo
      AND   ST.cinema_id = @CinemaID;

    -- Step 3: Calculate total price (seat + slot surcharge)
    SET @TotalPrice = @SeatPrice + @SlotPrice;

    -- Step 4: Insert BOOKING
    INSERT INTO BOOKING (customer_id, booking_date, booking_status)
    VALUES (@CustomerID, CAST(GETDATE() AS DATE), 'pending');

    SET @NewBookingID = SCOPE_IDENTITY();

    -- Step 5: Insert PAYMENT
    INSERT INTO PAYMENT (booking_id, payment_method, payment_date, amount, payment_status)
    VALUES (@NewBookingID, @PaymentMethod, CAST(GETDATE() AS DATE), @TotalPrice, 'pending');

    -- Step 6: Insert TICKET
    INSERT INTO TICKET (booking_id)
    VALUES (@NewBookingID);

    SET @NewTicketID = SCOPE_IDENTITY();

    -- Step 7: Insert RESERVATION
    INSERT INTO RESERVATION (ticket_id, seat_no, showtime_id, hall_no, cinema_id, price)
    VALUES (@NewTicketID, @SeatNo, @ShowtimeID, @HallNo, @CinemaID, @TotalPrice);

    -- Confirm booking
    PRINT 'Booking created successfully! Booking ID: ' + CAST(@NewBookingID AS VARCHAR);
END;

-- Call:
-- DECLARE @BookingRef INT;
-- EXEC sp_MakeBooking
--      @CustomerID    = 1,
--      @ShowtimeID    = 2,
--      @SeatNo        = 3,
--      @PaymentMethod = 'Credit Card',
--      @NewBookingID  = @BookingRef OUTPUT;
-- PRINT 'Your booking reference: ' + CAST(@BookingRef AS VARCHAR);


-- --------------------------------------------------------------
-- 1.6  View My Bookings
--      Input: @CustomerID
-- --------------------------------------------------------------
CREATE PROCEDURE sp_GetMyBookings
    @CustomerID INT             -- Input Parameter
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

-- Call:
-- EXEC sp_GetMyBookings @CustomerID = 1;


-- --------------------------------------------------------------
-- 1.7  View My Ticket Details  (full reservation info)
--      Input: @CustomerID
-- --------------------------------------------------------------
CREATE PROCEDURE sp_GetMyTickets
    @CustomerID INT             -- Input Parameter
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
    FROM    BOOKING     B
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

-- Call:
-- EXEC sp_GetMyTickets @CustomerID = 1;


-- --------------------------------------------------------------
-- 1.8  Cancel a Booking
--      Input: @BookingID, @CustomerID (safety check)
-- --------------------------------------------------------------
CREATE PROCEDURE sp_CancelBooking
    @BookingID  INT,
    @CustomerID INT             -- prevents cancelling someone else's booking
AS
BEGIN
    -- Verify the booking belongs to this customer
    IF EXISTS (
        SELECT 1 FROM BOOKING
        WHERE  booking_id  = @BookingID
          AND  customer_id = @CustomerID
          AND  booking_status <> 'cancelled'
    )
    BEGIN
        -- Cancel booking
        UPDATE BOOKING
        SET    booking_status = 'cancelled'
        WHERE  booking_id = @BookingID;

        -- Mark payment as failed
        UPDATE PAYMENT
        SET    payment_status = 'failed'
        WHERE  booking_id = @BookingID;

        PRINT 'Booking ' + CAST(@BookingID AS VARCHAR) + ' has been cancelled.';
    END
    ELSE
    BEGIN
        PRINT 'Cancellation failed: booking not found or already cancelled.';
    END;
END;

-- Call:
-- EXEC sp_CancelBooking @BookingID = 2, @CustomerID = 1;


-- --------------------------------------------------------------
-- 1.9  Update Payment Status to Completed
--      Input: @BookingID, @CustomerID
-- --------------------------------------------------------------
CREATE PROCEDURE sp_ConfirmPayment
    @BookingID  INT,
    @CustomerID INT
AS
BEGIN
    IF EXISTS (
        SELECT 1 FROM BOOKING
        WHERE  booking_id  = @BookingID
          AND  customer_id = @CustomerID
    )
    BEGIN
        UPDATE PAYMENT
        SET    payment_status = 'completed'
        WHERE  booking_id = @BookingID;

        UPDATE BOOKING
        SET    booking_status = 'confirmed'
        WHERE  booking_id = @BookingID;

        PRINT 'Payment confirmed for Booking ID: ' + CAST(@BookingID AS VARCHAR);
    END
    ELSE
    BEGIN
        PRINT 'Error: Booking not found for this customer.';
    END;
END;

-- Call:
-- EXEC sp_ConfirmPayment @BookingID = 2, @CustomerID = 2;


-- ==============================================================
-- SECTION 2: SCALAR FUNCTIONS  (Lab 7 Syntax)
-- ==============================================================


-- --------------------------------------------------------------
-- 2.1  Calculate Total Ticket Price
--      Returns: seat_price + slot_price for a given showtime & seat
-- --------------------------------------------------------------
CREATE FUNCTION dbo.fn_CalcTicketPrice
(
    @ShowtimeID INT,
    @SeatNo     INT
)
RETURNS MONEY
AS
BEGIN
    DECLARE @SeatPrice  MONEY;
    DECLARE @SlotPrice  MONEY;
    DECLARE @HallNo     INT;
    DECLARE @CinemaID   INT;
    DECLARE @Total      MONEY;

    SELECT  @HallNo   = hall_no,
            @CinemaID = cinema_id
    FROM    SHOWTIME
    WHERE   showtime_id = @ShowtimeID;

    SELECT  @SeatPrice = STV.seat_price
    FROM    SEAT            ST
    INNER JOIN SEAT_TYPE_VALUE STV ON ST.seat_type = STV.seat_type
    WHERE   ST.seat_no   = @SeatNo
      AND   ST.hall_no   = @HallNo
      AND   ST.cinema_id = @CinemaID;

    SELECT  @SlotPrice = SP.slot_price
    FROM    SHOWTIME            S
    INNER JOIN SHOWTIME_SLOT_PRICE SP ON S.slot = SP.slot
    WHERE   S.showtime_id = @ShowtimeID;

    SET @Total = ISNULL(@SeatPrice, 0) + ISNULL(@SlotPrice, 0);

    RETURN @Total;
END;

-- Call:
-- SELECT dbo.fn_CalcTicketPrice(1, 1) AS TicketPrice;


-- --------------------------------------------------------------
-- 2.2  Get Total Amount Spent by a Customer
--      Returns: SUM of all completed payments
-- --------------------------------------------------------------
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
    WHERE   B.customer_id   = @CustomerID
      AND   P.payment_status = 'completed';

    RETURN ISNULL(@TotalSpent, 0);
END;

-- Call:
-- SELECT dbo.fn_GetCustomerTotalSpent(1) AS TotalSpent;
-- Use inside a query:
-- SELECT first_name, last_name,
--        dbo.fn_GetCustomerTotalSpent(customer_id) AS TotalSpent
-- FROM CUSTOMER;


-- --------------------------------------------------------------
-- 2.3  Count How Many Bookings a Customer Has Made
--      Returns: total booking count
-- --------------------------------------------------------------
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

-- Call:
-- SELECT dbo.fn_CountCustomerBookings(1) AS BookingCount;


-- --------------------------------------------------------------
-- 2.4  Get Movie Duration Label
--      Returns: 'Short' / 'Standard' / 'Long'
-- --------------------------------------------------------------
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

    RETURN @Label;
END;

-- Call:
-- SELECT title,
--        duration_min,
--        dbo.fn_GetMovieDurationLabel(movie_id) AS DurationLabel
-- FROM MOVIE;


-- ==============================================================
-- SECTION 3: INLINE TABLE-VALUED FUNCTIONS  (Lab 7 Syntax)
-- ==============================================================


-- --------------------------------------------------------------
-- 3.1  Get Showtimes on a Specific Date
--      Returns a table of all shows on a given date
-- --------------------------------------------------------------
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
    FROM    SHOWTIME            S
    INNER JOIN MOVIE            M   ON S.movie_id  = M.movie_id
    INNER JOIN CINEMA           C   ON S.cinema_id = C.cinema_id
    INNER JOIN SHOWTIME_SLOT_PRICE SP ON S.slot    = SP.slot
    WHERE   S.date = @ShowDate
);

-- Call:
-- SELECT * FROM dbo.fn_GetShowtimesByDate('2026-04-25');


-- --------------------------------------------------------------
-- 3.2  Get All Movies Showing in a Specific Cinema
--      Returns distinct movies available at that cinema
-- --------------------------------------------------------------
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
    FROM    MOVIE       M
    INNER JOIN SHOWTIME S   ON M.movie_id  = S.movie_id
    LEFT  JOIN MOVIE_GENRE MG ON M.movie_id = MG.movie_id
    WHERE   S.cinema_id = @CinemaID
);

-- Call:
-- SELECT * FROM dbo.fn_GetMoviesByCinema(1);


-- --------------------------------------------------------------
-- 3.3  Get All Bookings for a Customer with Full Details
--      Useful for a customer's "My Orders" page
-- --------------------------------------------------------------
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
            M.title         AS movie_title,
            C.name          AS cinema_name,
            S.slot,
            S.date          AS show_date,
            R.seat_no,
            ST.seat_type,
            P.amount,
            P.payment_method,
            P.payment_status
    FROM    BOOKING     B
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

-- Call:
-- SELECT * FROM dbo.fn_GetCustomerBookingDetails(1);
-- Can also add WHERE / ORDER BY on top:
-- SELECT * FROM dbo.fn_GetCustomerBookingDetails(1)
-- WHERE booking_status = 'confirmed'
-- ORDER BY show_date DESC;


-- ==============================================================
-- SECTION 4: MULTI-STATEMENT TABLE-VALUED FUNCTIONS  (Lab 7 Syntax)
-- ==============================================================


-- --------------------------------------------------------------
-- 4.1  Get Movies Filtered by Slot Type
--      @SlotType = 'Today'   → shows on today's date
--      @SlotType = 'Weekend' → shows on Fri / Sat / Sun
--      @SlotType = 'All'     → all upcoming shows
-- --------------------------------------------------------------
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
        SELECT  S.showtime_id,
                M.title,
                C.name,
                C.city,
                S.slot,
                S.date,
                SP.slot_price
        FROM    SHOWTIME            S
        INNER JOIN MOVIE            M   ON S.movie_id  = M.movie_id
        INNER JOIN CINEMA           C   ON S.cinema_id = C.cinema_id
        INNER JOIN SHOWTIME_SLOT_PRICE SP ON S.slot    = SP.slot
        WHERE   S.date = CAST(GETDATE() AS DATE);
    END
    ELSE IF @SlotType = 'Weekend'
    BEGIN
        INSERT INTO @MovieTable
        SELECT  S.showtime_id,
                M.title,
                C.name,
                C.city,
                S.slot,
                S.date,
                SP.slot_price
        FROM    SHOWTIME            S
        INNER JOIN MOVIE            M   ON S.movie_id  = M.movie_id
        INNER JOIN CINEMA           C   ON S.cinema_id = C.cinema_id
        INNER JOIN SHOWTIME_SLOT_PRICE SP ON S.slot    = SP.slot
        WHERE   DATEPART(weekday, S.date) IN (6, 7, 1); -- Fri, Sat, Sun
    END
    ELSE -- 'All' or any other value
    BEGIN
        INSERT INTO @MovieTable
        SELECT  S.showtime_id,
                M.title,
                C.name,
                C.city,
                S.slot,
                S.date,
                SP.slot_price
        FROM    SHOWTIME            S
        INNER JOIN MOVIE            M   ON S.movie_id  = M.movie_id
        INNER JOIN CINEMA           C   ON S.cinema_id = C.cinema_id
        INNER JOIN SHOWTIME_SLOT_PRICE SP ON S.slot    = SP.slot
        WHERE   S.date >= CAST(GETDATE() AS DATE);
    END;

    RETURN;
END;

-- Call:
-- SELECT * FROM dbo.fn_GetMoviesBySlotType('Today');
-- SELECT * FROM dbo.fn_GetMoviesBySlotType('Weekend');
-- SELECT * FROM dbo.fn_GetMoviesBySlotType('All');


-- --------------------------------------------------------------
-- 4.2  Get Customer Booking Summary
--      @SummaryType = 'Confirmed'  → only confirmed bookings
--      @SummaryType = 'Cancelled'  → only cancelled bookings
--      @SummaryType = 'All'        → all bookings with totals
-- --------------------------------------------------------------
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
        SELECT  B.booking_id,
                B.booking_date,
                B.booking_status,
                M.title,
                S.date,
                S.slot,
                P.amount,
                P.payment_status
        FROM    BOOKING     B
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
        SELECT  B.booking_id,
                B.booking_date,
                B.booking_status,
                M.title,
                S.date,
                S.slot,
                P.amount,
                P.payment_status
        FROM    BOOKING     B
        INNER JOIN TICKET       T   ON B.booking_id  = T.booking_id
        INNER JOIN RESERVATION  R   ON T.ticket_id   = R.ticket_id
        INNER JOIN SHOWTIME     S   ON R.showtime_id = S.showtime_id
        INNER JOIN MOVIE        M   ON S.movie_id    = M.movie_id
        LEFT  JOIN PAYMENT      P   ON B.booking_id  = P.booking_id
        WHERE   B.customer_id    = @CustomerID
          AND   B.booking_status = 'cancelled';
    END
    ELSE -- 'All'
    BEGIN
        INSERT INTO @SummaryTable
        SELECT  B.booking_id,
                B.booking_date,
                B.booking_status,
                M.title,
                S.date,
                S.slot,
                P.amount,
                P.payment_status
        FROM    BOOKING     B
        INNER JOIN TICKET       T   ON B.booking_id  = T.booking_id
        INNER JOIN RESERVATION  R   ON T.ticket_id   = R.ticket_id
        INNER JOIN SHOWTIME     S   ON R.showtime_id = S.showtime_id
        INNER JOIN MOVIE        M   ON S.movie_id    = M.movie_id
        LEFT  JOIN PAYMENT      P   ON B.booking_id  = P.booking_id
        WHERE   B.customer_id = @CustomerID;
    END;

    RETURN;
END;

-- Call:
-- SELECT * FROM dbo.fn_GetCustomerBookingSummary(1, 'Confirmed');
-- SELECT * FROM dbo.fn_GetCustomerBookingSummary(1, 'Cancelled');
-- SELECT * FROM dbo.fn_GetCustomerBookingSummary(1, 'All');


-- ==============================================================
-- QUICK REFERENCE — DROP STATEMENTS (run before re-creating)
-- ==============================================================
/*
-- Stored Procedures
DROP PROCEDURE sp_GetAllMovies;
DROP PROCEDURE sp_GetMoviesByGenre;
DROP PROCEDURE sp_GetShowtimesByMovie;
DROP PROCEDURE sp_GetAvailableSeats;
DROP PROCEDURE sp_MakeBooking;
DROP PROCEDURE sp_GetMyBookings;
DROP PROCEDURE sp_GetMyTickets;
DROP PROCEDURE sp_CancelBooking;
DROP PROCEDURE sp_ConfirmPayment;

-- Scalar Functions
DROP FUNCTION dbo.fn_CalcTicketPrice;
DROP FUNCTION dbo.fn_GetCustomerTotalSpent;
DROP FUNCTION dbo.fn_CountCustomerBookings;
DROP FUNCTION dbo.fn_GetMovieDurationLabel;

-- Inline Table-Valued Functions
DROP FUNCTION dbo.fn_GetShowtimesByDate;
DROP FUNCTION dbo.fn_GetMoviesByCinema;
DROP FUNCTION dbo.fn_GetCustomerBookingDetails;

-- Multi-Statement Table-Valued Functions
DROP FUNCTION dbo.fn_GetMoviesBySlotType;
DROP FUNCTION dbo.fn_GetCustomerBookingSummary;
*/
