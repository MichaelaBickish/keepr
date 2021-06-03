-- required - not null:
-- profile name email id req
--
CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) NOT NULL COMMENT 'User Name',
  email varchar(255) NOT NULL COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8 COMMENT '';
-- PROFILE CREATOR is a prop in the KEEP and VAULT models that will be 'populated' - not on tables.
-- required - not null:
-- keep ids descrip img
CREATE TABLE IF NOT EXISTS keeps(
  id INT NOT NULL AUTO_INCREMENT primary key COMMENT 'primary key',
  creatorId VARCHAR(255) NOT NULL COMMENT 'FK: User Account',
  name VARCHAR(255) NOT NULL COMMENT 'Keep Name/Title',
  description VARCHAR(255) NOT NULL COMMENT 'Keep Description',
  img VARCHAR(255) NOT NULL COMMENT 'Keep imgUrl',
  views INT NOT NULL COMMENT 'Keep Views',
  keeps INT NOT NULL COMMENT 'Keep Saves',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  shares INT COMMENT 'Keep Shares',
  FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE
) default charset utf8 COMMENT '';
-- required - not null:
-- vaults id creator id name DESCription
CREATE TABLE IF NOT EXISTS vaults(
  id INT NOT NULL AUTO_INCREMENT primary key COMMENT 'primary key',
  creatorId VARCHAR (255) NOT NULL COMMENT 'FK: Account',
  name varchar(255) NOT NULL COMMENT 'Vault Name',
  description VARCHAR(255) NOT NULL COMMENT 'Vault Description',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  img VARCHAR(255) COMMENT 'Vault imgUrl',
  isPrivate boolean COMMENT 'Vault Privacy' default 0,
  FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE
) default charset utf8 COMMENT '';
-- required - not null:
-- vkeeps all ids.
CREATE TABLE IF NOT EXISTS vault_keeps(
  id INT AUTO_INCREMENT NOT NULL primary key COMMENT 'primary key',
  creatorId varchar(255) NOT NULL COMMENT 'FK: User Account',
  vaultId int NOT NULL COMMENT 'FK: Vault Id',
  keepId int NOT NULL COMMENT 'FK: Keep Id',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE,
  FOREIGN KEY (vaultId) REFERENCES vaults(id) ON DELETE CASCADE,
  FOREIGN KEY (keepId) REFERENCES keeps(id) ON DELETE CASCADE
) default charset utf8 COMMENT '';
-- //fkey for vault id, keep id, profile id.
-- SELECT
--   *
-- FROM
--   vaults
-- INSERT INTO
--   keeps (description, img, views, shares, keeps)
-- VALUES
--   ("My first keep!", "@Img", @Shares, @Keeps)
-- SELECT
--   LAST_INSERT_ID();
-- SELECT
--   v.*,
--   a.*
-- FROM
--   vaults v
--   JOIN accounts a ON a.id = v.creatorId
-- WHERE
--   v.creatorId = "10ef607a-e1b5-4618-a53a-fb81a2589d58"
--   AND v.isPrivate = 0;
-- SELECT
--   v.*,
--   a.*
-- FROM
--   vaults v
--   JOIN accounts a ON a.id = v.creatorId
-- WHERE
--   v.id = 50;
DROP TABLE keeps;