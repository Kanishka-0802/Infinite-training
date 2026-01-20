create database Cus_orderDb

create table customers(
custid tinyint primary key,
custname varchar(30),
age tinyint,
caddress varchar(30),
cphone  bigint)

select * from customers

insert into customers values
(100,'Ajay',23,'Banglore',6767676767),
(101,'Ananya',21,'Chennai',9679876123),
(102,'Raju',22,'Hyderabad',8785645321),
(103,'kaviya',20,'Banglore',9087654321),
(104,'yuva',23,'Pune',789654890),
(105,'kanish',23,'Mumbai',9008765643)


create table orders
(	custid tinyint primary key,
	orderid tinyint,
	orderdate date,
	products varchar(20),
	price int,
	qty int, foreign key (custid)references customers(custid))

	select * from orders;


insert into orders values
(100,10,'2025-01-01','Books',120,3),
(101,23, '2025-02-08','Pencilbox',300,4),
(102,43,'2025-03-26','Pen',50,2),
(103,22,'2025-10-10','Colouring book',180,10),
(104,38,'2025-11-26','Geometry box',200,1),
(105,18,'2025-04-27','Bag',700,3)



-- 1 --
select * from customers where caddress='Banglore'

-- 2 --
select * from customers where  caddress not in ('Banglore', 'Chennai')

-- 3 --
select * from customers where age >50 and caddress not in ('Banglore')

--4--
select * from  customers where custname like 'A%'

--5--
select * from  customers where custname like '%Br%'

--6--
select * from customers where custname Like '[A-k]%'

--7--
select * from customers where len(custname)=5

--8--
select  * from customers where custname Like 'S%' and custname Like '_c%' and custname Like '%e'

--9--

select  distinct custname from customers

--10--
select * from orders where (qty between 100 and 200) or  (qty between 700 and 1200)

--11--
select  * from customers where custname Like 'AL%' and  custname Like '%N'

--12--
select custid, price as Oldprice ,price * 1.2 as Newprice from orders
 
 --13--
select top 3 *  from orders order by qty desc

--14--

select custid ,count(*) as PurchasedCount  from orders group by custid

--15--

select * from orders where year(getdate()-year(orderdate))>5
--16--

 select * from customers where custname is null 

--17--

select (price*qty)as Total,orderdate from orders 

--18--

update   orders set price = price*0.8 where qty>50

--19--

select * from orders where orderdate ='1990-12-01' and price between 4000 and 6000 order by price desc

--20--

select custid ,sum(price) as Price ,count(qty)as Counts_ from orders group by custid

--21--

select custid ,sum(price) as Price ,count(qty)as Counts_ from orders group by custid having sum( price) >4000

--22--

select * into custhistory from customers
select * from custhistory
delete from custhistory insert into custhistory select * from customers where age > 30
