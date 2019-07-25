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
6) PersonDiary.BusinessLogic    - Юнит-тесты бизнес логики.
7) PersonDiary.Archivator       - Net.Core библиотека архиватора .doc файлов (находится в разработке)