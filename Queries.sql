

--  Select ALL columns from CUSTOMER
SELECT *
FROM CUSTOMER;


SELECT *
from SEAT_TYPE_VALUE;

--   Select specific columns (customer full name + email)
SELECT first_name, last_name, email
FROM CUSTOMER;

--   Using an arithmetic expression: show ticket price with 10% discount
SELECT seat_type, seat_price, seat_price * 0.90 AS discounted_price
FROM SEAT_TYPE_VALUE;


--  Eliminating duplicate rows — distinct cities that have cinemas
SELECT DISTINCT city
FROM CINEMA;

--  Distinct languages of available movies
SELECT DISTINCT language
FROM MOVIE;




--   Movies with duration longer than 120 minutes
SELECT title, duration_min, language
FROM MOVIE
WHERE duration_min > 120;

--   Confirmed bookings only
SELECT booking_id, customer_id, booking_date
FROM BOOKING
WHERE booking_status = 'confirmed';

--   Seats of type 'VIP' in a specific hall (hall_no=1, cinema_id=1)
SELECT seat_no, seat_type
FROM SEAT
WHERE seat_type in( 'VIP','Premium');

--  Showtimes on a specific date
SELECT showtime_id, movie_id, slot, date
FROM SHOWTIME
WHERE date = '2025-06-01';

--   Payments with amount greater than 200
SELECT payment_id, booking_id, amount, payment_method
FROM PAYMENT
WHERE amount  between 60 and 100;

--  Cinemas NOT in Cairo
SELECT name, city
FROM CINEMA
WHERE city <> 'Cairo';




--  Movies ordered by duration ascending (NULLs appear first)
SELECT title, duration_min
FROM MOVIE
ORDER BY duration_min;

--  Seat type prices ordered from most to least expensive
SELECT seat_type, seat_price
FROM SEAT_TYPE_VALUE
ORDER BY seat_price DESC;




--   Replace NULL language with 'Unknown'
SELECT title, ISNULL(language, 'Unknown') AS language
FROM MOVIE;





-- Average, max, min seat price across all seat types
SELECT
    AVG(seat_price) AS avg_price,
    MAX(seat_price) AS max_price,
    MIN(seat_price) AS min_price,
    SUM(seat_price) AS total_price_sum
FROM SEAT_TYPE_VALUE;

--   Total revenue from completed payments
SELECT SUM(amount) AS total_revenue
FROM PAYMENT
WHERE payment_status = 'completed';

--  Count of all customers registered
SELECT COUNT(*) AS total_customers
FROM CUSTOMER;

--   Count of pending bookings
SELECT COUNT(*) AS pending_bookings
FROM BOOKING
WHERE booking_status = 'pending';

--  Count of distinct movies showing in showtimes
SELECT COUNT(DISTINCT movie_id) AS distinct_movies_screening
FROM SHOWTIME;

--  Average capacity of halls
SELECT AVG(capacity) AS avg_hall_capacity
FROM HALL;



--   Count of bookings per status

SELECT booking_status, COUNT(*) AS total
FROM BOOKING
GROUP BY booking_status;

--   Total revenue per payment method

SELECT payment_method, SUM(amount) AS total_revenue
FROM PAYMENT
GROUP BY payment_method;


--  Payment methods with total revenue above 50

SELECT payment_method, SUM(amount) AS total_revenue
FROM PAYMENT
GROUP BY payment_method
HAVING SUM(amount) > 50;






--   Movies showing in the 'Evening' slot

SELECT title, duration_min, language
FROM MOVIE
WHERE movie_id IN (
    SELECT DISTINCT movie_id
    FROM SHOWTIME
    WHERE slot = 'Evening'
);



--  Bookings whose payment is 'completed'

SELECT booking_id, customer_id, booking_date, booking_status
FROM BOOKING
WHERE booking_id IN (
    SELECT booking_id
    FROM PAYMENT
    WHERE payment_status = 'completed'
);







--   Movie title alongside each showtime
--   Movie title alongside each showtime
SELECT SHOWTIME.showtime_id, MOVIE.title, SHOWTIME.slot, SHOWTIME.date
FROM SHOWTIME
INNER JOIN MOVIE ON SHOWTIME.movie_id = MOVIE.movie_id;

--   Booking details with customer name
SELECT BOOKING.booking_id, CUSTOMER.first_name, CUSTOMER.last_name,
       BOOKING.booking_date, BOOKING.booking_status
FROM BOOKING
INNER JOIN CUSTOMER ON BOOKING.customer_id = CUSTOMER.customer_id;


--   All customers including those with no bookings
SELECT CUSTOMER.customer_id, CUSTOMER.first_name, CUSTOMER.last_name,
       BOOKING.booking_id, BOOKING.booking_status
