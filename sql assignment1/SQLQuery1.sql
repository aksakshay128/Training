CREATE DATABASE ShoppingCartDb;


CREATE TABLE USERS(UserId INT not null, UserName VARCHAR(20), Password VARCHAR(16), ContactNumber INT, City VARCHAR(20));

SELECT * FROM USERS

CREATE TABLE PRODUCTS(ProductId INT Primary Key,
						NAME VARCHAR(20) NOT NULL,
						QuantityInStock INT NOT NULL,
						UnitPrice INT Not Null,
						CONSTRAINT CHK_PRODUCT_QuantityInStock CHECK(QuantityInStock>0),
						CONSTRAINT CHK_PRODUCT_UnitPrice CHECK(UnitPrice>0),
						CATEGORY VARCHAR(30) NOT NULL);


SELECT * FROM PRODUCTS

Create table CART(Id	INT Primary Key,  
					CartId  INT NOT NULL, 
					PRODUCTID INT NOT NULL,
					CONSTRAINT FK_ProductId Foreign Key(ProductId) REFERENCES PRODUCTS(PRODUCTID), 
					Quantity   INT Not Null,
					CONSTRAINT CHK_CART_QUANTITY CHECK(QUANTITY>0)); 

SELECT * FROM CART



drop table users;

ALTER TABLE USERS MODIFY ContactNumber LONG;

alter table users add constraint PK_userid primary key(userid);

CREATE TABLE ORDERS (OrderId INT Primary Key,  
					CartId INT NOT NULL, 
					OrderDate DATE ,
					TotalAmount INT,
					USERID INT,
					CONSTRAINT FK_ORDERS_USERS_USERID Foreign Key(UserId) REFERENCES USERS(USERID));
	

INSERT INTO USERS VALUES(100, 'AKASH', 'AKASH1234', 98765, 'HYD');
INSERT INTO USERS VALUES(200, 'AKA', 'AKA234', 987654321, 'CHE');
INSERT INTO USERS VALUES(300, 'ASH', 'ASH1234', 9876541, 'MUM');
INSERT INTO USERS VALUES(400, 'SH', 'SH1234', 987612345, 'HYD');



INSERT INTO USERS (UserId, UserName, Password, ContactNumber, City) VALUES (500, 'HAS', 'HAS1234', 123456789, 'PUNE');

SELECT * FROM USERS;

INSERT INTO PRODUCTS(ProductId, NAME, QuantityInStock, UnitPrice,CATEGORY) VALUES (500, 'HAS', 'HAS1234', 123456789, 'PUNE');

INSERT INTO Products VALUES(1,'LG',290,2500,'TV')

 

INSERT INTO Products VALUES(2,'IPhone',4,62500,'Phone')

 

INSERT INTO PRODUCTS(ProductId, NAME, QuantityInStock, UnitPrice,CATEGORY) VALUES (3,'samsung',9,105000,'Phone')

 

INSERT INTO Products VALUES(4,'Bullet350',9,325000,'Bike')

 

INSERT INTO Products VALUES(5,'KTM',9,200000,'Bike')

 

SELECT * FROM PRODUCTS



INSERT INTO CART VALUES(1,1,5,70)
INSERT INTO CART VALUES(2,2,2,32)
INSERT INTO CART VALUES(3,6,4,37)
INSERT INTO CART VALUES(4,3,1,29)
INSERT INTO CART VALUES(5,9,3,28)

 

SELECT * FROM CART


INSERT INTO Orders VALUES(1,2,'2008-11-11',25000,100)
INSERT INTO Orders VALUES(2,3,'2023-08-12',37820,200)
INSERT INTO Orders VALUES(3,5,'2001-06-19',28900,200)
INSERT INTO Orders VALUES(4,4,'2005-06-01',09272,300)
INSERT INTO Orders VALUES(5,1,'2015-03-09',49800,400)

SELECT * FROM Orders



SELECT * FROM Products
SELECT * FROM Products WHERE Category='Bike'
SELECT * FROM Products WHERE QuantityInStock=0
SELECT * FROM Products WHERE UnitPrice>=1000 AND UnitPrice<=10000
SELECT * FROM Products WHERE ProductId=3

 

SELECT * FROM Cart WHERE CartId=3
SELECT * FROM Cart WHERE ProductId=3

 

SELECT * FROM Users
SELECT * FROM Users WHERE UserName='Nikhil'
SELECT * FROM Users WHERE UserId=5

 

SELECT * FROM Orders WHERE OrderId=4;
SELECT * FROM Orders WHERE UserId=2;
SELECT * FROM Orders WHERE OrderDate='2008-11-11'