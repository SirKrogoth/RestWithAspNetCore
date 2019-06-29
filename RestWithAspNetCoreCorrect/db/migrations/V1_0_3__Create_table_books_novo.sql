CREATE TABLE IF NOT EXISTS books(
	id int(10) AUTO_INCREMENT PRIMARY KEY,
	author longtext,
	launchDate datetime NOT NULL,
	price decimal(65,2) NOT NULL,
	title longtext
) ENGINE=InnoDB DEFAULT CHARSET=latin1