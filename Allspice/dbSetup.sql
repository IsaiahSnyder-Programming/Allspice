CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8 COMMENT '';
--
--
CREATE TABLE IF NOT EXISTS recipes(
  id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  creatorId varchar(255) NOT NULL,
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP,
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  --
  name TEXT NOT NULL,
  description varchar(5000) DEFAULT 'no description provided',
  imgUrl varchar(5000) DEFAULT 'no image provided',
  category TEXT NOT NULL,
  averageTime INT DEFAULT 1,
  --
  FOREIGN KEY (creatorId) REFERENCES accounts(id)
) default charset utf8;
--
--
DROP TABLE IF EXISTS recipes;
--
--
INSERT INTO
  recipes (
    name,
    description,
    imgUrl,
    category,
    averageTime,
    creatorId
  )
VALUES
  (
    'Markarita',
    '+35hp',
    '//thiscatdoesnotexist.com/',
    'Potions',
    122,
    '621fe5d6dbe50cea2b338f0c'
  );
--
  --
SELECT
  *
FROM
  recipes;
--
  --
SELECT
  r.*,
  a.*
FROM
  recipes r
  JOIN accounts a
WHERE
  a.id = r.creatorId;
--
  --
UPDATE
  recipes
SET
  name = "Markarita",
  description = "+35hp"
WHERE
  id = 4;
--
  --
DELETE FROM
  recipes
WHERE
  id = 3
LIMIT
  1;