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