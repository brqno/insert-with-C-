CREATE DATABASE USERS;
USE USERS;
GO
CREATE TABLE usuarios (
    id INT NOT NULL IDENTITY(1,1),
    nome VARCHAR(40) NOT NULL,
    usuario VARCHAR(40) NOT NULL,
    senha VARCHAR(40) NOT NULL,
	   email VARCHAR(40) NOT NULL,
    PRIMARY KEY (id)
);
GO
select * from usuarios