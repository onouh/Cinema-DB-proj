
INSERT INTO MOVIE (title, description, duration_min, language) VALUES
('The Dark Knight', 'Action/Thriller', 152, 'English'),
('Dune: Part Two', 'Sci-Fi/Epic', 166, 'English'),
('Oppenheimer', 'Biography/Drama', 180, 'English'),
('Spider-Man: Across the Spider-Verse', 'Animation', 140, 'English'),
('Parasite', 'Thriller', 132, 'Korean'),
('The Godfather', 'Crime', 175, 'English'),
('Spirited Away', 'Anime', 125, 'Japanese'),
('Gladiator', 'Action', 155, 'English'),
('The Matrix', 'Sci-Fi', 136, 'English'),
('Avatar: The Way of Water', 'Sci-Fi', 192, 'English');


DECLARE @i INT = 5;
WHILE @i <= 30
BEGIN
    INSERT INTO SEAT VALUES (@i, 1, 1, 'Regular');
    INSERT INTO SEAT VALUES (@i, 1, 2, 'VIP');
    INSERT INTO SEAT VALUES (@i, 1, 3, 'Regular');
    SET @i = @i + 1;
END;