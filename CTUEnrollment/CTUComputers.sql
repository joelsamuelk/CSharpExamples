EXEC msdb.dbo.sp_delete_database_backuphistory @database_name = N'CTUComputers'
GO
USE [master]
GO
ALTER DATABASE [CTUComputers] SET  SINGLE_USER WITH ROLLBACK IMMEDIATE
GO
USE [master]
GO
/****** Object:  Database [CTUComputers]    Script Date: 2016/05/16 3:59:14 PM ******/
DROP DATABASE [CTUComputers]
GO

create database CTUComputers
go

use CTUComputers
go

create table Branches
(
Id int primary key identity,
Name nvarchar(30) not null,
Location nvarchar(30)
)

create table Students
(
Id int primary key identity,
Name nvarchar(30) not null,
Surname nvarchar(30) not null,
Branch int foreign key references Branches(Id) not null
)

create table Parents
(
Id int primary key identity,
Name nvarchar(30) not null,
Surname nvarchar(30) not null,
Student int foreign key references Students(Id) not null
)

create table HardwareTypes
(
Id int primary key identity,
Name nvarchar(30) not null,
)

insert into HardwareTypes values ('PC'), ('Mouse'), ('Keyboard'), ('Screen')

create table Hardware
(
Id int primary key identity,
Name nvarchar(100) not null,
Barcode nvarchar(30) not null,
[Type] int foreign key references HardwareTypes(Id) not null,
Campus int foreign key references Branches(Id) not null
)

create table WorkStations
(
Id int primary key identity,
Campus int foreign key references Branches(Id) not null,
Computer int  not null foreign key references Hardware(Id),
Mouse int  not null foreign key references Hardware(Id),
Keyboard int  not null foreign key references Hardware(Id),
Screen int not null  foreign key references Hardware(Id),
isAssigned bit  not null default 0,
)

create table AssignedStations
(
Id int primary key identity,
Student int foreign key references Students(Id) not null,
Workstation int foreign key references WorkStations(Id) not null
)

go
create view AllPCsPerCampus
as
select * from WorkStations
go

create view AllStudentsPerPcPerCampus
as
select Student, Workstation, Campus from Students
join AssignedStations on AssignedStations.Student = Students.Id
join WorkStations on WorkStations.Computer = AssignedStations.Workstation
go
create view AmountOfPCsPerCampus
as
select count(Id) as [PC Count] , Campus from WorkStations group by Campus