-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Хост: 127.0.0.1:3306
-- Время создания: Янв 23 2024 г., 11:01
-- Версия сервера: 8.2.0
-- Версия PHP: 8.2.13

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- База данных: `ordermanagement`
--

-- --------------------------------------------------------

--
-- Структура таблицы `clients`
--

DROP TABLE IF EXISTS `clients`;
CREATE TABLE IF NOT EXISTS `clients` (
  `Code_client` int NOT NULL AUTO_INCREMENT,
  `Name_client` varchar(40) NOT NULL,
  `Address_client` varchar(100) DEFAULT NULL,
  `Contact_person_client` varchar(30) DEFAULT NULL,
  `Phone_client` varchar(12) DEFAULT NULL,
  PRIMARY KEY (`Code_client`),
  UNIQUE KEY `Code_client` (`Code_client`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb3;

--
-- Дамп данных таблицы `clients`
--

INSERT INTO `clients` (`Code_client`, `Name_client`, `Address_client`, `Contact_person_client`, `Phone_client`) VALUES
(1, 'Иванов Иван', 'ул. Ленина, 1', 'ivanov@example.com', '1234567890'),
(2, 'Петров Петр', 'ул. Пушкина, 10', 'petrov@example.com', '9876543210'),
(3, 'Сидоров Сидор', 'ул. Гагарина, 5', 'sidorov@example.com', '5678901234'),
(4, 'Смирнова Анна', 'ул. Мира, 15', 'smirnova@example.com', '2345678901'),
(5, 'Козлова Елена', 'ул. Советская, 20', 'kozlova@example.com', '8901234567'),
(6, 'Морозов Дмитрий', 'ул. Лесная, 7', 'morozov@example.com', '4321098765'),
(7, 'Николаев Николай', 'ул. Зеленая, 3', 'nikolaev@example.com', '9012345678'),
(8, 'Васильева Ольга', 'ул. Набережная, 12', 'vasilieva@example.com', '6543210987'),
(9, 'Кузнецов Алексей', 'ул. Центральная, 9', 'kuznetsov@example.com', '7890123456'),
(10, 'Соколова Марина', 'ул. Солнечная, 6', 'sokolova@example.com', '2109876543');

-- --------------------------------------------------------

--
-- Структура таблицы `deliveries`
--

DROP TABLE IF EXISTS `deliveries`;
CREATE TABLE IF NOT EXISTS `deliveries` (
  `Code_delivery` int NOT NULL AUTO_INCREMENT,
  `Name_delivery` varchar(40) NOT NULL,
  `Price_delivery` decimal(20,2) NOT NULL,
  PRIMARY KEY (`Code_delivery`),
  UNIQUE KEY `Code_delivery` (`Code_delivery`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb3;

--
-- Дамп данных таблицы `deliveries`
--

INSERT INTO `deliveries` (`Code_delivery`, `Name_delivery`, `Price_delivery`) VALUES
(1, 'Курьерская доставка', 200.00),
(2, 'Самовывоз', 0.00),
(3, 'Почта России', 150.00),
(4, 'Транспортная компания', 300.00),
(5, 'Экспресс-доставка', 500.00),
(6, 'Доставка в офис', 100.00),
(7, 'Курьер по Москве', 250.00),
(8, 'Курьер по Санкт-Петербургу', 300.00),
(9, 'Международная доставка', 1000.00),
(10, 'Доставка в регионы', 400.00);

-- --------------------------------------------------------

--
-- Структура таблицы `orders`
--

DROP TABLE IF EXISTS `orders`;
CREATE TABLE IF NOT EXISTS `orders` (
  `Code_order` int NOT NULL AUTO_INCREMENT,
  `Code_client` int DEFAULT NULL,
  `Date_order` datetime NOT NULL,
  `Code_delivery` int DEFAULT NULL,
  PRIMARY KEY (`Code_order`),
  UNIQUE KEY `Code_order` (`Code_order`),
  KEY `Code_client` (`Code_client`),
  KEY `Code_delivery` (`Code_delivery`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb3;

--
-- Дамп данных таблицы `orders`
--

INSERT INTO `orders` (`Code_order`, `Code_client`, `Date_order`, `Code_delivery`) VALUES
(1, 1, '2022-01-01 10:00:00', 1),
(2, 1, '2022-01-02 12:30:00', 2),
(3, 1, '2022-01-03 14:45:00', 3),
(4, 4, '2022-01-04 16:15:00', 4),
(5, 5, '2022-01-05 18:30:00', 5),
(6, 6, '2022-01-06 20:45:00', 6),
(7, 6, '2022-01-07 09:30:00', 7),
(8, 8, '2022-01-08 11:45:00', 8),
(9, 9, '2022-01-09 13:15:00', 9),
(10, 5, '2022-01-10 15:30:00', 10);

-- --------------------------------------------------------

--
-- Структура таблицы `order_product`
--

DROP TABLE IF EXISTS `order_product`;
CREATE TABLE IF NOT EXISTS `order_product` (
  `code_order_product` int NOT NULL AUTO_INCREMENT,
  `Code_order` int DEFAULT NULL,
  `Code_product` int DEFAULT NULL,
  `Price_product` decimal(20,2) NOT NULL,
  `Amount_product` int NOT NULL DEFAULT '1',
  PRIMARY KEY (`code_order_product`),
  UNIQUE KEY `code_order_product_UNIQUE` (`code_order_product`),
  KEY `fk_products` (`Code_product`),
  KEY `fk_orders` (`Code_order`)
) ;

--
-- Дамп данных таблицы `order_product`
--

INSERT INTO `order_product` (`code_order_product`, `Code_order`, `Code_product`, `Price_product`, `Amount_product`) VALUES
(1, 1, 1, 900.00, 5),
(2, 1, 1, 50.00, 7),
(3, 2, 2, 4.00, 20),
(4, 3, 5, 90.00, 3),
(5, 4, 4, 2000.00, 8),
(6, 5, 7, 345.00, 8),
(7, 6, 6, 67.00, 34),
(8, 7, 9, 45.00, 3),
(9, 8, 8, 34.00, 2),
(10, 9, 10, 92.00, 5);

-- --------------------------------------------------------

--
-- Структура таблицы `products`
--

DROP TABLE IF EXISTS `products`;
CREATE TABLE IF NOT EXISTS `products` (
  `Code_product` int NOT NULL AUTO_INCREMENT,
  `Name_product` varchar(40) NOT NULL,
  `Delivery_check` tinyint(1) NOT NULL,
  `Product_description` varchar(300) DEFAULT NULL,
  PRIMARY KEY (`Code_product`),
  UNIQUE KEY `Code_product` (`Code_product`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb3;

--
-- Дамп данных таблицы `products`
--

INSERT INTO `products` (`Code_product`, `Name_product`, `Delivery_check`, `Product_description`) VALUES
(1, 'Футболка', 1, 'Комфортная футболка из натуральных материалов'),
(2, 'Джинсы', 0, 'Классические джинсы с зауженным краем'),
(3, 'Платье', 1, 'Элегантное платье для особых случаев'),
(4, 'Кроссовки', 1, 'Удобная обувь для активного образа жизни'),
(5, 'Свитер', 1, 'Теплый свитер из мягкой шерсти'),
(6, 'Брюки', 0, 'Строгие брюки для делового стиля'),
(7, 'Юбка', 1, 'Модная юбка с интересным узором'),
(8, 'Рубашка', 1, 'Классическая рубашка для офиса'),
(9, 'Костюм', 0, 'Стильный костюм для особых мероприятий'),
(10, 'Пиджак', 1, 'Элегантный пиджак для формальных случаев'),
(11, 'Штаны', 1, NULL);

-- --------------------------------------------------------

--
-- Структура таблицы `roles`
--

DROP TABLE IF EXISTS `roles`;
CREATE TABLE IF NOT EXISTS `roles` (
  `code_role` int NOT NULL AUTO_INCREMENT,
  `role` varchar(45) NOT NULL,
  PRIMARY KEY (`code_role`),
  UNIQUE KEY `code_role_UNIQUE` (`code_role`),
  UNIQUE KEY `role_UNIQUE` (`role`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb3;

--
-- Дамп данных таблицы `roles`
--

INSERT INTO `roles` (`code_role`, `role`) VALUES
(1, 'admin'),
(4, 'analyst'),
(2, 'manager'),
(3, 'operator');

-- --------------------------------------------------------

--
-- Структура таблицы `users`
--

DROP TABLE IF EXISTS `users`;
CREATE TABLE IF NOT EXISTS `users` (
  `id` int NOT NULL AUTO_INCREMENT,
  `login` varchar(45) NOT NULL,
  `pass` varchar(45) NOT NULL,
  `name` varchar(45) DEFAULT NULL,
  `code_role` int NOT NULL,
  `enable` tinyint(1) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `id_UNIQUE` (`id`),
  UNIQUE KEY `login_UNIQUE` (`login`),
  KEY `code_role_fk_idx` (`code_role`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb3;

--
-- Дамп данных таблицы `users`
--

INSERT INTO `users` (`id`, `login`, `pass`, `name`, `code_role`, `enable`) VALUES
(1, 'admin', 'pass', 'Danila', 1, 1),
(2, 'manager', 'pass', 'andrey', 2, 1),
(3, 'operator', 'pass', 'vova', 3, 1),
(4, 'analyst', 'pass', 'gerasim', 4, 1),
(5, 'mask', '123', 'ilon', 2, 0),
(6, 'user1', 'pass', 'danila', 4, 1);

--
-- Ограничения внешнего ключа сохраненных таблиц
--

--
-- Ограничения внешнего ключа таблицы `orders`
--
ALTER TABLE `orders`
  ADD CONSTRAINT `orders_ibfk_1` FOREIGN KEY (`Code_client`) REFERENCES `clients` (`Code_client`),
  ADD CONSTRAINT `orders_ibfk_2` FOREIGN KEY (`Code_delivery`) REFERENCES `deliveries` (`Code_delivery`);

--
-- Ограничения внешнего ключа таблицы `order_product`
--
ALTER TABLE `order_product`
  ADD CONSTRAINT `fk_orders` FOREIGN KEY (`Code_order`) REFERENCES `orders` (`Code_order`),
  ADD CONSTRAINT `fk_products` FOREIGN KEY (`Code_product`) REFERENCES `products` (`Code_product`);

--
-- Ограничения внешнего ключа таблицы `users`
--
ALTER TABLE `users`
  ADD CONSTRAINT `code_role_fk` FOREIGN KEY (`code_role`) REFERENCES `roles` (`code_role`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
