-- MySQL dump 10.13  Distrib 8.0.24, for Linux (x86_64)
--
-- Host: localhost    Database: BDD_Vehiculos
-- ------------------------------------------------------
-- Server version	8.0.24

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `__EFMigrationsHistory`
--

DROP TABLE IF EXISTS `__EFMigrationsHistory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `__EFMigrationsHistory` (
  `MigrationId` varchar(150) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ProductVersion` varchar(32) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `__EFMigrationsHistory`
--

LOCK TABLES `__EFMigrationsHistory` WRITE;
/*!40000 ALTER TABLE `__EFMigrationsHistory` DISABLE KEYS */;
INSERT INTO `__EFMigrationsHistory` VALUES ('20210715135429_CreateBDDMigration','5.0.8'),('20210715155627_FixBDDMigration','5.0.8'),('20210715170337_FixBDDMigrationTwo','5.0.8');
/*!40000 ALTER TABLE `__EFMigrationsHistory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Emails`
--

DROP TABLE IF EXISTS `Emails`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Emails` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `DireccionEmail` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `TitularId` int NOT NULL DEFAULT '0',
  PRIMARY KEY (`Id`),
  KEY `IX_Emails_TitularId` (`TitularId`),
  CONSTRAINT `FK_Emails_Titulares_TitularId` FOREIGN KEY (`TitularId`) REFERENCES `Titulares` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Emails`
--

LOCK TABLES `Emails` WRITE;
/*!40000 ALTER TABLE `Emails` DISABLE KEYS */;
INSERT INTO `Emails` VALUES (1,'ezequiel@minutto.it',1),(2,'sebastian@gomez.it',2),(3,'vanesa@gaitan.it',3),(4,'vanessa@gaitan.com',3),(7,'ezequiel@3at.it',18),(8,'eeezequielminutto@gmail.com',20),(9,'eve@holt.com',21),(10,'michael@lawson.com',22);
/*!40000 ALTER TABLE `Emails` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Marcas`
--

DROP TABLE IF EXISTS `Marcas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Marcas` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `NombreMarca` varchar(200) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Marcas`
--

LOCK TABLES `Marcas` WRITE;
/*!40000 ALTER TABLE `Marcas` DISABLE KEYS */;
INSERT INTO `Marcas` VALUES (1,'Ford'),(2,'Chevrolet'),(3,'Peugeot'),(4,'Nissan'),(15,'Audi'),(16,'Smart');
/*!40000 ALTER TABLE `Marcas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Titulares`
--

DROP TABLE IF EXISTS `Titulares`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Titulares` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(200) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `Apellido` varchar(200) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=25 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Titulares`
--

LOCK TABLES `Titulares` WRITE;
/*!40000 ALTER TABLE `Titulares` DISABLE KEYS */;
INSERT INTO `Titulares` VALUES (1,'Ezequiel','Minutto'),(2,'Sebastian','Gomez'),(3,'Vanesa','Gaitan'),(14,'Marcos','Popolo'),(16,'Marina','Martinez'),(17,'Esteban','Marquez'),(18,'Janet','Weaver'),(19,'Emma','Wong'),(20,'Tobias','Funke'),(21,'Eve','Holt'),(22,'Michael','Lawson'),(23,'George','Edwards'),(24,'Byron','Fields');
/*!40000 ALTER TABLE `Titulares` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `TitularesVehiculos`
--

DROP TABLE IF EXISTS `TitularesVehiculos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `TitularesVehiculos` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `VehiculoId` int NOT NULL,
  `TitularId` int NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_TitularesVehiculos_TitularId` (`TitularId`),
  KEY `IX_TitularesVehiculos_VehiculoId` (`VehiculoId`),
  CONSTRAINT `FK_TitularesVehiculos_Titulares_TitularId` FOREIGN KEY (`TitularId`) REFERENCES `Titulares` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_TitularesVehiculos_Vehiculos_VehiculoId` FOREIGN KEY (`VehiculoId`) REFERENCES `Vehiculos` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `TitularesVehiculos`
--

LOCK TABLES `TitularesVehiculos` WRITE;
/*!40000 ALTER TABLE `TitularesVehiculos` DISABLE KEYS */;
INSERT INTO `TitularesVehiculos` VALUES (1,1,2),(2,2,3),(3,3,2),(6,8,20),(7,9,21),(8,10,22),(9,11,22),(10,12,20),(11,13,21),(12,14,23),(13,15,24),(14,16,21);
/*!40000 ALTER TABLE `TitularesVehiculos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Vehiculos`
--

DROP TABLE IF EXISTS `Vehiculos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Vehiculos` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `MarcaId` int NOT NULL,
  `Modelo` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `Patente` varchar(8) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `CantPuertas` int NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_Vehiculos_MarcaId` (`MarcaId`),
  CONSTRAINT `FK_Vehiculos_Marcas_MarcaId` FOREIGN KEY (`MarcaId`) REFERENCES `Marcas` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Vehiculos`
--

LOCK TABLES `Vehiculos` WRITE;
/*!40000 ALTER TABLE `Vehiculos` DISABLE KEYS */;
INSERT INTO `Vehiculos` VALUES (1,1,'2020','AC34567V',5),(2,3,'2019','AW432',3),(3,2,'2021','QA3456',3),(8,1,'4343','sasdsas',4),(9,2,'Cruze','3ddaas1',3),(10,15,'TT','QAZ213',2),(11,1,'Ka','ER334AZ',5),(12,15,'TT','34RFSA1',4),(13,4,'Tiida','45REWA1',5),(14,16,'ics','AQ2345FC',2),(15,1,'T','LSZ908',4),(16,1,'T','RTYUIO',2);
/*!40000 ALTER TABLE `Vehiculos` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2021-07-20 19:07:23
