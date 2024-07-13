USE [HotelManagment]

/* --- СОЗДАНИЕ ТАБЛИЦ --- */

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'room_category')
	CREATE TABLE [dbo].[room_category] (
		[id] INT IDENTITY(1, 1) NOT NULL,
		[name] NVARCHAR(50) NOT NULL,
		[price_per_night] MONEY NOT NULL,

		CONSTRAINT [PK_room_category_id] PRIMARY KEY ([id])
	)

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'room')
	CREATE TABLE [dbo].[room] (
		[id] INT IDENTITY(1, 1) NOT NULL,
		[number] INT NOT NULL,
		[category_id] INT NOT NULL,
		[availability] BIT NOT NULL,

		CONSTRAINT [PK_room_id] PRIMARY KEY ([id]),
		CONSTRAINT [FK_room_category_id]
			FOREIGN KEY ([category_id]) REFERENCES [dbo].[room_category] ([id])
	)

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'customer')
	CREATE TABLE [dbo].[customer] (
		[id] INT IDENTITY(1, 1) NOT NULL,
		[first_name] NVARCHAR(50) NOT NULL,
		[last_name] NVARCHAR(50) NOT NULL,
		[email] NVARCHAR(256) NOT NULL,
		[pnone_number] NVARCHAR(50) NOT NULL,

		CONSTRAINT [PK_customer_id] PRIMARY KEY ([id])
	)

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'booking')
	CREATE TABLE [dbo].[booking] (
		[id] INT IDENTITY(1, 1) NOT NULL,
		[customer_id] INT NOT NULL,
		[room_id] INT NOT NULL,
		[check_in_date] DATE NOT NULL,
		[check_out_date] DATE NOT NULL,

		CONSTRAINT [PK_booking_id] PRIMARY KEY ([id]),
		CONSTRAINT [FK_booking_customer_id]
			FOREIGN KEY ([customer_id]) REFERENCES [dbo].[customer] ([id]),
		CONSTRAINT [FK_booking_room_id]
			FOREIGN KEY ([room_id]) REFERENCES [dbo].room ([id])
	)

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'facility')
	CREATE TABLE [dbo].[facility] (
		[id] INT IDENTITY(1, 1) NOT NULL,
		[name] NVARCHAR(100) NOT NULL,

		CONSTRAINT [PK_facility_id] PRIMARY KEY ([id])
	)

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'room_to_facility')
	CREATE TABLE [dbo].[room_to_facility] (
		[room_id] INT NOT NULL,
		[facility_id] INT NOT NULL,

		CONSTRAINT [PK_room_to_facility_id] PRIMARY KEY ([room_id], [facility_id]),
		CONSTRAINT [FK_room_to_facility_room_id]
			FOREIGN KEY ([room_id]) REFERENCES [dbo].[room] ([id]),
		CONSTRAINT [FK_room_to_facility_facility_id]
			FOREIGN KEY ([facility_id]) REFERENCES [dbo].[facility] ([id])
	)

/* --- ЗАПОЛНЕНИЕ ТАБЛИЦ ДАННЫМИ --- */

INSERT INTO [dbo].[room_category] ([name], [price_per_night])
VALUES
	('Одноместный', 2000.00),
	('Двухместный', 3500.00),
	('Люкс', 8000.00)

INSERT INTO [dbo].[room] ([number], [category_id], [availability])
VALUES
	(1, 1, 0),
	(2, 1, 1),
	(3, 2, 0),
	(4, 2, 1),
	(5, 3, 0),
	(6, 3, 1),
	(7, 1, 0),
	(8, 1, 1),
	(9, 2, 0),
	(10, 2, 1),
	(11, 3, 0),
	(12, 3, 1)

INSERT INTO [dbo].[customer] ([first_name], [last_name], [email], [pnone_number])
VALUES
	('Ivan', 'Petrov', 'ivan.petrov@mail.ru', '+79456765321'),
	('Vasily', 'Dmitriev', 'vasily.dmitriev@gmail.com', '+79023435341'),
	('Alexey', 'Smirnov', 'alex.alexeev@gmail.com', '+78901234563'),
	('Sergey', 'Osipov', 'dmitry.petrov@mail.ru', '+71234567890'),
	('Sam', 'Johnson', 'a.a@mail.ru', '+888888888888'),
	('Don', 'Smith', 'b.b@gmail.com', '+3327367633626323'),
	('Bob', 'Stown', 'd.d@gmail.com', '+3632876283627'),
	('Jason', 'Steel', 'c.c@mail.ru', '+36237263223682')

