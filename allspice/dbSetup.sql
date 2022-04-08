CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8 COMMENT '';
CREATE TABLE IF NOT EXISTS recipes(
  id INT AUTO_INCREMENT primary key,
  title TEXT NOT NULL,
  subtitle VARCHAR(500) DEFAULT '',
  category TEXT NOT NULL,
  image TEXT,
  creatorId VARCHAR(255) NOT NULL,
  FOREIGN KEY(creatorID) REFERENCES accounts(id)
) default charset utf8 COMMENT '';
INSERT INTO
  recipes (title, subtitle, category, creatorId)
VALUES
  (
    'Cheeseburger',
    'and Fries',
    'American',
    '6234f2ff8e822c2a6080865b'
  );
SELECT
  *
FROM
  recipes;
SELECT
  r.*,
  a.*
FROM
  recipes r
  JOIN accounts a
WHERE
  a.id = r.creatorId;
DELETE FROM
  recipes
WHERE
  id = 18
LIMIT
  1;
DROP TABLE IF EXISTS recipes