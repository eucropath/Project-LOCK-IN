/*
SQLyog Community v13.3.0 (64 bit)
MySQL - 10.4.32-MariaDB : Database - votingsystem
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`votingsystem` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci */;

USE `votingsystem`;

/*Table structure for table `candidates` */

DROP TABLE IF EXISTS `candidates`;

CREATE TABLE `candidates` (
  `CandidateID` int(11) NOT NULL AUTO_INCREMENT,
  `FirstName` varchar(100) DEFAULT NULL,
  `LastName` varchar(100) DEFAULT NULL,
  `PartyID` int(11) DEFAULT NULL,
  `POSITION` varchar(100) DEFAULT NULL,
  `CreatedAt` timestamp NOT NULL DEFAULT current_timestamp(),
  PRIMARY KEY (`CandidateID`),
  KEY `PartyID` (`PartyID`),
  CONSTRAINT `candidates_ibfk_1` FOREIGN KEY (`PartyID`) REFERENCES `parties` (`PartyID`) ON DELETE SET NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

/*Data for the table `candidates` */

/*Table structure for table `parties` */

DROP TABLE IF EXISTS `parties`;

CREATE TABLE `parties` (
  `PartyID` int(11) NOT NULL AUTO_INCREMENT,
  `PartyName` varchar(100) NOT NULL,
  `Acronym` varchar(20) DEFAULT NULL,
  `DESCRIPTION` text DEFAULT NULL,
  PRIMARY KEY (`PartyID`),
  UNIQUE KEY `PartyName` (`PartyName`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

/*Data for the table `parties` */

/*Table structure for table `users` */

DROP TABLE IF EXISTS `users`;

CREATE TABLE `users` (
  `UserID` int(11) NOT NULL AUTO_INCREMENT,
  `Username` varchar(100) NOT NULL,
  `Password` varchar(100) NOT NULL,
  `FullName` varchar(150) DEFAULT NULL,
  `Role` enum('admin','clerk') DEFAULT 'admin',
  `CreatedAt` timestamp NOT NULL DEFAULT current_timestamp(),
  PRIMARY KEY (`UserID`),
  UNIQUE KEY `Username` (`Username`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

/*Data for the table `users` */

insert  into `users`(`UserID`,`Username`,`Password`,`FullName`,`Role`,`CreatedAt`) values 
(1,'admin','admin123','Administrator','admin','2025-09-18 20:52:02'),
(2,'voter1','voter123','Juan Dela Cruz','','2025-09-18 20:57:06');

/*Table structure for table `voters` */

DROP TABLE IF EXISTS `voters`;

CREATE TABLE `voters` (
  `VoterID` int(11) NOT NULL AUTO_INCREMENT,
  `VoterNumber` varchar(50) NOT NULL,
  `FirstName` varchar(100) DEFAULT NULL,
  `LastName` varchar(100) DEFAULT NULL,
  `Email` varchar(150) DEFAULT NULL,
  `HasVoted` tinyint(1) DEFAULT 0,
  `RegisteredAt` timestamp NOT NULL DEFAULT current_timestamp(),
  PRIMARY KEY (`VoterID`),
  UNIQUE KEY `VoterNumber` (`VoterNumber`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

/*Data for the table `voters` */

insert  into `voters`(`VoterID`,`VoterNumber`,`FirstName`,`LastName`,`Email`,`HasVoted`,`RegisteredAt`) values 
(1,'1','Justin','Nabunturan','gang@email',0,'2025-09-18 20:53:29'),
(3,'','','','',0,'2025-09-18 21:00:58');

/*Table structure for table `votes` */

DROP TABLE IF EXISTS `votes`;

CREATE TABLE `votes` (
  `VoteID` int(11) NOT NULL AUTO_INCREMENT,
  `VoterID` int(11) NOT NULL,
  `CandidateID` int(11) NOT NULL,
  `CastAt` timestamp NOT NULL DEFAULT current_timestamp(),
  PRIMARY KEY (`VoteID`),
  UNIQUE KEY `unique_vote_per_voter` (`VoterID`),
  KEY `CandidateID` (`CandidateID`),
  CONSTRAINT `votes_ibfk_1` FOREIGN KEY (`VoterID`) REFERENCES `voters` (`VoterID`) ON DELETE CASCADE,
  CONSTRAINT `votes_ibfk_2` FOREIGN KEY (`CandidateID`) REFERENCES `candidates` (`CandidateID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

/*Data for the table `votes` */

/* Procedure structure for procedure `sp_AddCandidate` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_AddCandidate` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_AddCandidate`(IN in_fn VARCHAR(100), IN in_ln VARCHAR(100), IN in_party INT, IN in_position VARCHAR(100))
BEGIN
  INSERT INTO Candidates (FirstName, LastName, PartyID, Position)
  VALUES (in_fn, in_ln, in_party, in_position);
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_AddParty` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_AddParty` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_AddParty`(IN in_name VARCHAR(100), IN in_acronym VARCHAR(20), IN in_desc TEXT)
BEGIN
  INSERT INTO Parties (PartyName, Acronym, DESCRIPTION)
  VALUES (in_name, in_acronym, in_desc);
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_AddUser` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_AddUser` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_AddUser`(
  IN in_username VARCHAR(100),
  IN in_password VARCHAR(100),
  IN in_fullname VARCHAR(150),
  IN in_role VARCHAR(10)
)
BEGIN
  INSERT INTO Users (Username, Password, FullName, Role)
  VALUES (in_username, in_password, in_fullname, in_role);
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_AddVoter` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_AddVoter` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_AddVoter`(IN in_vnum VARCHAR(50), IN in_fn VARCHAR(100), IN in_ln VARCHAR(100), IN in_email VARCHAR(150))
BEGIN
  INSERT INTO Voters (VoterNumber, FirstName, LastName, Email)
  VALUES (in_vnum, in_fn, in_ln, in_email);
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_CastVote` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_CastVote` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_CastVote`(IN in_voterid INT, IN in_candidateid INT)
BEGIn
  DECLARE EXIT HANDLER FOR SQLEXCEPTION
  BEGIN
    ROLLBACK;
    RESIGNAL;
  END;
  
  START TRANSACTION;
  
  -- ensure voter exists and hasn't voted
  IF (SELECT HasVoted FROM Voters WHERE VoterID=in_voterid FOR UPDATE) = 1 THEN
    SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Voter has already voted';
  END IF;
  
  -- insert vote
  INSERT INTO Votes (VoterID, CandidateID) VALUES (in_voterid, in_candidateid);
  -- mark voter as voted
  UPDATE Voters SET HasVoted = 1 WHERE VoterID = in_voterid;
  
  COMMIT;
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_DeleteCandidate` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_DeleteCandidate` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_DeleteCandidate`(IN in_id INT)
BEGIN
  DELETE FROM Candidates WHERE CandidateID=in_id;
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_DeleteParty` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_DeleteParty` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_DeleteParty`(IN in_id INT)
BEGIN
  DELETE FROM Parties WHERE PartyID=in_id;
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_DeleteVoter` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_DeleteVoter` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_DeleteVoter`(IN in_id INT)
BEGIN
  DELETE FROM Voters WHERE VoterID=in_id;
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_GetAllCandidates` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_GetAllCandidates` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_GetAllCandidates`()
BEGIN
  SELECT c.CandidateID, c.FirstName, c.LastName, c.Position, c.PartyID, p.PartyName
  FROM Candidates c
  LEFT JOIN Parties p ON c.PartyID = p.PartyID
  ORDER BY c.Position, c.LastName;
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_GetAllParties` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_GetAllParties` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_GetAllParties`()
BEGIN
  SELECT PartyID, PartyName, Acronym, Description FROM Parties ORDER BY PartyName;
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_GetAllVoters` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_GetAllVoters` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_GetAllVoters`()
BEGIN
  SELECT VoterID, VoterNumber, FirstName, LastName, Email, HasVoted, RegisteredAt FROM Voters ORDER BY RegisteredAt DESC;
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_GetResults` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_GetResults` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_GetResults`()
BEGIN
  SELECT c.CandidateID, CONCAT(c.FirstName,' ',c.LastName) AS CandidateName, p.PartyName, c.Position, COUNT(v.VoteID) AS Votes
  FROM Candidates c
  LEFT JOIN Parties p ON c.PartyID = p.PartyID
  LEFT JOIN Votes v ON c.CandidateID = v.CandidateID
  GROUP BY c.CandidateID
  ORDER BY Votes DESC;
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_GetUserByUsername` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_GetUserByUsername` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_GetUserByUsername`(IN in_username VARCHAR(100))
BEGIN
  SELECT UserID, Username, Password, FullName, Role
  FROM Users
  WHERE Username = in_username;
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_GetVoterByNumber` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_GetVoterByNumber` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_GetVoterByNumber`(IN in_vnum VARCHAR(50))
BEGIN
  SELECT VoterID, VoterNumber, FirstName, LastName, Email, HasVoted FROM Voters WHERE VoterNumber = in_vnum;
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_UpdateCandidate` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_UpdateCandidate` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_UpdateCandidate`(IN in_id INT, IN in_fn VARCHAR(100), IN in_ln VARCHAR(100), IN in_party INT, IN in_position VARCHAR(100))
BEGIN
  UPDATE Candidates SET FirstName=in_fn, LastName=in_ln, PartyID=in_party, Position=in_position WHERE CandidateID=in_id;
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_UpdateVoter` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_UpdateVoter` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_UpdateVoter`(IN in_id INT, IN in_vnum VARCHAR(50), IN in_fn VARCHAR(100), IN in_ln VARCHAR(100), IN in_email VARCHAR(150))
BEGIN
  UPDATE Voters SET VoterNumber=in_vnum, FirstName=in_fn, LastName=in_ln, Email=in_email WHERE VoterID=in_id;
END */$$
DELIMITER ;

/*Table structure for table `candidateresults` */

DROP TABLE IF EXISTS `candidateresults`;

/*!50001 DROP VIEW IF EXISTS `candidateresults` */;
/*!50001 DROP TABLE IF EXISTS `candidateresults` */;

/*!50001 CREATE TABLE  `candidateresults`(
 `CandidateID` int(11) ,
 `CandidateName` varchar(201) ,
 `PartyName` varchar(100) ,
 `Position` varchar(100) ,
 `Votes` bigint(21) 
)*/;

/*View structure for view candidateresults */

/*!50001 DROP TABLE IF EXISTS `candidateresults` */;
/*!50001 DROP VIEW IF EXISTS `candidateresults` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `candidateresults` AS select `c`.`CandidateID` AS `CandidateID`,concat(`c`.`FirstName`,' ',`c`.`LastName`) AS `CandidateName`,`p`.`PartyName` AS `PartyName`,`c`.`POSITION` AS `Position`,count(`v`.`VoteID`) AS `Votes` from ((`candidates` `c` left join `parties` `p` on(`c`.`PartyID` = `p`.`PartyID`)) left join `votes` `v` on(`c`.`CandidateID` = `v`.`CandidateID`)) group by `c`.`CandidateID` */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