INSERT INTO [dbo].[booking] ([room_id], [customer_id], [check_in_date], [check_out_date])
VALUES
	(2, 4, '2024-07-08', '2024-07-09'),
	(1, 1, '2024-07-01', '2024-07-20'),
	(3, 2, '2024-06-29', '2024-07-15'),
	(5, 3, '2024-07-01', '2024-08-18'),
	(10, 5, '2024-05-08', '2024-06-09'),
	(7, 6, '2024-06-01', '2024-08-20'),
	(9, 7, '2024-05-29', '2025-07-15'),
	(11, 8, '2023-07-01', '2025-08-18')

INSERT INTO [dbo].[facility] ([name])
VALUES
	('WI-FI'),
	('Мини-бар'),
	('Кондиционер')

INSERT INTO [dbo].[room_to_facility] ([room_id], [facility_id])
VALUES
	(5, 1),
	(5, 2),
	(5, 3),
	(6, 1),
	(6, 2),
	(6, 3),
	(1, 1),
	(2, 3),
	(3, 1),
	(3, 2),
	(4, 1),
	(4, 3),
	(11, 1),
	(11, 2),
	(11, 3),
	(12, 1),
	(12, 2),
	(12, 3),
	(7, 2),
	(8, 3),
	(9, 2),
	(9, 3),
	(10, 1),
	(10, 2)

/* --- ПРОСМОТР ДАННЫХ В ТАБЛИЦЕ --- */
SELECT * FROM [dbo].[room_category]
SELECT * FROM [dbo].[room]
SELECT * FROM [dbo].[customer]
SELECT * FROM [dbo].[booking]
SELECT * FROM [dbo].[facility]
SELECT * FROM [dbo].[room_to_facility]

/* --- ВЫПОЛНЕНИЯ ЗАДАНИЯ --- */

/*Найдите все доступные номера для бронирования сегодня.*/
SELECT [dbo].[room].[number], [dbo].[room].[availability], [dbo].[room_category].[name], [dbo].[room_category].[price_per_night] FROM [dbo].[room]
LEFT JOIN [dbo].[room_category] ON [dbo].[room_category].[id] = [dbo].[room].[category_id]
WHERE 
	[dbo].[room].[availability] = 1
	AND
	[dbo].[room].[id] NOT IN (
		SELECT [dbo].[booking].[room_id] FROM [dbo].[booking]
		WHERE GETDATE() BETWEEN [dbo].[booking].[check_in_date] AND [dbo].[booking].[check_out_date]
	)

/*Найдите всех клиентов, чьи фамилии начинаются с буквы "S".*/
SELECT * FROM [dbo].[customer]
WHERE [dbo].[customer].[last_name] LIKE 'S%'

/*Найдите все бронирования для определенного клиента (по имени или электронному адресу).*/
SELECT * FROM [dbo].[booking]
LEFT JOIN [dbo].[customer] ON [dbo].[booking].[customer_id] = [dbo].[customer].[id]
WHERE [dbo].[customer].[first_name] = 'Sam' AND [dbo].[customer].[last_name] = 'Johnson'

SELECT * FROM [dbo].[booking]
LEFT JOIN [dbo].[customer] ON [dbo].[booking].[customer_id] = [dbo].[customer].[id]
WHERE [dbo].[customer].[email] = 'a.a@mail.ru'

/*Найдите все бронирования для определенного номера.*/
SELECT [dbo].[booking].* FROM [dbo].[booking]
LEFT JOIN [dbo].[room] ON [dbo].[booking].[room_id] = [dbo].[room].[id]
WHERE [dbo].[room].[number] = 1

/*Найдите все номера, которые не забронированы на определенную дату.*/
SELECT [dbo].[room].[number], [dbo].[room].[availability], [dbo].[room_category].[name], [dbo].[room_category].[price_per_night] FROM [dbo].[room]
LEFT JOIN [dbo].[room_category] ON [dbo].[room_category].[id] = [dbo].[room].[category_id]
WHERE [dbo].[room].[id] NOT IN (
	SELECT [dbo].[booking].[room_id] FROM [dbo].[booking]
	WHERE '2024-03-05' BETWEEN [dbo].[booking].[check_in_date] AND [dbo].[booking].[check_out_date]
)