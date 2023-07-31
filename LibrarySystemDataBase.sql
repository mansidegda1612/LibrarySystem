CREATE DATABASE  IF NOT EXISTS `librarysystem` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `librarysystem`;
-- MySQL dump 10.13  Distrib 8.0.27, for Win64 (x86_64)
--
-- Host: localhost    Database: librarysystem
-- ------------------------------------------------------
-- Server version	8.0.27

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `lib01`
--

DROP TABLE IF EXISTS `lib01`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `lib01` (
  `b01f01` int NOT NULL AUTO_INCREMENT COMMENT 'BookID',
  `b01f02` varchar(100) NOT NULL COMMENT 'BookName',
  `b01f03` varchar(500) DEFAULT NULL COMMENT 'Discription',
  `b01f04` varchar(50) DEFAULT NULL COMMENT 'AuthorName',
  `b01f05` varchar(500) DEFAULT NULL COMMENT 'ImagePath',
  PRIMARY KEY (`b01f01`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='Book';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `lib01`
--

LOCK TABLES `lib01` WRITE;
/*!40000 ALTER TABLE `lib01` DISABLE KEYS */;
INSERT INTO `lib01` VALUES (1,'Vahana Masterclass',NULL,'Alfredo Covelli',NULL),(2,'Arthashastra',NULL,'Kautilya',NULL),(3,'A Passage to India',NULL,'E.M. Foster',NULL),(4,'Ben Hur',NULL,' Lewis Wallace',NULL),(5,'Famous Books And Authors List',NULL,'Mark Twain',NULL),(6,'Baburnama',NULL,'Babur',NULL),(7,'Arthashastra',NULL,'Kautilya',NULL),(8,'Alice in Wonderland',NULL,'Lewis Carrol',NULL),(9,'Around the World in eighty days',NULL,'Jules Verne',NULL),(10,'Anna Karenina',NULL,'Leo Tolstoy',NULL);
/*!40000 ALTER TABLE `lib01` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `lib02`
--

DROP TABLE IF EXISTS `lib02`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `lib02` (
  `b02f01` int NOT NULL AUTO_INCREMENT COMMENT 'LibrarianID',
  `b02f02` varchar(50) NOT NULL COMMENT 'LibrarianName',
  `b02f03` varchar(10) NOT NULL COMMENT 'MobileNumber',
  `b02f04` varchar(50) NOT NULL COMMENT 'Email',
  `b02f05` varchar(6) DEFAULT NULL COMMENT 'Gender',
  `b02f06` varchar(100) NOT NULL COMMENT 'Password',
  PRIMARY KEY (`b02f01`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='Librarian';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `lib02`
--

LOCK TABLES `lib02` WRITE;
/*!40000 ALTER TABLE `lib02` DISABLE KEYS */;
INSERT INTO `lib02` VALUES (1,'Mansi','1234567890','mansidegda@gmail.com','female','Gy5P1XyWO9ShTZ+TJT7nZQ=='),(2,'Meera','2345678917','meerarajput@gmail.com','female','Qj+X793buDMNgaZMkf+OsQ==');
/*!40000 ALTER TABLE `lib02` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `lib03`
--

DROP TABLE IF EXISTS `lib03`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `lib03` (
  `b03f01` int NOT NULL AUTO_INCREMENT COMMENT 'UserID',
  `b03f02` varchar(50) NOT NULL COMMENT 'UserName',
  `b03f03` varchar(6) DEFAULT NULL COMMENT 'Gender',
  `b03f04` varchar(10) NOT NULL COMMENT 'MobileNumber',
  `b03f05` varchar(100) DEFAULT NULL COMMENT 'Address',
  `b03f06` varchar(50) NOT NULL COMMENT 'Email',
  `b03f07` varchar(100) NOT NULL COMMENT 'Password',
  PRIMARY KEY (`b03f01`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='User';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `lib03`
--

LOCK TABLES `lib03` WRITE;
/*!40000 ALTER TABLE `lib03` DISABLE KEYS */;
INSERT INTO `lib03` VALUES (1,'Mansi Degda','female','9879551413',NULL,'mansidegda123@gmail.com','Gy5P1XyWO9ShTZ+TJT7nZQ=='),(2,'MansiDegda','female','1234567890','geetanagar','mansidegda1612@gmail.com','nlP/eywqbgoArdEwJ4yByA=='),(3,'Divy','male','5673452896','Dharmjivan road','divydegda@gmail.com','4GdtO0arfWN3JXcXCxejiQ=='),(4,'Drasti','female','5673452896','Dharmjivan road','drastidegda@gmail.com','7CLwgIo/EQ22DaDK9yYvQA==');
/*!40000 ALTER TABLE `lib03` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `lib04`
--

DROP TABLE IF EXISTS `lib04`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `lib04` (
  `b04f01` int NOT NULL AUTO_INCREMENT COMMENT 'AccountID',
  `b04f02` int NOT NULL COMMENT 'BookID',
  `b04f03` int NOT NULL COMMENT 'BorrowerID',
  `b04f04` int DEFAULT NULL COMMENT 'IssuerID',
  `b04f05` datetime DEFAULT CURRENT_TIMESTAMP COMMENT 'DataOfIssue',
  `b04f06` datetime DEFAULT CURRENT_TIMESTAMP COMMENT 'DateOfReturn',
  `b04f07` double DEFAULT '0' COMMENT 'Fine',
  PRIMARY KEY (`b04f01`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='Account';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `lib04`
--

LOCK TABLES `lib04` WRITE;
/*!40000 ALTER TABLE `lib04` DISABLE KEYS */;
INSERT INTO `lib04` VALUES (1,1,1,1,'2022-02-19 00:00:00','2022-02-21 11:59:28',20),(2,2,2,0,NULL,NULL,0),(3,4,2,1,'2022-02-19 00:00:00','2022-02-21 11:59:28',20),(4,8,4,2,'2022-01-19 00:00:00','2022-02-11 00:00:00',0),(5,7,2,1,NULL,NULL,0),(6,5,3,2,'2022-02-23 17:31:16','2022-02-23 17:31:16',0);
/*!40000 ALTER TABLE `lib04` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'librarysystem'
--

--
-- Dumping routines for database 'librarysystem'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-02-23 17:33:10
