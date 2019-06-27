CREATE TABLE persons(
	id INT(10) NOT NULL,
	firstName VARCHAR(50) NULL DEFAULT NULL,
	lastName VARCHAR(50) NULL DEFAULT NULL,
	address VARCHAR(50) NULL DEFAULT NULL,
	gender VARCHAR(50) NULL DEFAULT NULL	
)
ENGINE=INNODB;

INSERT INTO `persons` (`Id`, `FirstName`, `LastName`, `Address`, `Gender`) VALUES
(1, 'Leandro', 'Costa', 'Uberlândia - Minas Gerais - Brasil', 'Male'),
(2, 'Flávio', 'Costa', 'Patos de Minas - Minas Gerais - Brasil', 'Male');
