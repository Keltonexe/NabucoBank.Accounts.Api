CREATE DATABASE `nabucobank_accounts`;

-- nabucobank_accounts.accounts definition

CREATE TABLE `accounts` (
  `ID` bigint NOT NULL AUTO_INCREMENT,
  `ID_USER` bigint NOT NULL,
  `NUMBER` varchar(100) NOT NULL,
  `BALANCE` decimal(10,0) NOT NULL,
  `DT_CREATED` datetime NOT NULL,
  `DT_UPDATED` datetime DEFAULT NULL,
  `DT_DELETED` datetime DEFAULT NULL,
  `HASH_CODE` varchar(100) NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `accounts_FK` (`ID_USER`),
  CONSTRAINT `accounts_FK` FOREIGN KEY (`ID_USER`) REFERENCES `users` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- nabucobank_accounts.address definition

CREATE TABLE `address` (
  `ID` bigint NOT NULL AUTO_INCREMENT,
  `ID_USER` bigint NOT NULL,
  `STREET` varchar(100) NOT NULL,
  `STATE` varchar(100) NOT NULL,
  `CITY` varchar(100) NOT NULL,
  `NUMBER` varchar(100) NOT NULL,
  `COMPLEMENT` varchar(100) NOT NULL,
  `DT_CREATED` datetime NOT NULL,
  `DT_UPDATED` datetime DEFAULT NULL,
  `DT_DELETED` datetime DEFAULT NULL,
  `HASH_CODE` varchar(100) NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `address_FK` (`ID_USER`),
  CONSTRAINT `address_FK` FOREIGN KEY (`ID_USER`) REFERENCES `users` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- nabucobank_accounts.users definition

CREATE TABLE `users` (
  `ID` bigint NOT NULL AUTO_INCREMENT,
  `CPF` varchar(100) NOT NULL,
  `NAME` varchar(100) NOT NULL,
  `EMAIL` varchar(100) NOT NULL,
  `PASSWORD` varchar(100) NOT NULL,
  `PHONE` varchar(100) NOT NULL,
  `DT_CREATED` datetime NOT NULL,
  `DT_UPDATED` datetime DEFAULT NULL,
  `DT_DELETED` datetime DEFAULT NULL,
  `HASH_CODE` varchar(100) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;