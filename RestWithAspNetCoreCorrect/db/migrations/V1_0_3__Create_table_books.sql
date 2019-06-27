CREATE TABLE IF NOT EXISTS books(
	id varchar(127) NOT NULL,
	autor longtext,
	launchDate datetime(6) NOT NULL,
	price decimal(65,2) NOT NULL,
	title longtext,
	primary key(id)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;