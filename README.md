# EmployeeManagementApp

dotnet new sln__
dotnet new mvc -o EmpApp__
dotnet new classlib -o BOL__
dotnet new classlib -o BLL__
dotnet new classlib -o DAL__











## For database
-
create database employee;
use employee;

create table employees(
id int primary key,
name varchar(20),
email varchar(20),
password varchar(20)
);

insert into employees values(1,"sujit","sujit@gmail.com","sujit@123");
insert into employees values(2,"shikha","shikha@gmail.com","shikha@123");

