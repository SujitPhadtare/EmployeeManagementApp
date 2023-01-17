# EmployeeManagementApp

dotnet new sln <br/>
dotnet new mvc -o EmpApp <br/>
dotnet new classlib -o BOL <br/>
dotnet new classlib -o BLL <br/>
dotnet new classlib -o DAL <br/>



## For database

create database employee;<br/>
use employee;<br/>

create table employees(<br/>
id int primary key,<br/>
name varchar(20),<br/>
email varchar(20),<br/>
password varchar(20)<br/>
);

insert into employees values(1,"sujit","sujit@gmail.com","sujit@123");<br/>
insert into employees values(2,"shikha","shikha@gmail.com","shikha@123");

