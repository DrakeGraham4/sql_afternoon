CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8 COMMENT '';
CREATE TABLE IF NOT EXISTS cars(
  id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  make TEXT NOT NULL,
  model TEXT NOT NULL,
  price INT NOT NULL,
  year INT NOT NULL
) default charset utf8;
/* POST*/
INSERT INTO
  cars (make, model, price, year)
VALUES
  ("Brown", "Probe", 300, 1989);
  /*GET*/
SELECT
  *
FROM
  cars;
  /* GET BY __*/
SELECT
  *
FROM
  cars
WHERE
  id = 3;
  /* PUT */
UPDATE
  cars
SET
  make = "Toyota",
  model = "Tundra",
  price = 32000,
  year = 2012
WHERE
  id = 2;
  /*Delete*/
DELETE FROM
  cars
WHERE
  id = 3
LIMIT
  1;
  /* POST */
  CREATE TABLE IF NOT EXISTS houses(
    id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    bedrooms INT NOT NULL,
    bathrooms INT NOT NULL,
    description TEXT,
    price INT NOT NULL,
    year INT NOT NULL
  ) default charset utf8;
INSERT INTO
  houses(bedrooms, bathrooms, description, price, year)
VALUES
  (
    10,
    12,
    "Ruining the economy one bedroom at a time",
    20000134,
    2021
  );
  /* GET ALL */
SELECT
  *
FROM
  houses;
  /* GET BY __ */
SELECT
  *
FROM
  houses
WHERE
  id = 3;
  /* PUT */
UPDATE
  houses
SET
  bedrooms = 5,
  bathrooms = 6,
  description = "Upgrade!",
  price = 1234456,
  year = 2006
WHERE
  id = 2;
  /* DELETE */
DELETE FROM
  houses
WHERE
  id = 2
LIMIT
  1;