use reviewsapi;
-- CREATE TABLE profiles
-- (
--   id VARCHAR(255) NOT NULL,
--   email VARCHAR(255) NOT NULL,
--   name VARCHAR(255),
--   picture VARCHAR(255),
--   PRIMARY KEY (id)
-- );

CREATE TABLE restaurants
(
  id VARCHAR(255) NOT NULL AUTO_INCREMENT,
  Name VARCHAR(255) NOT NULL,
  Location VARCHAR(255),
  Owner VARCHAR(255)
);

INSERT INTO restaurants
(Name, Location, Owner)
VALUES
("Pizza hut","Boise","John");
SELECT * FROM restaurants;