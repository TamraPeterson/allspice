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
  FOREIGN KEY(creatorId) REFERENCES accounts(id)  
) default charset utf8 COMMENT '';

ALTER TABLE recipes,
ON DELETE CASCADE;

CREATE TABLE IF NOT EXISTS ingredients(
    id INT AUTO_INCREMENT primary key,
    name TEXT NOT NULL,
    quantity TEXT,
    recipeId INT NOT NULL,
    FOREIGN KEY(recipeId) REFERENCES recipes(id)
  ) default charset utf8 COMMENT '';

ALTER TABLE ingredients
DROP FOREIGN KEY recipeId;

CREATE TABLE IF NOT EXISTS steps(
    id INT AUTO_INCREMENT primary key,
    position INT,
    body TEXT,
    recipeId INT NOT NULL,
    FOREIGN KEY(recipeId) REFERENCES recipes(id)
)   default charset utf8 COMMENT '';

ALTER TABLE steps
DROP FOREIGN KEY recipeId 

CREATE TABLE IF NOT EXISTS favorites(
  id INT AUTO_INCREMENT NOT NULL primary key,
  accountId VARCHAR(255) NOT NULL,
  recipeId INT NOT NULL,
  FOREIGN KEY (accountID) REFERENCES accounts(id) ON DELETE CASCADE,
  FOREIGN KEY (recipeID) REFERENCES recipes(id) ON DELETE CASCADE
)default charset utf8 COMMENT '';

-- Recipes
SELECT * FROM recipes;

DROP TABLE recipes;

INSERT INTO
  recipes (title, subtitle, category, image, creatorId)
VALUES
  (
    'Spaghet',
  'a tasty meal',
    'Dinner',
    'https://www.cookingclassy.com/wp-content/uploads/2012/11/spaghetti+with+meat+sauce11.jpg',
    '6234f2ff8e822c2a6080865b'
  );
SELECT * FROM steps;


SELECT r.*, a.*
FROM recipes r
  JOIN accounts a
WHERE a.id = r.creatorId;


DELETE FROM recipes
WHERE id = 3 LIMIT 1;


-- Ingredients

SELECT * FROM ingredients;
DROP TABLE ingredients;

INSERT INTO
  ingredients (name, quantity, recipeId)
VALUES
  (
    'Vomit',
    2,
    5
  );
  SELECT i.*, r.*
FROM ingredients i
  JOIN recipes r
WHERE r.id = i.recipeId;

DELETE FROM ingredients
WHERE id = 18 LIMIT 1;

-- Steps
SELECT * FROM steps;

DROP TABLE steps;

INSERT INTO
  steps (position, body, recipeId)
VALUES
  (
    1,
    "Boil the Noodles",
    3
  );
  SELECT s.*, r.*
FROM steps s
  JOIN recipes r
WHERE r.id = s.recipeId;


            SELECT * FROM ingredients i
            WHERE i.recipeId = 5;

DELETE FROM steps
WHERE id = 18 LIMIT 1;
