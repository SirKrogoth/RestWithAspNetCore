CREATE TABLE IF NOT EXISTS users(
	id int(10) NOT NULL AUTO_INCREMENT,
	login varchar(50) Unique NOT NULL,
	accessKey varchar(50) NOT NULL,
	primary key(id)
) ENGINE=InnoDB DEFAULT CHARSET=latin1