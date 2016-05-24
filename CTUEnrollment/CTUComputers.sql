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
BranchId int foreign key references Branches(Id) not null
)

create table Parents
(
Id int primary key identity,
Name nvarchar(30) not null,
Surname nvarchar(30) not null,
StudentId int foreign key references Students(Id) not null
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
[TypeId] int foreign key references HardwareTypes(Id) not null,
CampusId int foreign key references Branches(Id) not null
)

create table WorkStations
(
Id int primary key identity,
CampusId int foreign key references Branches(Id) not null,
ComputerId int  not null foreign key references Hardware(Id),
MouseId int  not null foreign key references Hardware(Id),
KeyboardId int  not null foreign key references Hardware(Id),
ScreenId int not null  foreign key references Hardware(Id),
isAssigned bit  not null default 0,
)

create table AssignedStations
(
Id int primary key identity,
StudentId int foreign key references Students(Id) not null,
WorkstationId int foreign key references WorkStations(Id) not null
)

go
create view AllPCsPerCampus
as
select * from WorkStations
go

create view AllStudentsPerPcPerCampus
as
select StudentId, WorkstationId, CampusId from Students
join AssignedStations on AssignedStations.StudentId = Students.Id
join WorkStations on WorkStations.ComputerId = AssignedStations.WorkstationId
go
create view AmountOfPCsPerCampus
as
select count(Id) as [PC Count] , CampusId from WorkStations group by CampusId