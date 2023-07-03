/*------------------------------------------------------------
*        Script SQLSERVER 
------------------------------------------------------------*/


/*------------------------------------------------------------
-- Table: brokers
------------------------------------------------------------*/
CREATE TABLE brokers(
	id_broker     INT IDENTITY (1,1) NOT NULL ,
	lastName      NVARCHAR (50) NOT NULL ,
	firstName     NVARCHAR (50) NOT NULL ,
	mail          NVARCHAR (100) NOT NULL ,
	phoneNumber   NVARCHAR (10) NOT NULL  ,
	CONSTRAINT brokers_PK PRIMARY KEY (id_broker)
);


/*------------------------------------------------------------
-- Table: customers
------------------------------------------------------------*/
CREATE TABLE customers(
	id_customer   INT IDENTITY (1,1) NOT NULL ,
	lastName      NVARCHAR (50) NOT NULL ,
	firstName     NVARCHAR (50) NOT NULL ,
	mail          NVARCHAR (100) NOT NULL ,
	phoneNumber   NVARCHAR (10) NOT NULL ,
	budget        INT  NOT NULL  ,
	CONSTRAINT customers_PK PRIMARY KEY (id_customer)
);


/*------------------------------------------------------------
-- Table: appointments
------------------------------------------------------------*/
CREATE TABLE appointments(
	id_appointement   INT IDENTITY (1,1) NOT NULL ,
	dateHour          DATETIME  NOT NULL ,
	subject           TEXT  NOT NULL ,
	id_broker         INT  NOT NULL ,
	id_customer       INT  NOT NULL  ,
	CONSTRAINT appointments_PK PRIMARY KEY (id_appointement)

	,CONSTRAINT appointments_brokers_FK FOREIGN KEY (id_broker) REFERENCES brokers(id_broker)
	,CONSTRAINT appointments_customers0_FK FOREIGN KEY (id_customer) REFERENCES customers(id_customer)
);



