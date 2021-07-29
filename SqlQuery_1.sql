create database LeaveDB;
use LeaveDB;

create table Employee(ID int primary key identity(12345,1), Name varchar(40), Designation varchar(30));
drop table Employee;

insert into Employee values 

('Awsathi', 'ITA'),
('Aishwarya', 'ITA'),
('Naresh', 'ASOC');

exec sp_help Employee;

select * from Employee;
delete from Employee;


create table Leave (LeaveID int primary key identity(1,1), EmpID int foreign key references Employee(ID), NoOfDays int, FromDate datetime, ToDate datetime, Status varchar(20) not null, Remarks varchar(500) null, constraint status_constraint check (Status in ('Pending', 'Approved','Rejected') ))  ;
alter table Leave add constraint status_default default 'Pending' for Status;
drop table Leave;

exec sp_help Leave; 
exec sp_rename 'Leave.FromData', 'FromDate', 'COLUMN';

insert into Leave values (12346, 1, '1/1/2021', '1/1/2021', 'Approved', 'Project Metting Planned');



insert into Leave (EmpId, NoOfdays, FromDate, ToDate, Status) values

(12346, 1, '4/20/2021', '4/21/2021', 'Pending'),
(12347, 2, '1/4/2021', '1/6/2021', 'Pending'),
(12347, 2, '4/5/2021', '4/7/2021', 'Approved'),
(12347, 1, '5/1/2021', '5/2/2021', 'Pending');


insert into Leave (EmpId, NoOfdays, FromDate, ToDate) values
(12347, 1, '5/1/2021', '5/2/2021');




select *from Leave;
delete from Leave;
delete from Leave where Status is null;

