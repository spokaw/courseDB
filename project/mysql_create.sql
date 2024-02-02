CREATE TABLE ordermanagement.Clients
(
	Code_client INT PRIMARY KEY NOT NULL auto_increment unique,
	Name_client VARCHAR(40) NOT NULL,
	Address_client VARCHAR(100),
	Contact_person_client VARCHAR(30),
	Phone_client VARCHAR(12)
);

CREATE TABLE ordermanagement.Deliveries
(
	Code_delivery INT PRIMARY KEY NOT NULL auto_increment unique,
	Name_delivery VARCHAR(40) NOT NULL,
	Price_delivery decimal(20,2) NOT NULL

);

CREATE TABLE ordermanagement.Products
(
	Code_product INT PRIMARY KEY NOT NULL auto_increment unique,
	Name_product VARCHAR(40) NOT NULL,
	Delivery_check TINYINT(1) NOT NULL,
	Product_description VARCHAR(300)

);

CREATE TABLE ordermanagement.Orders
(
	Code_order INT PRIMARY KEY NOT NULL auto_increment unique,
	Code_client INT ,
	Date_order DATETIME NOT NULL,
	Code_delivery INT ,
    FOREIGN KEY (`Code_client`) references ordermanagement.Clients (Code_client),
    FOREIGN KEY (`Code_delivery`) references ordermanagement.Deliveries (Code_delivery)
    
	
);

CREATE TABLE ordermanagement.Order_Product
(
	Code_order INT,
	Code_product INT,
	Price_product decimal(20,2) NOT NULL,
	Amount_product INT DEFAULT 1 NOT NULL CHECK(Amount_product > 0),
    FOREIGN KEY (`Code_order`) references ordermanagement.Orders (Code_order),
    FOREIGN KEY (`Code_product`) references ordermanagement.Products (Code_product)
	
);		

INSERT INTO Clients (Name_client, Address_client, Contact_person_client, Phone_client)
VALUES
('Иванов Иван', 'ул. Ленина, 1', 'ivanov@example.com', '1234567890'),
('Петров Петр', 'ул. Пушкина, 10', 'petrov@example.com', '9876543210'),
('Сидоров Сидор', 'ул. Гагарина, 5', 'sidorov@example.com', '5678901234'),
('Смирнова Анна', 'ул. Мира, 15', 'smirnova@example.com', '2345678901'),
('Козлова Елена', 'ул. Советская, 20', 'kozlova@example.com', '8901234567'),
('Морозов Дмитрий', 'ул. Лесная, 7', 'morozov@example.com', '4321098765'),
('Николаев Николай', 'ул. Зеленая, 3', 'nikolaev@example.com', '9012345678'),
('Васильева Ольга', 'ул. Набережная, 12', 'vasilieva@example.com', '6543210987'),
('Кузнецов Алексей', 'ул. Центральная, 9', 'kuznetsov@example.com', '7890123456'),
('Соколова Марина', 'ул. Солнечная, 6', 'sokolova@example.com', '2109876543');


INSERT INTO Deliveries (Name_delivery, Price_delivery)
VALUES
('Курьерская доставка', 200),
('Самовывоз', 0),
('Почта России', 150),
('Транспортная компания', 300),
('Экспресс-доставка', 500),
('Доставка в офис', 100),
('Курьер по Москве', 250),
('Курьер по Санкт-Петербургу', 300),
('Международная доставка', 1000),
('Доставка в регионы', 400);

INSERT INTO Products (Name_product, Delivery_check, Product_description)
VALUES
('Футболка', 1, 'Комфортная футболка из натуральных материалов'),
('Джинсы', 0, 'Классические джинсы с зауженным краем'),
('Платье', 1, 'Элегантное платье для особых случаев'),
('Кроссовки', 1, 'Удобная обувь для активного образа жизни'),
('Свитер', 1, 'Теплый свитер из мягкой шерсти'),
('Брюки', 0, 'Строгие брюки для делового стиля'),
('Юбка', 1, 'Модная юбка с интересным узором'),
('Рубашка', 1, 'Классическая рубашка для офиса'),
('Костюм', 0, 'Стильный костюм для особых мероприятий'),
('Пиджак', 1, 'Элегантный пиджак для формальных случаев');

INSERT INTO Orders (Code_client, Date_order, Code_delivery)
VALUES
(1,  '2022-01-01 10:00:00',1),
(1,  '2022-01-02 12:30:00',2),
(1,   '2022-01-03 14:45:00',3),
(4,  '2022-01-04 16:15:00',4),
(5,  '2022-01-05 18:30:00',5),
(6,  '2022-01-06 20:45:00',6),
(6,  '2022-01-07 09:30:00',7),
(8,  '2022-01-08 11:45:00',8),
(9,   '2022-01-09 13:15:00',9),
(10,  '2022-01-10 15:30:00',10);

INSERT INTO Order_Product (Code_order, Code_product, Amount_product, Price_product)
VALUES
(1, 1, 5, 900),
(1, 1, 7, 50),
(2, 2, 20, 4),
(3, 5, 3, 90),
(4, 4, 8, 2000),
(5, 7, 8, 345),
(6, 6, 34, 67),
(7, 9, 3, 45),
(8, 8, 2 , 34),
(9, 10, 5, 92);