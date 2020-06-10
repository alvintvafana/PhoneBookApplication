# PhoneBookApplication

About
=====

A simple phone book application

	- Domain Driven Design (DDD) was used as opposed to Anemic Entities, to allow for business logic to sit in one place.
	- Command Query Responsibility Segragation (CQRS) was used.
	
Technologies
=========

- Asp.Net Core 2.2
- SQlite
- Swagger	

SetUp
======
1. Clone the repo and open the command line

2. cd PhoneBookApplication

3. Run dotnet build

4. cd PhoneBookApplication.Api

5. Run dotnet run

6. Browse to http://localhost:5003/swagger/index.html