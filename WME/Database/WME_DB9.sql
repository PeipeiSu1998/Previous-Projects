create schema "WME";
set search_path = 'WME';
-----------------------------------Company Table-------------------------------------------------------
Create table Company (
CompanyID varchar (50) not null primary key,
Name varchar(50) not null,
Phone int not null,
Email varchar(50) not null
);

insert into Company(CompanyID, Name, Phone, Email) values 
('com1234', 'comAAA', '1111111', 'comA.com'),
('com2345','comBBB', '2222222', 'comB.com'), 
('com3456','comCCC', '3333333', 'comC.com'),
('com4567','comDDD', '4444444', 'comD.com'),
('com5678','comEEE', '5555555', 'comE.com');

--------------------------------------Locations Table---------------------------------------------

Create table Locations (
LocationID varchar not null primary key

);

insert into Locations(LocationID) values 
('locA'), ('locB'), ('locC'), ('locD'), ('locE');

-------------------------------------------RentedLocation Table-------------------------------------------------------

Create table RentedLocation (
CompanyID varchar not null,
LocationID varchar not null,
RentalStart date not null,
RentalEnd date not null,
Primary key (CompanyID, LocationID),
foreign key (CompanyID) references Company (CompanyID) on delete cascade on update cascade,
foreign key (LocationID) references Locations (LocationID) on delete cascade on update cascade
);

insert into RentedLocation(CompanyID, LocationID, RentalStart, RentalEnd) values 

((select CompanyID from Company where CompanyID = 'com1234'), (select LocationID from Locations where LocationID = 'locA'), 
 '10/10/2018', '10/05/2018'),
 
((select CompanyID from Company where CompanyID = 'com2345'), (select LocationID from Locations where LocationID = 'locB'),
 '10/11/2017', '10/08/2018' ),

((select CompanyID from Company where CompanyID = 'com3456'), (select LocationID from Locations where LocationID = 'locC'),
 '21/03/2019', '15/01/2019'),
 
 ((select CompanyID from Company where CompanyID = 'com4567'), (select LocationID from Locations where LocationID = 'locD'),
 '24/04/2019', '15/04/2019'),
 
 ((select CompanyID from Company where CompanyID = 'com5678'), (select LocationID from Locations where LocationID = 'locE'),
 '24/05/2019', '15/05/2019');


--------------------------------------Pallet Table--------------------------------------------

Create table Pallet (
PalletID varchar not null primary key,
CompanyID varchar not null,
LocationID varchar not null,
PalletHeight NUMERIC  not null,
PalletArea NUMERIC  not null,
ArrivaleDate date not null,
foreign key (CompanyID, LocationID) references RentedLocation (CompanyID, LocationID) on delete cascade

);

insert into Pallet(PalletID, CompanyID, LocationID, PalletHeight, PalletArea, ArrivaleDate) values 

('pal1111', (select CompanyID from Company where CompanyID = 'com1234'),
(select LocationID from RentedLocation where LocationID = 'locA'), '1.1', '10.10', '10/01/2019'),
 
('pal2222', (select CompanyID from Company where CompanyID = 'com2345'),
(select LocationID from RentedLocation where LocationID = 'locB'), '2.2', '20.20', '10/02/2019' ),

('pal3333', (select CompanyID from Company where CompanyID = 'com3456'),
(select LocationID from RentedLocation where LocationID = 'locC'), '3.3', '30.30', '10/03/2019'),

('pal4444', (select CompanyID from Company where CompanyID = 'com4567'),
(select LocationID from RentedLocation where LocationID = 'locD'), '4.4', '40.40', '10/04/2019'),

('pal5555', (select CompanyID from Company where CompanyID = 'com5678'),
(select LocationID from RentedLocation where LocationID = 'locE'), '5.5', '50.50', '10/05/2019');
------------------------------------------Available View--------------------------------------------

create view Available as 
select lt.LocationID as AvailableLocaiton from Locations lt
LEFT JOIN RentedLocation rt ON lt.LocationID = rt.LocationID where rt.LocationID is null;

-----------------------------------------PalletStored View----------------------------------------------
CREATE view PalletStored as  
select pt.PalletID, pt.CompanyID, pt.LocationID, pt.ArrivaleDate, daysStored from Pallet pt, age(ArrivaleDate) as daysStored where 
PalletID is not null and LocationID is not null;

-------------------------------------------------------------------------------------------------------
select * from Company;
select * from Locations;
select * from Pallet;
select * from RentedLocation;
select * from PalletStored;
select * from Available;

delete from Pallet where PalletID = 'pal4444';
delete from Locations where LocationID = 'locE';
delete from RentedLocation where LocationID = 'locE';
delete from Locations where LocationID = 'locD';
delete from Company where CompanyID = 'com1234';


