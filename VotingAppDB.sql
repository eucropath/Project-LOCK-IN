/*
SQLyog Community v13.3.0 (64 bit)
MySQL - 10.4.32-MariaDB : Database - votingappdb
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`votingappdb` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci */;

USE `votingappdb`;

/*Table structure for table `party` */

DROP TABLE IF EXISTS `party`;

CREATE TABLE `party` (
  `PartyID` int(11) NOT NULL,
  `PartyName` varchar(50) NOT NULL,
  PRIMARY KEY (`PartyID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

/*Data for the table `party` */

insert  into `party`(`PartyID`,`PartyName`) values 
(0,'HNP'),
(1,'Liberal');

/*Table structure for table `results` */

DROP TABLE IF EXISTS `results`;

CREATE TABLE `results` (
  `ResultsID` int(11) NOT NULL AUTO_INCREMENT,
  `PartyID` int(11) NOT NULL,
  `VoterID` int(11) NOT NULL,
  `VoteDate` timestamp NOT NULL DEFAULT current_timestamp(),
  PRIMARY KEY (`ResultsID`),
  KEY `fk_party` (`PartyID`),
  KEY `fk_voter` (`VoterID`),
  CONSTRAINT `fk_party` FOREIGN KEY (`PartyID`) REFERENCES `party` (`PartyID`),
  CONSTRAINT `fk_voter` FOREIGN KEY (`VoterID`) REFERENCES `voter` (`VoterID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

/*Data for the table `results` */

/*Table structure for table `students` */

DROP TABLE IF EXISTS `students`;

CREATE TABLE `students` (
  `student_id` int(11) NOT NULL AUTO_INCREMENT,
  `first_name` varchar(100) NOT NULL,
  `last_name` varchar(100) NOT NULL,
  `course` varchar(100) NOT NULL,
  `year_level` int(11) NOT NULL,
  PRIMARY KEY (`student_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

/*Data for the table `students` */

/*Table structure for table `voter` */

DROP TABLE IF EXISTS `voter`;

CREATE TABLE `voter` (
  `VoterID` int(11) NOT NULL,
  `Fullnames` varchar(50) NOT NULL,
  `Email` varchar(50) NOT NULL,
  PRIMARY KEY (`VoterID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

/*Data for the table `voter` */

insert  into `voter`(`VoterID`,`Fullnames`,`Email`) values 
(0,'Kyle Verdida','kyleverdz@gmail.com');

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
