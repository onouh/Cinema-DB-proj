-- CUSTOMER
INSERT INTO CUSTOMER (first_name, last_name, email, phone, password) VALUES
('Menna','Elnaiad','menna@gmail.com','01011111111','pass1'),
('Ahmed','Ali','ahmed@gmail.com','01022222222','pass2'),
('Sara','Hassan','sara@gmail.com','01033333333','pass3'),
('Omar','Khaled','omar@gmail.com','01044444444','pass4');

-- MOVIE
INSERT INTO MOVIE (title, description, duration_min, language) VALUES
('Inception','Sci-fi',148,'English'),
('Frozen','Animation',102,'English'),
('Interstellar','Space',169,'English'),
('Lion King','Classic',88,'English');

select * from MOVIE;
-- MOVIE_GENRE
INSERT INTO MOVIE_GENRE VALUES
(1,'Sci-Fi'),
(2,'Animation'),
(3,'Sci-Fi'),
(4,'Family');




-- CINEMA
INSERT INTO CINEMA (name,address,city,phone) VALUES
('Cinema One','Nasr City','Cairo','0221111111'),
('Cinema Two','Maadi','Cairo','0222222222'),
('Cinema Three','Heliopolis','Cairo','0223333333'),
('Cinema Four','6 October','Giza','0224444444');

-- HALL
INSERT INTO HALL VALUES
(1,1,100),
(1,2,120),
(1,3,90),
(1,4,80);

-- SEAT_TYPE_VALUE
INSERT INTO SEAT_TYPE_VALUE VALUES
('Regular',50),
('VIP',100),
('Premium',150),
('Economy',30);

-- SEAT
INSERT INTO SEAT VALUES
(1,1,1,'Regular'),
(2,1,2,'VIP'),
(3,1,3,'Premium'),
(4,1,4,'Economy');

-- SHOWTIME_SLOT_PRICE
INSERT INTO SHOWTIME_SLOT_PRICE VALUES
('Morning',20),
('Afternoon',30),
('Evening',40),
('Night',50);

-- SHOWTIME
INSERT INTO SHOWTIME (movie_id,hall_no,cinema_id,slot,date) VALUES
(1,1,1,'Morning','2026-04-25'),
(2,1,2,'Afternoon','2026-04-25'),
(3,1,3,'Evening','2026-04-25'),
(4,1,4,'Night','2026-04-25');

INSERT INTO SHOWTIME (movie_id,hall_no,cinema_id,slot,date) VALUES
(1,1,1,'Morning','2026-05-03'),
(2,1,2,'Afternoon','2026-05-04'),
(3,1,3,'Evening','2026-05-05'),
(4,1,4,'Night','2026-05-06');


-- BOOKING
INSERT INTO BOOKING (customer_id,booking_date,booking_status) VALUES
(1,'2026-04-22','confirmed'),
(2,'2026-04-22','pending'),
(3,'2026-04-22','cancelled'),
(4,'2026-04-22','confirmed');

-- PAYMENT
INSERT INTO PAYMENT (booking_id,payment_method,payment_date,amount,payment_status) VALUES
(1,'Credit Card','2026-04-22',100,'completed'),
(2,'Cash','2026-04-22',80,'pending'),
(3,'Vodafone Cash','2026-04-22',60,'failed'),
(4,'Credit Card','2026-04-22',120,'completed');

-- TICKET
INSERT INTO TICKET (booking_id) VALUES
(1),(2),(3),(4);

-- RESERVATION
INSERT INTO RESERVATION VALUES
(1,1,1,1,1,70),
(2,2,2,1,2,130),
(3,3,3,1,3,180),
(4,4,4,1,4,80);




-- -------------------------------------------------------
-- 1. ADDING MORE CUSTOMERS (To test TOP 3 and LEFT JOINS)
-- -------------------------------------------------------
INSERT INTO CUSTOMER (first_name, last_name, email, phone, password) VALUES
('Noreen', 'Tawfik', 'noreen@eng.asu.edu.eg', '01155555555', 'noreenpass'),
('Tasneem', 'Nasr', 'tasneem@eng.asu.edu.eg', '01266666666', 'tasneempass'),
('Habiba', 'Kotb', 'habiba@eng.asu.edu.eg', '01577777777', 'habibapass');

-- -------------------------------------------------------
-- 2. ADDING MORE SHOWTIMES (To test "Now Showing" and RIGHT JOINS)
-- -------------------------------------------------------
-- Adding showtimes for existing movies in different cinemas/slots
INSERT INTO SHOWTIME (movie_id, hall_no, cinema_id, slot, date) VALUES
(1, 1, 2, 'Evening', '2026-04-26'), -- Inception in Maadi
(3, 1, 1, 'Night', '2026-04-26'),   -- Interstellar in Nasr City
(1, 1, 3, 'Night', '2026-04-27');   -- Inception in Heliopolis

-- -------------------------------------------------------
-- 3. ADDING MULTIPLE BOOKINGS FOR THE SAME CUSTOMERS (To test TOP 3 & HAVING > 500)
-- -------------------------------------------------------
-- Noreen (ID 5) making 3 bookings to become a "Top Customer"
INSERT INTO BOOKING (customer_id, booking_date, booking_status) VALUES
(5, '2026-04-23', 'confirmed'),
(5, '2026-04-24', 'confirmed'),
(5, '2026-04-25', 'confirmed');

-- Ahmed (ID 2) making another booking
INSERT INTO BOOKING (customer_id, booking_date, booking_status) VALUES
(2, '2026-04-23', 'confirmed');

-- -------------------------------------------------------
-- 4. ADDING HIGH-VALUE PAYMENTS (To test HAVING SUM > 500)
-- -------------------------------------------------------
-- Payments for Noreen's bookings (IDs 5, 6, 7)
INSERT INTO PAYMENT (booking_id, payment_method, payment_date, amount, payment_status) VALUES
(5, 'Credit Card', '2026-04-23', 250, 'completed'),
(6, 'Credit Card', '2026-04-24', 300, 'completed'),
(7, 'Credit Card', '2026-04-25', 150, 'completed'); -- Total for Noreen = 700

-- -------------------------------------------------------
-- 5. ADDING TICKETS & RESERVATIONS (To link everything for Section 9 & 11)
-- -------------------------------------------------------
-- Link Noreen's bookings to tickets
INSERT INTO TICKET (booking_id) VALUES (5), (6), (7);

-- Reservations to generate Revenue per Cinema (Section 11.2)
-- Using different showtimes (Showtime IDs 5, 6, 7 from step 2)
INSERT INTO RESERVATION (ticket_id, seat_no, showtime_id, hall_no, cinema_id, price) VALUES
(5, 1, 5, 1, 2, 250), -- Reservation in Cinema Two
(6, 1, 6, 1, 1, 300), -- Reservation in Cinema One
(7, 2, 7, 1, 3, 150); -- Reservation in Cinema Three

----INTO GENRES
INSERT INTO MOVIE_GENRE VALUES
(5,'Comedy');

INSERT INTO MOVIE_GENRE VALUES
(6,'Classic');

select * from MOVIE_GENRE;
