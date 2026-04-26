-- ============================================================
-- Cinema Ticket Booking System — Database Schema
-- CSE244: Database System Design | Team #4
-- Ain Shams University, Faculty of Engineering
-- SQL Server Syntax
-- ============================================================

-- -------------------------------------------------------
-- CUSTOMER
-- -------------------------------------------------------
CREATE TABLE CUSTOMER (
    customer_id   INT           PRIMARY KEY  IDENTITY(1,1),
    first_name    VARCHAR(50)   NOT NULL,
    last_name     VARCHAR(50)   NOT NULL,
    email         VARCHAR(100)  NOT NULL UNIQUE,
    phone         VARCHAR(20),
    password      VARCHAR(255)  NOT NULL
);

-- -------------------------------------------------------
-- MOVIE
-- -------------------------------------------------------
CREATE TABLE MOVIE (
    movie_id      INT           PRIMARY KEY    IDENTITY(1,1),
    title         VARCHAR(200)  NOT NULL,
    description   VARCHAR(MAX),
    duration_min  INT           NOT NULL,
    language      VARCHAR(50)
);

-- -------------------------------------------------------
-- MOVIE_GENRE  (1NF: multivalued genre attribute extracted)
-- Composite PK: (movie_id, Mgenre)
-- -------------------------------------------------------
CREATE TABLE MOVIE_GENRE (
    movie_id  INT         NOT NULL,
    Mgenre    VARCHAR(50) NOT NULL,
    PRIMARY KEY (movie_id, Mgenre),
    FOREIGN KEY (movie_id) REFERENCES MOVIE(movie_id)
);


-- -------------------------------------------------------
-- CINEMA
-- Location decomposed into address + city (1NF)
-- -------------------------------------------------------
CREATE TABLE CINEMA (
    cinema_id  INT           PRIMARY KEY IDENTITY(1,1),
    name       VARCHAR(100)  NOT NULL,
    address    VARCHAR(200)  NOT NULL,
    city       VARCHAR(100)  NOT NULL,
    phone      VARCHAR(20)
);



-- -------------------------------------------------------
-- HALL
-- Composite PK: (hall_no, cinema_id)
-- hall_no is NOT auto-incremented: logical room number per cinema
-- -------------------------------------------------------
CREATE TABLE HALL (
    hall_no    INT  NOT NULL,
    cinema_id  INT  NOT NULL,
    capacity   INT  NOT NULL,
    PRIMARY KEY (hall_no, cinema_id),
    FOREIGN KEY (cinema_id) REFERENCES CINEMA(cinema_id)
       
);

-- -------------------------------------------------------
-- SEAT_TYPE_VALUE  (3NF: seat_type -> seat_price extracted)
-- -------------------------------------------------------
CREATE TABLE SEAT_TYPE_VALUE (
    seat_type   VARCHAR(20)    PRIMARY KEY,
    seat_price  MONEY NOT NULL
);

-- -------------------------------------------------------
-- SEAT
-- Composite PK: (seat_no, hall_no, cinema_id)
-- seat_no is NOT auto-incremented: logical seat number per hall
-- -------------------------------------------------------
CREATE TABLE SEAT (
    seat_no    INT         NOT NULL,
    hall_no    INT         NOT NULL,
    cinema_id  INT         NOT NULL,
    seat_type  VARCHAR(20) NOT NULL,
    PRIMARY KEY (seat_no, hall_no, cinema_id),
    FOREIGN KEY (hall_no, cinema_id) REFERENCES HALL(hall_no, cinema_id),
    FOREIGN KEY (seat_type)          REFERENCES SEAT_TYPE_VALUE(seat_type)
);

-- -------------------------------------------------------
-- SHOWTIME_SLOT_PRICE  (3NF: slot -> slot_price extracted)
-- -------------------------------------------------------
CREATE TABLE SHOWTIME_SLOT_PRICE (
    slot        VARCHAR(20)    PRIMARY KEY, --for easier handling
    slot_price  MONEY NOT NULL
);

-- -------------------------------------------------------
-- SHOWTIME
-- -------------------------------------------------------
CREATE TABLE SHOWTIME (
    showtime_id  INT         PRIMARY KEY IDENTITY(1,1),
    movie_id     INT         NOT NULL,
    hall_no      INT         NOT NULL,
    cinema_id    INT         NOT NULL,
    slot         VARCHAR(20) NOT NULL, --for easier handling 
    date         DATE        NOT NULL,
    FOREIGN KEY (movie_id)           REFERENCES MOVIE(movie_id),
    FOREIGN KEY (hall_no, cinema_id) REFERENCES HALL(hall_no, cinema_id),
    FOREIGN KEY (slot)               REFERENCES SHOWTIME_SLOT_PRICE(slot)
);

-- -------------------------------------------------------
-- BOOKING
-- -------------------------------------------------------
CREATE TABLE BOOKING (
    booking_id      INT         PRIMARY KEY IDENTITY(1,1),
    customer_id     INT         NOT NULL,
    booking_date    DATE        NOT NULL,
    booking_status  VARCHAR(20) NOT NULL DEFAULT 'pending',
    CHECK (booking_status IN ('confirmed', 'pending', 'cancelled')),
    FOREIGN KEY (customer_id) REFERENCES CUSTOMER(customer_id)
);

-- -------------------------------------------------------
-- PAYMENT  (1:1 with BOOKING; separated for 3NF)
-- -------------------------------------------------------
CREATE TABLE PAYMENT (
    payment_id      INT            PRIMARY KEY IDENTITY(1,1),
    booking_id      INT            NOT NULL UNIQUE, -- 1 to 1
    payment_method  VARCHAR(50)    NOT NULL,
    payment_date    DATE           NOT NULL,
    amount          MONEY NOT NULL,
    payment_status  VARCHAR(20)    NOT NULL DEFAULT 'pending',
    CHECK (payment_status IN ('pending', 'completed', 'failed')),
    FOREIGN KEY (booking_id) REFERENCES BOOKING(booking_id)
);

-- -------------------------------------------------------
-- TICKET
-- -------------------------------------------------------
CREATE TABLE TICKET (
    ticket_id   INT PRIMARY KEY IDENTITY(1,1),
    booking_id  INT NOT NULL,
    FOREIGN KEY (booking_id) REFERENCES BOOKING(booking_id)
);

-- -------------------------------------------------------
-- RESERVATION  (ternary: TICKET x SEAT x SHOWTIME)
-- price stored statically at booking time (point-in-time integrity)
-- -------------------------------------------------------
CREATE TABLE RESERVATION (
    ticket_id    INT            NOT NULL,
    seat_no      INT            NOT NULL,
    showtime_id  INT            NOT NULL,
    hall_no      INT            NOT NULL,
    cinema_id    INT            NOT NULL,
    price        Money          NOT NULL,
    PRIMARY KEY (ticket_id, seat_no, showtime_id, hall_no, cinema_id),
    FOREIGN KEY (ticket_id)                   REFERENCES TICKET(ticket_id),
    FOREIGN KEY (seat_no, hall_no, cinema_id) REFERENCES SEAT(seat_no, hall_no, cinema_id),
    FOREIGN KEY (showtime_id)                 REFERENCES SHOWTIME(showtime_id)
);
