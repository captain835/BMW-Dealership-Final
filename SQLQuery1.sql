Create table UserCredentials(
id int primary key,
username varchar(max),
password varchar(max))

create table UserInfo(
id int primary key,
username varchar(max),
email varchar(max),
phone varchar(max))

create table CarInfo(
id int primary key,
Model varchar(max),
Power varchar(max),
Type varchar(max),
Transmission varchar(max),
Color varchar(max),
"Mileage" int,
"Price" decimal,
"See More" varchar(max))

drop table CarInfo;
drop table UserInfo;
drop table UserCredentials;


select * from CarInfo;

insert into CarInfo
values(1, 'i4 M50 (G26)', '400 kW (~544 hp)', 'Fully Electric', 'Automatic', 'Alpine White', 0, 148000, 'https://www.bmw.bg/bg/all-models/m-series/i4-m50/2021/bmw-i4-m50-highlights.html'),
(2, 'M3 CS (G80)', '375 kW (~510 hp)', 'Petrol', 'Automatic', 'Isle of Man Green', 21300, 160522.97, 'https://www.mobile.bg/pcgi/mobile.cgi?act=4&adv=11666772180125197&slink=s6ochw'),
(3, 'X7 xDrive40i (G07)', '280 kW (~381 hp)', 'Diesel', 'Automatic', 'Frozen Portimao Blue Metallic', 0, 228000, 'https://www.mobile.bg/pcgi/mobile.cgi?act=4&adv=11666772180125197&slink=s6ochw'),
(4, 'X5 xDrive40i (G05)', '250 kW (~340 hp)', 'Petrol', 'Automatic', 'Alpine White', 62200, 131900, 'https://specialniofertisega.bmw.bg/upotrebjavani/trsene/podrobnosti/77117/')
