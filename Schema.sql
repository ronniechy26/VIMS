/*
SQLyog Ultimate v10.00 Beta1
MySQL - 5.5.5-10.2.7-MariaDB-10.2.7+maria~xenial : Database - vms
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`vms` /*!40100 DEFAULT CHARACTER SET latin1 */;

USE `vms`;

/*Table structure for table `t_Priority Cluster Province` */

DROP TABLE IF EXISTS `t_Priority Cluster Province`;

CREATE TABLE `t_Priority Cluster Province` (
  `priority cluster_ID` int(10) NOT NULL AUTO_INCREMENT,
  `Priority Cluster` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`priority cluster_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

/*Data for the table `t_Priority Cluster Province` */

insert  into `t_Priority Cluster Province`(`priority cluster_ID`,`Priority Cluster`) values (1,'1st priority cluster'),(2,'2nd priority cluster'),(3,'non priority');

/*Table structure for table `t_classification` */

DROP TABLE IF EXISTS `t_classification`;

CREATE TABLE `t_classification` (
  `classification_id` int(10) NOT NULL AUTO_INCREMENT,
  `classification_desc` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`classification_id`),
  KEY `ID_REGION_DESC` (`classification_desc`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;

/*Data for the table `t_classification` */

insert  into `t_classification`(`classification_id`,`classification_desc`) values (4,'1st'),(5,'2nd'),(6,'3rd'),(1,'4th'),(2,'5th'),(3,'6th');

/*Table structure for table `t_extension` */

DROP TABLE IF EXISTS `t_extension`;

CREATE TABLE `t_extension` (
  `extension_id` int(10) NOT NULL AUTO_INCREMENT,
  `request_sub_id` int(10) DEFAULT NULL,
  `start_date` date DEFAULT NULL,
  `end_date` date DEFAULT NULL,
  `remarks` text DEFAULT NULL,
  PRIMARY KEY (`extension_id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=latin1;

/*Data for the table `t_extension` */

insert  into `t_extension`(`extension_id`,`request_sub_id`,`start_date`,`end_date`,`remarks`) values (1,25,'2018-10-01','2018-12-29','awit'),(2,25,'2018-12-29','2019-03-23',''),(3,27,'2018-11-14','2020-01-24','1st extension'),(4,25,'2019-02-14','2019-11-15',''),(7,34,'2018-11-22','2019-02-08','');

/*Table structure for table `t_framework` */

DROP TABLE IF EXISTS `t_framework`;

CREATE TABLE `t_framework` (
  `Framework_Id` int(10) NOT NULL AUTO_INCREMENT,
  `Framework` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`Framework_Id`),
  KEY `Framework_Id` (`Framework_Id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;

/*Data for the table `t_framework` */

insert  into `t_framework`(`Framework_Id`,`Framework`) values (1,'Accelerated Economic Growth'),(2,'Improved Governance, Peace and Security'),(3,'Enhanced Quality of Education and Delivery of Social Services'),(4,'Environmental Sustainability'),(5,'Others');

/*Table structure for table `t_gender` */

DROP TABLE IF EXISTS `t_gender`;

CREATE TABLE `t_gender` (
  `sex_id` smallint(5) NOT NULL,
  `sex_desc` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`sex_id`),
  KEY `Sex_Id` (`sex_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `t_gender` */

insert  into `t_gender`(`sex_id`,`sex_desc`) values (1,'Male'),(2,'Female');

/*Table structure for table `t_host_org` */

DROP TABLE IF EXISTS `t_host_org`;

CREATE TABLE `t_host_org` (
  `host_org_id` int(10) NOT NULL AUTO_INCREMENT,
  `host_org` varchar(255) DEFAULT NULL,
  `host_org_type_id` int(10) DEFAULT NULL,
  `host_org_type_sub_id` int(10) DEFAULT NULL,
  `head_name` varchar(50) DEFAULT NULL,
  `title` varchar(50) DEFAULT NULL,
  `Address1` varchar(50) DEFAULT NULL,
  `Address2` varchar(50) DEFAULT NULL,
  `mun_city` varchar(50) DEFAULT NULL,
  `prov_id` int(10) DEFAULT NULL,
  `region_id` int(10) DEFAULT NULL,
  `tel_number1` varchar(25) DEFAULT NULL,
  `tel_number2` varchar(25) DEFAULT NULL,
  `fax_number` varchar(25) DEFAULT NULL,
  `email` varchar(50) DEFAULT NULL,
  `website` varchar(30) DEFAULT NULL,
  `Mandate` text DEFAULT NULL,
  `Date_entry` datetime DEFAULT NULL,
  `isActive` int(5) DEFAULT NULL,
  PRIMARY KEY (`host_org_id`),
  KEY `host_org_type_sub_id` (`host_org_type_sub_id`),
  KEY `HostOrganization` (`host_org`),
  KEY `prov_id` (`prov_id`),
  KEY `region_id` (`region_id`)
) ENGINE=InnoDB AUTO_INCREMENT=3034 DEFAULT CHARSET=utf8;

/*Data for the table `t_host_org` */

insert  into `t_host_org`(`host_org_id`,`host_org`,`host_org_type_id`,`host_org_type_sub_id`,`head_name`,`title`,`Address1`,`Address2`,`mun_city`,`prov_id`,`region_id`,`tel_number1`,`tel_number2`,`fax_number`,`email`,`website`,`Mandate`,`Date_entry`,`isActive`) values (1,'Baguio Water District',3,24,'Head Name','Crdinatr','001','Vicente St','Baguio City',71,14,'564-1233-33','123-123-312(02)','123-9091-1','email@email.com','www.webiste.com','hep hep horaay','2018-09-27 00:00:00',1),(3,'Rotary Club of Vigan',1,17,'n/a','n/a','District 7390','Quezon Ave','Vigan',54,10,'00','00','00','00','00','hep hep horay','2018-09-09 00:00:00',1),(4,'Community and Family Services International',1,17,'Mr. Vladimir Hernandez','Director for Philippine Program','2/F Torres Building','2442 Park Avenue','Pasay City',79,15,'02-510-1045/1043','0123','02-551-2225','headquarters@cfsi.ph','www.cfsi.ph','CFSI is a humanitarian organization committed to peace and social development, with a particular interest in the psychosocial dimension. The purpose of CFSI is rebuilding lives with a vision of diverse people living together in dignity, peace and harmony. Based in the Philippines, CFSI works internationally primarily but not exclusively in the Asia and Pacific Region\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n','2018-09-09 00:00:00',1),(5,'Negros Forests And Ecological Foundation Inc',2,1,'Mr. Gerardo L. Ledesma','Chairman','NFEFI Compound1','South Capitol Road1','Bacolod City1',59,12,'034-433-92341','123-0345-433','034-433-92341','nfefi@mozcom.com','1','hep hep hoooray!11','2018-09-09 00:00:00',1),(6,'Notre Dame University-Cotabato',4,4,'Fr. Ramon Ma. G. Bernabe','President','007','Notre Dame Avenue 9600','Cotabato City',13,3,'064-421-8879','','064-421-4312','ndupeacecenter@yahoo.com','','Promote and institutionalize a culture of peace in Mindanao','2018-09-09 00:00:00',1),(7,'Municipal Government of San Jose de Buenavista, Antique',2,2,'Hon. Rony L. Molina','Municipal Mayor','0312','Municipal Hall','San Jose de Buenavista',6,2,'0365407079','00','036-5408202','lgu_sjdb_antique@yahoo.com','n/a','','2018-09-09 00:00:00',1),(8,'Phil-Australian Project in Basic Education',4,4,'','','EDPITAF Bldg.,','DECS','Pasig City',79,15,'','','','','','test','2018-09-09 00:00:00',1),(9,'Municipal Government of Altavas,Aklan',3,6,'Hon. Denny Repor','Municipal Mayor','','','Altavas',38,7,'036-269-1059','','','altavas_aklan@yahoo.com','','','2018-09-09 00:00:00',1),(10,'Provincial Government of Bohol',4,4,'Atty. Edgardo M. Chatto','Governor','The Governor\'s Mansion','Carlos P. Garcia Avenue','Tagbilaran City',38,7,'038-501-9186','','038-412-3666','boholtourismoffice @yahoo.com','http://www.bohol.gov.ph','The proceedings of the first Environment Summit in the province of Bohol, marked the beginnings of the Bohol Environment Management Office (BEMO).  After the summit, the Environment Code of the Province\r\nof Bohol was created and finally adopted by virtue of the Provincial Ordinance No. 1, series of 1998, an ordinance adopting the Bohol Environment Code of 1998.  BEMO steers the implementation of the \r\nEnvironment Code guided by the provisions of the Code.  \r\nBohol\'s vision is to become an eco-cultural tourist destination \r\nand an agro-industrialized province.','2018-09-09 00:00:00',1),(11,'Kanlungan Center Foundation',2,1,'','','77','K-10 corner KJ','Quezon City',79,15,'','','','','','','2018-09-09 00:00:00',1),(12,'Alliance of Philippine Partners in Enterprise Development',3,6,'','','Unit A, 157 K-6th St.','East Kamias','Quezon City',79,15,'','','','','','','2018-09-09 00:00:00',1),(13,'Department of Education-Pasig',4,4,'Ms. Mirla R. Olores','Chief, Special Education Division','DepEd Complex','Meralco Avenue','Pasig City',79,15,'02-633-7237','','02-638-8638','sped_bee.deped@yahoo.com','http://www.deped.gov.ph','Delivery of quality education to all children with special needs.','2018-09-09 00:00:00',1),(14,'World Vision Development Foundation, Inc.',1,26,'Rommel Fuerte','Executive Director',NULL,'389 Quezon Ave. Cor. West 6th St. West Triangle,','Quezon City',79,15,'372-7777',NULL,NULL,'rommel_fuerte@wvi.org','www.worldvision.org.ph','World Vision is an international partnership of Christmas whose mission is to follow or Lord and Savior Jesus Christ in working with the poor and depressed to promote human transformation, seek justice, and bear witness to the good news of the kingdom of God\r\n\r\nNote: Documents Submitted: Copy of SEC Registration dated 7/12/1995; set of docs. On Amended Articles of Inc., and Amended By-Laws.','2018-09-09 00:00:00',1),(15,'University of St. La Salle - Bacolod',1,5,NULL,NULL,NULL,NULL,'Bacolod City',36,6,NULL,NULL,NULL,NULL,NULL,NULL,'2018-09-09 00:00:00',1),(16,'Kabalikat Para sa Maunlad na Buhay, Inc.',1,8,NULL,NULL,NULL,NULL,'Valenzuela City',79,15,NULL,NULL,NULL,NULL,NULL,NULL,'2018-09-09 00:00:00',1),(17,'Brent International School-Baguio',4,5,'','','78','Brent Road','Baguio City',71,14,'','','','','','','2018-09-09 00:00:00',1),(18,'Tarlac Training Center',1,8,'Mr. Jeciel Severino','Technical Training Officer','Central Azucarera de Tarlac','San Miguel','Tarlac City',14,3,NULL,NULL,NULL,NULL,NULL,NULL,'2018-09-09 00:00:00',1),(19,'Federation of Multi-sectoral Alliance for Development-Negros (MU-AD-NEGROS), Inc.',1,8,'Mr. Reynic S. Alo','Executive Director','Farmers Marketing Center','Circumferential Road, Alijis','Bacolod City',36,6,'446-7503',NULL,'446-7503','muad_neg@yahoo.com',NULL,'MUAD shall promote development programs and services to its members and covered communities for proverty alleviation.\r\nSpecifically shall implement the Rural Enterprise Advancement Program as banner initiative with education, environment and effective governance and linkages as supporting programs\r\n\r\nNotes: Docs. Submitted: SEC Registration with Reg. No. I000914 dated 1/26/1990 from Iloilo Extension Office, Iloilo City; Amended Articles of Inc. & Amended Contitution and By-Laws.','2018-09-09 00:00:00',1),(20,'University of the Philippines - Cebu',1,4,NULL,NULL,'Cebu College','Lahug','Cebu City',39,7,NULL,NULL,NULL,NULL,NULL,NULL,'2018-09-09 00:00:00',1),(21,'City Government of Cebu',1,3,'Hon. Tomas R. Osmeña','City Mayor','12','M.C. Briones Street','Cebu City',39,7,'032-253-6348','','032-253-7558','','www.cebucity.gov.ph','','2018-09-09 00:00:00',1),(22,'Salesian Society of St. John Bosco-South',1,5,'Fr. Patrick Buzon, SDB','Provincial Superior','Don Bosco Provinciate','Maryville Subdivision','Talamban',39,7,NULL,NULL,NULL,NULL,NULL,NULL,'2018-09-09 00:00:00',1),(23,'Western Visayas College of Science and Technology',1,4,'Dr. Renato V. Alba','President','Burgos Street','La Paz','Iloilo City',35,6,'0333206634',NULL,'0333294274','wvcst@stealth.iloilo.net','http://www.wvcst.edu.ph',NULL,'2018-09-09 00:00:00',1),(25,'Furniture Industry Board Foundation',1,8,NULL,NULL,'UnitH 9/F Strate 100, Emerald Ave.',NULL,'Pasig City',79,15,NULL,NULL,NULL,NULL,NULL,NULL,'2018-09-09 00:00:00',1),(26,'Bataan Polytechnic State College',1,4,'Dr. Delfin O. Magpantay','President',NULL,'Capitol Drive','Balanga',10,3,'047-237-2350',NULL,'047-237-2350','batpolstatecol@yahoo.com.ph','http://bpsc.edu.ph','To provide higher, professional, technical and special instruction and promote technological studies and scientific researches, advanced studies and progressive leadership in industrial technology, education, engineering science, arts and humanities and other fields which may be relevant','2018-09-09 00:00:00',1),(27,'St. Catherine Family Helper Project, Inc.',1,6,'Mr. Albert C. Aquino','Executive Director','L. Rovira St.','Bantayan','Dumaguete City',40,7,'0352251643','','0352251643','scfhpi@mozcom.com','','To promote and organize community and citizens action for the welfare and well-being of individual families by engaging in simple, understandable, practical and pertinent projects and activities which will redound to the spiritual, economic, social, physical and mental well-being of the members and the community.','2018-09-09 00:00:00',1),(28,'PROCESS-Bohol',1,8,'Ms. Emilia Roslinda','Executive Director',NULL,'Purok 5, Esabo Road, Tiptip District','Tagbilaran City',38,7,'038-510-8255','038-416-0067',NULL,'executivedirector@processbohol.org',NULL,'To improve the living conditions of marginalized fisherfolks and farmers thru participatory research, organization of communities and education and training towards s sustainable use of the natural resources','2018-09-09 00:00:00',1),(30,'Technical Education and Skills Development Authority-Regional Office No. 7',1,7,'Ms. Rosanna A. Urdaneta','Regional Director','','Arch. Reyes Avenue','Cebu City',39,17,'032-4127267','','032-4168876','rtcvii@yahoo.com','','','2018-09-09 00:00:00',1),(31,'Provincial Government of Guimaras',2,1,'Hon. Felipe Hilan A. Nava','Provincial Governor','','','Jordan',37,6,'(063) 237-1394','','(063) 237-1394','galiagualberto@yahoo.com','','','2018-09-09 00:00:00',1),(32,'Provincial Government of Leyte',2,1,'Hon. Leopoldo Dominico L. Petilla','Provincial Governor','','Provincial Capitol','Tacloban City',45,8,'053-3214927','','0533255156','leyteprovince@leyte.org.ph','','','2018-09-09 00:00:00',1),(34,'Department of Agriculture-Bohol',1,17,NULL,NULL,NULL,NULL,'Bohol',38,7,NULL,NULL,NULL,NULL,NULL,NULL,'2018-09-09 00:00:00',1),(35,'German Development Service',3,8,'','','','','Makati City',79,15,'','','','','','','2018-09-09 00:00:00',1),(36,'Guimaras Polytechnic College',1,4,'Dr. Sofronio Dignomo','Vocational Superintendent',NULL,NULL,'Buenavista',37,6,NULL,NULL,NULL,NULL,NULL,NULL,'2018-09-09 00:00:00',1),(37,'Eduardo Aboitiz Development Studies Center',1,8,NULL,NULL,NULL,NULL,'Cebu City',39,7,NULL,NULL,NULL,NULL,NULL,NULL,'2018-09-09 00:00:00',1),(38,'Mary Help of Christians School, Inc.-Pampanga',1,5,'Sr. Aurora C. Roble','Head',NULL,'Mabiga','Mabalacat',13,3,NULL,NULL,NULL,NULL,NULL,NULL,'2018-09-09 00:00:00',1),(39,'Pablo Borbon Memorial Institute of Technology',1,4,NULL,NULL,NULL,NULL,'Batangas City',17,4,NULL,NULL,NULL,NULL,NULL,NULL,'2018-09-09 00:00:00',1),(41,'Ting Matiao Foundation',1,8,NULL,NULL,NULL,NULL,'Dumaguete City',40,7,NULL,NULL,NULL,NULL,NULL,NULL,'2018-09-09 00:00:00',1),(42,'Institute for Small Business, Inc.',1,8,NULL,NULL,NULL,NULL,'Tacloban City',45,8,NULL,NULL,NULL,NULL,NULL,NULL,'2018-09-09 00:00:00',1),(43,'Municipal Government of Naval Biliran',1,2,'Hon. Susan V. Parilla','Municipal Mayor','','Municipal Building','Naval',42,8,'053-5009371','','053-5009405','','','','2018-09-09 00:00:00',1),(44,'Provincial Government of Negros Oriental',1,1,'Hon. Roel R. Degamo','Provincial Governor',NULL,NULL,'Dumaguete City',40,7,'035-225-5563','035-225-1601','035-225-5563','enrd_negor@yahoo.com',NULL,'ro provide skills training on TESDA Technical-Vocational Education Training (TVET) Programs.','2018-09-09 00:00:00',0),(45,'Clark Development Corporation',1,17,NULL,NULL,NULL,NULL,'Pampanga',13,3,NULL,NULL,NULL,NULL,NULL,NULL,'2018-09-09 00:00:00',0),(46,'Angeles City National Trade School',1,4,'Ms. Aida T. Galura','Vocational School Administrator',NULL,'Friendship Hi-way, Sunset Valley, Cutcut','Angeles City',13,3,'045-887-4188',NULL,'045-887-4188','aidagalura@yahoo.com',NULL,'Provide every graduate quality technical-vocational education and training that will make them self-reliant, productive and responsible citizen','2018-09-09 00:00:00',0),(48,'Wood Producers Association of Cebu',1,8,NULL,NULL,'104 WDC Bldg.,','Osmeña Blvd.,','Cebu City',39,7,NULL,NULL,NULL,NULL,NULL,NULL,'2018-09-09 00:00:00',0),(49,'Ramon Magsaysay Technological University-Ramon Magsaysay Polytechnic College',1,4,'Cornelio C. Garcia, Ph D','University President',NULL,NULL,'Iba',15,3,'0478111683',NULL,'0478111683','rmtupresident@yahoo.com','rmtu.edu.ph','Instruction, research, extension, and production','2018-09-09 00:00:00',0),(50,'Marcelino Veloso Polytechnic College',1,4,NULL,NULL,NULL,'Otabon','Tabango',45,8,'053-5519014',NULL,'053-551-9014',NULL,NULL,NULL,'2018-09-09 00:00:00',0),(3028,'San Jose Koop',3,19,'Ronnie Chy','CEO','','','',11,3,'','','','','','','2018-11-09 00:00:00',1),(3029,'test',1,17,'','','','','',1,1,'','','','','','','2018-11-13 00:00:00',0),(3030,'LPI-San Jose',3,24,'Gaik Karrem','Coordinator','123','San Jose','City',12,3,'5445-54212-12','45687-45645-456-45','12312-129823-44325','.com','.com','','2018-11-21 15:38:39',1),(3032,'test 3032',1,17,'','','','','',1,1,'','','','','','','2018-11-26 11:35:34',0),(3033,'Test',1,17,'','','','','',1,1,'','','','','','','2018-11-29 14:02:19',0);

/*Table structure for table `t_host_org_type` */

DROP TABLE IF EXISTS `t_host_org_type`;

CREATE TABLE `t_host_org_type` (
  `host_org_type_id` int(10) NOT NULL AUTO_INCREMENT,
  `host_org_type` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`host_org_type_id`),
  KEY `ID_HOST_DESC` (`host_org_type`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8;

/*Data for the table `t_host_org_type` */

insert  into `t_host_org_type`(`host_org_type_id`,`host_org_type`) values (4,'Academic Institutions'),(5,'Government-Owned & Controlled Corporation'),(2,'Local Government Unit'),(1,'National Government Agency'),(3,'Non-Government Organization'),(6,'Others'),(14,'test');

/*Table structure for table `t_host_org_type_sub` */

DROP TABLE IF EXISTS `t_host_org_type_sub`;

CREATE TABLE `t_host_org_type_sub` (
  `host_org_type_sub_id` int(10) NOT NULL AUTO_INCREMENT,
  `host_org_type_id` int(10) DEFAULT NULL,
  `host_org_type_sub` varchar(50) DEFAULT NULL,
  `isNGO` int(10) DEFAULT NULL,
  PRIMARY KEY (`host_org_type_sub_id`),
  KEY `host_org_type_id` (`host_org_type_id`),
  KEY `org_type_sub_id` (`host_org_type_sub_id`)
) ENGINE=InnoDB AUTO_INCREMENT=43 DEFAULT CHARSET=utf8;

/*Data for the table `t_host_org_type_sub` */

insert  into `t_host_org_type_sub`(`host_org_type_sub_id`,`host_org_type_id`,`host_org_type_sub`,`isNGO`) values (1,2,'Provincial Government',0),(2,2,'Municipal Government',0),(3,2,'City Government',0),(4,4,'Public',0),(5,4,'Private',0),(6,3,'Civic/Cause Oriented',1),(7,3,'Faith_based',1),(8,3,'Community-based/Peoples\' Org.',1),(9,3,'International Org.',1),(17,1,'National Government Agency',0),(18,3,'Tri-Sectoral: Gov\'t., Business, Private',1),(19,3,'Non-Sectarian',1),(20,3,'Social Development',1),(21,3,'Corporate Foundation',1),(22,3,'Development NGO',1),(23,3,'Business Support Organization',1),(24,3,'Industry Association',1),(25,3,'Technical Cooperation',1),(26,3,'Others',1),(27,3,'Community Based Rehabilitation',1),(28,2,'Barangay Government',0),(29,5,'n/a',0),(30,3,'Foundation',1),(33,6,'Humanitarian Organization Auxiliary to the Gov\'t.',0),(34,6,'n/a',0),(42,14,'test',1);

/*Table structure for table `t_island` */

DROP TABLE IF EXISTS `t_island`;

CREATE TABLE `t_island` (
  `island_name` varchar(50) DEFAULT NULL,
  `island_id` int(10) NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`island_id`),
  KEY `island_id` (`island_id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

/*Data for the table `t_island` */

insert  into `t_island`(`island_name`,`island_id`) values ('Luzon',1),('Visayas',2),('Mindanao',3);

/*Table structure for table `t_login` */

DROP TABLE IF EXISTS `t_login`;

CREATE TABLE `t_login` (
  `ID` int(24) NOT NULL AUTO_INCREMENT,
  `login_userName` varchar(255) DEFAULT NULL,
  `login_password` varchar(255) DEFAULT NULL,
  `userLevel` int(10) NOT NULL,
  `login_name` varchar(255) NOT NULL,
  `secret_question` varchar(255) DEFAULT NULL,
  `secret_answer` varchar(255) DEFAULT NULL,
  `hint` varchar(255) DEFAULT NULL,
  `isActive` int(10) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=latin1;

/*Data for the table `t_login` */

insert  into `t_login`(`ID`,`login_userName`,`login_password`,`userLevel`,`login_name`,`secret_question`,`secret_answer`,`hint`,`isActive`) values (1,'admin','238218CCEAC5952373B1',2,'admin','what is your pet\'s name ?','awit','wit',1),(2,'user1','238218CCEA92',2,'Johnny Thor','awit','awit','awit',1),(3,'user2','238218CCEAF0',1,'Kalad kare','awit','awit','awit',1),(4,'user3','238218CCEAA0',1,'Kareem abdul jabaar','awit','awit','awit',1),(5,'awit','23080D4042',1,'pnvsca@User','awit','awit','awit',1),(6,'Ang','23FDFBB83471D9853D',1,'Malou Ang','what is your name ?','awit','awit',1),(7,'awit2','23080D4042EA',1,'pnvsca@User','what is the smallest particle ?','atom?','?',1);

/*Table structure for table `t_logs` */

DROP TABLE IF EXISTS `t_logs`;

CREATE TABLE `t_logs` (
  `id` int(10) NOT NULL AUTO_INCREMENT,
  `account_name` varchar(255) DEFAULT NULL,
  `log_action` varchar(255) DEFAULT NULL,
  `log_date` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=1235 DEFAULT CHARSET=latin1;

/*Data for the table `t_logs` */

insert  into `t_logs`(`id`,`account_name`,`log_action`,`log_date`) values (1,'Johnny Thor','Log in','2018-11-21 11:27:00'),(2,'Johnny Thor','Updated a Sector id 4','2018-11-21 11:27:11'),(3,'Johnny Thor','Updated a Specialization id 5','2018-11-21 11:27:14'),(4,'Johnny Thor','Deleted LPI id 50','2018-11-21 11:27:43'),(5,'Johnny Thor','Log in','2018-11-21 11:28:48'),(6,'Johnny Thor','Deleted LPI id 50','2018-11-21 11:29:19'),(7,'Johnny Thor','Log in','2018-11-21 11:31:39'),(8,'Johnny Thor','Added a Project in LPI id 8','2018-11-21 11:32:43'),(9,'Johnny Thor','Log in','2018-11-21 11:36:41'),(10,'Johnny Thor','Updated LPI id 5','2018-11-21 11:36:53'),(11,'Johnny Thor','Log in','2018-11-21 11:44:46'),(12,'Johnny Thor','Updated Request sub ID  29','2018-11-21 11:45:07'),(13,'Johnny Thor','Updated Request ID  18-0005','2018-11-21 11:45:11'),(14,'Johnny Thor','Updated Request ID  18-0005','2018-11-21 11:45:15'),(15,'Johnny Thor','Log in','2018-11-21 13:10:19'),(16,'Johnny Thor','Log in','2018-11-21 13:12:44'),(17,'Johnny Thor','Restore Request sub ID  36','2018-11-21 13:12:55'),(18,'Johnny Thor','Log in','2018-11-21 13:17:14'),(19,'Johnny Thor','Log in','2018-11-21 13:19:19'),(20,'Johnny Thor','Log in','2018-11-21 13:23:25'),(21,'Johnny Thor','Log in','2018-11-21 13:27:51'),(22,'Johnny Thor','Log in','2018-11-21 13:28:37'),(23,'Johnny Thor','Log in','2018-11-21 13:30:07'),(24,'Johnny Thor','Log in','2018-11-21 13:32:18'),(25,'Johnny Thor','Log in','2018-11-21 13:35:33'),(26,'Johnny Thor','Log in','2018-11-21 14:03:32'),(27,'Johnny Thor','Log in','2018-11-21 14:06:30'),(28,'Johnny Thor','Log in','2018-11-21 14:07:44'),(29,'Johnny Thor','Log in','2018-11-21 14:09:39'),(30,'Johnny Thor','Updated Request ID  18-0005','2018-11-21 14:09:45'),(31,'Johnny Thor','Updated Request sub ID  30','2018-11-21 14:13:41'),(32,'Johnny Thor','Updated Volunteer id 12-0001','2018-11-21 14:14:13'),(33,'Johnny Thor','Log in','2018-11-21 14:15:38'),(34,'Johnny Thor','Log in','2018-11-21 14:16:22'),(35,'Johnny Thor','Log in','2018-11-21 14:24:19'),(36,'Johnny Thor','Log in','2018-11-21 14:43:14'),(37,'Johnny Thor','Log in','2018-11-21 15:34:54'),(38,'Johnny Thor','added Volunteer','2018-11-21 15:36:43'),(39,'Johnny Thor','Added a LPI','2018-11-21 15:38:39'),(40,'Johnny Thor','Updated LPI id 3030','2018-11-21 15:38:49'),(41,'Johnny Thor','Added a Project in LPI id 3030','2018-11-21 15:41:02'),(42,'Johnny Thor','Updated a Project id 7191','2018-11-21 15:41:11'),(43,'Johnny Thor','Added Request id ','2018-11-21 15:42:08'),(44,'Johnny Thor','Added Request sub of request ID 34','2018-11-21 15:42:21'),(45,'Johnny Thor','Log in','2018-11-21 15:44:00'),(46,'Johnny Thor','Log in','2018-11-21 15:44:36'),(47,'Johnny Thor','Log in','2018-11-21 15:47:30'),(48,'Johnny Thor','Updated Request ID  18-0001','2018-11-21 15:47:57'),(49,'Johnny Thor','Log in','2018-11-21 15:49:02'),(50,'Johnny Thor','Updated Request ID  18-0009','2018-11-21 15:49:06'),(51,'Johnny Thor','Updated Request ID  18-0017','2018-11-21 15:49:22'),(52,'Johnny Thor','Log in','2018-11-21 15:50:45'),(53,'Johnny Thor','Log in','2018-11-21 15:51:21'),(54,'Johnny Thor','Log in','2018-11-21 15:52:05'),(55,'Johnny Thor','Log in','2018-11-21 15:54:10'),(56,'Johnny Thor','Log in','2018-11-21 16:05:27'),(57,'Johnny Thor','Added Request sub of request ID 34','2018-11-21 16:05:47'),(58,'Johnny Thor','Updated Request sub ID  39','2018-11-21 16:05:59'),(59,'Johnny Thor','Log in','2018-11-21 16:06:12'),(60,'Johnny Thor','Updated Request sub ID  39','2018-11-21 16:06:17'),(61,'Johnny Thor','Log in','2018-11-21 16:07:13'),(62,'Johnny Thor','Updated Request sub ID  39','2018-11-21 16:07:25'),(63,'Johnny Thor','Updated Request ID  18-0017','2018-11-21 16:07:39'),(64,'Johnny Thor','Updated Request sub ID  39','2018-11-21 16:07:47'),(65,'Johnny Thor','Log in','2018-11-21 16:08:17'),(66,'Johnny Thor','Updated Request sub ID  40','2018-11-21 16:08:22'),(67,'Johnny Thor','Log in','2018-11-21 16:11:31'),(68,'Johnny Thor','Log in','2018-11-21 16:11:57'),(69,'Johnny Thor','Updated Request sub ID  38','2018-11-21 16:12:46'),(70,'Johnny Thor','Updated Request sub ID  38','2018-11-21 16:12:56'),(71,'Johnny Thor','Log in','2018-11-21 16:23:02'),(72,'Johnny Thor','Updated Request sub ID  39','2018-11-21 16:23:17'),(73,'Johnny Thor','Updated Request sub ID  40','2018-11-21 16:23:19'),(74,'Johnny Thor','Updated Request ID  18-0017','2018-11-21 16:25:34'),(75,'Johnny Thor','Log in','2018-11-22 08:09:35'),(76,'Johnny Thor','Updated Request sub ID  34','2018-11-22 08:09:43'),(77,'Johnny Thor','Updated Request sub ID  34','2018-11-22 08:09:58'),(78,'Johnny Thor','Updated Request sub ID  34','2018-11-22 08:29:50'),(79,'Johnny Thor','Updated Request sub ID  34','2018-11-22 08:31:12'),(80,'Johnny Thor','Log in','2018-11-22 08:41:38'),(81,'Johnny Thor','Updated Request sub ID  40','2018-11-22 08:43:48'),(82,'Johnny Thor','Log in','2018-11-22 08:55:03'),(83,'Johnny Thor','Log in','2018-11-22 09:26:59'),(84,'Johnny Thor','Log in','2018-11-22 10:07:18'),(85,'Johnny Thor','Updated Volunteer id 17-0003','2018-11-22 10:07:34'),(86,'Johnny Thor','Updated his/her own account  ','2018-11-22 10:12:09'),(87,'Johnny Thor','added Volunteer','2018-11-22 10:14:05'),(88,'Johnny Thor','Updated Volunteer id 18-0012','2018-11-22 10:14:25'),(89,'Johnny Thor','Log in','2018-11-22 10:26:47'),(90,'Johnny Thor','Log in','2018-11-22 10:28:39'),(91,'Johnny Thor','Deleted Request ID  18-0011','2018-11-22 10:29:45'),(92,'Johnny Thor','Deleted Request sub permanently ID  36','2018-11-22 10:30:40'),(93,'Johnny Thor','Log in','2018-11-22 10:32:41'),(94,'Johnny Thor','Deleted Request ID  18-0017','2018-11-22 10:33:02'),(95,'Johnny Thor','Deleted Request sub permanently ID  39','2018-11-22 10:33:16'),(96,'Johnny Thor','Log in','2018-11-22 10:36:10'),(97,'Johnny Thor','Log in','2018-11-22 10:40:16'),(98,'Johnny Thor','Log in','2018-11-22 11:03:19'),(99,'Johnny Thor','Updated LPI id 5','2018-11-22 11:03:40'),(100,'Johnny Thor','Updated a Project id 4','2018-11-22 11:04:35'),(101,'Johnny Thor','Log in','2018-11-22 13:44:46'),(102,'Johnny Thor','Updated LPI id 11','2018-11-22 13:45:39'),(103,'Johnny Thor','Updated LPI id 11','2018-11-22 13:45:44'),(104,'Johnny Thor','Updated Volunteer id 18-0003','2018-11-22 14:08:49'),(105,'Johnny Thor','Updated LPI id 21','2018-11-22 14:17:10'),(106,'Johnny Thor','Log in','2018-11-22 14:20:49'),(107,'Johnny Thor','Log in','2018-11-22 15:04:36'),(108,'Johnny Thor','Log in','2018-11-22 15:05:37'),(109,'Johnny Thor','Log in','2018-11-22 15:12:09'),(110,'Johnny Thor','Log in','2018-11-22 15:26:23'),(111,'Johnny Thor','Log in','2018-11-22 15:35:32'),(112,'Johnny Thor','Updated Volunteer id 17-0005','2018-11-22 15:35:49'),(113,'Johnny Thor','Updated Volunteer id 18-0006','2018-11-22 15:36:15'),(114,'admin','Log in','2018-11-22 15:37:07'),(115,'3r15M15c@l@','Log in','2018-11-22 15:38:32'),(116,'3r15M15c@l@','Updated LPI id 5','2018-11-22 15:38:57'),(117,'3r15M15c@l@','Updated LPI id 1','2018-11-22 15:39:03'),(118,'3r15M15c@l@','Updated Volunteer id 17-0005','2018-11-22 15:39:15'),(119,'3r15M15c@l@','Updated Request ID  18-0010','2018-11-22 15:39:24'),(120,'3r15M15c@l@','Updated Request sub ID  29','2018-11-22 15:39:32'),(121,'3r15M15c@l@','Updated a Project id 3','2018-11-22 15:39:54'),(122,'3r15M15c@l@','Updated Volunteer id 17-0002','2018-11-22 15:40:16'),(123,'3r15M15c@l@','Added a LPI','2018-11-22 15:41:11'),(124,'admin','Log in','2018-11-22 15:41:56'),(125,'admin','Deleted LPI id 3031','2018-11-22 15:43:21'),(126,'admin','Log in','2018-11-22 16:04:54'),(127,'Johnny Thor','Log in','2018-11-22 16:05:02'),(128,'admin','Updated LPI id 4','2018-11-22 16:05:39'),(129,'admin','Updated LPI id 5','2018-11-22 16:05:49'),(130,'admin','Updated Volunteer id 18-0003','2018-11-22 16:06:00'),(131,'Johnny Thor','Log in','2018-11-22 16:06:27'),(132,'Johnny Thor','Updated Volunteer id 17-0004','2018-11-22 16:06:36'),(133,'Kareem abdul jabaar','Log in','2018-11-22 16:06:46'),(134,'user3','Recover his/her account ','2018-11-22 16:07:20'),(135,'Johnny Thor','Log in','2018-11-22 16:09:21'),(136,'Johnny Thor','Log in','2018-11-22 16:14:24'),(137,'Johnny Thor','Log in','2018-11-22 16:14:32'),(138,'admin','Log in','2018-11-22 16:14:40'),(139,'admin','Log in','2018-11-22 16:16:01'),(140,'Johnny Thor','Log in','2018-11-22 16:16:46'),(141,'Johnny Thor','Log in','2018-11-22 16:20:05'),(142,'Johnny Thor','Log in','2018-11-22 16:21:32'),(143,'Johnny Thor','Log in','2018-11-22 16:21:52'),(144,'Johnny Thor','Log in','2018-11-22 16:22:22'),(145,'Johnny Thor','Log in','2018-11-22 16:22:38'),(146,'Johnny Thor','Log in','2018-11-22 16:22:52'),(147,'Johnny Thor','Log in','2018-11-22 16:23:16'),(148,'Johnny Thor','Log in','2018-11-22 16:23:35'),(149,'Johnny Thor','Log in','2018-11-22 16:23:48'),(150,'Johnny Thor','Log in','2018-11-22 16:24:00'),(151,'Johnny Thor','Log in','2018-11-22 16:25:17'),(152,'Johnny Thor','Log in','2018-11-22 16:25:34'),(153,'Johnny Thor','Log in','2018-11-23 08:21:27'),(154,'Johnny Thor','Updated Request sub ID  27','2018-11-23 08:22:28'),(155,'Johnny Thor','Updated Request sub ID  27','2018-11-23 08:22:57'),(156,'Johnny Thor','Log in','2018-11-23 08:24:57'),(157,'Johnny Thor','Log in','2018-11-23 08:25:38'),(158,'Johnny Thor','Updated Request sub ID  27','2018-11-23 08:25:50'),(159,'Johnny Thor','Log in','2018-11-23 08:27:21'),(160,'Johnny Thor','Log in','2018-11-23 08:30:42'),(161,'Johnny Thor','Updated Request sub ID  27','2018-11-23 08:30:51'),(162,'Johnny Thor','Log in','2018-11-23 08:31:10'),(163,'Johnny Thor','Log in','2018-11-23 08:31:42'),(164,'Johnny Thor','Updated Request sub ID  27','2018-11-23 08:31:47'),(165,'Johnny Thor','Log in','2018-11-23 08:32:27'),(166,'Johnny Thor','Log in','2018-11-23 08:33:05'),(167,'Johnny Thor','Log in','2018-11-23 08:34:40'),(168,'Johnny Thor','Updated Request ID  18-0003','2018-11-23 08:35:40'),(169,'Johnny Thor','Updated Request sub ID  27','2018-11-23 08:35:46'),(170,'Johnny Thor','Log in','2018-11-23 08:36:23'),(171,'Johnny Thor','Log in','2018-11-23 08:37:04'),(172,'Johnny Thor','Updated Request sub ID  27','2018-11-23 08:37:15'),(173,'Johnny Thor','Updated Request sub ID  27','2018-11-23 08:37:26'),(174,'Johnny Thor','Log in','2018-11-23 08:38:57'),(175,'Johnny Thor','Updated Request sub ID  27','2018-11-23 08:39:06'),(176,'Johnny Thor','Log in','2018-11-23 08:41:24'),(177,'Johnny Thor','Deleted LPI permanently ID  3031','2018-11-23 08:42:06'),(178,'Johnny Thor','Log in','2018-11-23 08:55:16'),(179,'Johnny Thor','Added Request sub of request ID 20','2018-11-23 08:55:31'),(180,'Johnny Thor','Deleted Request ID  18-0003','2018-11-23 08:55:43'),(181,'Johnny Thor','Updated Request sub ID  27','2018-11-23 08:55:47'),(182,'Johnny Thor','Deleted Request sub permanently ID  41','2018-11-23 08:56:16'),(183,'Johnny Thor','Log in','2018-11-23 14:04:54'),(184,'admin','Log in','2018-11-23 15:50:50'),(185,'admin','Updated Volunteer id 18-0001','2018-11-23 15:51:29'),(186,'Johnny Thor','Log in','2018-11-26 10:11:17'),(187,'Johnny Thor','Updated Volunteer id 17-0006','2018-11-26 10:13:21'),(188,'Johnny Thor','Updated Request ID  18-0001','2018-11-26 10:17:52'),(189,'Johnny Thor','Log in','2018-11-26 10:32:39'),(190,'Johnny Thor','Updated LPI id 8','2018-11-26 10:33:04'),(191,'Johnny Thor','Log in','2018-11-26 11:12:51'),(192,'Johnny Thor','Log in','2018-11-26 11:22:31'),(193,'admin','Log in','2018-11-26 11:23:32'),(194,'Johnny Thor','Updated LPI id 1','2018-11-26 11:23:42'),(195,'Johnny Thor','Updated LPI id 5','2018-11-26 11:23:49'),(196,'Johnny Thor','Updated Request ID  18-0010','2018-11-26 11:24:14'),(197,'Johnny Thor','Updated Request sub ID  29','2018-11-26 11:24:23'),(198,'Johnny Thor','Updated Request ID  18-0013','2018-11-26 11:24:33'),(199,'Johnny Thor','Log in','2018-11-26 11:25:23'),(200,'Johnny Thor','Updated Request ID  18-0010','2018-11-26 11:25:29'),(201,'Johnny Thor','Updated account of User id 3','2018-11-26 11:31:23'),(202,'Johnny Thor','Log in','2018-11-26 11:32:48'),(203,'Johnny Thor','Updated account of Username user3','2018-11-26 11:32:57'),(204,'Johnny Thor','Updated account of Username user2','2018-11-26 11:33:12'),(205,'admin','Log in','2018-11-26 11:33:58'),(206,'admin','Updated a Organization type id 2','2018-11-26 11:34:20'),(207,'admin','Updated the account eris','2018-11-26 11:34:46'),(208,'admin','Updated LPI id 5','2018-11-26 11:35:06'),(209,'admin','Added a LPI','2018-11-26 11:35:34'),(210,'admin','Updated LPI id 3032','2018-11-26 11:35:57'),(211,'admin','Added a Project in LPI id 3032','2018-11-26 11:36:13'),(212,'Johnny Thor','Log in','2018-11-26 11:45:13'),(213,'Johnny Thor','Log in','2018-11-26 13:07:19'),(214,'Johnny Thor','Updated Request ID  18-0017','2018-11-26 13:12:12'),(215,'admin','Log in','2018-11-26 13:14:06'),(216,'admin','Log in','2018-11-26 13:20:59'),(217,'Johnny Thor','Log in','2018-11-26 13:22:28'),(218,'Johnny Thor','Log in','2018-11-26 13:22:53'),(219,'3r15M15c@l@','Log in','2018-11-26 13:23:38'),(220,'3r15M15c@l@','Updated his/her own account  ','2018-11-26 13:24:28'),(221,'Malou','Log in','2018-11-26 13:25:21'),(222,'Malou','Log in','2018-11-26 13:32:50'),(223,'Malou','Log in','2018-11-26 13:37:37'),(224,'admin','Log in','2018-11-26 13:37:59'),(225,'admin','Log in','2018-11-26 15:51:25'),(226,'admin','Log in','2018-11-26 16:13:41'),(227,'admin','Updated Volunteer id 18-0004','2018-11-26 16:14:08'),(228,'admin','Log in','2018-11-27 08:42:23'),(229,'admin','Updated Volunteer id 17-0005','2018-11-27 08:43:09'),(230,'admin','Updated Request sub ID  29','2018-11-27 08:45:14'),(231,'admin','Updated Request sub ID  29','2018-11-27 08:45:24'),(232,'admin','Updated Request sub ID  29','2018-11-27 08:45:36'),(233,'admin','Updated Request sub ID  29','2018-11-27 08:46:20'),(234,'admin','Log in','2018-11-27 08:48:29'),(235,'admin','Updated Request sub ID  29','2018-11-27 08:48:48'),(236,'admin','Added Request sub of request ID 24','2018-11-27 08:49:00'),(237,'admin','Deleted Request ID  18-0005','2018-11-27 08:49:06'),(238,'admin','Added Request sub of request ID 24','2018-11-27 08:49:32'),(239,'admin','Log in','2018-11-27 08:50:51'),(240,'admin','Updated Volunteer id 17-0004','2018-11-27 08:50:55'),(241,'admin','Log in','2018-11-27 08:52:50'),(242,'admin','Log in','2018-11-27 08:57:34'),(243,'admin','Log in','2018-11-27 09:02:34'),(244,'admin','Updated Volunteer id 17-0005','2018-11-27 09:02:52'),(245,'admin','Updated Request sub ID  31','2018-11-27 09:06:44'),(246,'admin','Updated Request sub ID  34','2018-11-27 09:07:19'),(247,'admin','added extension of request sub id 34','2018-11-27 09:10:19'),(248,'admin','Updated Request sub ID  34','2018-11-27 09:14:59'),(249,'admin','Updated Request sub ID  34','2018-11-27 09:15:27'),(250,'admin','added extension of request sub id 34','2018-11-27 09:16:27'),(251,'admin','Log in','2018-11-27 09:21:13'),(252,'admin','Updated Request sub ID  34','2018-11-27 09:21:31'),(253,'admin','added extension of request sub id 34','2018-11-27 09:21:52'),(254,'admin','Log in','2018-11-27 09:23:05'),(255,'admin','Log in','2018-11-27 09:36:39'),(256,'admin','Log in','2018-11-27 09:39:41'),(257,'admin','Log in','2018-11-27 09:41:04'),(258,'admin','Log in','2018-11-27 09:41:26'),(259,'admin','Log in','2018-11-27 09:44:59'),(260,'admin','Log in','2018-11-27 09:45:38'),(261,'admin','Log in','2018-11-27 09:46:25'),(262,'admin','Log in','2018-11-27 09:47:37'),(263,'admin','Log in','2018-11-27 09:48:05'),(264,'admin','Log in','2018-11-27 09:48:28'),(265,'admin','Log in','2018-11-27 09:48:51'),(266,'admin','Log in','2018-11-27 09:49:07'),(267,'admin','Log in','2018-11-27 09:49:50'),(268,'admin','Log in','2018-11-27 09:51:07'),(269,'admin','Log in','2018-11-27 09:52:04'),(270,'admin','Log in','2018-11-27 09:52:37'),(271,'admin','Log in','2018-11-27 09:53:23'),(272,'admin','Log in','2018-11-27 09:55:18'),(273,'admin','Log in','2018-11-27 09:56:15'),(274,'admin','Log in','2018-11-27 09:56:30'),(275,'admin','Log in','2018-11-27 09:57:29'),(276,'admin','Log in','2018-11-27 09:57:50'),(277,'admin','Log in','2018-11-27 09:58:40'),(278,'admin','Log in','2018-11-27 09:59:14'),(279,'admin','Log in','2018-11-27 09:59:57'),(280,'admin','Log in','2018-11-27 10:00:20'),(281,'admin','Log in','2018-11-27 10:09:43'),(282,'admin','Log in','2018-11-27 10:12:06'),(283,'admin','Log in','2018-11-27 10:23:33'),(284,'admin','Log in','2018-11-27 10:24:07'),(285,'admin','Log in','2018-11-27 10:25:54'),(286,'admin','Log in','2018-11-27 10:26:40'),(287,'admin','Log in','2018-11-27 10:27:32'),(288,'admin','Added Request sub of request ID 31','2018-11-27 10:27:55'),(289,'admin','Deleted Request ID  18-0014','2018-11-27 10:28:04'),(290,'admin','Log in','2018-11-27 10:28:51'),(291,'admin','Added Request id ','2018-11-27 10:29:45'),(292,'admin','Updated Request ID  18-0018','2018-11-27 10:29:55'),(293,'admin','Added Request sub of request ID 32','2018-11-27 10:30:19'),(294,'admin','Deleted Request ID  18-0015','2018-11-27 10:30:23'),(295,'admin','Added Request sub of request ID 33','2018-11-27 10:30:43'),(296,'admin','Added Request sub of request ID 33','2018-11-27 10:30:48'),(297,'admin','Deleted Request ID  18-0016','2018-11-27 10:30:52'),(298,'admin','Deleted Request ID  18-0016','2018-11-27 10:30:54'),(299,'admin','Log in','2018-11-27 10:31:18'),(300,'admin','Added Request sub of request ID 29','2018-11-27 10:31:29'),(301,'admin','Deleted Request ID  18-0012','2018-11-27 10:31:34'),(302,'admin','Log in','2018-11-27 10:31:56'),(303,'admin','Added Request sub of request ID 35','2018-11-27 10:32:11'),(304,'admin','Deleted Request ID  18-0018','2018-11-27 10:32:14'),(305,'admin','Log in','2018-11-27 10:32:57'),(306,'admin','Deleted Request ID  18-0002','2018-11-27 10:33:05'),(307,'admin','Deleted Request ID  18-0002','2018-11-27 10:33:10'),(308,'admin','Restore Request sub ID  26','2018-11-27 10:33:19'),(309,'admin','Restore Request sub ID  31','2018-11-27 10:33:21'),(310,'admin','Deleted Request ID  18-0002','2018-11-27 10:33:45'),(311,'admin','Log in','2018-11-27 10:38:33'),(312,'admin','Log in','2018-11-27 10:40:00'),(313,'admin','Log in','2018-11-27 10:44:09'),(314,'admin','Log in','2018-11-27 10:46:35'),(315,'admin','Added Request id ','2018-11-27 10:46:57'),(316,'admin','Deleted Request id 12','2018-11-27 10:48:34'),(317,'admin','Log in','2018-11-27 10:49:53'),(318,'admin','Log in','2018-11-27 10:50:35'),(319,'admin','Updated Request ID  18-0010','2018-11-27 10:50:38'),(320,'admin','Updated Request ID  18-0012','2018-11-27 10:51:09'),(321,'admin','Log in','2018-11-27 10:53:43'),(322,'admin','Added Request sub of request ID 29','2018-11-27 10:53:57'),(323,'admin','Deleted Request ID  18-0012','2018-11-27 10:54:03'),(324,'admin','Log in','2018-11-27 11:03:11'),(325,'admin','Log in','2018-11-27 11:05:50'),(326,'admin','Log in','2018-11-27 11:21:06'),(327,'admin','Log in','2018-11-27 12:58:56'),(328,'admin','Log in','2018-11-27 13:13:42'),(329,'admin','Log in','2018-11-27 13:14:01'),(330,'Kareem abdul jabaar','Log in','2018-11-27 13:14:35'),(331,'Kareem abdul jabaar','Updated LPI id 5','2018-11-27 13:14:41'),(332,'Kareem abdul jabaar','Updated LPI id 6','2018-11-27 13:15:05'),(333,'Kareem abdul jabaar','Updated Request ID  18-0013','2018-11-27 13:15:11'),(334,'Kareem abdul jabaar','Updated Request sub ID  38','2018-11-27 13:15:22'),(335,'admin','Log in','2018-11-27 13:18:32'),(336,'admin','Log in','2018-11-27 13:20:43'),(337,'admin','Log in','2018-11-27 13:48:10'),(338,'admin','Added Request sub of request ID 20','2018-11-27 13:48:44'),(339,'admin','Updated Request ID  18-0003','2018-11-27 13:48:55'),(340,'admin','Updated Request sub ID  51','2018-11-27 13:49:18'),(341,'admin','Updated Request sub ID  51','2018-11-27 13:49:26'),(342,'admin','Updated a Specialization sub id 27','2018-11-27 13:53:41'),(343,'admin','Updated a Specialization id 107','2018-11-27 13:54:07'),(344,'admin','Log in','2018-11-27 14:07:28'),(345,'admin','Log in','2018-11-27 14:07:42'),(346,'Johnny Thor','Log in','2018-11-27 14:08:27'),(347,'admin','Log in','2018-11-27 14:08:43'),(348,'admin','Log in','2018-11-27 14:09:11'),(349,'admin','Log in','2018-11-27 14:09:20'),(350,'Johnny Thor','Log in','2018-11-27 14:09:38'),(351,'admin','Log in','2018-11-27 14:10:07'),(352,'admin','Log in','2018-11-27 14:10:18'),(353,'admin','Log in','2018-11-27 14:10:30'),(354,'admin','Log in','2018-11-27 14:11:24'),(355,'admin','Log in','2018-11-27 14:21:16'),(356,'admin','Log in','2018-11-27 14:21:24'),(357,'admin','Log in','2018-11-27 15:00:29'),(358,'admin','Log in','2018-11-27 15:00:42'),(359,'admin','Log in','2018-11-27 15:03:29'),(360,'admin','Updated Request sub ID  34','2018-11-27 15:04:03'),(361,'admin','Log in','2018-11-27 15:46:55'),(362,'admin','Log in','2018-11-28 08:18:06'),(363,'admin','Log in','2018-11-28 08:27:57'),(364,'admin','Log in','2018-11-28 08:33:50'),(365,'admin','Updated a Project id 11','2018-11-28 08:34:55'),(366,'admin','Updated Request ID  18-0016','2018-11-28 08:35:37'),(367,'admin','Updated LPI id 4','2018-11-28 08:35:49'),(368,'admin','Log in','2018-11-28 08:38:14'),(369,'admin','Updated Request sub ID  27','2018-11-28 08:39:15'),(370,'admin','updated extension of request sub id 27','2018-11-28 08:39:32'),(371,'admin','Updated Request sub ID  27','2018-11-28 08:39:39'),(372,'admin','Deleted Request ID  18-0009','2018-11-28 08:44:54'),(373,'admin','Restored Request sub ID  33','2018-11-28 08:45:54'),(374,'admin','Log in','2018-11-28 10:31:17'),(375,'admin','Log in','2018-11-28 10:45:34'),(376,'admin','Log in','2018-11-28 10:48:41'),(377,'admin','Log in','2018-11-28 10:51:48'),(378,'admin','Log in','2018-11-28 10:52:05'),(379,'admin','Log in','2018-11-28 10:52:14'),(380,'admin','Log in','2018-11-28 10:52:39'),(381,'admin','Log in','2018-11-28 10:56:31'),(382,'admin','Updated LPI id 6','2018-11-28 10:57:25'),(383,'admin','Log in','2018-11-28 10:59:54'),(384,'admin','Log in','2018-11-28 11:00:27'),(385,'admin','Log in','2018-11-28 11:03:04'),(386,'admin','Log in','2018-11-28 11:03:32'),(387,'admin','Log in','2018-11-28 11:09:44'),(388,'admin','Log in','2018-11-28 11:14:07'),(389,'admin','Log in','2018-11-28 11:14:45'),(390,'admin','Log in','2018-11-28 11:15:22'),(391,'admin','Log in','2018-11-28 11:16:18'),(392,'admin','Log in','2018-11-28 11:16:54'),(393,'admin','Log in','2018-11-28 11:20:10'),(394,'admin','Log in','2018-11-28 11:20:30'),(395,'admin','Log in','2018-11-28 11:20:51'),(396,'admin','Log in','2018-11-28 11:21:01'),(397,'admin','Log in','2018-11-28 11:21:38'),(398,'admin','Log in','2018-11-28 11:21:53'),(399,'admin','Log in','2018-11-28 11:22:08'),(400,'admin','Log in','2018-11-28 11:22:27'),(401,'admin','Log in','2018-11-28 11:23:08'),(402,'admin','Log in','2018-11-28 11:23:49'),(403,'admin','Log in','2018-11-28 11:24:02'),(404,'admin','Log in','2018-11-28 11:25:47'),(405,'admin','Log in','2018-11-28 11:27:32'),(406,'admin','Log in','2018-11-28 11:30:42'),(407,'admin','Updated the account user2','2018-11-28 11:31:02'),(408,'admin','Log in','2018-11-28 11:31:17'),(409,'admin','Log in','2018-11-28 11:31:41'),(410,'Pano mo nasabi?','Log in','2018-11-28 11:31:56'),(411,'Pano mo nasabi?','Updated his/her own account  ','2018-11-28 11:32:31'),(412,'Kalad kare','Log in','2018-11-28 11:32:56'),(413,'admin','Log in','2018-11-28 11:34:46'),(414,'admin','Logged in','2018-11-28 11:49:30'),(415,'admin','Logged in','2018-11-28 13:14:51'),(416,'admin','Logged in','2018-11-28 13:16:14'),(417,'admin','Logged in','2018-11-28 13:17:17'),(418,'admin','Logged in','2018-11-28 13:17:45'),(419,'admin','Logged in','2018-11-28 13:18:29'),(420,'admin','Logged in','2018-11-28 13:20:01'),(421,'admin','Logged in','2018-11-28 13:21:06'),(422,'admin','Updated Volunteer id 17-0003','2018-11-28 13:22:19'),(423,'Kalad kare','Logged in','2018-11-28 13:23:11'),(424,'Kalad kare','Added Request id ','2018-11-28 13:25:04'),(425,'admin','Logged in','2018-11-28 14:33:12'),(426,'Kalad kare','Log in','2018-11-28 14:39:38'),(427,'Kalad kare','Log in','2018-11-28 14:39:43'),(428,'Kalad kare','Log in','2018-11-28 14:40:38'),(429,'admin','Log in','2018-11-28 14:41:21'),(430,'admin','Log in','2018-11-28 14:41:36'),(431,'admin','Logged in','2018-11-28 14:45:08'),(432,'admin','Logged in','2018-11-28 14:46:24'),(433,'admin','Logged in','2018-11-28 14:48:48'),(434,'admin','Updated Request ID  18-0017','2018-11-28 14:55:54'),(435,'admin','Logged in','2018-11-28 15:04:28'),(436,'admin','Logged in','2018-11-28 15:05:58'),(437,'admin','Logged in','2018-11-28 15:11:32'),(438,'admin','Updated Request ID  18-0017','2018-11-28 15:13:09'),(439,'admin','Updated Volunteer id 18-0001','2018-11-28 15:14:04'),(440,'admin','Added Request id ','2018-11-28 15:15:08'),(441,'admin','Updated Request ID  18-0011','2018-11-28 15:15:28'),(442,'admin','Added Request sub of request ID 38','2018-11-28 15:15:54'),(443,'admin','Updated Request sub ID  52','2018-11-28 15:16:13'),(444,'admin','Updated Volunteer id 17-0003','2018-11-28 15:27:13'),(445,'admin','Updated LPI id 17','2018-11-28 15:34:07'),(446,'admin','Updated LPI id 17','2018-11-28 15:35:09'),(447,'admin','Logged in','2018-11-28 15:51:55'),(448,'admin','Logged in','2018-11-28 15:53:35'),(449,'admin','Logged in','2018-11-28 15:54:38'),(450,'admin','Updated Volunteer id 17-0006','2018-11-28 16:02:07'),(451,'admin','Updated Volunteer id 17-0006','2018-11-28 16:02:21'),(452,'admin','Logged in','2018-11-29 08:29:53'),(453,'admin','Updated Request sub ID  38','2018-11-29 08:30:23'),(454,'admin','Updated Request ID  18-0013','2018-11-29 08:30:38'),(455,'admin','Logged in','2018-11-29 09:27:57'),(456,'admin','Logged in','2018-11-29 09:29:19'),(457,'admin','Logged in','2018-11-29 09:39:21'),(458,'admin','Logged in','2018-11-29 09:44:12'),(459,'admin','Logged in','2018-11-29 10:23:42'),(460,'admin','Logged in','2018-11-29 13:13:44'),(461,'admin','Added Request sub of request ID 37','2018-11-29 13:20:24'),(462,'admin','Logged in','2018-11-29 13:21:20'),(463,'admin','Deleted Request ID  18-0003','2018-11-29 13:21:28'),(464,'admin','Logged in','2018-11-29 13:27:31'),(465,'admin','Logged in','2018-11-29 13:36:19'),(466,'admin','Logged in','2018-11-29 13:37:19'),(467,'admin','Logged in','2018-11-29 13:37:54'),(468,'admin','Added Request id ','2018-11-29 13:38:53'),(469,'admin','Added Request sub of request ID 39','2018-11-29 13:39:22'),(470,'admin','Deleted Request ID  18-0021','2018-11-29 13:39:26'),(471,'admin','Added Request sub of request ID 39','2018-11-29 13:40:03'),(472,'admin','Deleted Request ID  18-0021','2018-11-29 13:40:12'),(473,'admin','Logged in','2018-11-29 13:41:41'),(474,'admin','Deleted Request ID  18-0003','2018-11-29 13:41:49'),(475,'admin','Deleted Request ID  18-0003','2018-11-29 13:41:53'),(476,'Johnny Thor','Logged in','2018-11-29 13:42:23'),(477,'Johnny Thor','Added Request sub of request ID 39','2018-11-29 13:42:44'),(478,'Johnny Thor','Deleted Request ID  18-0021','2018-11-29 13:43:10'),(479,'Johnny Thor','Logged in','2018-11-29 13:44:09'),(480,'Johnny Thor','Added Request sub of request ID 39','2018-11-29 13:44:24'),(481,'Johnny Thor','Deleted Request ID  18-0021','2018-11-29 13:44:47'),(482,'Johnny Thor','Updated LPI id 31','2018-11-29 13:58:06'),(483,'Johnny Thor','Updated LPI id 32','2018-11-29 13:58:12'),(484,'Johnny Thor','Updated LPI id 35','2018-11-29 13:58:25'),(485,'admin','Logged in','2018-11-29 14:01:46'),(486,'admin','Added a LPI','2018-11-29 14:02:19'),(487,'admin','Updated Volunteer id 18-0021','2018-11-29 14:21:31'),(488,'admin','Updated Volunteer id 18-0021','2018-11-29 14:22:26'),(489,'Johnny Thor','Logged in','2018-11-29 14:25:33'),(490,'admin','Logged in','2018-11-29 14:33:58'),(491,'admin','Logged in','2018-11-29 14:34:35'),(492,'admin','Logged in','2018-11-29 14:36:49'),(493,'admin','Logged in','2018-11-29 14:37:00'),(494,'admin','Logged in','2018-11-29 14:37:38'),(495,'admin','Logged in','2018-11-29 14:38:07'),(496,'admin','Logged in','2018-11-29 14:40:59'),(497,'admin','Logged in','2018-11-29 14:43:43'),(498,'admin','Logged in','2018-11-29 14:44:26'),(499,'admin','Logged in','2018-11-29 14:44:33'),(500,'admin','Logged in','2018-11-29 14:58:34'),(501,'admin','Logged in','2018-11-29 15:14:44'),(502,'admin','Logged in','2018-11-29 15:18:38'),(503,'admin','Logged in','2018-12-04 08:10:03'),(504,'admin','Logged in','2018-12-04 08:28:47'),(505,'admin','Updated Volunteer id 17-0006','2018-12-04 08:29:51'),(506,'admin','Updated Request sub ID  52','2018-12-04 08:30:25'),(507,'admin','Updated LPI id 8','2018-12-04 08:31:05'),(508,'admin','Logged in','2018-12-04 08:37:32'),(509,'admin','Updated LPI id 6','2018-12-04 08:40:23'),(510,'admin','Added a Project for LPI ID 6','2018-12-04 08:42:18'),(511,'admin','Updated Project id 7193','2018-12-04 08:42:24'),(512,'admin','Added Request id ','2018-12-04 08:43:16'),(513,'admin','Updated Request ID  18-0022','2018-12-04 08:43:28'),(514,'admin','Added Request sub of request ID 40','2018-12-04 08:43:39'),(515,'admin','Logged in','2018-12-04 16:17:28'),(516,'admin','Updated LPI id 3','2018-12-04 16:18:09'),(517,'admin','Updated Project id 1','2018-12-04 16:18:30'),(518,'admin','Logged in','2018-12-05 08:10:49'),(519,'admin','Updated LPI id 4','2018-12-05 08:12:21'),(520,'admin','Logged in','2018-12-05 08:17:07'),(521,'admin','Logged in','2018-12-05 08:22:29'),(522,'admin','Logged in','2018-12-05 08:25:01'),(523,'admin','added Volunteer','2018-12-05 08:41:27'),(524,'Johnny Thor','Logged in','2018-12-05 08:56:30'),(525,'admin','Logged in','2018-12-05 09:10:34'),(526,'admin','Logged in','2018-12-05 09:16:37'),(527,'Johnny Thor','Logged in','2018-12-05 09:22:03'),(528,'admin','Logged in','2018-12-05 09:22:14'),(529,'Kareem abdul jabaar','Logged in','2018-12-05 09:25:27'),(530,'admin','Logged in','2018-12-05 09:32:01'),(531,'admin','Updated his/her own account  ','2018-12-05 09:34:39'),(532,'Johnny Thor','Updated LPI id 1','2018-12-05 09:36:39'),(533,'admin','Updated LPI id 1','2018-12-05 09:36:40'),(534,'Johnny Thor','Updated LPI id 1','2018-12-05 09:36:51'),(535,'admin','Logged in','2018-12-05 09:41:48'),(536,'admin','Logged in','2018-12-05 10:06:22'),(537,'admin','Logged in','2018-12-05 10:12:29'),(538,'admin','Logged in','2018-12-05 10:21:52'),(539,'admin','Logged in','2018-12-05 10:25:49'),(540,'admin','Updated Request ID  18-0016','2018-12-05 10:26:48'),(541,'admin','Logged in','2018-12-05 10:28:17'),(542,'admin','Logged in','2018-12-05 10:29:13'),(543,'admin','Logged in','2018-12-05 10:31:28'),(544,'admin','Logged in','2018-12-05 10:34:31'),(545,'admin','Logged in','2018-12-05 10:40:20'),(546,'admin','Logged in','2018-12-05 10:42:07'),(547,'admin','Updated Request ID  18-0021','2018-12-05 10:45:46'),(548,'admin','Logged in','2018-12-05 10:52:43'),(549,'admin','Logged in','2018-12-05 10:54:02'),(550,'admin','Logged in','2018-12-05 10:55:57'),(551,'admin','Logged in','2018-12-05 11:01:50'),(552,'admin','updated extension of request sub id 27','2018-12-05 13:06:27'),(553,'admin','updated extension of request sub id 27','2018-12-05 13:06:43'),(554,'admin','Updated Request sub ID  27','2018-12-05 13:06:50'),(555,'admin','Logged in','2018-12-05 13:10:43'),(556,'admin','Updated Request sub ID  58','2018-12-05 13:11:35'),(557,'admin','Updated Project id 11','2018-12-05 13:11:56'),(558,'admin','Updated Project id 11','2018-12-05 13:12:00'),(559,'admin','Logged in','2018-12-05 13:35:25'),(560,'admin','Logged in','2018-12-05 13:37:55'),(561,'admin','Added Request id ','2018-12-05 13:45:40'),(562,'admin','Added Request sub of request ID 41','2018-12-05 13:46:55'),(563,'admin','Updated Request sub ID  59','2018-12-05 13:47:46'),(564,'admin','Updated Request ID  19-0001','2018-12-05 13:48:04'),(565,'admin','Logged in','2018-12-05 14:15:50'),(566,'admin','Updated Request sub ID  34','2018-12-05 14:19:10'),(567,'admin','Updated Request sub ID  34','2018-12-05 14:19:30'),(568,'admin','Logged in','2018-12-05 14:20:24'),(569,'admin','Updated Request sub ID  59','2018-12-05 14:20:47'),(570,'admin','Updated Request sub ID  59','2018-12-05 14:21:04'),(571,'admin','Updated Request ID  19-0001','2018-12-05 14:21:13'),(572,'admin','Updated Request ID  18-0020','2018-12-05 14:21:29'),(573,'admin','Updated Request ID  18-0020','2018-12-05 14:21:37'),(574,'admin','Logged in','2018-12-05 14:28:20'),(575,'admin','Logged in','2018-12-05 14:40:37'),(576,'admin','Logged in','2018-12-05 14:50:41'),(577,'admin','Logged in','2018-12-05 15:28:23'),(578,'admin','Updated a Specialization sub id 26','2018-12-05 15:31:41'),(579,'admin','Updated Volunteer id 18-0003','2018-12-05 15:33:10'),(580,'admin','Updated Volunteer id 17-0001','2018-12-05 15:39:38'),(581,'admin','Logged in','2018-12-05 15:49:28'),(582,'admin','Logged in','2018-12-05 16:17:39'),(583,'Johnny Thor','Logged in','2018-12-05 16:22:20'),(584,'admin','Logged in','2018-12-05 16:22:43'),(585,'admin','Logged in','2018-12-06 08:31:27'),(586,'admin','Updated Request ID  18-0017','2018-12-06 08:31:41'),(587,'admin','Logged in','2018-12-06 08:36:20'),(588,'admin','Logged in','2018-12-06 08:38:35'),(589,'admin','Logged in','2018-12-06 08:40:17'),(590,'admin','Logged in','2018-12-06 08:41:32'),(591,'admin','Logged in','2018-12-06 08:43:03'),(592,'admin','Logged in','2018-12-06 08:46:01'),(593,'admin','Restored Request sub ID  26','2018-12-06 08:46:18'),(594,'admin','Deleted Request ID  18-0002','2018-12-06 08:47:12'),(595,'admin','Deleted Request sub permanently ID  26','2018-12-06 08:47:23'),(596,'admin','Logged in','2018-12-06 08:49:06'),(597,'Malou','Logged in','2018-12-06 08:50:04'),(598,'Malou','Updated his/her own account  ','2018-12-06 08:50:41'),(599,'admin','Logged in','2018-12-06 08:51:44'),(600,'Johnny Thor','Logged in','2018-12-06 08:57:44'),(601,'Johnny Thor','Logged in','2018-12-06 09:45:15'),(602,'Johnny Thor','Logged in','2018-12-06 09:59:34'),(603,'Johnny Thor','Logged in','2018-12-06 10:26:55'),(604,'Johnny Thor','Logged in','2018-12-06 10:33:58'),(605,'Johnny Thor','Logged in','2018-12-06 10:44:06'),(606,'Johnny Thor','added Volunteer','2018-12-06 10:47:42'),(607,'Johnny Thor','Logged in','2018-12-06 10:48:48'),(608,'Johnny Thor','added Volunteer','2018-12-06 10:55:45'),(609,'Johnny Thor','added Volunteer','2018-12-06 10:56:20'),(610,'Johnny Thor','added Volunteer','2018-12-06 10:56:43'),(611,'Johnny Thor','added Volunteer','2018-12-06 10:58:03'),(612,'Johnny Thor','added Volunteer','2018-12-06 10:58:37'),(613,'Johnny Thor','added Volunteer','2018-12-06 10:59:02'),(614,'Johnny Thor','added Volunteer','2018-12-06 10:59:32'),(615,'Johnny Thor','Updated Volunteer id 19-0010','2018-12-06 10:59:47'),(616,'Johnny Thor','Updated Volunteer id 19-0009','2018-12-06 11:00:07'),(617,'Johnny Thor','added Volunteer','2018-12-06 11:01:15'),(618,'Johnny Thor','Updated Volunteer id 19-0011','2018-12-06 11:01:41'),(619,'Johnny Thor','Logged in','2018-12-06 11:07:40'),(620,'Johnny Thor','Logged in','2018-12-06 11:07:54'),(621,'Johnny Thor','Logged in','2018-12-06 11:09:57'),(622,'Johnny Thor','Logged in','2018-12-06 11:10:58'),(623,'Johnny Thor','Logged in','2018-12-06 13:26:19'),(624,'Johnny Thor','Logged in','2018-12-06 13:27:48'),(625,'Johnny Thor','Logged in','2018-12-06 13:30:05'),(626,'Johnny Thor','Logged in','2018-12-06 13:41:24'),(627,'Johnny Thor','Logged in','2018-12-06 13:43:26'),(628,'Johnny Thor','Logged in','2018-12-06 13:44:28'),(629,'Johnny Thor','Logged in','2018-12-06 13:51:29'),(630,'Johnny Thor','Logged in','2018-12-06 14:06:52'),(631,'admin','Logged in','2018-12-06 14:26:34'),(632,'admin','Logged in','2018-12-07 08:24:42'),(633,'admin','Updated Request sub ID  52','2018-12-07 08:25:39'),(634,'admin','Logged in','2018-12-07 08:29:07'),(635,'admin','Logged in','2018-12-07 08:29:30'),(636,'admin','Logged in','2018-12-07 08:30:54'),(637,'admin','Logged in','2018-12-07 08:31:51'),(638,'admin','Logged in','2018-12-07 08:33:29'),(639,'admin','Logged in','2018-12-07 08:37:33'),(640,'admin','Logged in','2018-12-07 08:37:58'),(641,'admin','Logged in','2018-12-07 08:38:39'),(642,'admin','Logged in','2018-12-07 08:41:57'),(643,'admin','Logged in','2018-12-07 08:42:20'),(644,'admin','Logged in','2018-12-07 08:43:59'),(645,'admin','Logged in','2018-12-07 08:46:45'),(646,'admin','Logged in','2018-12-07 08:47:10'),(647,'admin','Logged in','2018-12-07 08:48:02'),(648,'admin','Logged in','2018-12-07 08:48:33'),(649,'admin','Logged in','2018-12-07 08:49:23'),(650,'admin','Logged in','2018-12-07 08:51:54'),(651,'admin','Logged in','2018-12-07 08:52:32'),(652,'admin','Logged in','2018-12-07 08:53:02'),(653,'admin','Logged in','2018-12-07 08:55:17'),(654,'admin','Logged in','2018-12-07 08:56:51'),(655,'admin','Logged in','2018-12-07 08:57:49'),(656,'admin','Logged in','2018-12-07 08:57:59'),(657,'admin','Logged in','2018-12-07 08:58:41'),(658,'admin','Logged in','2018-12-07 08:59:18'),(659,'admin','Logged in','2018-12-07 09:00:44'),(660,'admin','Logged in','2018-12-07 09:02:38'),(661,'admin','Logged in','2018-12-07 09:05:24'),(662,'admin','Logged in','2018-12-07 09:08:10'),(663,'admin','Logged in','2018-12-07 09:10:05'),(664,'admin','Logged in','2018-12-07 09:20:42'),(665,'admin','Logged in','2018-12-07 09:21:41'),(666,'admin','Logged in','2018-12-07 09:22:30'),(667,'admin','Logged in','2018-12-07 09:22:54'),(668,'admin','Logged in','2018-12-07 09:23:12'),(669,'admin','Logged in','2018-12-07 09:24:11'),(670,'admin','Logged in','2018-12-07 09:26:00'),(671,'admin','Logged in','2018-12-07 09:26:47'),(672,'admin','Logged in','2018-12-07 09:27:04'),(673,'admin','Logged in','2018-12-07 09:27:32'),(674,'admin','Logged in','2018-12-07 09:28:13'),(675,'admin','Logged in','2018-12-07 09:29:23'),(676,'admin','Logged in','2018-12-07 09:29:58'),(677,'admin','Logged in','2018-12-07 09:33:05'),(678,'admin','Logged in','2018-12-07 09:56:40'),(679,'admin','Logged in','2018-12-07 10:02:57'),(680,'admin','Logged in','2018-12-07 10:05:46'),(681,'Johnny Thor','Logged in','2018-12-07 10:10:15'),(682,'Malou Ang','Logged in','2018-12-07 10:12:17'),(683,'Johnny Thor','Logged in','2018-12-07 10:18:51'),(684,'Johnny Thor','Logged in','2018-12-07 10:18:57'),(685,'Johnny Thor','Logged in','2018-12-07 10:22:19'),(686,'Johnny Thor','Logged in','2018-12-07 10:23:00'),(687,'Johnny Thor','Logged in','2018-12-07 10:23:32'),(688,'Johnny Thor','Updated LPI id 1','2018-12-07 10:23:35'),(689,'Johnny Thor','Added a Project for LPI ID 3028','2018-12-07 10:23:43'),(690,'Johnny Thor','Deleted Project ID 7194','2018-12-07 10:23:49'),(691,'Johnny Thor','Logged in','2018-12-07 10:26:23'),(692,'Johnny Thor','Logged in','2018-12-07 10:29:59'),(693,'Johnny Thor','Logged in','2018-12-07 10:35:12'),(694,'Johnny Thor','Updated Volunteer id 19-0004','2018-12-07 10:36:24'),(695,'Johnny Thor','Logged in','2018-12-07 10:37:35'),(696,'Johnny Thor','Updated Volunteer id 19-0006','2018-12-07 10:38:07'),(697,'Johnny Thor','Updated Volunteer id 18-0012','2018-12-07 10:38:37'),(698,'Johnny Thor','Updated Volunteer id 17-0001','2018-12-07 10:38:46'),(699,'Johnny Thor','Updated Volunteer id 12-0001','2018-12-07 10:39:02'),(700,'Johnny Thor','Logged in','2018-12-07 10:39:46'),(701,'Kareem abdul jabaar','Logged in','2018-12-07 11:10:31'),(702,'Malou Ang','Logged in','2018-12-07 11:11:30'),(703,'Malou Ang','Updated LPI id 43','2018-12-07 11:12:35'),(704,'Malou Ang','Logged in','2018-12-07 11:55:23'),(705,'Johnny Thor','Logged in','2018-12-07 12:03:32'),(706,'Malou Ang','Logged in','2018-12-07 12:03:59'),(707,'Malou Ang','Updated LPI id 3032','2018-12-07 12:04:38'),(708,'Johnny Thor','Updated LPI id 3032','2018-12-07 12:05:05'),(709,'Malou Ang','Logged in','2018-12-07 13:25:46'),(710,'Malou Ang','Updated LPI id 3033','2018-12-07 13:25:50'),(711,'Malou Ang','Logged in','2018-12-07 13:50:32'),(712,'Malou Ang','Logged in','2018-12-07 13:54:00'),(713,'Malou Ang','Logged in','2018-12-07 13:54:56'),(714,'Malou Ang','Logged in','2018-12-07 13:55:54'),(715,'Malou Ang','Logged in','2018-12-07 13:57:29'),(716,'Malou Ang','Logged in','2018-12-07 13:59:28'),(717,'Malou Ang','Logged in','2018-12-07 14:01:07'),(718,'admin','Logged in','2018-12-07 14:01:18'),(719,'Malou Ang','Logged in','2018-12-07 14:03:57'),(720,'admin','Logged in','2018-12-07 14:04:09'),(721,'admin','Updated LPI id 3033','2018-12-07 14:04:19'),(722,'admin','Updated Request sub ID  53','2018-12-07 14:04:34'),(723,'Johnny Thor','Logged in','2018-12-07 14:06:09'),(724,'admin','Logged in','2018-12-07 14:06:26'),(725,'Malou Ang','Logged in','2018-12-07 14:06:43'),(726,'Malou Ang','Updated Volunteer id 19-0011','2018-12-07 14:06:54'),(727,'Malou Ang','Updated Request ID  18-0021','2018-12-07 14:07:19'),(728,'Johnny Thor','Logged in','2018-12-07 14:09:09'),(729,'Malou Ang','Logged in','2018-12-07 14:09:37'),(730,'admin','Logged in','2018-12-07 14:09:51'),(731,'admin','Logged in','2018-12-07 14:10:05'),(732,'admin','Logged in','2018-12-07 14:10:36'),(733,'admin','Logged in','2018-12-07 14:11:31'),(734,'admin','Logged in','2018-12-07 14:11:57'),(735,'admin','Updated Volunteer id 19-0009','2018-12-07 14:12:24'),(736,'Johnny Thor','Logged in','2018-12-07 14:14:20'),(737,'Malou Ang','Logged in','2018-12-07 14:14:54'),(738,'admin','Logged in','2018-12-07 14:15:22'),(739,'admin','Logged in','2018-12-07 14:17:24'),(740,'admin','Updated LPI id 3032','2018-12-07 14:17:33'),(741,'Malou Ang','Logged in','2018-12-07 14:19:41'),(742,'Malou Ang','Logged in','2018-12-07 14:23:55'),(743,'Johnny Thor','Logged in','2018-12-07 14:25:00'),(744,'Johnny Thor','Logged in','2018-12-07 14:25:17'),(745,'Malou Ang','Logged in','2018-12-07 14:31:57'),(746,'admin','Logged in','2018-12-07 14:32:06'),(747,'admin','Updated Volunteer id 19-0007','2018-12-07 14:32:20'),(748,'admin','Logged in','2018-12-07 14:33:01'),(749,'admin','Logged in','2018-12-07 14:33:22'),(750,'admin','Logged in','2018-12-07 14:38:00'),(751,'Johnny Thor','Logged in','2018-12-07 14:38:19'),(752,'admin','Logged in','2018-12-07 14:38:37'),(753,'admin','Updated Volunteer id 19-0010','2018-12-07 14:38:44'),(754,'admin','Logged in','2018-12-07 14:39:09'),(755,'admin','Updated Volunteer id 19-0010','2018-12-07 14:39:18'),(756,'admin','Updated Request sub ID  40','2018-12-07 14:39:31'),(757,'admin','updated extension of request sub id 27','2018-12-07 14:40:07'),(758,'admin','Logged in','2018-12-07 14:40:32'),(759,'admin','updated extension of request sub id 34','2018-12-07 14:40:47'),(760,'admin','Logged in','2018-12-07 14:41:37'),(761,'admin','Logged in','2018-12-07 14:41:52'),(762,'admin','Logged in','2018-12-07 14:42:08'),(763,'Johnny Thor','Logged in','2018-12-07 14:42:39'),(764,'Johnny Thor','Updated Request ID  18-0022','2018-12-07 14:42:49'),(765,'Johnny Thor','Deleted Request sub permanently ID  56','2018-12-07 14:43:20'),(766,'Johnny Thor','Deleted Volunteer id 18-0004','2018-12-07 14:44:05'),(767,'Johnny Thor','Restore Volunteer ID  18-0004','2018-12-07 14:44:21'),(768,'Johnny Thor','Updated a Sector id 9','2018-12-07 14:44:36'),(769,'Johnny Thor','Logged in','2018-12-07 14:47:35'),(770,'Johnny Thor','Logged in','2018-12-07 14:48:25'),(771,'Johnny Thor','Updated LPI id 12','2018-12-07 14:49:14'),(772,'Johnny Thor','Updated LPI id 3032','2018-12-07 14:49:26'),(773,'Johnny Thor','Updated Volunteer id 19-0005','2018-12-07 14:49:48'),(774,'Johnny Thor','Updated Request ID  18-0020','2018-12-07 14:50:19'),(775,'Johnny Thor','Updated Request sub ID  58','2018-12-07 14:50:39'),(776,'Johnny Thor','added Volunteer','2018-12-07 14:51:59'),(777,'Johnny Thor','Logged in','2018-12-07 14:54:24'),(778,'Johnny Thor','Updated LPI id 3030','2018-12-07 15:00:55'),(779,'Johnny Thor','Updated Volunteer id 19-0007','2018-12-07 15:01:11'),(780,'Johnny Thor','Updated Request sub ID  52','2018-12-07 15:01:47'),(781,'Johnny Thor','Updated Request sub ID  52','2018-12-07 15:02:46'),(782,'Johnny Thor','Updated Request sub ID  52','2018-12-07 15:03:47'),(783,'Johnny Thor','Updated Request sub ID  52','2018-12-07 15:10:38'),(784,'admin','Logged in','2018-12-07 15:18:46'),(785,'Malou Ang','Logged in','2018-12-07 15:19:09'),(786,'Malou Ang','Updated Volunteer id 19-0011','2018-12-07 15:19:17'),(787,'Malou Ang','Updated Request ID  18-0019','2018-12-07 15:19:27'),(788,'Malou Ang','Updated LPI id 1','2018-12-07 15:19:36'),(789,'Malou Ang','Updated Request ID  18-0001','2018-12-07 15:19:44'),(790,'Johnny Thor','Logged in','2018-12-07 15:21:20'),(791,'Johnny Thor','Deleted LPI id 44','2018-12-07 15:21:33'),(792,'Johnny Thor','Updated Volunteer id 19-0009','2018-12-07 15:22:11'),(793,'Johnny Thor','Updated Volunteer id 19-0009','2018-12-07 15:22:19'),(794,'Johnny Thor','Updated Request ID  18-0001','2018-12-07 15:22:31'),(795,'Johnny Thor','Updated Request sub ID  53','2018-12-07 15:22:38'),(796,'Johnny Thor','Logged in','2018-12-07 15:23:54'),(797,'Johnny Thor','Logged in','2018-12-07 15:24:31'),(798,'Johnny Thor','Deleted LPI id 45','2018-12-07 15:24:59'),(799,'Johnny Thor','Deleted LPI id 44','2018-12-07 15:25:06'),(800,'Johnny Thor','Updated LPI id 5','2018-12-07 15:35:00'),(801,'Johnny Thor','Updated Volunteer id 19-0009','2018-12-07 15:35:11'),(802,'Johnny Thor','Updated Request ID  18-0017','2018-12-07 15:41:19'),(803,'Johnny Thor','Updated Volunteer id 19-0011','2018-12-07 15:41:50'),(804,'Johnny Thor','Logged in','2018-12-07 15:42:49'),(805,'Johnny Thor','Logged in','2018-12-07 15:43:57'),(806,'Johnny Thor','Logged in','2018-12-07 15:44:10'),(807,'Johnny Thor','Logged in','2018-12-07 15:44:51'),(808,'Johnny Thor','Updated LPI id 1','2018-12-07 15:45:01'),(809,'Johnny Thor','Logged in','2018-12-07 15:45:48'),(810,'Johnny Thor','Logged in','2018-12-07 15:46:24'),(811,'Johnny Thor','Logged in','2018-12-07 15:48:12'),(812,'Johnny Thor','Logged in','2018-12-07 15:49:41'),(813,'Johnny Thor','Logged in','2018-12-07 15:52:19'),(814,'admin','Logged in','2018-12-07 15:55:34'),(815,'admin','Updated Volunteer id 19-0008','2018-12-07 15:55:51'),(816,'Johnny Thor','Logged in','2018-12-07 15:56:15'),(817,'Johnny Thor','Updated LPI id 3','2018-12-07 15:56:26'),(818,'Johnny Thor','Updated Volunteer id 19-0010','2018-12-07 15:57:04'),(819,'Johnny Thor','updated extension of request sub id 34','2018-12-07 15:57:34'),(820,'Johnny Thor','Updated Request ID  18-0010','2018-12-07 15:57:57'),(821,'Johnny Thor','Updated Request ID  18-0020','2018-12-07 15:58:07'),(822,'Johnny Thor','Updated IVSO id 5','2018-12-07 15:58:23'),(823,'Johnny Thor','Updated IVSO id 6','2018-12-07 15:58:35'),(824,'Johnny Thor','Updated Specialization sub id 22','2018-12-07 15:58:48'),(825,'Johnny Thor','Updated Specialization sub id 22','2018-12-07 15:59:00'),(826,'Johnny Thor','Updated LPI id 3029','2018-12-07 16:00:23'),(827,'Johnny Thor','Logged in','2018-12-07 16:03:17'),(828,'Johnny Thor','Updated Request sub ID  52','2018-12-07 16:03:31'),(829,'Johnny Thor','Updated Request ID  18-0020','2018-12-07 16:23:54'),(830,'Johnny Thor','Updated Request ID  18-0022','2018-12-07 16:24:14'),(831,'Johnny Thor','Updated Request ID  18-0004','2018-12-07 16:24:21'),(832,'Johnny Thor','Updated Request sub ID  52','2018-12-07 16:24:47'),(833,'Johnny Thor','Logged in','2018-12-10 08:19:42'),(834,'Johnny Thor','Updated Volunteer id 19-0010','2018-12-10 08:19:50'),(835,'Johnny Thor','Logged in','2018-12-10 09:30:15'),(836,'Johnny Thor','Updated Volunteer id 19-0008','2018-12-10 09:30:26'),(837,'Johnny Thor','Logged in','2018-12-10 09:32:34'),(838,'Johnny Thor','Logged in','2018-12-10 09:33:13'),(839,'Johnny Thor','Logged in','2018-12-10 09:34:02'),(840,'Johnny Thor','Logged in','2018-12-10 09:35:05'),(841,'admin','Logged in','2018-12-10 09:36:08'),(842,'Johnny Thor','Logged in','2018-12-10 09:37:33'),(843,'Johnny Thor','Logged in','2018-12-10 09:42:13'),(844,'admin','Logged in','2018-12-10 09:44:24'),(845,'admin','Updated LPI id 3030','2018-12-10 09:46:36'),(846,'admin','Updated Volunteer id 19-0008','2018-12-10 09:46:50'),(847,'admin','Updated Request ID  18-0022','2018-12-10 09:47:01'),(848,'admin','Updated IVSO id 5','2018-12-10 09:47:42'),(849,'admin','Updated IVSO id 8','2018-12-10 09:48:08'),(850,'Johnny Thor','Logged in','2018-12-10 11:03:57'),(851,'Johnny Thor','Logged in','2018-12-10 13:29:46'),(852,'Johnny Thor','Logged in','2018-12-10 13:32:45'),(853,'Johnny Thor','Logged in','2018-12-10 13:54:09'),(854,'admin','Logged in','2018-12-10 13:55:16'),(855,'Malou Ang','Logged in','2018-12-10 13:58:26'),(856,'Malou Ang','Logged in','2018-12-10 13:59:48'),(857,'admin','Logged in','2018-12-10 14:04:08'),(858,'admin','Logged in','2018-12-10 14:11:03'),(859,'admin','Logged in','2018-12-10 14:15:00'),(860,'admin','Logged in','2018-12-10 14:16:42'),(861,'admin','Logged in','2018-12-10 14:18:34'),(862,'admin','Logged in','2018-12-10 14:19:14'),(863,'admin','Logged in','2018-12-10 14:20:29'),(864,'admin','Logged in','2018-12-10 14:29:20'),(865,'admin','Logged in','2018-12-10 14:29:59'),(866,'admin','Logged in','2018-12-10 14:31:10'),(867,'admin','Logged in','2018-12-10 14:32:35'),(868,'admin','Logged in','2018-12-10 14:33:23'),(869,'admin','Logged in','2018-12-10 14:43:48'),(870,'admin','Logged in','2018-12-10 14:44:34'),(871,'Malou Ang','Logged in','2018-12-10 14:59:30'),(872,'admin','Logged in','2018-12-10 14:59:38'),(873,'Malou Ang','Logged in','2018-12-10 15:07:02'),(874,'Malou Ang','Updated Request ID  18-0021','2018-12-10 15:08:20'),(875,'Malou Ang','Updated LPI id 4','2018-12-10 15:08:49'),(876,'admin','Logged in','2018-12-10 15:11:51'),(877,'admin','Restored Request sub ID  47','2018-12-10 15:12:17'),(878,'admin','Deleted Request ID  18-0016','2018-12-10 15:13:36'),(879,'admin','Logged in','2018-12-10 15:16:21'),(880,'admin','Logged in','2018-12-10 16:15:08'),(881,'admin','Logged in','2018-12-10 16:21:04'),(882,'admin','Logged in','2018-12-10 16:21:39'),(883,'admin','Logged in','2018-12-10 16:22:18'),(884,'admin','Logged in','2018-12-10 16:22:57'),(885,'admin','Logged in','2018-12-10 16:23:44'),(886,'admin','Logged in','2018-12-10 16:26:28'),(887,'admin','Logged in','2018-12-11 09:00:22'),(888,'admin','Logged in','2018-12-11 09:02:26'),(889,'admin','Logged in','2018-12-11 09:13:28'),(890,'admin','Logged in','2018-12-11 09:15:13'),(891,'admin','Logged in','2018-12-11 09:26:31'),(892,'admin','Updated Volunteer id 19-0008','2018-12-11 09:26:38'),(893,'admin','Updated Volunteer id 19-0006','2018-12-11 09:26:41'),(894,'admin','Updated Volunteer id 19-0005','2018-12-11 09:26:44'),(895,'admin','Logged in','2018-12-11 10:48:53'),(896,'Johnny Thor','Logged in','2018-12-11 10:58:44'),(897,'Johnny Thor','Added Request sub of request ID 18','2018-12-11 10:59:14'),(898,'Johnny Thor','Logged in','2018-12-11 11:00:39'),(899,'Johnny Thor','Logged in','2018-12-11 11:01:34'),(900,'Johnny Thor','Logged in','2018-12-11 11:04:42'),(901,'Johnny Thor','Logged in','2018-12-11 11:10:20'),(902,'Johnny Thor','Logged in','2018-12-11 11:11:02'),(903,'Johnny Thor','Logged in','2018-12-11 11:12:07'),(904,'Johnny Thor','Logged in','2018-12-11 14:40:20'),(905,'Johnny Thor','Logged in','2018-12-11 14:46:56'),(906,'Johnny Thor','Logged in','2018-12-11 14:47:49'),(907,'Johnny Thor','Logged in','2018-12-11 15:03:23'),(908,'Johnny Thor','Logged in','2018-12-11 15:06:28'),(909,'Johnny Thor','Generate Reports from Volunteer Activities ','2018-12-11 15:06:32'),(910,'Johnny Thor','Generate Reports from Volunteer Activities ','2018-12-11 15:06:43'),(911,'Johnny Thor','Logged in','2018-12-11 15:07:45'),(912,'Johnny Thor','Updated LPI id 3029','2018-12-11 15:08:47'),(913,'Johnny Thor','Updated LPI id 3030','2018-12-11 15:09:13'),(914,'Johnny Thor','Updated Request ID  18-0003','2018-12-11 15:09:23'),(915,'Johnny Thor','Updated Request ID  18-0022','2018-12-11 15:10:03'),(916,'Johnny Thor','Logged in','2018-12-11 15:35:01'),(917,'Johnny Thor','Logged in','2018-12-11 15:36:08'),(918,'Malou Ang','Logged in','2018-12-11 15:36:40'),(919,'Johnny Thor','Logged in','2018-12-11 15:54:38'),(920,'Johnny Thor','Logged in','2018-12-11 16:02:34'),(921,'Johnny Thor','Logged in','2018-12-11 16:06:48'),(922,'Johnny Thor','Logged in','2018-12-11 16:21:03'),(923,'Johnny Thor','Logged in','2018-12-12 13:13:45'),(924,'Johnny Thor','Logged in','2018-12-12 13:26:58'),(925,'Johnny Thor','Updated Request sub ID  28','2018-12-12 13:28:15'),(926,'Johnny Thor','Logged in','2018-12-12 13:49:46'),(927,'Johnny Thor','Logged in','2018-12-12 13:55:03'),(928,'Johnny Thor','Logged in','2018-12-12 13:55:24'),(929,'Johnny Thor','Logged in','2018-12-12 13:55:37'),(930,'Johnny Thor','Logged in','2018-12-12 13:56:08'),(931,'Johnny Thor','Logged in','2018-12-12 13:56:28'),(932,'Johnny Thor','Logged in','2018-12-12 13:57:37'),(933,'Johnny Thor','Updated Request sub ID  28','2018-12-12 13:57:48'),(934,'Johnny Thor','Updated Request sub ID  28','2018-12-12 13:57:59'),(935,'Johnny Thor','Logged in','2018-12-12 14:00:25'),(936,'Johnny Thor','Logged in','2018-12-12 14:06:18'),(937,'Johnny Thor','Logged in','2018-12-12 14:07:18'),(938,'Johnny Thor','Logged in','2018-12-12 14:07:45'),(939,'Johnny Thor','Logged in','2018-12-12 14:09:16'),(940,'Johnny Thor','Logged in','2018-12-12 14:10:08'),(941,'Malou Ang','Logged in','2018-12-12 14:10:29'),(942,'Malou Ang','Logged in','2018-12-12 14:11:36'),(943,'Malou Ang','Logged in','2018-12-12 14:12:24'),(944,'Malou Ang','Logged in','2018-12-12 14:13:08'),(945,'Malou Ang','Logged in','2018-12-12 14:13:23'),(946,'Malou Ang','Logged in','2018-12-12 14:14:10'),(947,'Malou Ang','Logged in','2018-12-12 14:23:12'),(948,'Malou Ang','Logged in','2018-12-12 14:24:22'),(949,'Malou Ang','Logged in','2018-12-12 14:24:55'),(950,'Malou Ang','Logged in','2018-12-12 14:25:27'),(951,'Malou Ang','Logged in','2018-12-12 14:25:52'),(952,'Malou Ang','Logged in','2018-12-12 14:26:37'),(953,'Malou Ang','Logged in','2018-12-12 14:26:59'),(954,'Malou Ang','Logged in','2018-12-12 14:27:49'),(955,'Malou Ang','Updated Request sub ID  28','2018-12-12 14:28:02'),(956,'Malou Ang','Logged in','2018-12-12 14:28:15'),(957,'Malou Ang','Updated Request sub ID  28','2018-12-12 14:29:00'),(958,'admin','Logged in','2018-12-12 14:29:11'),(959,'Malou Ang','Logged in','2018-12-12 14:29:25'),(960,'Malou Ang','Updated Request sub ID  28','2018-12-12 14:29:38'),(961,'admin','Logged in','2018-12-12 14:29:49'),(962,'admin','Logged in','2018-12-12 14:35:13'),(963,'admin','Logged in','2018-12-12 14:36:09'),(964,'Malou Ang','Logged in','2018-12-12 14:36:50'),(965,'Malou Ang','Updated Request sub ID  28','2018-12-12 14:37:13'),(966,'Malou Ang','Logged in','2018-12-12 14:37:30'),(967,'Malou Ang','Logged in','2018-12-12 14:37:51'),(968,'Malou Ang','Updated Request sub ID  28','2018-12-12 14:38:09'),(969,'Malou Ang','Updated Request sub ID  28','2018-12-12 14:38:36'),(970,'Malou Ang','Updated Request sub ID  28','2018-12-12 14:39:01'),(971,'Malou Ang','Updated Request sub ID  28','2018-12-12 14:39:17'),(972,'Malou Ang','Logged in','2018-12-12 14:39:58'),(973,'Malou Ang','Logged in','2018-12-12 14:42:17'),(974,'Malou Ang','Logged in','2018-12-12 14:44:11'),(975,'Malou Ang','Logged in','2018-12-12 14:45:54'),(976,'Malou Ang','Logged in','2018-12-12 14:47:07'),(977,'Malou Ang','Updated Request ID  18-0016','2018-12-12 14:47:50'),(978,'Malou Ang','Added Request sub of request ID 33','2018-12-12 14:48:07'),(979,'Malou Ang','Updated Request sub ID  61','2018-12-12 14:48:12'),(980,'Malou Ang','Logged in','2018-12-12 14:48:53'),(981,'Malou Ang','Logged in','2018-12-12 15:02:43'),(982,'Malou Ang','Logged in','2018-12-12 15:04:46'),(983,'Malou Ang','Logged in','2018-12-12 15:06:07'),(984,'Malou Ang','Logged in','2018-12-12 15:06:26'),(985,'Malou Ang','Logged in','2018-12-12 15:07:13'),(986,'Malou Ang','Logged in','2018-12-12 15:18:30'),(987,'admin','Logged in','2018-12-12 15:25:04'),(988,'Malou Ang','Logged in','2018-12-12 16:12:00'),(989,'Malou Ang','Generate Reports from Volunteer Activities ','2018-12-12 16:12:45'),(990,'Malou Ang','Updated LPI id 3033','2018-12-12 16:13:07'),(991,'Malou Ang','Logged in','2018-12-12 16:13:14'),(992,'admin','Logged in','2018-12-12 16:13:58'),(993,'admin','Updated Volunteer id 19-0007','2018-12-12 16:15:21'),(994,'admin','Updated Request ID  18-0001','2018-12-12 16:15:32'),(995,'admin','Generate Reports from Volunteer Activities ','2018-12-12 16:16:09'),(996,'admin','Generate Reports from Volunteer Activities ','2018-12-12 16:16:16'),(997,'Malou Ang','Logged in','2018-12-13 08:13:28'),(998,'Malou Ang','Logged in','2018-12-13 10:49:58'),(999,'Malou Ang','Logged in','2018-12-13 11:24:28'),(1000,'Malou Ang','Generate Reports from Volunteer Activities ','2018-12-13 11:28:11'),(1001,'admin','Logged in','2018-12-13 11:28:24'),(1002,'admin','Updated Request ID  18-0022','2018-12-13 11:28:59'),(1003,'admin','Updated Volunteer id 19-0009','2018-12-13 11:29:49'),(1004,'admin','Updated Volunteer id 19-0008','2018-12-13 11:32:29'),(1005,'admin','Logged in','2018-12-13 11:32:46'),(1006,'Malou Ang','Logged in','2018-12-13 13:25:27'),(1007,'Malou Ang','Updated LPI id 27','2018-12-13 13:25:56'),(1008,'admin','Logged in','2018-12-13 13:29:12'),(1009,'admin','Logged in','2018-12-13 15:01:21'),(1010,'admin','Updated Volunteer id 19-0010','2018-12-13 15:01:58'),(1011,'admin','Generate Reports from Volunteer Activities ','2018-12-13 15:02:11'),(1012,'admin','Updated Project id 1','2018-12-13 15:02:37'),(1013,'Johnny Thor','Logged in','2018-12-13 15:40:43'),(1014,'Johnny Thor','Updated LPI id 3029','2018-12-13 15:41:13'),(1015,'admin','Logged in','2018-12-14 13:42:10'),(1016,'admin','Logged in','2018-12-14 13:48:08'),(1017,'admin','Logged in','2018-12-14 13:52:45'),(1018,'admin','Logged in','2018-12-14 13:53:01'),(1019,'admin','Updated Volunteer id 19-0012','2018-12-14 13:53:39'),(1020,'admin','Updated Volunteer id 19-0011','2018-12-14 13:54:00'),(1021,'admin','Updated Volunteer id 19-0010','2018-12-14 13:54:06'),(1022,'admin','Updated Volunteer id 19-0009','2018-12-14 13:54:12'),(1023,'admin','Updated Volunteer id 19-0008','2018-12-14 13:54:17'),(1024,'admin','Updated Volunteer id 19-0007','2018-12-14 13:54:23'),(1025,'admin','Updated Volunteer id 19-0006','2018-12-14 13:54:31'),(1026,'admin','Updated Volunteer id 19-0005','2018-12-14 13:54:46'),(1027,'admin','Updated Volunteer id 19-0004','2018-12-14 13:54:53'),(1028,'admin','Updated Volunteer id 19-0003','2018-12-14 13:55:00'),(1029,'admin','Updated Volunteer id 19-0002','2018-12-14 13:55:09'),(1030,'admin','Updated Volunteer id 18-0012','2018-12-14 13:55:26'),(1031,'admin','Updated Volunteer id 17-0001','2018-12-14 13:55:31'),(1032,'admin','Updated Volunteer id 19-0001','2018-12-14 13:55:37'),(1033,'admin','Updated Volunteer id 18-0009','2018-12-14 13:55:48'),(1034,'admin','Updated Volunteer id 17-0003','2018-12-14 13:55:55'),(1035,'admin','Updated Volunteer id 18-0003','2018-12-14 13:56:00'),(1036,'admin','Updated Volunteer id 18-0006','2018-12-14 13:56:05'),(1037,'admin','Updated Volunteer id 18-0008','2018-12-14 13:56:09'),(1038,'admin','Updated Volunteer id 17-0004','2018-12-14 13:56:16'),(1039,'admin','Updated Volunteer id 17-0005','2018-12-14 13:56:23'),(1040,'admin','Updated Volunteer id 17-0006','2018-12-14 13:56:30'),(1041,'admin','Updated Volunteer id 18-0004','2018-12-14 13:56:36'),(1042,'admin','Updated Volunteer id 17-0002','2018-12-14 13:56:42'),(1043,'admin','Updated Volunteer id 18-0021','2018-12-14 13:56:48'),(1044,'admin','Updated Volunteer id 12-0001','2018-12-14 13:56:56'),(1045,'admin','Updated Volunteer id 18-0034','2018-12-14 13:57:02'),(1046,'admin','Updated Volunteer id 18-0002','2018-12-14 13:57:22'),(1047,'admin','Updated Volunteer id 18-0011','2018-12-14 13:57:27'),(1048,'admin','Updated Volunteer id 18-0001','2018-12-14 13:57:34'),(1049,'admin','Generate Reports from Volunteer Activities ','2018-12-14 13:58:07'),(1050,'admin','Logged in','2018-12-14 13:59:13'),(1051,'admin','Restore Volunteer ID  18-0005','2018-12-14 13:59:22'),(1052,'admin','Added Request sub of request ID 25','2018-12-14 14:00:10'),(1053,'admin','Logged in','2018-12-14 14:02:40'),(1054,'admin','Updated Volunteer id 19-0009','2018-12-14 14:02:48'),(1055,'admin','Logged in','2018-12-14 14:14:12'),(1056,'Johnny Thor','Logged in','2018-12-14 14:18:47'),(1057,'Johnny Thor','Updated Volunteer id 19-0010','2018-12-14 14:19:11'),(1058,'admin','Logged in','2018-12-14 14:31:25'),(1059,'admin','Updated Volunteer id 19-0007','2018-12-14 14:31:56'),(1060,'admin','Updated LPI id 3032','2018-12-14 14:32:23'),(1061,'admin','Logged in','2018-12-14 15:11:46'),(1062,'admin','Updated Volunteer id 19-0012','2018-12-14 15:12:13'),(1063,'admin','Logged in','2018-12-14 15:12:49'),(1064,'admin','Updated Volunteer id 19-0012','2018-12-14 15:13:01'),(1065,'admin','Added a Project for LPI ID 10','2018-12-14 15:33:59'),(1066,'admin','Updated Volunteer id 19-0009','2018-12-14 15:35:39'),(1067,'admin','Updated Volunteer id 17-0001','2018-12-14 15:37:08'),(1068,'admin','Logged in','2018-12-14 15:51:29'),(1069,'admin','Logged in','2018-12-14 15:53:05'),(1070,'admin','Logged in','2018-12-14 15:53:36'),(1071,'admin','Logged in','2018-12-14 15:55:52'),(1072,'admin','Logged in','2018-12-14 15:59:34'),(1073,'admin','Logged in','2018-12-14 16:00:28'),(1074,'admin','Logged in','2018-12-14 16:02:17'),(1075,'admin','Updated Volunteer id 19-0010','2018-12-14 16:05:55'),(1076,'admin','Logged in','2018-12-14 16:08:19'),(1077,'admin','Logged in','2018-12-14 16:08:58'),(1078,'admin','Logged in','2018-12-14 16:09:19'),(1079,'admin','Logged in','2018-12-14 16:09:44'),(1080,'admin','Logged in','2018-12-14 16:17:34'),(1081,'admin','Logged in','2018-12-14 16:18:14'),(1082,'admin','Updated Volunteer id 17-0001','2018-12-14 16:18:47'),(1083,'admin','Logged in','2018-12-14 16:21:42'),(1084,'admin','Updated Volunteer id 17-0002','2018-12-14 16:22:20'),(1085,'admin','Updated Volunteer id 18-0003','2018-12-14 16:22:46'),(1086,'admin','Logged in','2018-12-14 16:23:44'),(1087,'admin','Updated Volunteer id 17-0002','2018-12-14 16:23:53'),(1088,'admin','Logged in','2018-12-14 16:25:03'),(1089,'admin','Updated Volunteer id 17-0002','2018-12-14 16:25:23'),(1090,'admin','Updated Volunteer id 17-0002','2018-12-14 16:25:29'),(1091,'admin','Updated Volunteer id 17-0002','2018-12-14 16:25:33'),(1092,'admin','Logged in','2018-12-14 16:27:31'),(1093,'admin','Updated Volunteer id 17-0002','2018-12-14 16:27:45'),(1094,'admin','Updated Volunteer id 17-0002','2018-12-14 16:28:25'),(1095,'admin','Logged in','2018-12-14 16:30:50'),(1096,'admin','Updated Volunteer id 17-0003','2018-12-14 16:31:17'),(1097,'admin','Logged in','2018-12-14 16:33:31'),(1098,'admin','Logged in','2018-12-14 16:34:32'),(1099,'admin','Updated Volunteer id 17-0004','2018-12-14 16:35:18'),(1100,'admin','Updated Volunteer id 17-0004','2018-12-14 16:35:26'),(1101,'admin','Logged in','2018-12-14 16:38:00'),(1102,'admin','Updated Volunteer id 17-0005','2018-12-14 16:38:45'),(1103,'admin','Updated Volunteer id 17-0005','2018-12-14 16:38:48'),(1104,'admin','Logged in','2018-12-14 16:39:55'),(1105,'admin','Updated Volunteer id 17-0006','2018-12-14 16:40:23'),(1106,'admin','Logged in','2018-12-14 16:40:59'),(1107,'admin','Updated Volunteer id 17-0006','2018-12-14 16:41:18'),(1108,'admin','Logged in','2018-12-14 16:41:57'),(1109,'admin','Updated Volunteer id 18-0001','2018-12-14 16:42:21'),(1110,'admin','Logged in','2018-12-14 16:43:42'),(1111,'admin','Logged in','2018-12-14 16:48:30'),(1112,'admin','Updated Volunteer id 19-0003','2018-12-14 16:48:58'),(1113,'admin','Logged in','2018-12-14 16:50:12'),(1114,'admin','Logged in','2018-12-14 16:50:33'),(1115,'admin','Updated Volunteer id 19-0008','2018-12-14 16:50:57'),(1116,'admin','Logged in','2018-12-14 16:52:34'),(1117,'admin','Updated Volunteer id 19-0001','2018-12-14 16:53:01'),(1118,'admin','Logged in','2018-12-17 08:20:36'),(1119,'admin','Updated Volunteer id 18-0011','2018-12-17 08:21:15'),(1120,'admin','Logged in','2018-12-17 08:26:01'),(1121,'admin','Updated Volunteer id 19-0007','2018-12-17 08:26:50'),(1122,'admin','Logged in','2018-12-17 08:28:34'),(1123,'admin','Logged in','2018-12-17 08:45:45'),(1124,'admin','Updated Volunteer id 18-0011','2018-12-17 08:45:52'),(1125,'admin','Updated Volunteer id 19-0011','2018-12-17 08:45:57'),(1126,'admin','Updated Volunteer id 19-0010','2018-12-17 08:46:00'),(1127,'admin','Logged in','2018-12-17 09:05:49'),(1128,'admin','Updated Volunteer id 19-0001','2018-12-17 09:06:46'),(1129,'admin','Logged in','2018-12-17 09:07:42'),(1130,'admin','Updated Volunteer id 18-0012','2018-12-17 09:08:16'),(1131,'admin','Logged in','2018-12-17 09:09:12'),(1132,'admin','Updated Volunteer id 19-0002','2018-12-17 09:09:59'),(1133,'admin','Logged in','2018-12-17 09:11:06'),(1134,'admin','Generate Reports from RFV Records','2018-12-17 09:11:34'),(1135,'admin','Generate Reports from RFV Records','2018-12-17 09:11:34'),(1136,'admin','Generate Reports from Volunteer Activities ','2018-12-17 09:11:40'),(1137,'admin','Logged in','2018-12-17 09:16:44'),(1138,'admin','Updated Volunteer id 19-0005','2018-12-17 09:17:14'),(1139,'Johnny Thor','Logged in','2018-12-17 09:17:50'),(1140,'Johnny Thor','Updated Volunteer id 19-0009','2018-12-17 09:18:24'),(1141,'Johnny Thor','Logged in','2018-12-17 09:18:50'),(1142,'Johnny Thor','Updated Volunteer id 19-0010','2018-12-17 09:19:23'),(1143,'Johnny Thor','Logged in','2018-12-17 09:20:11'),(1144,'Johnny Thor','Updated Volunteer id 19-0011','2018-12-17 09:20:25'),(1145,'Johnny Thor','Updated Request ID  18-0020','2018-12-17 09:21:33'),(1146,'Johnny Thor','Updated Volunteer id 19-0012','2018-12-17 09:23:14'),(1147,'Johnny Thor','Updated Volunteer id 18-0009','2018-12-17 09:26:21'),(1148,'Johnny Thor','Logged in','2018-12-17 09:27:31'),(1149,'Johnny Thor','Logged in','2018-12-17 09:28:34'),(1150,'Johnny Thor','Logged in','2018-12-17 09:29:46'),(1151,'Johnny Thor','Logged in','2018-12-17 09:30:39'),(1152,'Johnny Thor','Logged in','2018-12-17 09:31:30'),(1153,'Johnny Thor','Logged in','2018-12-17 09:35:10'),(1154,'Johnny Thor','Updated Volunteer id 18-0034','2018-12-17 09:35:25'),(1155,'Johnny Thor','Updated Volunteer id 18-0008','2018-12-17 09:36:04'),(1156,'Johnny Thor','Logged in','2018-12-17 09:36:54'),(1157,'Johnny Thor','Updated Volunteer id 18-0004','2018-12-17 09:37:26'),(1158,'Johnny Thor','Logged in','2018-12-17 09:44:01'),(1159,'Johnny Thor','Logged in','2018-12-17 09:55:42'),(1160,'Johnny Thor','added Volunteer','2018-12-17 09:56:17'),(1161,'Johnny Thor','Updated Volunteer id 19-0013','2018-12-17 09:56:58'),(1162,'Johnny Thor','Updated Volunteer id 19-0014','2018-12-17 09:57:11'),(1163,'Johnny Thor','Updated Volunteer id 19-0013','2018-12-17 09:57:24'),(1164,'Johnny Thor','Logged in','2018-12-17 09:58:19'),(1165,'Johnny Thor','Updated Volunteer id 19-0014','2018-12-17 09:58:25'),(1166,'Johnny Thor','Updated Volunteer id 19-0013','2018-12-17 09:58:34'),(1167,'Johnny Thor','Logged in','2018-12-17 10:09:36'),(1168,'Johnny Thor','Logged in','2018-12-17 10:14:04'),(1169,'Johnny Thor','Logged in','2018-12-17 10:16:13'),(1170,'Johnny Thor','Generate Reports from RFV Records','2018-12-17 10:16:33'),(1171,'Johnny Thor','Generate Reports from RFV Records','2018-12-17 10:16:34'),(1172,'Johnny Thor','Updated Volunteer id 19-0006','2018-12-17 10:21:41'),(1173,'Johnny Thor','Updated Volunteer id 19-0010','2018-12-17 10:22:48'),(1174,'Johnny Thor','Updated Volunteer id 19-0011','2018-12-17 10:53:26'),(1175,'Johnny Thor','Updated Volunteer id 19-0011','2018-12-17 10:53:57'),(1176,'Johnny Thor','Updated Volunteer id 19-0011','2018-12-17 10:54:06'),(1177,'Johnny Thor','Logged in','2018-12-17 10:55:16'),(1178,'Johnny Thor','Updated Volunteer id 19-0013','2018-12-17 10:55:36'),(1179,'Johnny Thor','Logged in','2018-12-17 10:56:11'),(1180,'Johnny Thor','Updated Volunteer id 19-0008','2018-12-17 10:56:19'),(1181,'Johnny Thor','Updated Volunteer id 19-0003','2018-12-17 10:56:31'),(1182,'Johnny Thor','Logged in','2018-12-17 10:56:41'),(1183,'Johnny Thor','Updated Volunteer id 19-0007','2018-12-17 10:57:05'),(1184,'Johnny Thor','Updated Volunteer id 19-0007','2018-12-17 10:57:08'),(1185,'Johnny Thor','Updated Volunteer id 19-0006','2018-12-17 10:57:27'),(1186,'Johnny Thor','Updated Volunteer id 18-0002','2018-12-17 10:57:39'),(1187,'Johnny Thor','Updated Volunteer id 19-0012','2018-12-17 10:58:31'),(1188,'Johnny Thor','Logged in','2018-12-17 10:58:44'),(1189,'Johnny Thor','Updated Volunteer id 19-0006','2018-12-17 10:58:57'),(1190,'Johnny Thor','Updated Volunteer id 19-0002','2018-12-17 11:01:25'),(1191,'Johnny Thor','Updated Volunteer id 18-0009','2018-12-17 11:02:04'),(1192,'admin','Logged in','2018-12-17 11:17:59'),(1193,'Johnny Thor','Logged in','2018-12-17 13:04:12'),(1194,'Johnny Thor','Updated Request ID  19-0001','2018-12-17 13:04:19'),(1195,'Johnny Thor','Logged in','2018-12-17 13:13:34'),(1196,'Johnny Thor','Deleted LPI id 3033','2018-12-17 13:34:35'),(1197,'Johnny Thor','Deleted LPI id 3032','2018-12-17 13:34:39'),(1198,'Johnny Thor','Deleted LPI id 3029','2018-12-17 13:34:57'),(1199,'Johnny Thor','Updated LPI id 3','2018-12-17 13:47:12'),(1200,'Johnny Thor','Updated Volunteer id 19-0013','2018-12-17 13:48:11'),(1201,'Johnny Thor','Updated Request ID  18-0022','2018-12-17 13:48:46'),(1202,'Johnny Thor','Updated Volunteer id 19-0007','2018-12-17 13:50:53'),(1203,'admin','Logged in','2018-12-17 13:56:56'),(1204,'admin','Updated Request ID  18-0019','2018-12-17 13:57:07'),(1205,'admin','Logged in','2018-12-17 13:59:26'),(1206,'admin','Updated Request ID  18-0021','2018-12-17 13:59:35'),(1207,'admin','Logged in','2018-12-17 14:05:55'),(1208,'admin','Updated Project id 11','2018-12-17 14:06:14'),(1209,'admin','Logged in','2018-12-17 14:16:40'),(1210,'admin','Logged in','2018-12-17 14:17:37'),(1211,'admin','Logged in','2018-12-17 14:21:34'),(1212,'admin','Updated LPI id 8','2018-12-17 14:21:57'),(1213,'admin','Updated Volunteer id 19-0005','2018-12-17 14:41:58'),(1214,'admin','Updated Volunteer id 19-0007','2018-12-17 14:42:02'),(1215,'admin','Logged in','2018-12-17 14:46:12'),(1216,'admin','Logged in','2018-12-17 14:48:04'),(1217,'admin','Logged in','2018-12-17 14:56:15'),(1218,'admin','Logged in','2018-12-17 14:58:40'),(1219,'admin','Updated Volunteer id 19-0013','2018-12-17 14:58:43'),(1220,'Johnny Thor','Logged in','2018-12-17 14:59:38'),(1221,'admin','Logged in','2018-12-17 15:00:04'),(1222,'admin','Updated Volunteer id 19-0011','2018-12-17 15:08:04'),(1223,'admin','Logged in','2018-12-17 15:18:41'),(1224,'admin','Logged in','2018-12-17 15:32:21'),(1225,'admin','Logged in','2018-12-17 15:32:57'),(1226,'admin','Logged in','2018-12-17 15:33:31'),(1227,'admin','Logged in','2018-12-17 15:34:51'),(1228,'Johnny Thor','Logged in','2018-12-17 15:48:45'),(1229,'admin','Logged in','2018-12-17 15:55:23'),(1230,'admin','Updated Request sub ID  60','2018-12-17 15:55:58'),(1231,'admin','Updated LPI id 1','2018-12-17 15:57:26'),(1232,'admin','Updated Project id 1','2018-12-17 15:57:41'),(1233,'admin','Logged in','2018-12-18 08:22:42'),(1234,'admin','Updated Request ID  18-0005','2018-12-18 08:22:50');

/*Table structure for table `t_municipality_city` */

DROP TABLE IF EXISTS `t_municipality_city`;

CREATE TABLE `t_municipality_city` (
  `mun/city_id` int(10) NOT NULL AUTO_INCREMENT,
  `mun/city_dsc` varchar(50) DEFAULT NULL,
  `province_id` int(10) DEFAULT NULL,
  `class_id` int(10) DEFAULT NULL,
  PRIMARY KEY (`mun/city_id`),
  KEY `prov_id` (`mun/city_id`),
  KEY `region_id` (`province_id`)
) ENGINE=InnoDB AUTO_INCREMENT=192 DEFAULT CHARSET=utf8;

/*Data for the table `t_municipality_city` */

insert  into `t_municipality_city`(`mun/city_id`,`mun/city_dsc`,`province_id`,`class_id`) values (1,'Baay-Licuan',69,2),(2,'Boliney',69,2),(3,'Bucay',69,2),(4,'Bucloc',69,3),(5,'Daguioman',69,3),(6,'Danglas',69,2),(7,'Dolores',69,2),(8,'La Paz',69,2),(9,'Lacub',69,2),(10,'Lagangilang',69,2),(11,'Lagayan',69,2),(12,'Langiden',69,2),(13,'Luba',69,2),(14,'Malibcong',69,2),(15,'Manabo',69,2),(16,'Pennarubia',69,2),(17,'Pidigan',69,2),(18,'Pilar',69,2),(19,'Sallapadan',69,2),(20,'San Isidro',69,3),(21,'San Juan',69,2),(22,'San Quintin',69,2),(23,'Tayum',69,2),(24,'Tineg',69,1),(25,'Tubo',69,1),(26,'Villaviciosa',69,2),(27,'Flora',70,1),(28,'Pudtol',70,1),(29,'Sta. Marcela',70,2),(30,'Atok',71,1),(31,'Bakun',71,1),(32,'Bokod',71,1),(33,'Buguias',71,1),(34,'Kabayan',71,2),(35,'Kapangan',71,2),(36,'Kibungan',71,1),(37,'Mankayan',71,1),(38,'Sablan',71,2),(39,'Tublay',71,2),(40,'Aguinaldo',72,1),(41,'Alfonso Lista',72,1),(42,'Asipulo',72,2),(43,'Banaue',72,1),(44,'Hingyon',72,2),(45,'Hungduan',72,2),(46,'Kiangan',72,1),(47,'Lagawe',72,1),(48,'Lamut',72,1),(49,'Mayoyao',72,1),(50,'Tinoc',72,2),(51,'Kalinga',72,3),(52,'Balbalan',72,1),(53,'Lubuagan',72,1),(54,'Pasil',72,2),(55,'Rizal',72,2),(56,'Tanudan',72,1),(57,'Tinglayan',72,2),(58,'Barlig',74,2),(59,'Bauko',74,1),(60,'Besao',74,2),(61,'Bontoc',74,1),(62,'Natonin',74,1),(63,'Paracelis',74,1),(64,'Sabangan',74,2),(65,'Sadanga',74,2),(66,'Sagada',74,2),(67,'Tadian',74,1),(68,'Adams',1,2),(69,'Bacarra',1,1),(70,'Badoc',1,1),(71,'Bangui',1,1),(72,'Burgos',1,2),(73,'Carasi',1,2),(74,'Currimao',1,2),(75,'Dingras',1,1),(76,'Dumalneg',1,2),(77,'Espiritu/Banna',1,1),(78,'Marcos',1,1),(79,'Nueva Era',1,1),(80,'Pagudpud',1,1),(81,'Paoay',1,1),(82,'Pasuquin',1,1),(83,'Piddig',1,1),(84,'Pinili',1,2),(85,'San Nicolas',1,1),(86,'Sarrat',1,1),(87,'Solsona',1,1),(88,'Alilem',2,2),(89,'Banayoyo',2,2),(90,'Bantay',2,1),(91,'Burgos',2,1),(92,'Caoayan',2,2),(93,'Cervantes',2,1),(94,'G. Del Pilar',2,2),(95,'Galimuyod',2,1),(96,'Lidlida',2,2),(97,'Magsingal',2,1),(98,'Nagbukel',2,2),(99,'Quirino',2,1),(100,'Salcedo',2,1),(101,'San Emilio',2,1),(102,'San EstebanB',2,2),(103,'San Ildefonso',2,2),(104,'San Juan',2,1),(105,'San Vicente',2,2),(106,'Santa',2,1),(107,'Santiago',2,1),(108,'Sigay',2,2),(109,'Sta. Catalina',2,2),(110,'Sta. Cruz',2,1),(111,'Sto. Domingo',2,1),(112,'Sugpon',2,2),(113,'Suyo',2,1),(114,'Tagudin',2,1),(115,'Bagulin',3,2),(116,'Burgos',3,2),(117,'Caba',3,1),(118,'Luna',3,1),(119,'Pugo',3,2),(120,'San Gabriel',3,1),(121,'Santol',3,2),(122,'Sto Tomas',3,1),(123,'Sudipen',3,1),(124,'Tubao',3,1),(125,'Agno',4,1),(126,'Aguilar',4,1),(127,'Alcala',4,1),(128,'Anda',4,1),(129,'Balungao',4,1),(130,'Basista',4,2),(131,'Bautista',4,2),(132,'Burgos',4,2),(133,'Dasol',4,1),(134,'Infanta',4,1),(135,'Labrador',4,2),(136,'Laoac',4,2),(137,'Mabini',4,1),(138,'Mapandan',4,1),(139,'Natividad',4,2),(140,'San Jacinto',4,1),(141,'San Manuel',4,1),(142,'San Nicolas',4,1),(143,'San Quintin',4,1),(144,'Sison',4,1),(145,'Sta. Maria',4,1),(146,'Sto. Tomas',4,2),(147,'Tayug',4,1),(148,'Urbiztondo',4,1),(149,'Angadanan',7,1),(150,'Aurora',7,1),(151,'Benito Soliven',7,1),(152,'Burgos',7,2),(153,'Cabatuan',7,1),(154,'Delfin Albano',7,1),(155,'Divilican',7,1),(156,'Gamu',7,1),(157,'Gordon',7,1),(158,'Luna',7,2),(159,'Maconacon',7,1),(160,'Mallig',7,1),(161,'Naguilian',7,1),(162,'Quezon',7,1),(163,'Quirino',7,2),(164,'Reina Mercedes',7,2),(165,'San Agustin',7,1),(166,'San Guillermo',7,2),(167,'San Isidro',7,2),(168,'San Manuel',7,1),(169,'Sta. Maria',7,2),(170,'Sto. Tomas',7,2),(171,'A. Castañeda',8,2),(172,'Ambaguio',8,2),(173,'Diadi',8,1),(174,'Dupax del Norte',8,1),(175,'Dupax del Sur',8,1),(176,'Kasibu',8,0),(177,'Kayapa',8,1),(178,'Quezon',8,2),(179,'Sta. Fe',8,1),(180,'Villaverde',8,2),(181,'Aglipay',9,1),(182,'Cabarroguis',9,1),(183,'Saguday',9,2),(184,'Basco',5,2),(185,'Itbayat',5,2),(186,'Ivana',5,3),(187,'Mahatao',5,3),(188,'Sabtang',5,3),(189,'Uyugan',5,3),(190,'Abulog',0,0),(191,'Alcala',0,0);

/*Table structure for table `t_perf_rating` */

DROP TABLE IF EXISTS `t_perf_rating`;

CREATE TABLE `t_perf_rating` (
  `rating ID` int(10) NOT NULL AUTO_INCREMENT,
  `rating` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`rating ID`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;

/*Data for the table `t_perf_rating` */

insert  into `t_perf_rating`(`rating ID`,`rating`) values (1,'Outstanding'),(2,'Very Satisfactory'),(3,'Satisfactory'),(4,'Fair'),(5,'Poor');

/*Table structure for table `t_program_type` */

DROP TABLE IF EXISTS `t_program_type`;

CREATE TABLE `t_program_type` (
  `Program_type_id` int(10) NOT NULL AUTO_INCREMENT,
  `Program_Type` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`Program_type_id`),
  KEY `Program_id` (`Program_type_id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

/*Data for the table `t_program_type` */

insert  into `t_program_type`(`Program_type_id`,`Program_Type`) values (1,'Local'),(2,'International');

/*Table structure for table `t_project` */

DROP TABLE IF EXISTS `t_project`;

CREATE TABLE `t_project` (
  `project_id` int(10) NOT NULL AUTO_INCREMENT,
  `host_org_id` int(10) DEFAULT NULL,
  `proj_title` varchar(255) DEFAULT NULL,
  `proj_mgr` varchar(255) DEFAULT NULL,
  `proj_duration` varchar(255) DEFAULT NULL,
  `proj_address_no` varchar(255) DEFAULT NULL,
  `proj_address_street` varchar(255) DEFAULT NULL,
  `mun_city` varchar(255) DEFAULT NULL,
  `prov_id` int(10) DEFAULT NULL,
  `region_id` int(10) DEFAULT NULL,
  `bugdet` varchar(255) DEFAULT NULL,
  `source_fund` varchar(255) DEFAULT NULL,
  `objective` text DEFAULT NULL,
  `date_start` varchar(255) DEFAULT NULL,
  `date_end` varchar(255) DEFAULT NULL,
  `date_created` datetime DEFAULT NULL,
  `target_benificiaries` varchar(255) DEFAULT NULL,
  `proj_position` varchar(255) DEFAULT NULL,
  `proj_contactNo` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`project_id`),
  KEY `host_org_id` (`host_org_id`),
  KEY `NORM_OrderByIndex` (`proj_title`,`proj_mgr`)
) ENGINE=InnoDB AUTO_INCREMENT=7196 DEFAULT CHARSET=utf8;

/*Data for the table `t_project` */

insert  into `t_project`(`project_id`,`host_org_id`,`proj_title`,`proj_mgr`,`proj_duration`,`proj_address_no`,`proj_address_street`,`mun_city`,`prov_id`,`region_id`,`bugdet`,`source_fund`,`objective`,`date_start`,`date_end`,`date_created`,`target_benificiaries`,`proj_position`,`proj_contactNo`) values (1,1,'Assessment of the Squid Resources of Visayan Sea and Vicinities','shariif karif','24','12','Barotac Nuevo','st bernard',1,1,'100000','government','hep hep hooooray!','2018-10-08','2018-10-29','2018-10-08 00:00:00','youth','coordinator','093671477979'),(3,5,'Biak na Bato National Park','nigguh','6','111','Bgy. Sibul,','111',37,6,'1233','goverrment','hep hep hooray! hahkdg','2018-10-28','2018-10-27','2018-10-27 00:00:00','youth','Coordinato','545-124234-234'),(4,5,'Bohol Loomweaving Development Programme','Maah Boy Mah Meeeen','12','12','Brgy. Irawan,','12',41,7,'33333','governmemnt','hep hep hooray!','2018-10-16','2018-12-29','2018-10-15 00:00:00','mother earth','Coordinator','09121233331'),(5,15,'Breeder Base Expansion Program',NULL,NULL,'000','Brgy. Irawan,','Puerto Princesa, ',13,4,'10000','barangay','hep hep hooray!','2018-10-08','2019-02-22','2018-10-23 00:00:00',NULL,NULL,NULL),(6,2,'Composite Forestry System & Coffee Cultivation Project',NULL,NULL,NULL,'Brgy. Sag-ang','La Castellana',1,1,NULL,NULL,NULL,'2018-10-24','2018-10-23','2018-10-16 00:00:00',NULL,NULL,NULL),(7,2,'Computer Hardware Technology, Upgrading and Repair',NULL,NULL,NULL,'Bgy. Hamorawon,','Calbayog City',1,1,NULL,NULL,NULL,'2018-10-24','2018-10-08','2018-10-26 00:00:00',NULL,NULL,NULL),(8,23,'CVPC Agroforestry Project',NULL,NULL,'Sitio So-oc','Bgy. Masbate','Ayungon',1,1,NULL,NULL,NULL,'2018-10-08','2018-10-24','2018-10-24 00:00:00',NULL,NULL,NULL),(11,4,'San Jose Del Monte Bulacan Kooperatiba Ng Bayan','Ronnie Chy','1','11112','111','11112',31,5,'10000','Government','to test the system at its finest','2018-10-15','2019-02-22','2018-10-09 00:00:00','youth','awit','09166666123'),(7184,13,'Alternative Learning System','Ronnie Chy','12','12','San Mateo','San Luis',24,4,'10,000','Na','test','3rd week May','','2018-10-24 00:00:00','Youth',NULL,NULL),(7186,14,'Test','Test','Test','Test','Test','Test',23,4,'Test','Test','test','test','test','2018-11-05 00:00:00','Test',NULL,NULL),(7188,3028,'Oplan Tokhang','Ronnie Chy','12','76','San Lucas','San Jose Del Monte',11,3,'1000','Government','n/a','june 25',NULL,'2018-11-09 00:00:00','Youth','ceo','091233123'),(7190,8,'Awit','Ng','Panahon','12','San','Jose',49,9,'1k','Community','awit','ng',NULL,'2018-11-21 11:32:43','Kabataan','Kabataan','Awit'),(7191,3030,'Feeding Program','Ronnie Chy','24','78','Saksak','Tagok',11,3,'100k','Community','test','June 2018',NULL,'2018-11-21 15:41:02','Youth','Cooridantr','09367147913'),(7192,3032,'test','','','','','',1,1,'','','','',NULL,'2018-11-26 11:36:13','','',''),(7193,6,'The Ultimate Project','Ronnie Chy','12','12','Maginhawa','Quezon City',79,15,'1200000','Government','test remarks','june 26 2017',NULL,'2018-12-04 08:42:18','Youth','Coordinator','09154313131'),(7195,10,'Tarsier','Tarsier','Tarsier','Tarsier','Tarsier','Tarsier',38,7,'Tarsier','Tarsier','Tarsier Tarsier Tarsier Tarsier Tarsier Tarsier Tarsier Tarsier','Tarsier',NULL,'2018-12-14 15:33:59','Tarsier','Tarsier ','Tarsier ');

/*Table structure for table `t_province` */

DROP TABLE IF EXISTS `t_province`;

CREATE TABLE `t_province` (
  `prov_id` int(10) NOT NULL AUTO_INCREMENT,
  `prov_dsc` varchar(50) DEFAULT NULL,
  `region_id` int(10) DEFAULT NULL,
  `priority cluster_id` int(10) DEFAULT NULL,
  PRIMARY KEY (`prov_id`),
  KEY `priority cluster_id` (`priority cluster_id`),
  KEY `prov_id` (`prov_id`),
  KEY `region_id` (`region_id`)
) ENGINE=InnoDB AUTO_INCREMENT=83 DEFAULT CHARSET=utf8;

/*Data for the table `t_province` */

insert  into `t_province`(`prov_id`,`prov_dsc`,`region_id`,`priority cluster_id`) values (1,'Ilocos Norte',1,3),(2,'Ilocos Sur',1,3),(3,'La Union',1,3),(4,'Pangasinan',1,3),(5,'Batanes',2,3),(6,'Cagayan',2,3),(7,'Isabela',2,3),(8,'Nueva Vizcaya',2,3),(9,'Quirino',2,3),(10,'Bataan',3,3),(11,'Bulacan',3,3),(12,'Nueva Ecija',3,3),(13,'Pampanga',3,3),(14,'Tarlac',3,3),(15,'Zambales',3,3),(16,'Aurora',3,3),(17,'Batangas',4,3),(18,'Cavite',4,3),(19,'Laguna',4,3),(20,'Marinduque',17,2),(21,'Occidental Mindoro',17,3),(22,'Palawan',17,3),(23,'Quezon',4,3),(24,'Rizal',4,3),(25,'Romblon',17,1),(26,'Albay',5,1),(27,'Camarines Norte',5,2),(28,'Camarines Sur',5,1),(29,'Catanduanes',5,3),(30,'Masbate',5,1),(31,'Sorsogon',5,2),(32,'Aklan',6,1),(33,'Antique',6,2),(34,'Capiz',6,3),(35,'Iloilo',6,3),(36,'Negros Occidental',6,3),(37,'Guimaras',6,3),(38,'Bohol',7,1),(39,'Cebu',7,3),(40,'Negros Oriental',7,2),(41,'Siquijor',7,2),(42,'Biliran',8,2),(43,'Samar (Western Samar)',8,1),(44,'Eastern Samar',8,1),(45,'Leyte',8,2),(46,'Northern Samar',8,1),(47,'Southern Leyte',8,2),(48,'Basilan',16,3),(49,'Zamboanga del Norte',9,1),(50,'Zamboanga del Sur',9,3),(51,'Zamboanga Sibugay',9,1),(52,'Bukidnon',10,2),(53,'Camiguin',10,2),(54,'Misamis Occidental',10,1),(55,'Misamis Oriental',10,3),(56,'Davao del Norte',11,2),(57,'Davao del Sur',11,3),(58,'Davao Oriental',11,1),(59,'Sarangani',12,1),(60,'South Cotabato',12,3),(61,'Compostela Valley',11,2),(62,'North Cotabato',12,3),(63,'Lanao del Norte',10,1),(64,'Sultan Kudarat',12,2),(65,'Agusan del Norte',13,2),(66,'Agusan del Sur',13,1),(67,'Surigao del Norte',13,1),(68,'Surigao del Sur',13,2),(69,'Abra',14,2),(70,'Apayao',14,2),(71,'Benguet',14,3),(72,'Ifugao',14,3),(73,'Kalinga',14,3),(74,'Mt. Province',14,2),(75,'Lanao del Sur',16,1),(76,'Maguindanao',16,1),(77,'Sulu',16,1),(78,'Tawi-Tawi',16,2),(79,'Metro Manila',15,3),(80,'Oriental Mindoro',17,3),(81,'Western Samar',8,1),(82,'Dinagat Islands',13,3);

/*Table structure for table `t_region` */

DROP TABLE IF EXISTS `t_region`;

CREATE TABLE `t_region` (
  `region_id` int(10) NOT NULL AUTO_INCREMENT,
  `region_desc` varchar(50) DEFAULT NULL,
  `island_id` int(10) DEFAULT NULL,
  PRIMARY KEY (`region_id`),
  KEY `ID_REGION_DESC` (`region_desc`),
  KEY `island_id` (`island_id`)
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8;

/*Data for the table `t_region` */

insert  into `t_region`(`region_id`,`region_desc`,`island_id`) values (1,'I',1),(2,'II',1),(3,'III',1),(4,'IV-A',1),(5,'V',1),(6,'VI',2),(7,'VII',2),(8,'VIII',2),(9,'IX',3),(10,'X',3),(11,'XI',3),(12,'XII',3),(13,'XIII',3),(14,'CAR',1),(15,'NCR',1),(16,'ARMM',3),(17,'IV-B',1),(18,'NIR',2);

/*Table structure for table `t_reports` */

DROP TABLE IF EXISTS `t_reports`;

CREATE TABLE `t_reports` (
  `report_id` int(10) NOT NULL AUTO_INCREMENT,
  `report_wfp` date DEFAULT NULL,
  `report_placement` date DEFAULT NULL,
  `report_initial` date DEFAULT NULL,
  `report_annual` date DEFAULT NULL,
  `report_end` date DEFAULT NULL,
  `act_acomp` longtext DEFAULT NULL,
  `issue_concern` longtext DEFAULT NULL,
  `major_outputs` longtext DEFAULT NULL,
  `outcomes` longtext DEFAULT NULL,
  `recommend` longtext DEFAULT NULL,
  PRIMARY KEY (`report_id`)
) ENGINE=InnoDB AUTO_INCREMENT=63 DEFAULT CHARSET=latin1;

/*Data for the table `t_reports` */

insert  into `t_reports`(`report_id`,`report_wfp`,`report_placement`,`report_initial`,`report_annual`,`report_end`,`act_acomp`,`issue_concern`,`major_outputs`,`outcomes`,`recommend`) values (25,'2018-11-05','2018-10-23','2018-10-09','2018-10-16','2018-10-16','','','','',''),(27,'2018-11-23','2018-11-22','2018-11-21','2018-11-22','2018-11-22','','','','',''),(28,NULL,NULL,NULL,NULL,NULL,'','','','',''),(29,NULL,NULL,NULL,NULL,NULL,'act','issue','major','out','recomm'),(30,'2018-11-23','2018-11-15','2018-12-06','2018-11-22','2018-11-28','','','','',''),(31,NULL,NULL,NULL,NULL,NULL,'','','','',''),(32,'2018-10-30','2018-10-03','2018-10-16','2018-10-17','2018-10-24','','','','',''),(33,NULL,NULL,NULL,NULL,NULL,'','','','',''),(34,'2018-11-23','2018-11-23','2018-11-23','2018-11-24','2018-11-23','','','','',''),(35,NULL,NULL,NULL,NULL,NULL,'','','','',''),(37,NULL,NULL,NULL,NULL,NULL,'','','','',''),(38,NULL,NULL,NULL,NULL,NULL,'','','','',''),(40,NULL,NULL,NULL,NULL,NULL,'','','','',''),(42,NULL,NULL,NULL,NULL,NULL,'','','','',''),(43,NULL,NULL,NULL,NULL,NULL,'act','issu','major','outcome','recom'),(44,NULL,NULL,NULL,NULL,NULL,'','','','',''),(45,NULL,NULL,NULL,NULL,NULL,'','','','',''),(46,NULL,NULL,NULL,NULL,NULL,'','','','',''),(47,NULL,NULL,NULL,NULL,NULL,'','','','',''),(48,NULL,NULL,NULL,NULL,NULL,'','','','',''),(49,NULL,NULL,NULL,NULL,NULL,'','','','',''),(50,NULL,NULL,NULL,NULL,NULL,'','','','',''),(51,NULL,NULL,NULL,NULL,NULL,'','','','',''),(52,NULL,NULL,NULL,NULL,NULL,'test','','','',''),(53,'2018-11-22','2018-11-22','2018-11-16','2018-11-22','2018-11-29','','','','',''),(54,NULL,NULL,NULL,NULL,NULL,'','','','',''),(55,NULL,NULL,NULL,NULL,NULL,'','','','',''),(57,NULL,NULL,NULL,NULL,NULL,'','','','',''),(58,NULL,NULL,NULL,NULL,NULL,'','','','',''),(59,'2018-12-04','2018-12-05','2018-12-05','2018-12-05','2018-12-06','','','','',''),(60,'2018-12-17','2018-12-18','2018-12-06','2018-12-05','2018-12-12','','','','',''),(61,NULL,NULL,NULL,NULL,NULL,'','','','',''),(62,NULL,NULL,NULL,NULL,NULL,'','','','','');

/*Table structure for table `t_request` */

DROP TABLE IF EXISTS `t_request`;

CREATE TABLE `t_request` (
  `request_id` int(10) NOT NULL AUTO_INCREMENT,
  `ref_no` varchar(50) DEFAULT NULL,
  `request_status_id` int(10) DEFAULT NULL,
  `host_org_id` int(10) DEFAULT NULL,
  `project_id` int(10) DEFAULT NULL,
  `vol_org_id` int(10) DEFAULT NULL,
  `duration_vol_assistance` varchar(50) DEFAULT NULL,
  `assessed_by` varchar(50) DEFAULT NULL,
  `date_received` date DEFAULT NULL,
  `date_assessed` date DEFAULT NULL,
  `date_approved` date DEFAULT NULL,
  `remarks` text DEFAULT NULL,
  `complete_requirements` int(24) NOT NULL,
  `date_letter_intent` date DEFAULT NULL,
  `date_request_volunteer` date DEFAULT NULL,
  `date_site_assesment` date DEFAULT NULL,
  `sec_registration` varchar(255) DEFAULT NULL,
  `date_app_volorgr` date DEFAULT NULL,
  `date_completion` date DEFAULT NULL,
  `requirement_remarks` text DEFAULT NULL,
  `isActive` int(5) DEFAULT NULL,
  `date_created` datetime DEFAULT NULL,
  PRIMARY KEY (`request_id`),
  KEY `project_id` (`project_id`)
) ENGINE=InnoDB AUTO_INCREMENT=42 DEFAULT CHARSET=utf8;

/*Data for the table `t_request` */

insert  into `t_request`(`request_id`,`ref_no`,`request_status_id`,`host_org_id`,`project_id`,`vol_org_id`,`duration_vol_assistance`,`assessed_by`,`date_received`,`date_assessed`,`date_approved`,`remarks`,`complete_requirements`,`date_letter_intent`,`date_request_volunteer`,`date_site_assesment`,`sec_registration`,`date_app_volorgr`,`date_completion`,`requirement_remarks`,`isActive`,`date_created`) values (18,'18-0001',4,1,1,3,'12','admin','2018-11-22','2018-11-15','2018-11-22','test',1,'2018-11-08','2018-11-07','2018-11-13','23490-234-234','2018-10-31','2018-10-31','test',1,NULL),(19,'18-0002',1,5,3,4,'12','Johnny Thor',NULL,NULL,NULL,'',1,'2018-11-08','2018-11-29','2018-11-15','','2018-11-30','2018-11-14','',1,NULL),(20,'18-0003',4,1,1,1,'12','admin','2018-11-20','2018-11-20','2019-01-17','',1,'2018-11-06','2018-11-07','2018-11-21','123-09234-123','2018-11-08','2018-11-13','',1,NULL),(21,'18-0004',1,4,11,4,'12','Johnny Thor','2018-11-05','2018-11-14','2018-11-21','',1,'2018-11-07','2018-10-31','2018-11-08','','2018-11-30','2018-11-07','',1,NULL),(22,'18-0007',1,4,11,5,'','Johnny Thor',NULL,NULL,NULL,'',0,NULL,NULL,NULL,'',NULL,NULL,'',0,NULL),(23,'18-0008',1,5,4,6,'','Kareem abdul jabaar',NULL,NULL,NULL,'',0,NULL,NULL,NULL,'123-3123-3123',NULL,NULL,'',0,NULL),(24,'18-0005',1,5,4,3,'12','Kareem abdul jabaar','2018-11-14','2018-11-07','2018-11-07','',1,'2018-11-07','2018-11-15','2018-11-15','','2018-11-22','2018-11-06','',1,NULL),(25,'18-0006',4,4,11,5,'12','Kareem abdul jabaar','2018-11-06','2018-11-14','2018-11-21','',1,NULL,NULL,NULL,'',NULL,'2018-11-15','',1,NULL),(26,'18-0009',1,5,3,2,'12','Johnny Thor','2018-11-07','2018-11-14','2018-11-07','',1,'2018-11-15','2018-10-31','2018-11-15','','2018-11-07','2018-11-06','',1,NULL),(27,'18-0010',4,3028,7188,2,'12','Kareem abdul jabaar','2018-11-16','2018-11-23','2018-11-24','',1,'2018-11-15','2018-11-07','2018-11-15','454-230-12312','2018-11-22','2018-11-14','',1,NULL),(28,'18-0011',1,5,3,3,'12','Johnny Thor','2018-11-08','2018-11-08','2018-11-01','',0,NULL,NULL,NULL,'',NULL,NULL,'',1,NULL),(29,'18-0012',1,5,4,2,'','Johnny Thor',NULL,NULL,NULL,'',0,NULL,NULL,NULL,'',NULL,NULL,'',1,NULL),(30,'18-0013',1,14,7192,3,'12','Kareem abdul jabaar','2018-11-07','2018-11-13','2018-11-20','',1,'2018-11-06','2018-10-30','2018-11-06','129-76687-123','2018-11-21','2018-11-28','',1,NULL),(31,'18-0014',1,4,11,3,'12','admin',NULL,NULL,NULL,'',0,NULL,NULL,NULL,'',NULL,NULL,'',1,'2018-11-16 00:00:00'),(32,'18-0015',1,23,8,5,'','admin',NULL,NULL,NULL,'',0,NULL,NULL,NULL,'',NULL,NULL,'',1,'2018-11-16 00:00:00'),(33,'18-0016',1,4,11,1,'','admin','2018-11-07','2018-11-15','2018-11-15','',0,NULL,NULL,NULL,'',NULL,NULL,'',1,'2018-11-16 00:00:00'),(34,'18-0017',4,3030,7191,12,'24','admin','2018-11-21','2018-11-28','2018-11-21','',1,'2018-11-15','2018-11-29','2018-11-15','656-0456-4555','2018-10-31','2018-11-07','',1,'2018-11-21 15:42:08'),(35,'18-0018',1,1,1,3,'','Johnny Thor',NULL,NULL,NULL,'',0,NULL,NULL,NULL,'897SDSDR788',NULL,NULL,'',1,'2018-11-27 10:29:44'),(36,'12-0001',1,8,7190,6,'','admin',NULL,NULL,NULL,'',0,NULL,NULL,NULL,'',NULL,NULL,'',0,'2018-11-27 10:46:57'),(37,'18-0019',1,15,5,5,'12','Kalad kare','2018-11-22','2018-11-23','2018-11-22','',1,'2018-11-22','2018-11-22','2018-11-15','','2018-11-23','2018-11-23','',1,'2018-11-28 13:25:04'),(38,'18-0020',1,8,7190,7,'12','admin','2018-11-28','2018-11-28','2018-11-28','',1,'2018-11-16','2018-11-23','2018-11-29','','2018-12-18','2018-12-12','',1,'2018-11-28 15:15:08'),(39,'18-0021',4,8,7190,3,'24','admin','2018-11-28','2018-11-28','2018-11-28','',1,'2018-11-28','2018-11-28','2018-11-28','','2018-11-28','2018-11-28','test',1,'2018-11-29 13:38:53'),(40,'18-0022',4,6,7193,11,'12','admin','2018-11-28','2018-11-28','2018-11-29','',1,'2018-11-28','2018-11-29','2018-11-28','','2018-11-28','2018-11-28','',1,'2018-12-04 08:43:16'),(41,'19-0001',4,14,7192,10,'23','admin','2018-12-11','2018-12-11','2018-12-11','',1,'2018-12-04','2018-12-05','2018-12-04','4987-487-646SDEWR',NULL,'2018-12-04','',1,'2018-12-05 13:45:40');

/*Table structure for table `t_request_status` */

DROP TABLE IF EXISTS `t_request_status`;

CREATE TABLE `t_request_status` (
  `request_status_ID` int(10) NOT NULL AUTO_INCREMENT,
  `request_status` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`request_status_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;

/*Data for the table `t_request_status` */

insert  into `t_request_status`(`request_status_ID`,`request_status`) values (1,'In Process'),(2,'Deffered'),(3,'Disapproved'),(4,'Approved'),(5,'Cancelled'),(6,'n/a');

/*Table structure for table `t_request_sub` */

DROP TABLE IF EXISTS `t_request_sub`;

CREATE TABLE `t_request_sub` (
  `request_sub_id` int(10) NOT NULL AUTO_INCREMENT,
  `report_id` int(10) DEFAULT NULL,
  `request_id` int(10) DEFAULT NULL,
  `sector_id` int(10) DEFAULT NULL,
  `specialization_id` int(10) DEFAULT NULL,
  `specialization_sub_id` int(10) DEFAULT NULL,
  `batch_number` varchar(50) DEFAULT NULL,
  `vol_status_id` int(10) DEFAULT NULL,
  `vol_id` int(10) DEFAULT NULL,
  `asst_start` date DEFAULT NULL,
  `asst_end` date DEFAULT NULL,
  `isActive` int(10) DEFAULT NULL,
  `date_entry` datetime DEFAULT NULL,
  PRIMARY KEY (`request_sub_id`),
  KEY `request_id` (`request_id`),
  KEY `request_sub_id` (`request_sub_id`),
  KEY `sector_id` (`sector_id`),
  KEY `specialization_id` (`specialization_id`),
  KEY `status_id` (`vol_status_id`),
  KEY `vol_id` (`vol_id`)
) ENGINE=InnoDB AUTO_INCREMENT=63 DEFAULT CHARSET=utf8;

/*Data for the table `t_request_sub` */

insert  into `t_request_sub`(`request_sub_id`,`report_id`,`request_id`,`sector_id`,`specialization_id`,`specialization_sub_id`,`batch_number`,`vol_status_id`,`vol_id`,`asst_start`,`asst_end`,`isActive`,`date_entry`) values (25,25,18,1,1,2,'12',5,6819,'2018-10-05','2019-11-15',1,'2018-12-07 00:00:00'),(27,27,20,3,14,2,'69',5,3,'2018-11-05','2020-01-24',1,'2019-02-15 00:00:00'),(28,28,21,1,1,2,'',5,13,'2018-12-11','2018-12-18',1,'2019-02-15 00:00:00'),(29,29,24,1,1,2,'12',1,15,NULL,NULL,1,'2019-02-15 00:00:00'),(30,30,25,1,1,2,'12',7,6817,'2018-10-09','2018-11-30',1,'2018-12-01 00:00:00'),(31,31,19,1,6,1,'12',5,13,'2018-11-16','2019-02-01',1,'2018-12-01 00:00:00'),(32,32,18,1,1,2,'12',1,6815,NULL,NULL,1,'2018-12-01 00:00:00'),(33,33,26,1,1,2,'12',5,2,'2018-10-01','2019-03-15',1,'2018-12-01 00:00:00'),(34,34,27,46,106,26,'12',5,6822,'2017-11-14','2019-02-08',1,'2018-12-01 00:00:00'),(35,35,26,1,1,2,'',1,4,NULL,NULL,0,'2018-12-01 00:00:00'),(37,37,28,1,1,2,'',7,15,'2018-11-08','2018-11-24',1,'2018-11-13 00:00:00'),(38,38,30,1,1,2,'12',1,16,NULL,NULL,1,'2018-11-12 00:00:00'),(40,40,34,1,1,2,'12',5,6823,'2018-11-19','2019-02-15',1,'2018-11-21 16:05:46'),(42,42,24,1,1,2,'12',1,16,NULL,NULL,0,'2018-11-27 08:48:59'),(43,43,24,1,1,2,'12',1,16,NULL,NULL,1,'2018-11-27 08:49:32'),(44,44,31,1,1,2,'',1,16,NULL,NULL,0,'2018-11-27 10:27:54'),(45,45,32,1,1,2,'',1,6812,NULL,NULL,0,'2018-11-27 10:30:18'),(46,46,33,1,1,2,'',1,6822,NULL,NULL,0,'2018-11-27 10:30:42'),(47,47,33,1,1,2,'',1,6822,NULL,NULL,0,'2018-11-27 10:30:48'),(48,48,29,1,1,2,'',1,4,NULL,NULL,0,'2018-11-27 10:31:28'),(49,49,35,1,1,2,'',1,16,NULL,NULL,0,'2018-11-27 10:32:10'),(50,50,29,1,1,2,'',1,4,NULL,NULL,0,'2018-11-27 10:53:57'),(51,51,20,1,1,2,'',1,6822,NULL,NULL,0,'2018-11-27 13:48:43'),(52,52,38,3,24,25,'12',5,7,'2018-11-28','2020-05-28',1,'2018-11-28 15:15:53'),(53,53,37,6,52,1,'12',5,6812,'2018-11-28','2019-10-17',1,'2018-11-29 13:20:23'),(54,54,39,1,1,2,'',1,15,NULL,NULL,0,'2018-11-29 13:39:22'),(55,55,39,1,1,2,'',5,15,NULL,NULL,0,'2018-11-29 13:40:02'),(57,57,39,1,1,2,'',5,15,'2018-11-21','2019-02-15',0,'2018-11-29 13:44:23'),(58,58,40,1,1,2,'12',1,1,NULL,NULL,1,'2018-12-04 08:43:38'),(59,59,41,1,1,2,'12',5,6825,'2018-12-04','2019-12-05',1,'2018-12-05 13:46:50'),(60,60,18,2,10,1,'',1,16,NULL,NULL,1,'2018-12-11 10:59:13'),(61,61,33,1,1,2,'23',5,6822,'2018-10-30','2018-12-18',1,'2018-12-12 14:48:05'),(62,62,25,1,1,2,'',1,12,NULL,NULL,1,'2018-12-14 14:00:09');

/*Table structure for table `t_sector` */

DROP TABLE IF EXISTS `t_sector`;

CREATE TABLE `t_sector` (
  `sector_id` int(10) NOT NULL AUTO_INCREMENT,
  `sector` varchar(255) DEFAULT NULL,
  `framework_id` int(10) DEFAULT NULL,
  PRIMARY KEY (`sector_id`),
  KEY `framework_id` (`framework_id`),
  KEY `sector_id` (`sector_id`)
) ENGINE=InnoDB AUTO_INCREMENT=48 DEFAULT CHARSET=utf8;

/*Data for the table `t_sector` */

insert  into `t_sector`(`sector_id`,`sector`,`framework_id`) values (1,'Agriculture',NULL),(2,'Culture and Values',NULL),(3,'Education',NULL),(4,'Environment',NULL),(5,'Governance abd Public Administration',NULL),(6,'Health',NULL),(7,'Industry, Service and Energy',NULL),(8,'Peace and Security',NULL),(9,'Safety and Resilience',NULL),(10,'Science Technology and Innovation',NULL),(11,'Social Welfare and Services',NULL),(46,'test',NULL),(47,'test2',NULL);

/*Table structure for table `t_specialization` */

DROP TABLE IF EXISTS `t_specialization`;

CREATE TABLE `t_specialization` (
  `specialization_id` int(10) NOT NULL AUTO_INCREMENT,
  `sector_id` int(10) DEFAULT NULL,
  `specialization_dsc` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`specialization_id`),
  KEY `specialization_id` (`specialization_id`)
) ENGINE=InnoDB AUTO_INCREMENT=108 DEFAULT CHARSET=utf8;

/*Data for the table `t_specialization` */

insert  into `t_specialization`(`specialization_id`,`sector_id`,`specialization_dsc`) values (1,1,'Agricultural (Crop) Production'),(2,1,'Agricultural Products Processing/Marketing'),(3,1,'Agri-Enterprise Development'),(4,1,'Fisheries/Aquaculture'),(5,1,'Livestock/Animal Husbandry'),(6,1,'Organic Farming /Agriculture'),(7,1,'Post Harvest Technology'),(8,1,'Poultry Production'),(9,1,'Sustainable/Resilient farming'),(10,2,'Arts Administration'),(11,2,'Cultural Antropological Studies '),(12,2,'Heritage /Artifacts Conservation/Restoration'),(13,2,'Survey and Documentation of Historic and Cultural Sites'),(14,3,'Alternate Learning System(ALS)'),(15,3,'Curriculum Development and Management'),(16,3,'English Language'),(17,3,'Music and Arts'),(18,3,'Physical / Sports Education'),(19,3,'School Facilities Improvement '),(20,3,'Science and Math'),(21,3,'Special Education'),(22,3,'Special Foreign Languanges(per DepED)'),(23,3,'Teacher Training'),(24,3,'Technical Vocational Education and Training (TVET)'),(28,4,'Coastal(incl Mangrove and fishery) Resources Management'),(29,4,'Proctected Areas Management'),(30,4,'Biodiversity Conservation and Management'),(31,4,'Forestry and Reforestation'),(32,4,'Environmental Impact Assestment'),(33,4,'Enviromental Education'),(34,4,'Ecotourism development'),(35,4,'Solid waste Management'),(36,4,'Mining and Geo-Sciences'),(37,4,'water Supply and Sanitation'),(38,4,'Watershed Conservation and Management'),(39,5,'Anti-Corruption'),(40,5,'Comprehensive land use Planning(CLUP)'),(41,5,'Financial system development/Management'),(42,5,'Geographic Information System'),(43,5,'Information Systems Development /Management'),(44,5,'Organization/ Human resources development'),(45,5,'Planning for LGUs'),(46,5,'Resettlement Governance'),(47,5,'Resources Mobilization'),(48,5,'Urban and Regional planning'),(49,6,'Alternate Health Care Services'),(50,6,'Disease Prevention and Control:HIV/AIDS,Tubercolosis,Malaria'),(51,6,'Health facilities Improvement/Maintenance(incl 5S)'),(52,6,'Maternal,newborn and Child Health/Widwifery'),(53,6,'Medical Laboratory services'),(54,6,'Mental Health and Psycho-social Services'),(55,6,'Nursing'),(56,6,'Nutrition and dietetics'),(57,6,'Occupational and Physical Therapy'),(58,6,'Orthotics and Protesthetic '),(59,6,'Primary / Public Health Care'),(60,6,'Reproductive Health     '),(61,6,'Support to Health Information Gathering and Analysis '),(62,6,'Water,Sanitation , and Hygiene(WASH)'),(63,7,'Digital fabrication and Prduct Design and Engineering'),(64,7,'Entrepreneurship Developement'),(65,7,'Fair Trade Promotion /developement'),(66,7,'Green Industry Promotion'),(67,7,'Inclusive Business Models and Social Enterprise development'),(68,7,'Industry-Academe Linkaging'),(69,7,'Market and Promotion Planning'),(70,7,'Micro ,Small and Medium Enterprise (MSMEs) Development'),(71,7,'Microfinancing'),(72,7,'Prduct design and Development'),(73,7,'PWD Employment'),(74,7,'Renewable Energy'),(75,7,'Tourism development and Promotion'),(76,7,'Value-Chain Upgrade'),(77,8,'Conflict Trasformation'),(78,8,'Peace Building and developement'),(79,8,'Peace Education /Advocay'),(80,8,'Support to Internally Displaced Person(IDPs)'),(81,8,'Culture of Peace Promotion'),(82,9,'Climate change Adaptation and Migration '),(83,9,'Disaster Risk reduction and Management(DRRM)'),(84,9,'Emergency Operation center Management'),(85,9,'Emergency Search and Rescue '),(86,9,'Evacuation camp Management '),(87,9,'Resilient Livelihood'),(88,9,'Resilient Housing and Resstlement'),(89,9,'Hazard Vulnerablity and Capacity Assestment'),(90,10,'Commercialization and Utilization f Technologies'),(91,10,'Information Analytics'),(92,10,'Information Network design and Set up'),(93,10,'Small Media and Digital Communication'),(94,10,'Software Design and Development'),(95,10,'Web Development and Communication Plannings'),(96,11,'Anti Human Trafficking'),(97,11,'Child Protection and Child Rights Advocy'),(98,11,'Crisis Intervention'),(99,11,'Early Childhod care and development '),(100,11,'Gender and development'),(101,11,'Justice system for vulnerable sectors'),(102,11,'Risk Transfer Mechnism (eg Insurance) for vulnerable'),(103,11,'Social service Delivery sectors(IP,PWD,Women,OFWs,Elderly,etc)'),(104,11,'Support services for Recovering Drug dependents'),(105,11,'Youth Welfare and Development'),(106,NULL,'n/a'),(107,2,'test');

/*Table structure for table `t_specialization_sub` */

DROP TABLE IF EXISTS `t_specialization_sub`;

CREATE TABLE `t_specialization_sub` (
  `specialization_sub_id` int(10) NOT NULL AUTO_INCREMENT,
  `specialization_id` int(10) DEFAULT NULL,
  `sector_id` int(10) DEFAULT NULL,
  `specialization_sub_desc` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`specialization_sub_id`)
) ENGINE=InnoDB AUTO_INCREMENT=28 DEFAULT CHARSET=latin1;

/*Data for the table `t_specialization_sub` */

insert  into `t_specialization_sub`(`specialization_sub_id`,`specialization_id`,`sector_id`,`specialization_sub_desc`) values (1,NULL,NULL,'n/a'),(2,1,1,'Crop Diversification'),(3,1,1,'Disease and Pest Control Management'),(4,1,1,'Farm Mechanization '),(5,1,1,'High value Crops Prduction/ Vegetable Growing'),(6,1,1,'Intensified Cereal Crops farming '),(7,1,1,'New Farm Technology / Farming systems'),(8,1,1,'Small scale irrigation Systems'),(9,1,1,'Upland farming'),(10,5,1,'Artificial Breeding '),(11,5,1,'Dairy farming Development'),(12,5,1,'Forage Production'),(13,5,1,'Livestock Production'),(14,5,1,'Veterinary Medicine / Animal health'),(15,24,3,'Air Conditioning and refrigiration'),(16,24,3,'Automotive '),(17,24,3,'Electricity'),(18,24,3,'Carpentry'),(19,24,3,'Culinary Arts / Food Processing '),(20,24,3,'Electronics'),(21,24,3,'Furniture design and Construction'),(22,24,3,'Garments and Tailoring'),(23,24,3,'Handicafts '),(24,24,3,'Housekeeping'),(25,24,3,'Information and Communication Technology'),(26,106,47,'tests'),(27,106,47,'testss');

/*Table structure for table `t_vol_org` */

DROP TABLE IF EXISTS `t_vol_org`;

CREATE TABLE `t_vol_org` (
  `vol_org_id` int(10) NOT NULL AUTO_INCREMENT,
  `vol_org_dsc` varchar(50) DEFAULT NULL,
  `Program_type_id` int(10) DEFAULT NULL,
  PRIMARY KEY (`vol_org_id`),
  KEY `ID_VOL_DESC` (`vol_org_dsc`),
  KEY `Program_type_id` (`Program_type_id`)
) ENGINE=InnoDB AUTO_INCREMENT=70 DEFAULT CHARSET=utf8;

/*Data for the table `t_vol_org` */

insert  into `t_vol_org`(`vol_org_id`,`vol_org_dsc`,`Program_type_id`) values (1,'AVp',2),(2,'FV',2),(3,'GIZ',2),(4,'GIED',2),(5,'FORUM ZFD',2),(6,'ENTREPRENUERS DU MONDE',2),(7,'JICA',2),(8,'KOICA',2),(9,'OISCA',1),(10,'UNV',1),(11,'VSO',2),(12,'PEACE CORP',2);

/*Table structure for table `t_vol_status` */

DROP TABLE IF EXISTS `t_vol_status`;

CREATE TABLE `t_vol_status` (
  `status_id` int(10) NOT NULL AUTO_INCREMENT,
  `status_vol` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`status_id`),
  KEY `NORM_OrderByIndex` (`status_vol`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8;

/*Data for the table `t_vol_status` */

insert  into `t_vol_status`(`status_id`,`status_vol`) values (4,'Approved'),(6,'Cancelled'),(2,'Deffered'),(3,'Disapproved'),(7,'Finished Contract'),(1,'In Process'),(5,'In Service'),(11,'n/a'),(8,'Preterminated'),(10,'Transferred');

/*Table structure for table `t_volunteer` */

DROP TABLE IF EXISTS `t_volunteer`;

CREATE TABLE `t_volunteer` (
  `vol_id` int(10) NOT NULL AUTO_INCREMENT,
  `ref_no` varchar(255) NOT NULL,
  `vol_status` varchar(255) DEFAULT NULL,
  `vol_name` varchar(50) DEFAULT NULL,
  `vol_org` int(50) DEFAULT NULL,
  `sex` varchar(25) DEFAULT NULL,
  `birthdate` date DEFAULT NULL,
  `add_no` varchar(50) DEFAULT NULL,
  `add_st` varchar(50) DEFAULT NULL,
  `mun_city` varchar(50) DEFAULT NULL,
  `prov_id` int(10) DEFAULT NULL,
  `region_id` int(10) DEFAULT NULL,
  `email` varchar(50) DEFAULT NULL,
  `mobile_number` varchar(35) DEFAULT NULL,
  `date_arrival` date DEFAULT NULL,
  `date_departure` date DEFAULT NULL,
  `visa_exp_date` date DEFAULT NULL,
  `passport_exp` date DEFAULT NULL,
  `remarks` text DEFAULT NULL,
  `vol_picture` varchar(255) DEFAULT NULL,
  `date_entry` datetime DEFAULT NULL,
  `isActive` int(5) DEFAULT NULL,
  PRIMARY KEY (`vol_id`,`ref_no`),
  KEY `prov_id` (`prov_id`),
  KEY `region_id` (`region_id`),
  KEY `sex_id` (`sex`),
  KEY `Volunteer_ID` (`vol_id`)
) ENGINE=InnoDB AUTO_INCREMENT=6838 DEFAULT CHARSET=utf8;

/*Data for the table `t_volunteer` */

insert  into `t_volunteer`(`vol_id`,`ref_no`,`vol_status`,`vol_name`,`vol_org`,`sex`,`birthdate`,`add_no`,`add_st`,`mun_city`,`prov_id`,`region_id`,`email`,`mobile_number`,`date_arrival`,`date_departure`,`visa_exp_date`,`passport_exp`,`remarks`,`vol_picture`,`date_entry`,`isActive`) values (1,'17-0002','In Process','Hannah Wunschel',11,'Male','1984-04-03','242','san jose st','san jose del monte',79,15,'','','2018-10-03','2018-10-03','2018-10-15','2018-10-15','Not yet registered as of 1/7/2015','\\\\CHY\\ShareDocs\\uploads\\chyrWSPrSTX44VdbQEf4QOvhQ9ggGRyJh.jpg','2018-10-24 00:00:00',1),(2,'17-0003','In Service','Carl Douglas Mitchell',6,'Male','1993-01-10','23','san jose st','san jose del monte',1,1,'','','2004-03-10','2018-10-01','2018-10-16','2018-10-17','','\\\\CHY\\ShareDocs\\uploads\\chyOA1cByTnrwOUl2kmEBzJkhx1c7DbZ4.jpg','2018-10-26 00:00:00',1),(3,'17-0004','In Service','Rosanna Spanio',1,'Female','1984-07-23','43','San Jose St S','San Jose Del Monte',69,14,'','','2004-03-08','2018-10-14','2018-10-01','2018-10-29','','\\\\CHY\\ShareDocs\\uploads\\chyqcTqEBL9IeJyJug1wdOOJdUdOmazd3.jpg','2018-10-25 00:00:00',1),(4,'17-0005','In Process','Amber Sky Robertson Rowe',2,'Male','1985-11-07','11','san jose st','san jose del monte',56,11,'email','mobile number','2004-03-28','2018-10-18','2018-10-16','2018-10-19','awit','\\\\CHY\\ShareDocs\\uploads\\chyJwyUH4Wqs4B77V9nA5KRZ8kBqPbJ5K.jpg','2018-10-12 00:00:00',1),(5,'17-0006','n/a','Richard Weslie Miller',9,'Male','1975-11-02','11','san jose sts','san jose del monte',1,1,'@.com','09134877785','2018-10-10','2018-10-18','2018-10-23','2019-01-01','test','\\\\CHY\\ShareDocs\\uploads\\chydmxzsADCJoluNHS7zWMhbdg3w4Mx7c.jpg','2018-10-04 00:00:00',1),(7,'18-0001','In Service','Katarina Bezerra-Clark',7,'Female','1981-10-28','2a','san jose st','Bantayan',56,11,'','','2018-10-16','2018-10-24','2018-10-09','2018-10-15','','\\\\CHY\\ShareDocs\\uploads\\chyspg3RCKCuVhSoZp1G64xH8zN7XdzSE.jpg','2018-10-06 00:00:00',1),(8,'18-0002','n/a','Kimberly Bohnet',12,'Female','1993-10-16','233','san jose st','Legazpi City',32,6,'e','a',NULL,'2018-10-22','2018-10-19','2018-11-08','a','\\\\CHY\\ShareDocs\\uploads\\chyISPML8ddVhFecM6Y5p1fEX9c3G6pWt.jpg','2018-10-12 00:00:00',1),(10,'18-0003','n/a','Erica Chan',10,'Male','1990-02-09','456','san jose st','Bacolod City',50,9,'gmail','12312','2018-10-16','2018-10-30','2018-10-30','2018-10-10','hihihi','\\\\CHY\\ShareDocs\\uploads\\chy_DysQ62gH6msyKjabgfvGChoT1ylZm7.jpg','2018-10-26 00:00:00',1),(11,'18-0004','n/a','Marla Chassels',5,'Female','1941-04-23','4544','san jose st','san jose del monte',5,2,'','','2004-01-31','2005-06-04','2018-10-26','2018-10-26','','\\\\CHY\\ShareDocs\\uploads\\chyXbzOlSOwmBHjbFDeGgYEAjIKqlDO2S.jpg','2018-10-16 00:00:00',1),(12,'18-0005','In Process','Naotaka Kawamura',5,'Female','1993-04-23','4485','san jose st','Alegria',1,1,'','','2004-04-10','2018-10-16','2018-10-24','2018-10-11','','','2018-10-25 00:00:00',1),(13,'18-0006','In Service','Almuth Schellpeper',4,'Female','1983-04-23','44','san jose st','san jose del monte',42,8,'','','2018-10-25','2018-10-25','2019-12-07','2019-07-11','PT','\\\\CHY\\ShareDocs\\uploads\\chy_3aRHbiTzSsXLydeeSy4yXosZTce6VU.jpg','2018-10-26 00:00:00',1),(14,'18-0007','n/a','Katherine Driscoll',1,'Female','1993-04-23','234','san jose st','san jose del monte ',17,4,'test','test','2004-01-31','2018-10-15','2018-10-16','2018-10-19','PT','','2018-10-19 00:00:00',0),(15,'18-0008','Finished Contract','Thor Erickson',3,'Female','1975-11-02','11','san jose st','Basco',32,6,'','','2004-01-31','2018-10-25','2006-10-27','2008-11-16','','\\\\CHY\\ShareDocs\\uploads\\chyMHwn1Vhsx5ZwZYECvAm9NZ7TzBn32N.jpg','2018-10-26 00:00:00',1),(16,'18-0009','In Process','Corey Fitch',3,'Female','1936-01-02','2311','san jose st','Sagada',56,11,'','','2004-01-31','2018-10-10','2006-04-30','2008-11-27','','\\\\CHY\\ShareDocs\\uploads\\chy2RS9gt4cilaTGFFBicMaUbxLe2blqV.jpg','2018-10-27 00:00:00',1),(6812,'18-0011','In Service','Awit',5,'Male','1952-01-02','078','san lucas','san jose del monte',11,3,'ronnie.chy26@gmail.com','09367147913','2018-10-16','2018-10-09','2018-11-06','2018-10-16','test test','\\\\CHY\\ShareDocs\\uploads\\chyxo1HnSwM8Lz8CBowhZq8KhnswTyF3B.jpg','2018-10-12 00:00:00',1),(6815,'18-0034','In Process','Ronaldo Bato',3,'Female','1977-01-02','546','san jose','san jose del monte',58,11,'email','mobile',NULL,NULL,NULL,NULL,'n/a','\\\\CHY\\ShareDocs\\uploads\\chyqYYGLkqdQeN4dT1Fk1DNx5iykrIwfA.jpg','2018-10-17 00:00:00',1),(6817,'12-0001','Finished Contract','Kareem Abdul Jabar',5,'Male','1967-11-02','Asd','Asd','Asdasd',1,1,'das','asd','2018-10-09','2018-10-16','2018-10-09','2018-10-24','asdsd','\\\\CHY\\ShareDocs\\uploads\\chy_NAPp1yuwTVQdEDohXJQHfrrzVxjS6N.jpg','2018-10-23 00:00:00',1),(6819,'18-0021','In Service','Gatotka  ka',3,'Male','2000-11-02','56','San Jose','Del Monte',59,12,'email','','2018-10-31','2018-10-24','2018-10-09','2018-10-10','','\\\\CHY\\ShareDocs\\uploads\\chy_ojYzWD2M4CZ9arcHcf95qh4gD6ZjEj.jpg','2018-10-24 00:00:00',1),(6822,'19-0001','In Service','Awit Gaik',1,'Male','1984-11-29','092','Putol Na Daan Lagro','Fairview',79,15,'email.com','215-54522-2111','2018-10-17','2018-10-10','2018-10-10','2018-10-17','','\\\\CHY\\ShareDocs\\uploads\\chyNH3cIxyS7ATi1v5jGFYJWkh15CYLXG.jpg','2018-11-09 00:00:00',1),(6823,'17-0001','In Service','Kimi Dela Cruz',12,'Male','1988-12-23','123','San Mateo','Batangas',17,4,'email@com','35125412','2018-11-20','2018-11-13','2018-11-07','2018-11-20','','\\\\CHY\\ShareDocs\\uploads\\chyxlSSj9Fm8KyNPQ9IqSfuR35pUarTdr.jpg','2018-11-21 15:36:42',1),(6824,'18-0012','n/a','Toots',12,'Male','2018-11-30','12','San Saksak','San Awit',6,2,'email@.com','09234442343',NULL,NULL,NULL,NULL,'','\\\\CHY\\ShareDocs\\uploads\\chyAOeRbWzYHwfRmJcZxoAUR5sliZbA3F.jpg','2018-11-22 10:14:03',1),(6825,'19-0002','In Service','Henry Ford',10,'Male','1989-10-11','090','Street','City',29,5,'@.com','+6397534534555','2018-12-11','2018-12-11','2019-08-16','2019-06-15','','\\\\CHY\\ShareDocs\\uploads\\chyyp2O5kZjAu4j34LATRdzuTBRe9CtAt.jpg','2018-12-05 08:41:25',1),(6827,'19-0003','n/a','Bak Hyun Wa',8,'Female','1989-06-16','09','','',1,1,'','','2018-12-04','2019-04-18','2018-12-20','2018-12-20','test','\\\\CHY\\ShareDocs\\uploads\\chymEnsv7xojVzxfVzRDHaMpgmppxBj3g.jpg','2018-12-06 10:47:40',1),(6828,'19-0004','n/a','Hatake Kakashi',7,'Male','2018-12-07','22','Jumps','Street',40,7,'email@email.com','0936123722312','2018-11-27','2018-12-04','2018-12-19','2018-11-27','reamrks','\\\\CHY\\ShareDocs\\uploads\\chy_fnDimTCsEfbyFHfbd2hw97QbrlYHm8.jpg','2018-12-06 10:55:45',1),(6829,'19-0005','n/a','Kang Bong Hon',8,'Male','2018-12-11','','','',1,1,'','',NULL,NULL,NULL,NULL,'','\\\\CHY\\ShareDocs\\uploads\\chymauCza8BpsceHd6NUazxj8ZjS6DRkA.jpg','2018-12-06 10:56:19',1),(6830,'19-0006','n/a','Kim Yejin',8,'Female','2018-12-21','','','',1,1,'','',NULL,NULL,NULL,NULL,'','\\\\CHY\\ShareDocs\\uploads\\chyifre9KJNAUttgMuc9ywdJ8cMHhSbPq.jpg','2018-12-06 10:56:42',1),(6831,'19-0007','n/a','Akbar Buchanan',12,'Male','2018-12-26','','','',1,1,'','',NULL,NULL,NULL,NULL,'','\\\\CHY\\ShareDocs\\uploads\\chywsbDluqOhnrdqll5joUtHuwsuywkDr.jpg','2018-12-06 10:58:03',1),(6832,'19-0008','n/a','Jessica Monique August',12,'Male','2018-12-28','','','',1,1,'','',NULL,NULL,NULL,NULL,'','\\\\CHY\\ShareDocs\\uploads\\chy5xvuckUGtxYvxuq3oOLFcD4kFOQjli.jpg','2018-12-06 10:58:37',1),(6833,'19-0009','n/a','Jeremy Ariza',12,'Male','2018-12-21','21','Jump','street',1,1,'','',NULL,NULL,NULL,NULL,'','\\\\CHY\\ShareDocs\\uploads\\chyiIBDNTVaO3P9oxeFWdouciM5YDCLK9.jpg','2018-12-06 10:59:01',1),(6834,'19-0010','n/a','Rhylee Brown',12,'Male','2018-12-20','12','street','',1,1,'','',NULL,NULL,NULL,NULL,'','\\\\CHY\\ShareDocs\\uploads\\chyFEOQSXrSFqpix5YPrymBZdvMj8hJad.jpg','2018-12-06 10:59:32',1),(6835,'19-0011','n/a','Robert Quoss',4,'Male','2018-08-21','22','Jumps','Street',1,1,'email','093654564654',NULL,NULL,NULL,NULL,'','\\\\CHY\\ShareDocs\\uploads\\chyIa1ZUEdgVpELWYOYsWvn5hHV1P6GDQ.jpg','2018-12-06 11:01:14',1),(6836,'19-0012','n/a','Awit Cavite',10,'Male','2018-12-26','','','',1,1,'','',NULL,NULL,NULL,NULL,'','\\\\CHY\\ShareDocs\\uploads\\chyFVWsy15fwdmmntd13zhz2pLRp1PYPy.jpg','2018-12-07 14:51:56',1),(6837,'19-0013','n/a','Abdul Jabaar',10,'Male','2019-01-19','12','San Lucas','San Jose Del Monte',11,3,'@.com','09312354123','2018-12-03','2018-12-04','2018-12-11','2018-12-11','','\\\\CHY\\ShareDocs\\uploads\\chygUMG9rwhLVnOVrWmoKMsEmIWWcFgup.jpg','2018-12-17 09:56:16',1);

/* Function  structure for function  `DECRYPTER` */

/*!50003 DROP FUNCTION IF EXISTS `DECRYPTER` */;
DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` FUNCTION `DECRYPTER`(
  enc_str VARCHAR (5000),
  key_str VARCHAR (5000)
) RETURNS varchar(5000) CHARSET latin1
BEGIN
DECLARE DEC_STR VARCHAR(5000);
	SET @DEC_STR = (SELECT SUBSTRING_INDEX(DECODE(UNHEX(enc_str),key_str),':',-1) FROM DUAL);
	
RETURN @DEC_STR;
END */$$
DELIMITER ;

/* Function  structure for function  `ENCRYPTER` */

/*!50003 DROP FUNCTION IF EXISTS `ENCRYPTER` */;
DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` FUNCTION `ENCRYPTER`(
  str VARCHAR (5000),
  key_str VARCHAR (5000)
) RETURNS varchar(5000) CHARSET latin1
BEGIN
  DECLARE ENC_STR VARCHAR (5000);
  SET @ENC_STR = (SELECT HEX(ENCODE(CONCAT(':', str), key_str)) FROM DUAL);
    RETURN @ENC_STR;
    
  END */$$
DELIMITER ;

/* Function  structure for function  `getBirthday` */

/*!50003 DROP FUNCTION IF EXISTS `getBirthday` */;
DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` FUNCTION `getBirthday`(bday date) RETURNS int(10)
BEGIN
  DECLARE age int (10);
  set @age = (SELECT ROUND(DATEDIFF(NOW(), bday) / 365.25)  FROM DUAL);
    return @age;
END */$$
DELIMITER ;

/* Procedure structure for procedure `report_vol_ivso` */

/*!50003 DROP PROCEDURE IF EXISTS  `report_vol_ivso` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `report_vol_ivso`()
BEGIN
  SELECT 
    vol_org.`vol_org_dsc` 
  FROM
    `t_request_sub` AS sub_req 
    JOIN `t_request` AS req 
      ON sub_req.`request_id` = req.`request_id` 
    JOIN `t_vol_org` AS vol_org 
      ON vol_org.`vol_org_id` = req.`vol_org_id` 
  WHERE sub_req.`vol_status_id` = 
    (SELECT 
      status_id 
    FROM
      `t_vol_status` 
    WHERE status_vol = 'In Service') ;
END */$$
DELIMITER ;

/* Procedure structure for procedure `report_vol_lpi_type` */

/*!50003 DROP PROCEDURE IF EXISTS  `report_vol_lpi_type` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `report_vol_lpi_type`()
BEGIN
SELECT 
  lpi_type.`host_org_type`  AS 'LPI_type'
FROM
  `t_request_sub` AS sub_req 
  JOIN `t_request` AS req 
    ON req.`request_id` = sub_req.`request_id` 
  JOIN `t_host_org` AS lpi 
    ON req.`host_org_id` = lpi.`host_org_id` 
  JOIN `t_host_org_type` AS lpi_type 
    ON lpi_type.`host_org_type_id` = lpi.`host_org_type_id` 
WHERE sub_req.`vol_status_id` = 
  (SELECT 
    status_id 
  FROM
    `t_vol_status` 
  WHERE status_vol = 'In Service');
    END */$$
DELIMITER ;

/* Procedure structure for procedure `report_vol_reg` */

/*!50003 DROP PROCEDURE IF EXISTS  `report_vol_reg` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `report_vol_reg`()
BEGIN
  SELECT 
    reg.`region_desc` 
  FROM
    `t_request_sub` AS sub_req 
    JOIN `t_request` AS req 
      ON req.`request_id` = sub_req.`request_id` 
    JOIN t_project AS proj 
      ON proj.`project_id` = req.`project_id` 
    JOIN `t_region` AS reg 
      ON reg.`region_id` = proj.`region_id` 
  WHERE sub_req.`vol_status_id` = 
    (SELECT 
      status_id 
    FROM
      `t_vol_status` 
    WHERE status_vol = 'In Service') ;
END */$$
DELIMITER ;

/* Procedure structure for procedure `report_vol_sector` */

/*!50003 DROP PROCEDURE IF EXISTS  `report_vol_sector` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `report_vol_sector`()
BEGIN
  SELECT 
    sec.sector as 'sector_sec'
  FROM
    `t_request_sub` AS sub_req 
    JOIN `t_sector` AS sec 
      ON sub_req.`sector_id` = sec.`sector_id` 
  WHERE sub_req.`vol_status_id` = 
    (SELECT 
      status_id 
    FROM
      `t_vol_status` 
    WHERE status_vol = 'In Service') ;
END */$$
DELIMITER ;

/* Procedure structure for procedure `report_1` */

/*!50003 DROP PROCEDURE IF EXISTS  `report_1` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `report_1`()
BEGIN
SELECT 
  req.`ref_no` as 'Request No',
  vol.`vol_name`,
  lpi.`host_org` as 'LPI',
  proj.`proj_title` ,
  vol_org.`vol_org_dsc` as 'IVSO',
  sub.`asst_start`,
  sub.`asst_end`,
  vol_status.`status_vol`,
  sec.`sector`,
  spec.`specialization_dsc`,
  spec_sub.`specialization_sub_desc` ,
  reg.`region_desc`,
  prov.`prov_dsc`
FROM
  `t_request_sub` AS sub 
  JOIN `t_request` AS req 
    ON sub.`request_id` = req.`request_id` 
  JOIN `t_sector` AS sec 
    ON sub.`sector_id` = sec.`sector_id` 
  JOIN `t_specialization` AS spec 
    ON sub.`specialization_id` = spec.`specialization_id` 
  JOIN `t_specialization_sub` AS spec_sub 
    ON sub.`specialization_sub_id` = spec_sub.`specialization_sub_id` 
  JOIN `t_volunteer` AS vol 
    ON sub.`vol_id` = vol.`vol_id` 
  JOIN `t_host_org` AS lpi 
    ON req.`host_org_id` = lpi.`host_org_id` 
  JOIN `t_project` AS proj 
    ON req.`project_id` = proj.`project_id` 
  JOIN `t_vol_org` AS vol_org 
    ON req.`vol_org_id` = vol_org.`vol_org_id` 
  JOIN `t_vol_status` AS vol_status 
    ON sub.`vol_status_id` = vol_status.`status_id` 
  JOIN `t_region` AS reg 
    ON proj.`region_id` = reg.`region_id` 
  JOIN `t_province` AS prov 
    ON proj.`prov_id` = prov.`prov_id` 
WHERE req.`isActive` = 1 order by sub.date_entry desc limit 200;
    END */$$
DELIMITER ;

/* Procedure structure for procedure `report_vol_sex` */

/*!50003 DROP PROCEDURE IF EXISTS  `report_vol_sex` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `report_vol_sex`()
BEGIN
  SELECT 
    vol.sex 
  FROM
    `t_request_sub` AS sub_req 
    JOIN `t_volunteer` AS vol 
      ON sub_req.`vol_id` = vol.`vol_id` 
  WHERE sub_req.`vol_status_id` = 
    (SELECT 
      status_id 
    FROM
      `t_vol_status` 
    WHERE status_vol = 'In Service') ;
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_1` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_1` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_1`()
BEGIN
DECLARE a INT(10);
SELECT 
    @a := status_id 
  FROM
    `t_vol_status` 
  WHERE status_vol =  'Finished Contract';
  UPDATE 
    `t_volunteer` AS vol 
    JOIN `t_request_sub` AS sub 
       SET vol.vol_status = 'Finished Contract',
    sub.`vol_status_id` = @a 
  WHERE NOW() >= sub.`asst_end` 
    AND sub.`vol_id` = vol.`vol_id` ;
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_audit_trail` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_audit_trail` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_audit_trail`(date1 datetime, date2 datetime)
BEGIN
  SELECT 
    * 
  FROM
    t_logs 
  WHERE log_date BETWEEN CONVERT(date1, DATETIME) 
    AND CONVERT(date2, DATETIME) ;
END */$$
DELIMITER ;

/* Procedure structure for procedure `report_lpi_all` */

/*!50003 DROP PROCEDURE IF EXISTS  `report_lpi_all` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `report_lpi_all`()
BEGIN
  SELECT 
    lpi.host_org_id,
    lpi.host_org,
    lpi.`tel_number1`,
    lpi.`email`,
    lpi.`website`,
    CONCAT(
      lpi.Address1,
      ' ',
      lpi.Address2,
      ' ',
      lpi.mun_city
    ) AS 'address',
    reg.`region_desc` AS 'region',
    prov.`prov_dsc` AS 'province',
    sub.`host_org_type_sub` AS 'host_org_type_sub',
    org.`host_org_type` AS 'host_org_type' 
  FROM
    `t_host_org` AS lpi 
    JOIN `t_region` AS reg 
      ON reg.`region_id` = lpi.`region_id` 
    JOIN `t_province` AS prov 
      ON prov.`prov_id` = lpi.`prov_id` 
    JOIN `t_host_org_type_sub` AS sub 
      ON sub.`host_org_type_sub_id` = lpi.`host_org_type_sub_id` 
    JOIN `t_host_org_type` AS org 
      ON lpi.`host_org_type_id` = org.`host_org_type_id` 
  ORDER BY lpi.`host_org_id` ;
END */$$
DELIMITER ;

/* Procedure structure for procedure `report_LPI_per_orgtype_main` */

/*!50003 DROP PROCEDURE IF EXISTS  `report_LPI_per_orgtype_main` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `report_LPI_per_orgtype_main`(ID int (10))
BEGIN
  SELECT 
    lpi.host_org_id,
    lpi.host_org,
    lpi.`tel_number1`,
    lpi.`email`,
    lpi.`website`,
    CONCAT(
      lpi.Address1,
      ' ',
      lpi.Address2,
      ' ',
      lpi.mun_city
    ) AS 'address',
    reg.`region_desc` AS 'region',
    prov.`prov_dsc` AS 'province',
    sub.`host_org_type_sub` AS 'host_org_type_sub',
    org.`host_org_type` AS 'host_org_type' 
  FROM
    `t_host_org` AS lpi 
    JOIN `t_region` AS reg 
      ON reg.`region_id` = lpi.`region_id` 
    JOIN `t_province` AS prov 
      ON prov.`prov_id` = lpi.`prov_id` 
    JOIN `t_host_org_type_sub` AS sub 
      ON sub.`host_org_type_sub_id` = lpi.`host_org_type_sub_id` 
    JOIN `t_host_org_type` AS org 
      ON lpi.`host_org_type_id` = org.`host_org_type_id` 
  WHERE lpi.host_org_type_id = ID
  ORDER BY lpi.`host_org_id` ;
END */$$
DELIMITER ;

/* Procedure structure for procedure `report_lpi_per_province` */

/*!50003 DROP PROCEDURE IF EXISTS  `report_lpi_per_province` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `report_lpi_per_province`(ID int (10))
BEGIN
  SELECT 
    lpi.host_org_id,
    lpi.host_org,
    lpi.`tel_number1`,
    lpi.`email`,
    lpi.`website`,
    CONCAT(
      lpi.Address1,
      ' ',
      lpi.Address2,
      ' ',
      lpi.mun_city
    ) AS 'address',
    reg.`region_desc` AS 'region',
    prov.`prov_dsc` AS 'province',
    sub.`host_org_type_sub` AS 'host_org_type_sub',
    org.`host_org_type` AS 'host_org_type' 
  FROM
    `t_host_org` AS lpi 
    JOIN `t_region` AS reg 
      ON reg.`region_id` = lpi.`region_id` 
    JOIN `t_province` AS prov 
      ON prov.`prov_id` = lpi.`prov_id` 
    JOIN `t_host_org_type_sub` AS sub 
      ON sub.`host_org_type_sub_id` = lpi.`host_org_type_sub_id` 
    JOIN `t_host_org_type` AS org 
      ON lpi.`host_org_type_id` = org.`host_org_type_id` 
  WHERE lpi.`prov_id` = ID 
  ORDER BY lpi.`host_org_id` ;
END */$$
DELIMITER ;

/* Procedure structure for procedure `report_lpi_per_region` */

/*!50003 DROP PROCEDURE IF EXISTS  `report_lpi_per_region` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `report_lpi_per_region`(ID int(10))
BEGIN
  SELECT 
    lpi.host_org_id,
    lpi.host_org,
    lpi.`tel_number1`,
    lpi.`email`,
    lpi.`website`,
    CONCAT(
      lpi.Address1,
      ' ',
      lpi.Address2,
      ' ',
      lpi.mun_city
    ) AS 'address',
    reg.`region_desc` AS 'region',
    prov.`prov_dsc` AS 'province',
    sub.`host_org_type_sub` AS 'host_org_type_sub',
    org.`host_org_type` AS 'host_org_type' 
  FROM
    `t_host_org` AS lpi 
    JOIN `t_region` AS reg 
      ON reg.`region_id` = lpi.`region_id` 
    JOIN `t_province` AS prov 
      ON prov.`prov_id` = lpi.`prov_id` 
    JOIN `t_host_org_type_sub` AS sub 
      ON sub.`host_org_type_sub_id` = lpi.`host_org_type_sub_id` 
    JOIN `t_host_org_type` AS org 
      ON lpi.`host_org_type_id` = org.`host_org_type_id` 
  WHERE lpi.`region_id` = ID
  ORDER BY lpi.`host_org_id` ;
END */$$
DELIMITER ;

/* Procedure structure for procedure `report_RFV` */

/*!50003 DROP PROCEDURE IF EXISTS  `report_RFV` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `report_RFV`()
BEGIN
SELECT 
  DISTINCT req.`ref_no` AS 'Request No',
  lpi.`host_org` AS 'LPI',
  proj.`proj_title`,
  vol_org.`vol_org_dsc` AS 'IVSO',
  req_stat.`request_status`,
  req.`date_received`,
  req.`date_assessed`,
  req.`date_approved`,
  req.`date_letter_intent`,
  req.`date_site_assesment`,
  req.`date_request_volunteer`
FROM
  `t_request` AS req 
  JOIN `t_request_sub` AS sub 
    ON sub.`request_id` = req.`request_id` 
  JOIN `t_host_org` AS lpi 
    ON req.`host_org_id` = lpi.`host_org_id` 
  JOIN `t_project` AS proj 
    ON req.`project_id` = proj.`project_id` 
  JOIN `t_vol_org` AS vol_org 
    ON req.`vol_org_id` = vol_org.`vol_org_id` 
  JOIN `t_vol_status` AS vol_status 
    ON sub.`vol_status_id` = vol_status.`status_id` 
    JOIN `t_request_status` AS req_stat
    ON req.`request_status_id` = req_stat.`request_status_ID`
WHERE req.`isActive` = 1 ORDER BY req.`date_created` DESC LIMIT 200 ;
    END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_check_id_request` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_check_id_request` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_check_id_request`(foo VARCHAR (255))
BEGIN
  Select 
    ref_no 
  from
    `t_request` 
  where ref_no = foo ;
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_check_id_volunteer` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_check_id_volunteer` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_check_id_volunteer`(foo Varchar (255))
BEGIN
  Select 
    ref_no 
  from
    `t_volunteer` 
  where ref_no = foo ;
  
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_check_institution_Main` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_check_institution_Main` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_check_institution_Main`(foo varchar(255))
BEGIN
	select * from `t_host_org_type` where host_org_type = foo;
    END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_check_institution_sub` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_check_institution_sub` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_check_institution_sub`(foo VARCHAR(255))
BEGIN
SELECT * FROM `t_host_org_type_sub` WHERE host_org_type_sub = foo;
    END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_check_isNGO` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_check_isNGO` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_check_isNGO`(foo varchar (255))
BEGIN
  SELECT 
    org_type.isNGO 
  FROM
    `t_host_org_type_sub` AS org_type 
    JOIN `t_host_org` AS org 
      ON org_type.`host_org_type_sub_id` = org.`host_org_type_sub_id` 
  WHERE org.`host_org` = foo;
  END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_check_ivso_name` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_check_ivso_name` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_check_ivso_name`(foo varchar(255))
BEGIN
	select * from `t_vol_org` where vol_org_dsc = foo;
    END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_check_notification_for_asst_end` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_check_notification_for_asst_end` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_check_notification_for_asst_end`()
BEGIN
  SELECT 
    req.`ref_no`,
    sub.request_sub_id,
    vol.`vol_name`,
    org.`vol_org_dsc`,
    sub.`asst_start`,
    sub.`asst_end` 
  FROM
    `t_request_sub` AS sub 
    JOIN `t_volunteer` AS vol 
      ON vol.`vol_id` = sub.`vol_id` 
    JOIN `t_vol_org` AS org 
      ON vol.`vol_org` = org.`vol_org_id` 
      JOIN `t_request` AS req
      ON sub.`request_id` = req.`request_id`
  WHERE asst_end BETWEEN NOW() 
    AND ADDDATE(NOW(), 7) ;
  END */$$
DELIMITER ;

/* Procedure structure for procedure `report_vol_age_range` */

/*!50003 DROP PROCEDURE IF EXISTS  `report_vol_age_range` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `report_vol_age_range`()
BEGIN
  SELECT 
    CASE
      WHEN `getBirthday` (birthdate) BETWEEN 18 
      AND 35 
      THEN '18-35' 
      WHEN `getBirthday` (birthdate) BETWEEN 36 
      AND 50 
      THEN '36-50' 
      WHEN `getBirthday` (birthdate) BETWEEN 51 
      AND 65 
      THEN '51-65' 
      WHEN `getBirthday` (birthdate) >= 66 
      THEN '66 above' 
    END AS 'age_range' 
  FROM
    `t_volunteer` AS volunteer 
    JOIN `t_request_sub` AS sub_req 
      ON volunteer.vol_id = sub_req.vol_id 
  WHERE sub_req.`vol_status_id` = 
    (SELECT 
      status_id 
    FROM
      `t_vol_status` 
    WHERE status_vol = 'In Service') ;
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_check_project` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_check_project` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_check_project`(ID int (10))
BEGIN
SELECT * FROM `t_request` WHERE project_id = ID;
    END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_check_sector` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_check_sector` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_check_sector`(foo varchar (255))
BEGIN
  select 
    * 
  from
    `t_sector` 
  where sector = foo ;
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_check_specialization` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_check_specialization` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_check_specialization`(foo varchar(255))
BEGIN
	Select * from `t_specialization` where specialization_dsc = foo;
    END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_check_specialization_sub` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_check_specialization_sub` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_check_specialization_sub`(foo varchar(255))
BEGIN
SELECT * FROM `t_specialization_sub` WHERE specialization_sub_desc = foo;
    END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_check_volunteer_before_deleting` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_check_volunteer_before_deleting` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_check_volunteer_before_deleting`(foo varchar (255))
BEGIN
  SELECT 
    vol.* 
  FROM
    `t_volunteer` AS vol 
  WHERE vol.`ref_no` = foo 
    AND vol.`vol_status` IN 
    (SELECT 
      status_vol 
    FROM
      `t_vol_status` 
    WHERE status_vol IN (
        'Finished Contract',
        'Disapproved',
        'Cancelled',
        'Disapproved',
        'n/a'
      )) ;
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_check_vol_in_service` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_check_vol_in_service` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_check_vol_in_service`(foo Varchar(255))
BEGIN
	SELECT vol_status FROM `t_volunteer` WHERE ref_no = foo;
    END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_delete_host_org` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_delete_host_org` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_delete_host_org`(ID int (10))
BEGIN
  delete 
  from
    `t_host_org` 
  where host_org_id = ID ;
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_delete_host_proj` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_delete_host_proj` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_delete_host_proj`(ID int (10))
BEGIN
  delete 
  from
    `t_project` 
  where project_id = ID ;
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_delete_request` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_delete_request` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_delete_request`(ID varchar (255))
BEGIN
  DECLARE a INT (10) ;
  declare b int (10) ;
  SELECT 
    @a := request_id 
  FROM
    `t_request` 
  WHERE ref_no = ID ;
  select 
    @b := report_id 
  from
    `t_request_sub` 
  where request_id = @a ;
  
  delete from `t_reports` where report_id = @b;
  delete from `t_request_sub` where request_id = @a;
  delete from `t_request` where ref_no = ID;
  
  
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_delete_request_sub_vol_info` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_delete_request_sub_vol_info` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_delete_request_sub_vol_info`(ID int(10))
BEGIN
delete from `t_request_sub` where request_sub_id = ID;
DELETE FROM `t_reports` WHERE report_id = ID;
    END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_delete_volunteer` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_delete_volunteer` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_delete_volunteer`(ID int (10))
BEGIN
  Delete 
  from
    `t_volunteer` 
  where vol_id = ID ;
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_delete_volunteer_by_ref_no` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_delete_volunteer_by_ref_no` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_delete_volunteer_by_ref_no`(ID varchar(255))
BEGIN
  DELETE 
  FROM
    `t_volunteer` 
  WHERE ref_no = ID ;
    END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_get_cmb_host_org_type_main` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_get_cmb_host_org_type_main` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_get_cmb_host_org_type_main`(foo VARCHAR(255))
BEGIN
  SELECT 
    host_org_type_id 
  FROM
    `t_host_org_type` 
  WHERE host_org_type = foo;
    END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_get_cmb_host_org_type_sub` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_get_cmb_host_org_type_sub` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_get_cmb_host_org_type_sub`(foo varchar(255))
BEGIN
  SELECT 
    host_org_type_sub_id 
  FROM
    `t_host_org_type_sub` 
  WHERE host_org_type_sub = foo;
  END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_get_cmb_institution_Main` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_get_cmb_institution_Main` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_get_cmb_institution_Main`(foo varchar(255))
BEGIN
Select host_org_type_id from `t_host_org_type` where host_org_type = foo;
    END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_get_cmb_province` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_get_cmb_province` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_get_cmb_province`(foo varchar (255))
BEGIN
  SELECT 
    prov_id 
  FROM
    `t_province` 
  WHERE prov_dsc = foo;
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_get_cmb_region` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_get_cmb_region` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_get_cmb_region`(foo varchar (255))
BEGIN
  SELECT 
    region_id 
  FROM
    `t_region` 
  WHERE region_desc = foo;
  END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_get_cmb_req_status` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_get_cmb_req_status` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_get_cmb_req_status`(foo varchar (255))
BEGIN
  select 
    request_status_ID 
  from
    `t_request_status` 
  where request_status = foo ;
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_get_cmb_sector` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_get_cmb_sector` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_get_cmb_sector`(foo varchar(255))
BEGIN
select sector_id from `t_sector` where sector = foo;
    END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_get_cmb_specialization` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_get_cmb_specialization` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_get_cmb_specialization`(foo varchar(255))
BEGIN
Select specialization_id from `t_specialization` where specialization_dsc = foo;
    END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_get_cmb_specializationSUB` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_get_cmb_specializationSUB` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_get_cmb_specializationSUB`(foo varchar (255))
BEGIN
  select 
    specialization_sub_id 
  from
    `t_specialization_sub` 
  where specialization_sub_desc = foo;
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_get_cmb_vol_status` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_get_cmb_vol_status` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_get_cmb_vol_status`(foo varchar(255))
BEGIN
select status_id from `t_vol_status` where status_vol = foo;
    END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_get_host_org_id` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_get_host_org_id` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_get_host_org_id`(foo varchar(255))
BEGIN
  Select 
    host_org_id 
  from
    `t_host_org` 
  where host_org = foo ;
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_get_host_org_name` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_get_host_org_name` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_get_host_org_name`(ID int (10))
BEGIN
  Select 
    host_org 
  from
    `t_host_org` 
  where host_org_id = ID ;
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_get_project_id` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_get_project_id` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_get_project_id`(foo varchar (255))
BEGIN
  Select 
    project_id 
  from
    `t_project` 
  where proj_title = foo ;
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_get_vol_id` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_get_vol_id` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_get_vol_id`(foo varchar (255))
BEGIN
Select vol_id from `t_volunteer` where ref_no = foo;
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_get_vol_org` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_get_vol_org` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_get_vol_org`(foo varchar (255))
BEGIN
  select 
    vol_org_id
  from
    `t_vol_org`
  where vol_org_dsc = foo ;
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_insert_extension` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_insert_extension` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_insert_extension`(
  subID INT (10),
  startDate VARCHAR (255),
  endDate VARCHAR (255),
  remarksExt VARCHAR (2500)
)
BEGIN
  insert into `t_extension` (
    request_sub_id,
    start_date,
    end_date,
    remarks
  ) 
  values
    (
      subID,
      CONVERT(startDate, DATE),
      CONVERT(endDate, DATE),
      remarksExt
    ) ;
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_insert_host_org` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_insert_host_org` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_insert_host_org`(
  orgName VARCHAR (255),
  orgHeadName VARCHAR (255),
  orgTitle VARCHAR (255),
  orgAddress1 VARCHAR (255),
  orgAddress2 VARCHAR (255),
  munCity VARCHAR (255),
  telNumber1 VARCHAR (255),
  telNumber2 VARCHAR (255),
  faxNumber VARCHAR (255),
  orgEmail VARCHAR (255),
  orgWebsite VARCHAR (255),
  orgMandate VARCHAR (5000),
  provID INT (10),
  regionID INT (10),
  hostSubID INT (10),
  hostMain int(10)
)
BEGIN
  INSERT INTO t_host_org (
    host_org,
    head_name,
    title,
    Address1,
    Address2,
    mun_city,
    tel_number1,
    tel_number2,
    fax_number,
    email,
    website,
    Mandate,
    prov_id,
    region_id,
    host_org_type_sub_id,
    Date_entry,isActive,
    host_org_type_id
  ) 
  VALUES
    (
      orgName,
      orgHeadName,
      orgTitle,
      orgAddress1,
      orgAddress2,
      munCity,
      telNumber1,
      telNumber2,
      faxNumber,
      orgEmail,
      orgWebsite,
      orgMandate,
      provID,
      regionID,
      hostSubID,
      now(),1,hostMain
    ) ;
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_insert_host_proj` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_insert_host_proj` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_insert_host_proj`(
  hostOrgID int (10),
  projTitle VARCHAR (255),
  projMgr VARCHAR (255),
  projDuration VARCHAR (255),
  projAddressNo VARCHAR (255),
  projAddressStreet VARCHAR (255),
  projMunCity VARCHAR (255),
  projBudget VARCHAR (255),
  provID INT (10),
  regionID INT (10),
  projSourceFund VARCHAR (255),
  projObjective VARCHAR (5000),
  projTargetBeneficiaries VARCHAR (255),
  projDateStart varchar (255),
  projPosition VARCHAR(255),
  projContactNo VARCHAR(255)
)
BEGIN
  insert into `t_project` (
    host_org_id,
    proj_title,
    proj_mgr,
    proj_duration,
    proj_address_no,
    proj_address_street,
    mun_city,
    prov_id,
    region_id,
    bugdet,
    source_fund,
    objective,
    target_benificiaries,
    date_start,
    date_created,
    proj_position,
    proj_contactNo
  ) 
  VALUES
    (
      hostOrgID,
      projTitle,
      projMgr,
      projDuration,
      projAddressNo,
      projAddressStreet,
      projMunCity,
      provID,
      regionID,
      projBudget,
      projSourceFund,
      projObjective,
      projTargetBeneficiaries,
      projDateStart,
      now(),
      projPosition,
      projContactNo
    ) ;
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_insert_institution_Main` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_insert_institution_Main` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_insert_institution_Main`(orgTitle varchar (255))
BEGIN
  insert into `t_host_org_type` (host_org_type) 
  VALUES
    (orgTitle) ;
    
  INSERT INTO `t_host_org_type_sub` (
    host_org_type_id,
    host_org_type_sub,
    isNGO
  ) 
  VALUES
    (
      LAST_INSERT_ID(),
      CONCAT(
        'Initial value,update this later',
        ' ',
        orgTitle
      ),
      0
    ) ;
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_insert_institution_sub` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_insert_institution_sub` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_insert_institution_sub`(
  subName VARCHAR (255),
  subIsNGO VARCHAR (255),
  main INT (10)
)
BEGIN
  insert into `t_host_org_type_sub` (
    host_org_type_id,
    host_org_type_sub,
    isNGO
  )values (main,subName,subIsNGO);
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_insert_ivso` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_insert_ivso` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_insert_ivso`(orgName varchar (255))
BEGIN
  insert into `t_vol_org` (vol_org_dsc) 
  values
    (orgName) ;
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_insert_logs` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_insert_logs` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_insert_logs`(
  logname varchar (255),
  logAction varchar (255)
)
BEGIN
  insert into `t_logs` (account_name,log_action,log_date) 
  values
    (logName, logAction, now()) ;
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_insert_sector` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_insert_sector` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_insert_sector`(sectorName varchar(255))
BEGIN
insert into `t_sector`(sector) values(sectorName);
    END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_insert_specialization` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_insert_specialization` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_insert_specialization`(
  sec int (10),
  specializationDESC varchar (255)
)
BEGIN
  insert into `t_specialization` (sector_id, specialization_dsc) 
  values
    (sec, specializationDESC);
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_insert_specialization_sub` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_insert_specialization_sub` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_insert_specialization_sub`(
  spec INT (10),
  sec INT (10),
  specSubDesc VARCHAR (255)
)
BEGIN
  insert into `t_specialization_sub` (
    specialization_sub_desc,
    specialization_id,
    sector_id
  ) 
  values
    (specSubDesc, spec, sec) ;
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_load_extension` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_load_extension` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_load_extension`(ID int(10))
BEGIN
  SELECT 
    extension_id AS 'ID',
    start_date AS 'Start Date',
    end_date AS 'End Date'
      FROM
    `t_extension` where request_sub_id = ID ;
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_load_host_org` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_load_host_org` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_load_host_org`(ID int(10))
BEGIN
  SELECT 
    host_org_id AS 'ID',
    host_org AS 'Organization Name',
    head_name AS 'Head Coordinator',
    CONCAT(
      address1,
      ' ',
      address2,
      ' ',
      mun_city
    ) AS 'Address' 
  from
    t_host_org 
    where isActive = ID ORDER BY date_entry DESC LIMIT 300;
  END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_load_host_org_pop_up` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_load_host_org_pop_up` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_load_host_org_pop_up`()
BEGIN
  Select 
    host_org_id AS 'ID',
    host_org AS 'LPI' 
  FROM
    `t_host_org` 
  ORDER BY host_org_id ;
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_load_institution_type` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_load_institution_type` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_load_institution_type`()
BEGIN
  SELECT 
    host_org_type_id AS 'ID',
    host_org_type AS 'Institution Type' 
  FROM
    `t_host_org_type` 
  ORDER BY host_org_type_id ;
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_insert_request` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_insert_request` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_insert_request`(
  refNo VARCHAR (255),
  duration VARCHAR (255),
  hostOrgID INT (25),
  projID INT (25),
  volOrgID INT (25),
  dateReceived VARCHAR (255),
  dateAssessed VARCHAR (255),
  dateApproved VARCHAR (255),
  assessedBy VARCHAR (255),
  requestStatusID INT (10),
  remarksRequest VARCHAR (2500),
  dateLetterIntent VARCHAR (255),
  dateRequestVolunteer VARCHAR (255),
  dateSiteAssesment VARCHAR (255),
  secRegistration VARCHAR (255),
  dateAppVolOrg VARCHAR (255),
  completeRequirement INT (10),
  dateCompletion VARCHAR (255),
  requirementRemarks VARCHAR (2550)
)
BEGIN
  insert into `t_request` (
    ref_no,
    duration_vol_assistance,
    host_org_id,
    project_id,
    vol_org_id,
    date_received,
    date_assessed,
    date_approved,
    assessed_by,
    request_status_id,
    remarks,
    date_letter_intent,
    date_request_volunteer,
    date_site_assesment,
    sec_registration,
    date_app_volorgr,
    complete_requirements,
    date_completion,
    requirement_remarks,
    isActive,
    date_created
  ) 
  values
    (
      refNo,
      duration,
      hostOrgID,
      projID,
      volOrgID,
      CONVERT(dateReceived, DATE),
      CONVERT(dateAssessed, DATE),
      CONVERT(dateApproved, DATE),
      assessedBy,
      requestStatusID,
      remarksRequest,
      CONVERT(dateLetterIntent, DATE),
      CONVERT(dateRequestVolunteer, DATE),
      CONVERT(dateSiteAssesment, DATE),
      secRegistration,
      CONVERT(dateAppVolOrg, DATE),
      completeRequirement,
      CONVERT(dateCompletion, DATE),
      requirementRemarks,1,now()
    ) ;
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_insert_request_sub` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_insert_request_sub` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_insert_request_sub`(
  reqID int (10),
  sectorID INT (10),
  specializationID INT (10),
  specializationSubID INT (10),
  batchNumber VARCHAR (255),
  volStatusID INT (10),
  volID INT (10),
  asstStart VARCHAR (255),
  asstEnd VARCHAR (255),
  rptWFP VARCHAR (255),
  rptPlacement VARCHAR (255),
  rptInitial VARCHAR (255),
  rptAnnual VARCHAR (255),
  rptEndofAssignment VARCHAR (255),
  activitiesAndAccmplshmnt VARCHAR (255),
  issueAndConcern VARCHAR (255),
  majorOutput VARCHAR (255),
  outComes VARCHAR (255),
  recommendations VARCHAR (255)
)
BEGIN
  insert into `t_reports` (
    report_wfp,
    report_placement,
    report_initial,
    report_annual,
    report_end,
    act_acomp,
    issue_concern,
    major_outputs,
    outcomes,
    recommend
  ) 
  values
    (
      CONVERT(rptWFP, DATE),
      CONVERT(rptPlacement, DATE),
      CONVERT(rptInitial, DATE),
      CONVERT(rptAnnual, DATE),
      CONVERT(rptEndofAssignment, DATE),
      activitiesAndAccmplshmnt,
      issueAndConcern,
      majorOutput,
      outComes,
      recommendations
    ) ;
  insert into `t_request_sub` (
    request_id,
    report_id,
    sector_id,
    specialization_id,
    specialization_sub_id,
    batch_number,
    vol_status_id,
    vol_id,
    asst_start,
    asst_end,
    isActive,
    date_entry
  ) 
  values
    (
      reqID,
      last_insert_id(),
      sectorID,
      specializationID,
      specializationSubID,
      batchNumber,
      volStatusID,
      volID,
      CONVERT(asstStart, DATE),
      CONVERT(asstEnd, DATE),
      1,
      now()
    ) ;
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_insert_volunteer` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_insert_volunteer` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_insert_volunteer`(
  refNo VARCHAR (255),
  volName VARCHAR (255),
  volOrg INT (10),
  volSex VARCHAR (255),
  volBday DATETIME (6),
  addNo VARCHAR (255),
  addSt VARCHAR (255),
  munCity VARCHAR (255),
  provID INT (10),
  regionID INT (10),
  volEmail VARCHAR (255),
  mobileNumber VARCHAR (255),
  dateArrival VARCHAR (255),
  dateDeparture VARCHAR (255),
  dateVisa VARCHAR (255),
  datePassport VARCHAR (255),
  volRemarks VARCHAR (2550),
  volPicture MEDIUMBLOB
)
BEGIN
  insert into `t_volunteer` (
    ref_no,
    vol_name,
    vol_org,
    sex,
    birthdate,
    add_no,
    add_st,
    mun_city,
    prov_id,
    region_id,
    email,
    mobile_number,
    date_arrival,
    date_departure,
    visa_exp_date,
    passport_exp,
    remarks,
    vol_picture,
    date_entry,
    vol_status,
    isActive
  ) 
  VALUES
    (
      refNo,
      volName,
      volOrg,
      volSex,
      volBday,
      addNo,
      addSt,
      munCity,
      provID,
      regionID,
      volEmail,
      mobileNumber,
      convert(dateArrival,date),
      convert(dateDeparture,date),
      convert(dateVisa,date),
      convert(datePassport,date),
      volRemarks,
      volPicture,
      now(),'n/a',1
    ) ;
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_load_history_hostOrg` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_load_history_hostOrg` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_load_history_hostOrg`(ID int (10))
BEGIN
  SELECT 
    req.`ref_no` AS 'Request_No',
    sub.request_sub_id as 'Sub id',
    vol_org.`vol_org_dsc` AS 'IVSO',
    vol.`vol_name` AS 'Volunteer Name',
    proj.`proj_title` AS 'Project Title',
  vol_status.`status_vol` AS 'Volunteer Status' 
  FROM
    `t_request_sub` AS sub 
    JOIN `t_request` AS req 
      ON req.`request_id` = sub.`request_id` 
    JOIN `t_project` AS proj 
      ON req.`project_id` = proj.`project_id` 
    JOIN `t_volunteer` AS vol 
      ON sub.`vol_id` = vol.vol_id 
    JOIN `t_vol_org` AS vol_org 
      ON req.`vol_org_id` = vol_org.`vol_org_id` 
    JOIN `t_vol_status` AS vol_status 
      ON sub.`vol_status_id` = vol_status.`status_id` 
  WHERE req.`host_org_id` = ID ;
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_load_history_vol` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_load_history_vol` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_load_history_vol`(foo varchar (255))
BEGIN
  SELECT 
    req.`ref_no` as 'Request No.',
    sub.request_sub_id AS 'Sub ID',
    org.`host_org` as 'LPI',
    proj.`proj_title` as 'Project Title',
    sub.`asst_start` as 'Date Start',
    sub.`asst_end` as 'Date End',
    vol_status.`status_vol` AS 'Volunteer Status' 
  FROM
    `t_request` AS req 
    JOIN `t_request_sub` AS sub 
      ON req.`request_id` = sub.`request_id` 
    JOIN `t_host_org` AS org 
      ON org.`host_org_id` = req.`host_org_id` 
    JOIN `t_project` AS proj 
      ON req.`project_id` = proj.`project_id` 
    JOIN `t_volunteer` AS vol 
      ON sub.`vol_id` = vol.vol_id 
    JOIN `t_vol_status` AS vol_status 
      ON sub.`vol_status_id` = vol_status.`status_id` 
  WHERE vol.`ref_no` = foo ;
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_load_institution_type_Sub` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_load_institution_type_Sub` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_load_institution_type_Sub`()
BEGIN
SELECT 
  sub.`host_org_type_sub_id` AS 'ID',
  
  sub.`host_org_type_sub` as 'Sub Type' 
FROM
  `t_host_org_type_sub` AS sub 
  JOIN `t_host_org_type` AS main 
    ON sub.`host_org_type_id` = main.`host_org_type_id` 
ORDER BY sub.`host_org_type_sub_id` ;
    END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_load_login` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_load_login` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_load_login`()
BEGIN
  SELECT 
    ID,login_name AS 'Name',
    login_userName AS 'Username'
  FROM
    `t_login` ;
  END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_load_logs` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_load_logs` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_load_logs`()
BEGIN
SELECT 
    * 
  FROM
    `t_logs` 
  WHERE CONVERT(log_date, DATE) = CURDATE() 
  ORDER BY id DESC LIMIT 500;
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_load_pop_up_vol` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_load_pop_up_vol` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_load_pop_up_vol`(foo varchar (255))
BEGIN
  SELECT 
    vol.ref_no,
    vol.vol_name 
  FROM
    `t_volunteer` AS vol 
    JOIN `t_vol_org` AS vol_org 
      ON vol.vol_org = vol_org.vol_org_id 
  WHERE vol_org.vol_org_dsc = foo 
    and vol.isActive = 1 
    and vol.vol_status not in ('In Service') ;
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_load_project` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_load_project` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_load_project`(ID int (10))
BEGIN
  Select 
    project_id as 'Project ID',
    proj_title as 'Title',
    proj_duration as 'Duration',
    bugdet as 'Budget' 
  from
    `t_project` 
  where host_org_id = ID;
  END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_load_proj_pop_up` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_load_proj_pop_up` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_load_proj_pop_up`(ID int (255))
BEGIN
  Select 
    project_id as 'ID',
    proj_title as 'Project Description/Name' 
  from
    `t_project` where host_org_id = ID ;
  END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_load_request` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_load_request` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_load_request`(ID int(10))
BEGIN
  SELECT 
    req.ref_no AS 'Reference_No',
    org.host_org AS 'Host_Organization',
    proj.proj_title AS 'Project_Title',
    vso.vol_org_dsc AS 'Volunteer_Organization',
    req_stat.request_status AS 'Request_Status',
    req.assessed_by as 'Assessed_By'
  FROM
    `t_request` AS req 
    JOIN `t_host_org` AS org 
      ON req.`host_org_id` = org.host_org_id 
    JOIN `t_project` AS proj 
      ON req.`project_id` = proj.project_id 
    JOIN `t_vol_org` AS vso 
      ON req.`vol_org_id` = vso.vol_org_id 
    JOIN `t_request_status` AS req_stat 
      ON req.`request_status_id` = req_stat.request_status_ID 
      where req.isActive =ID
  ORDER BY date_received DESC limit 300;
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_load_req_sub_volunteerInfo` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_load_req_sub_volunteerInfo` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_load_req_sub_volunteerInfo`(ID int (10))
BEGIN
  Select 
    req_sub.request_sub_id as 'Sub ID',
    vol.ref_no as 'Vol ID',
    vol.vol_name,
    req_sub.asst_start,
    req_sub.asst_end
 
  from
    t_request_sub as req_sub 
    join `t_volunteer` as vol 
      on req_sub.vol_id = vol.vol_id 
  where req_sub.isActive = 1 and req_sub.request_id = ID ;
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_load_req_sub_volunteerinfo_recyclebin` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_load_req_sub_volunteerinfo_recyclebin` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_load_req_sub_volunteerinfo_recyclebin`(ID int (10))
BEGIN
SELECT 
  req.`ref_no` AS 'Request No',
  req_sub.request_sub_id AS 'Sub ID',
  vol.ref_no AS 'Vol Ref No',
  vol.vol_name,
  req_sub.asst_start,
  req_sub.asst_end,
  vol_stat.`status_vol`
FROM
  t_request_sub AS req_sub 
  JOIN `t_volunteer` AS vol 
    ON req_sub.vol_id = vol.vol_id 
  JOIN `t_request` AS req 
    ON req.request_id = req_sub.request_id 
    JOIN `t_vol_status` AS vol_stat
    ON vol_stat.`status_id` = req_sub.`vol_status_id`
WHERE req_sub.isActive = ID ;
    
    
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_load_sector` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_load_sector` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_load_sector`()
BEGIN
	Select sector_id as 'ID',sector as 'Sector' from `t_sector`;
    END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_load_specialization` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_load_specialization` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_load_specialization`()
BEGIN
SELECT 
  specialization_id AS 'ID',
  specialization_dsc AS 'Title' 
FROM
  `t_specialization` where specialization_id != 106 ;
    END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_load_specialization_sub` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_load_specialization_sub` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_load_specialization_sub`()
BEGIN
  SELECT 
    specialization_sub_id AS 'ID',
    specialization_sub_desc AS 'Title' 
  FROM
    `t_specialization_sub` 
  WHERE specialization_sub_id != 1 ;
  END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_load_volunteer` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_load_volunteer` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_load_volunteer`(ID int(10))
BEGIN
  SELECT 
    vol.ref_no AS 'ID',
    vol.vol_name AS 'Volunteer Name',
    vol.sex AS 'Sex',
    vol_org.vol_org_dsc AS 'Volunteer Organization',
    CONCAT(
      vol.add_no,
      ' ',
      vol.add_st,
      ' ',
      vol.mun_city
    ) AS 'Address' 
  FROM
    `t_volunteer` as vol 
    JOIN `t_vol_org` AS vol_org 
      ON vol_org.vol_org_id = vol.vol_org
      where vol.isActive =ID order by date_entry desc limit 300;
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_load_vol_org_pop_up` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_load_vol_org_pop_up` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_load_vol_org_pop_up`()
BEGIN
  select 
    vol_org_id  as 'ID',vol_org_dsc as 'VSO'
  from
    `t_vol_org` order by vol_org_id ;
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_login` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_login` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_login`(
  userName varchar (255),
  userPassword varchar (255), 
  key_str varchar (255)
)
BEGIN
  Select 
    * 
  from
    `t_login` 
  where login_username = userName 
    and login_password = `ENCRYPTER`(userPassword,key_str);
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_login_check_if_active` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_login_check_if_active` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_login_check_if_active`(
  userName VARCHAR (255),
  userPassword VARCHAR (255),key_str varchar(255)
)
BEGIN
 SELECT 
    isActive 
  FROM
    `t_login` 
  WHERE login_username = userName 
    AND login_password = `ENCRYPTER`(userPassword,key_str);
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_login_check_QandA` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_login_check_QandA` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_login_check_QandA`(
  foo varchar (255),
  foo2 varchar (255),
  userName varchar (255)
)
BEGIN
  Select 
    * 
  from
    `t_login` 
  where secret_question = foo 
    and secret_answer = foo2 
    and login_userName = userName ;
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_login_check_username` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_login_check_username` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_login_check_username`(foo varchar(255))
BEGIN
select * from  `t_login` where login_userName = foo;
    END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_login_get_id` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_login_get_id` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_login_get_id`(
  userName VARCHAR (255),
  userPassword VARCHAR (255),
  key_str VARCHAR (255)
)
BEGIN
SELECT 
    ID
  FROM
    `t_login` 
  WHERE login_username = userName 
    AND login_password = `ENCRYPTER`(userPassword,key_str) ;
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_login_get_name` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_login_get_name` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_login_get_name`(
  userName VARCHAR (255),
  userPassword VARCHAR (255),key_str varchar(255)
)
BEGIN
  SELECT 
    login_name 
  FROM
    `t_login` 
  WHERE login_username = userName 
    AND login_password = `ENCRYPTER`(userPassword,key_str) ;
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_login_get_userlevel` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_login_get_userlevel` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_login_get_userlevel`(
  userName VARCHAR (255),
  userPassword VARCHAR (255),key_str varchar(255)
)
BEGIN
 SELECT 
    userLevel
  FROM
    `t_login` 
  WHERE login_username = userName 
    AND login_password = `ENCRYPTER`(userPassword,key_str) ;
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_login_insert_account` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_login_insert_account` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_login_insert_account`(
  userPassword varchar (255),
  userName varchar (255),
  userRole INT (10),
  userStatus INT (10),
  key_str varchar (255)
)
BEGIN
  insert into `t_login` (
    login_userName,
    login_password,
    userLevel,
    isActive,
    login_name
  ) 
  values
    (
      userName,
      `ENCRYPTER` (userPassword, key_str),
      userRole,
      userStatus,
      'pnvsca@User'
    ) ;
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_login_update_admin` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_login_update_admin` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_login_update_admin`(
  loginID int (10),
  userRole int (10),
  userStatus int (10)
)
BEGIN
  update 
    `t_login` 
  set
    userLevel = userRole,
    isActive = userStatus 
  where ID = loginID ;
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_login_update_password` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_login_update_password` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_login_update_password`(userPassword varchar(255),userName varchar(255),key_str varchar(255))
BEGIN
update `t_login` set login_password = `ENCRYPTER`(userPassword,key_str) where login_userName = userName;
    END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_login_update_user` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_login_update_user` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_login_update_user`(
  loginID INT (10),
  acctName varchar (255),
  userName varchar (255),
  userPassword varchar (255),
  secretQuestion varchar (255),
  secretAnswer varchar (255),
  secretHint varchar (255),
  key_str varchar (255)
)
BEGIN
  update 
    `t_login` 
  set
    login_name = acctName,
    login_userName = userName,
    login_password = `ENCRYPTER`(userPassword,key_str),
    secret_question = secretQuestion,
    secret_answer = secretAnswer,
    hint = secretHint 
  where ID = loginID ;
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_logs_get_latest_id` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_logs_get_latest_id` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_logs_get_latest_id`()
BEGIN
SELECT 
    account_name,log_action,log_date
  FROM
    `t_logs` ORDER BY id DESC LIMIT 1 ;
    END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_logs_latestid` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_logs_latestid` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_logs_latestid`()
BEGIN
SELECT 
    MAX(id) 
  FROM
    `t_logs` ;
    END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_populate_cmb_host` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_populate_cmb_host` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_populate_cmb_host`()
BEGIN
  SELECT 
    host_org_type 
  FROM
    `t_host_org_type` 
  ORDER BY host_org_type_id ;
  END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_populate_cmb_host_org` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_populate_cmb_host_org` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_populate_cmb_host_org`(foo varchar(255))
BEGIN
  SELECT 
    sub.host_org_type_sub 
  FROM
    `t_host_org_type_sub` AS sub 
    JOIN `t_host_org_type` AS org 
      ON sub.`host_org_type_id` = org.`host_org_type_id` 
  WHERE org.host_org_type =  foo;
  
  END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_populate_cmb_province` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_populate_cmb_province` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_populate_cmb_province`(foo varchar(255))
BEGIN
  SELECT 
    prov.prov_dsc 
  FROM
    `t_province` AS prov 
    JOIN `t_region` AS reg 
      ON prov.`region_id` = reg.`region_id` 
  WHERE reg.`region_desc` = foo;
  END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_populate_cmb_region` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_populate_cmb_region` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_populate_cmb_region`()
BEGIN
  SELECT 
    region_desc 
  FROM
    `t_region` 
  ORDER BY region_id ;
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_populate_cmb_request_status` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_populate_cmb_request_status` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_populate_cmb_request_status`()
BEGIN
  Select 
    request_status 
  from
    `t_request_status` ;
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_populate_cmb_sector` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_populate_cmb_sector` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_populate_cmb_sector`()
BEGIN
select sector from `t_sector`;
    END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_populate_cmb_specialization` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_populate_cmb_specialization` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_populate_cmb_specialization`(foo varchar (255))
BEGIN
  Select 
    spe.specialization_dsc 
  from
    `t_specialization` as spe 
    join `t_sector` as sec
    on spe.sector_id = sec.sector_id
    where sec.sector = foo;
    END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_populate_cmb_specialization_sub` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_populate_cmb_specialization_sub` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_populate_cmb_specialization_sub`(foo varchar(255), foo2 varchar(255))
BEGIN
 SELECT 
    sub.specialization_sub_desc 
  FROM
    `t_specialization_sub` AS sub
    JOIN `t_specialization` AS spec
    ON sub.specialization_id = spec.specialization_id 
    JOIN `t_sector` AS sec
    ON sec.sector_id = sub.sector_id
  WHERE spec.specialization_dsc = foo
    AND sec.sector = foo2 ;
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_populate_cmb_vol_status` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_populate_cmb_vol_status` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_populate_cmb_vol_status`()
BEGIN
  Select 
    status_vol 
  from
    `t_vol_status` ORDER BY status_id;
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_recycle_hostOrg_0` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_recycle_hostOrg_0` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_recycle_hostOrg_0`(ID int(10))
BEGIN
update `t_host_org` set isActive = 1 where host_org_id = ID;
    END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_recycle_hostOrg_1` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_recycle_hostOrg_1` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_recycle_hostOrg_1`(ID int(10))
BEGIN
update `t_host_org` set isActive = 0 where host_org_id = ID;
    END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_recycle_request_0` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_recycle_request_0` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_recycle_request_0`(ID varchar(25))
BEGIN
	update `t_request` set isActive = 1 where ref_no = ID;
    END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_recycle_request_1` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_recycle_request_1` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_recycle_request_1`(ID varchar(25))
BEGIN
	update `t_request` set isActive = 0 where ref_no = ID;
    END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_recycle_req_sub_0` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_recycle_req_sub_0` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_recycle_req_sub_0`(ID int(10))
BEGIN
update `t_request_sub` set isActive = 1 where request_sub_id = ID;
    END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_recycle_req_sub_1` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_recycle_req_sub_1` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_recycle_req_sub_1`(ID int(10))
BEGIN
update `t_request_sub` set isActive = 0 where request_sub_id = ID;
    END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_recycle_volunteer_0` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_recycle_volunteer_0` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_recycle_volunteer_0`(ID varchar(25))
BEGIN
update `t_volunteer` set isActive = 1 where ref_no = ID;
    END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_recycle_volunteer_1` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_recycle_volunteer_1` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_recycle_volunteer_1`(ID varchar(25))
BEGIN
update `t_volunteer` set isActive = 0 where ref_no = ID;
    END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_select_extension` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_select_extension` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_select_extension`(extensionID int(10))
BEGIN
	select * from `t_extension` where extension_id = extensionID;
    END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_select_host_project` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_select_host_project` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_select_host_project`(ID int (10))
BEGIN
  SELECT 
    proj.*,
    reg.`region_desc`,
    prov.`prov_dsc` 
  FROM
    `t_project` AS proj 
    JOIN `t_province` AS prov 
      ON proj.prov_id = prov.`prov_id` 
    JOIN `t_region` AS reg 
      ON reg.`region_id` = proj.`region_id` 
  WHERE project_id = ID ;
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_select_institution_main` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_select_institution_main` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_select_institution_main`(ID int (10))
BEGIN
  SELECT 
    * 
  FROM
    `t_host_org_type` 
  WHERE host_org_type_id = ID ;
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_select_institution_type_Sub` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_select_institution_type_Sub` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_select_institution_type_Sub`(ID int(10))
BEGIN
SELECT 
  sub.`host_org_type_sub_id`,
  main.`host_org_type`,
  sub.`host_org_type_sub`,sub.isNGO
FROM
  `t_host_org_type_sub` AS sub 
  JOIN `t_host_org_type` AS main 
    ON sub.`host_org_type_id` = main.`host_org_type_id` 
where sub.`host_org_type_sub_id` = ID 
ORDER BY sub.`host_org_type_sub_id`;
    END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_select_host_org` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_select_host_org` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_select_host_org`(orgID int(10))
BEGIN
  SELECT 
    org.host_org_id,
    org.`host_org`,
    org.`head_name`,
    org.`title`,
    org.`Address1`,
    org.`Address2`,
    org.mun_city,
    org.`tel_number1`,
    org.`tel_number2`,
    org.`fax_number`,
    org.`email`,
    org.`website`,
    org.`Mandate`,
    prov.prov_dsc,
    hsub.`host_org_type_sub`,
    h.host_org_type,
    r.region_desc 
  FROM
    t_host_org AS org 
    JOIN `t_province` AS prov 
      ON org.prov_id = prov.`prov_id` 
    JOIN `t_host_org_type_sub` AS hsub 
      ON hsub.`host_org_type_sub_id` = org.`host_org_type_sub_id` 
    JOIN `t_host_org_type` AS h 
      ON h.host_org_type_id = org.`host_org_type_id` 
    JOIN `t_region` AS r 
      ON r.`region_id` = org.`region_id` 
  WHERE host_org_id = orgID;
  END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_select_ivso` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_select_ivso` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_select_ivso`(ID int(10))
BEGIN
select * from `t_vol_org` where vol_org_id = ID;
    END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_select_login` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_select_login` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_select_login`(loginID int (10), key_str varchar (255))
BEGIN
  Select 
    ID,
    login_userName,
    `DECRYPTER`(login_password,key_str) as 'login_password',
    userLevel,
    login_name,
    secret_question,
    secret_answer,
    hint,
    isActive
  from
    `t_login` 
  where ID = loginID ;
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_select_login_by_username` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_select_login_by_username` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_select_login_by_username`(foo varchar (255))
BEGIN
  select 
*
  from
    `t_login` 
  where login_userName = foo ;
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_select_request` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_select_request` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_select_request`(refNo varchar(25))
BEGIN
  SELECT 
    req.*,
    org.host_org,
    proj.proj_title,
    vol_org.vol_org_dsc,
    stat.request_status 
  FROM
    `t_request` AS req 
    JOIN `t_host_org` AS org 
      ON req.host_org_id = org.host_org_id 
    JOIN `t_project` AS proj 
      ON req.project_id = proj.`project_id` 
    JOIN `t_vol_org` AS vol_org 
      ON req.`vol_org_id` = vol_org.`vol_org_id` 
    JOIN `t_request_status` AS stat 
      ON req.`request_status_id` = stat.`request_status_ID` 
  WHERE req.`ref_no` = refNo ;
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_select_request_sub` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_select_request_sub` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_select_request_sub`(subID int (24))
BEGIN
  SELECT 
    sub.*,
    sec.`sector`,
    spec.`specialization_dsc`,
    stat.`status_vol`,
    vol.`vol_name`,
    vol.`ref_no`,
    vol.`vol_picture`,
    spec_sub.`specialization_sub_desc`,
    rep.*
  FROM
    `t_request_sub` AS sub 
    JOIN `t_sector` AS sec 
      ON sub.`sector_id` = sec.`sector_id` 
    JOIN `t_specialization` AS spec 
      ON sub.`specialization_id` = spec.`specialization_id` 
    JOIN `t_vol_status` AS stat 
      ON sub.`vol_status_id` = stat.`status_id` 
    JOIN `t_volunteer` AS vol 
      ON sub.`vol_id` = vol.`vol_id` 
    JOIN `t_specialization_sub` AS spec_sub 
      ON sub.`specialization_sub_id` = spec_sub.`specialization_sub_id` 
    JOIN `t_reports` AS rep 
      ON sub.report_id = rep.report_id
  WHERE sub.`request_sub_id` = subID ;
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_select_sector` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_select_sector` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_select_sector`(ID int(10))
BEGIN
Select * from `t_sector`WHERE sector_id = ID;
    END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_select_specialization` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_select_specialization` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_select_specialization`(ID int(10))
BEGIN
SELECT 
  spec.*,sec.`sector`
FROM
  `t_specialization` AS spec 
  JOIN `t_sector` AS  sec
  ON spec.`sector_id` = sec.`sector_id`
WHERE specialization_id = ID;
    END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_select_specialization_sub` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_select_specialization_sub` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_select_specialization_sub`(ID int (10))
BEGIN
  SELECT 
    sub.*,
    spec.`specialization_dsc`,
    sec.`sector` 
  FROM
    `t_specialization_sub` AS sub 
    JOIN `t_specialization` AS spec 
      ON spec.`specialization_id` = sub.`specialization_id` 
    JOIN `t_sector` AS sec 
      ON sec.`sector_id` = sub.`sector_id` 
  WHERE sub.`specialization_sub_id` = ID ;
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_select_volunteer` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_select_volunteer` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_select_volunteer`(refNo varchar (100))
BEGIN
  Select 
    vol.*,
    vol_org.vol_org_dsc,
    reg.`region_desc`,
    prov.`prov_dsc` 
  FROM
    `t_volunteer` AS vol 
    JOIN `t_province` AS prov 
      ON vol.prov_id = prov.`prov_id` 
    JOIN `t_region` AS reg 
      ON reg.`region_id` = vol.`region_id` 
    JOIN `t_vol_org` AS vol_org
      ON vol_org.vol_org_id= vol.vol_org
      
  where ref_no = refNo ;
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_update_endOfAssistance_via_extension` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_update_endOfAssistance_via_extension` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_update_endOfAssistance_via_extension`(SubID int (10), endDate varchar (255))
BEGIN
  DECLARE a INT (10) ;
  SELECT 
    @a := status_id 
  FROM
    `t_vol_status` 
  WHERE status_vol = 'In Service' ;
  
  update 
    `t_request_sub` 
  set
    asst_end = convert(endDate, date),
    vol_status_id = @a
  where request_sub_id = SubID ;
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_update_extension` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_update_extension` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_update_extension`(
  extensionID int (10),
  subID INT (10),
  startDate VARCHAR (255),
  endDate VARCHAR (255),
  remarksExt VARCHAR (2500)
)
BEGIN
  update 
    `t_extension` 
  set
    request_sub_id = subID,
    start_date = convert(startDate,date),
    end_date = CONVERT(endDate,DATE),
    remarks = remarksExt
    where extension_id = extensionID;
  END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_update_host_org` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_update_host_org` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_update_host_org`(
  orgID INT (10),
  orgName VARCHAR (255),
  orgHeadName VARCHAR (255),
  orgTitle VARCHAR (255),
  orgAddress1 VARCHAR (255),
  orgAddress2 VARCHAR (255),
  munCity VARCHAR (255),
  telNumber1 VARCHAR (255),
  telNumber2 VARCHAR (255),
  faxNumber VARCHAR (255),
  orgEmail VARCHAR (255),
  orgWebsite VARCHAR (255),
  orgMandate VARCHAR (5000),
  provID INT (10),
  hostSubID INT (10),
  regionID INT (10),
  hostMain int(10)
)
BEGIN
  UPDATE 
    `t_host_org` 
  SET
    host_org = orgName,
    head_name = orgHeadName,
    title = orgTitle,
    Address1 = orgAddress1,
    Address2 = orgAddress2,
    mun_city = munCity,
    tel_number1 = telNumber1,
    tel_number2 = telNumber2,
    fax_number = faxNumber,
    email = orgEmail,
    website = orgWebsite,
    Mandate = orgMandate,
    prov_id = provID,
    region_id = regionID,
    host_org_type_sub_id = hostSubID,
    host_org_type_id = hostMain
  WHERE host_org_id = orgID ;
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_update_host_project` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_update_host_project` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_update_host_project`(
  projID int (10),
  projTitle varchar (255),
  projMgr varchar (255),
  projDuration VARCHAR (255),
  projAddressNo VARCHAR (255),
  projAddressStreet VARCHAR (255),
  projMunCity VARCHAR (255),
  projBudget VARCHAR (255),
  provID INT (10),
  regionID INT (10),
  projSourceFund VARCHAR (255),
  projObjective VARCHAR (5000),
  projTargetBeneficiaries VARCHAR (255),
  projDateStart varchar (255),
  projPosition varchar(255),
  projContactNo varchar(255)
)
BEGIN
  UPDATE 
    `t_project` 
  SET
    proj_title = projTitle,
    proj_mgr = projMgr,
    proj_duration = projDuration,
    proj_address_no = projAddressNo,
    proj_address_street = projAddressStreet,
    mun_city = projMunCity,
    prov_id = provID,
    region_id = regionID,
    bugdet = projBudget,
    source_fund = projSourceFund,
    objective = projObjective,
    target_benificiaries=projTargetBeneficiaries,
    date_start = projDateStart,
    proj_position = projPosition,
    proj_contactNo = projContactNo
    where project_id = projID;
    
    
    
  END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_update_institution_Main` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_update_institution_Main` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_update_institution_Main`(ID int (10), orgTitle varchar (255))
BEGIN
  update 
    `t_host_org_type` 
  set
    host_org_type = orgTitle 
  where host_org_type_id = ID ;
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_update_institution_Sub` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_update_institution_Sub` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_update_institution_Sub`(
  ID int (10),
  subName varchar (255),
  subIsNGO varchar (255),main int (10)
)
BEGIN
  update 
    `t_host_org_type_sub` 
  set
    host_org_type_sub = subName,
    isNGO = subIsNGO,
    host_org_type_id = main 
  where host_org_type_sub_id = ID;
  END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_update_ivso` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_update_ivso` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_update_ivso`(ID int(10), orgName varchar(255))
BEGIN
	update `t_vol_org` set vol_org_dsc = orgName where vol_org_id = ID;
    END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_update_request` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_update_request` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_update_request`(
  reqID int (20),
  refNo varchar (255),
  duration varchar (255),
  hostOrgID INT (25),
  projID int (25),
  volOrgID int (25),
  dateReceived varchar (255),
  dateAssessed varchar (255),
  dateApproved varchar (255),
  requestStatusID int (10),
  remarksRequest varchar (2500),
  dateLetterIntent varchar (255),
  dateRequestVolunteer VARCHAR (255),
  dateSiteAssesment VARCHAR (255),
  secRegistration varchar (255),
  dateAppVolOrg varchar (255),
  completeRequirement int (10),
  dateCompletion varchar (255),
  requirementRemarks varchar (2505)
)
BEGIN
  update 
    `t_request` 
  set
    ref_no = refNo,
    duration_vol_assistance = duration,
    host_org_id = hostOrgID,
    project_id = projID,
    vol_org_id = volOrgID,
    date_received = convert(dateReceived, date),
    date_assessed = convert(dateAssessed, date),
    date_approved = convert(dateApproved, date),
    request_status_id = requestStatusID,
    remarks = remarksRequest,
    date_letter_intent = convert(dateLetterIntent, date),
    date_request_volunteer = convert(dateRequestVolunteer, date),
    date_site_assesment = convert(dateSiteAssesment, date),
    sec_registration = secRegistration,
    date_app_volorgr = convert(dateAppVolOrg, date),
    complete_requirements = completeRequirement,
    date_completion = convert(dateCompletion, date),
    requirement_remarks = requirementRemarks 
  where request_id = reqID ;
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_update_request_sub` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_update_request_sub` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_update_request_sub`(subID INT (10),
  reportID INT (10),
  sectorID INT (10),
  specializationID INT (10),
  specializationSubID INT (10),
  batchNumber VARCHAR (255),
  volStatusID INT (10),
  volID INT (10),
  asstStart VARCHAR (255),
  asstEnd VARCHAR (255),
  rptWFP VARCHAR (255),
  rptPlacement VARCHAR (255),
  rptInitial VARCHAR (255),
  rptAnnual VARCHAR (255),
  rptEndofAssignment VARCHAR (255),
  activitiesAndAccmplshmnt VARCHAR (2500),
  issueAndConcern VARCHAR (2550),
  majorOutput VARCHAR (2550),
  outComes VARCHAR (2550),
  recommendations VARCHAR (2550)
)
BEGIN
  UPDATE 
    `t_request_sub` 
  SET
    sector_id = sectorID,
    specialization_id = specializationID,
    specialization_sub_id = specializationSubID,
    batch_number = batchNumber,
    vol_status_id = volStatusID,
    vol_id = volID,
    asst_start = CONVERT(asstStart,DATE),
    asst_end = CONVERT(asstEnd,DATE)
  WHERE request_sub_id = subID ;
  UPDATE 
    `t_reports` 
  SET
    report_wfp = CONVERT(rptWFP,DATE),
    report_placement = CONVERT(rptPlacement,DATE),
    report_initial = CONVERT(rptInitial,DATE),
    report_annual = CONVERT(rptAnnual,DATE),
    report_end = CONVERT(rptEndofAssignment,DATE),
    act_acomp =activitiesAndAccmplshmnt,
    issue_concern = issueAndConcern,
    major_outputs =  majorOutput,
    outcomes = outComes,
    recommend =  recommendations 
    WHERE report_id = reportID;
    END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_update_sector` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_update_sector` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_update_sector`(ID int(10),sectorName varchar(255))
BEGIN
	update `t_sector` set sector = sectorName where sector_id = ID;
    END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_update_specialization` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_update_specialization` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_update_specialization`(
  ID INT (10),
  specializationDESC VARCHAR (255),
  sec INT (10)
)
BEGIN
  update 
    `t_specialization` 
  set
    specialization_dsc = specializationDESC,
    sector_id = sec 
  where specialization_id = ID ;
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_update_specialization_sub` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_update_specialization_sub` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_update_specialization_sub`(
  ID int (10),
  spec int (10),
  sec int (10),
  specSubDesc varchar (255)
)
BEGIN
  update 
    `t_specialization_sub` 
  set
    specialization_sub_desc = specSubDesc,
    specialization_id = spec,
    sector_id = sec
    where specialization_sub_id = ID;
  END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_update_volunteer` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_update_volunteer` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_update_volunteer`(
  volID INT (10),
  refNo VARCHAR (255),
  volName VARCHAR (255),
  volOrg INT (10),
  volSex VARCHAR (255),
  volBday datetime (6),
  addNo VARCHAR (255),
  addSt VARCHAR (255),
  munCity VARCHAR (255),
  provID INT (10),
  regionID INT (10),
  volEmail VARCHAR (255),
  mobileNumber VARCHAR (255),
  dateArrival VARCHAR (255),
  dateDeparture VARCHAR (255),
  dateVisa VARCHAR (255),
  datePassport VARCHAR (255),
  volRemarks VARCHAR (2505),
  volPicture mediumblob 
)
BEGIN
  UPDATE 
    `t_volunteer` 
  SET
    ref_no = refNo,
    vol_name = volName,
    vol_org = volOrg,
    sex = volSex,
    birthdate = volBday,
    add_no = addNo,
    add_st = addSt,
    mun_city = munCity,
    prov_id = provID,
    region_id = regionID,
    email = volEmail,
    mobile_number = mobileNumber,
    date_arrival = convert(dateArrival,date),
    date_departure = Convert(dateDeparture,date),
    visa_exp_date = convert(dateVisa,date),
    passport_exp = convert(datePassport,date),
    remarks = volRemarks,
    vol_picture = volPicture 
  WHERE vol_id = volID ;
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_update_vol_status_on_req` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_update_vol_status_on_req` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_update_vol_status_on_req`(foo varchar(255),refNo varchar(255))
BEGIN
	update `t_volunteer` set vol_status = foo where ref_no = refNo;
    END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_update_vol_status_via_delete_in_request` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_update_vol_status_via_delete_in_request` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`SYSTEM`@`%` PROCEDURE `sp_update_vol_status_via_delete_in_request`(foo varchar (255))
BEGIN
  update 
    `t_volunteer` 
  set
    vol_status = 'n/a' 
  where ref_no = foo ;
END */$$
DELIMITER ;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
