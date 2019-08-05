Данный проект написан в ходе чтения книги Марка Симана "Внедрение зависимостей в .Net".
Цель: реализовать бизнес логику, к которой можно было бы подключать различные реализации уровня доступа к данным и 
различные реализации клиентов без переписывания самой бизнес логики, т.е. создать систему со слабо связанным кодом.
Так же учтены некоторые рекомендации из "Асинхронного программирования в  C# 5.0" Алекса Дэвиса

Предметная область:
Человек/Персона (имя, фамилия, .doc-файл биографии) и события его жизни (название события, дата события). 

Реализация:
1) PersonDiary.Angular.EFCore   - клиентское приложение, Asp.Net core web application Angular 6, с data-сервисами.
2) PersonDiary.React.EFCore     - клиентское приложение, Asp.Net core web application ReactJS and Redux.
3) PersonDiary.BusinessLogic    - Net.Core библиотека бизнес логики, с которой работают оба клиентских приложения, 
в конструкторы моделей которой впрыскиваются зависимости уровня доступа к данным и архиватора .doc файлов
4) PersonDiary.DataLayer.EFCore - Net.Core библиотека уровня доступа к данным (MS SQL/EF Core).
5) PersonDiary.Interfaces       - Net.Core библиотека, в которой описаны интерфейсы, 
которые должны реализовывать зависимости, так же тут находятся сущности.
6) PersonDiary.BusinessLogicTest    - Юнит-тесты бизнес логики.
7) PersonDiary.Archivator       - Net.Core библиотека архиватора .doc файлов (находится в разработке)

This project was writen during reading Mark Seeman "Dependency Injection in .Net" book.
The goal: to implement business logic, which could be able to work with different implementation of data layer and MVVM clients. i.e. the main goal is to implement system with loosely coupled code. Also this project implements some recomendations of "Asyc in C# 5.0" Alex Davies's book.

Domain:
Person (his name, surname and biography file) and his life events list (event name adn event date). 

Projects list:
1) PersonDiary.Angular.EFCore   - client application, Asp.Net core web application Angular 6.
2) PersonDiary.React.EFCore     - client application, Asp.Net core web application ReactJS and Redux.
3) PersonDiary.BusinessLogic    - Net.Core library of business logic, both client applications (angular and react) works with only BL. 
4) PersonDiary.DataLayer.EFCore - Net.Core data access level library based on MS SQL/EF Core. The other implementations of DA layer will be added later.
5) PersonDiary.Interfaces       - Net.Core library, contains interfaces for Dependency Injecton.
6) PersonDiary.BusinessLogicTest- nUnit test of business logic.
7) PersonDiary.Archivator       - Net.Core archivator library, for biography file packing (under construction)
