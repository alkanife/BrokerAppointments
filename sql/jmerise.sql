/*------------------------------------------------------------
*        Script SQLSERVER 
------------------------------------------------------------*/


/*------------------------------------------------------------
-- Table: brokers
------------------------------------------------------------*/
CREATE TABLE brokers(
	id_broker      INT IDENTITY (1,1) NOT NULL ,
	last_name      NVARCHAR (50) NOT NULL ,
	first_name     NVARCHAR (50) NOT NULL ,
	mail           NVARCHAR (100) NOT NULL ,
	phone_number   NVARCHAR (10) NOT NULL  ,
	CONSTRAINT brokers_PK PRIMARY KEY (id_broker)
);


/*------------------------------------------------------------
-- Table: customers
------------------------------------------------------------*/
CREATE TABLE customers(
	id_customer    INT IDENTITY (1,1) NOT NULL ,
	last_name      NVARCHAR (50) NOT NULL ,
	first_name     NVARCHAR (50) NOT NULL ,
	mail           NVARCHAR (100) NOT NULL ,
	phone_number   NVARCHAR (10) NOT NULL ,
	budget         INT  NOT NULL  ,
	CONSTRAINT customers_PK PRIMARY KEY (id_customer)
);


/*------------------------------------------------------------
-- Table: appointements
------------------------------------------------------------*/
CREATE TABLE appointements(
	id_appointement   INT IDENTITY (1,1) NOT NULL ,
	date_hour         DATETIME  NOT NULL ,
	subject           TEXT  NOT NULL ,
	id_broker         INT  NOT NULL ,
	id_customer       INT  NOT NULL  ,
	CONSTRAINT appointements_PK PRIMARY KEY (id_appointement)

	,CONSTRAINT appointements_brokers_FK FOREIGN KEY (id_broker) REFERENCES brokers(id_broker)
	,CONSTRAINT appointements_customers0_FK FOREIGN KEY (id_customer) REFERENCES customers(id_customer)
);