FROM CUSTOMER
LEFT JOIN BOOKING ON CUSTOMER.customer_id = BOOKING.customer_id;

--  All movies including those with no scheduled showtimes
SELECT MOVIE.movie_id, MOVIE.title, SHOWTIME.showtime_id, SHOWTIME.slot, SHOWTIME.date
FROM MOVIE
LEFT JOIN SHOWTIME ON MOVIE.movie_id = SHOWTIME.movie_id;


--   All showtimes including those with no reservations yet
SELECT SHOWTIME.showtime_id, SHOWTIME.slot, SHOWTIME.date,
       RESERVATION.ticket_id, RESERVATION.seat_no
FROM RESERVATION
RIGHT JOIN SHOWTIME ON RESERVATION.showtime_id = SHOWTIME.showtime_id;


--   All bookings and all payments — matched or unmatched
SELECT BOOKING.booking_id, BOOKING.booking_status,
       PAYMENT.payment_id, PAYMENT.payment_status, PAYMENT.amount
FROM BOOKING
FULL OUTER JOIN PAYMENT ON BOOKING.booking_id = PAYMENT.booking_id;



--   Showtimes in April 2026 (the actual inserted date range)

SELECT showtime_id, movie_id, slot, date
FROM SHOWTIME
WHERE date BETWEEN '2026-04-01' AND '2026-04-30';



--  Customers whose email ends with '@gmail.com'

SELECT first_name, last_name, email
FROM CUSTOMER
WHERE email LIKE '%@gmail.com';



-- Cinemas whose name contains the word 'Cinema'

SELECT name, city, address
FROM CINEMA
WHERE name LIKE '%Cinema%';


--  Movies with no language specified — returns EMPTY (all have 'English')
SELECT movie_id, title
FROM MOVIE
WHERE language IS NULL;

--  Movies that do have a language — returns all 4
SELECT movie_id, title, language
FROM MOVIE
WHERE language IS NOT NULL;





--  Movies starting with 'I', duration between 100 and 170, sorted ASC

SELECT title, duration_min, language
FROM MOVIE
WHERE title        LIKE 'I%'
  AND duration_min BETWEEN 100 AND 170
ORDER BY duration_min;

--  Confirmed or pending bookings sorted by booking date DESC

SELECT booking_id, customer_id, booking_date, booking_status
FROM BOOKING
WHERE booking_status IN ('confirmed', 'pending')
ORDER BY booking_date DESC;

--  Customers with a non-null email, sorted by last name ASC

SELECT first_name, last_name, email, phone
FROM CUSTOMER
WHERE email IS NOT NULL
ORDER BY last_name;

--  Payments between 50 and 200, paid by Credit Card or Cash, sorted DESC

SELECT payment_id, booking_id, amount, payment_method, payment_status
FROM PAYMENT
WHERE amount         BETWEEN 50 AND 200
  AND payment_method IN ('Credit Card', 'Cash')
ORDER BY amount DESC;




--   Top 3 customers by number of bookings

SELECT TOP 3 CUSTOMER.first_name, CUSTOMER.last_name, COUNT(BOOKING.booking_id) AS booking_count
FROM CUSTOMER
INNER JOIN BOOKING ON CUSTOMER.customer_id = BOOKING.customer_id
GROUP BY CUSTOMER.first_name, CUSTOMER.last_name
ORDER BY booking_count DESC;

--  Total revenue per cinema
SELECT CINEMA.name, CINEMA.city, SUM(RESERVATION.price) AS total_revenue
FROM RESERVATION
INNER JOIN SHOWTIME ON RESERVATION.showtime_id = SHOWTIME.showtime_id
INNER JOIN CINEMA ON SHOWTIME.cinema_id = CINEMA.cinema_id
GROUP BY CINEMA.name, CINEMA.city
ORDER BY total_revenue DESC;

--  Movies with their genre count
SELECT MOVIE.title, COUNT(MOVIE_GENRE.Mgenre) AS genre_count
FROM MOVIE
LEFT JOIN MOVIE_GENRE ON MOVIE.movie_id = MOVIE_GENRE.movie_id
GROUP BY MOVIE.title
ORDER BY genre_count DESC;

--  Customers with total spending on confirmed bookings above 50
SELECT CUSTOMER.first_name, CUSTOMER.last_name, SUM(PAYMENT.amount) AS total_spent
FROM CUSTOMER
INNER JOIN BOOKING ON CUSTOMER.customer_id = BOOKING.customer_id
INNER JOIN PAYMENT ON BOOKING.booking_id = PAYMENT.booking_id
WHERE BOOKING.booking_status = 'confirmed'
GROUP BY CUSTOMER.first_name, CUSTOMER.last_name
HAVING SUM(PAYMENT.amount) > 50
ORDER BY total_spent DESC;
