create table `order`
(
    orderQty    int                         not null,
    orderPrice  float                       not null,
    orderReview float                       not null,
    orderTime   datetime                    not null,
    orderName   varchar(20) charset utf8mb3 not null,
    userName    varchar(20) charset utf8mb3 null,
    primary key (orderTime, orderName),
    constraint order_ibfk_1
        foreign key (orderName) references products (itemName),
    constraint order_ibfk_2
        foreign key (orderPrice) references products (itemPrice),
    constraint order_ibfk_3
        foreign key (userName) references Customers (userName)
);

create index orderName
    on `order` (orderName);

create index orderPrice
    on `order` (orderPrice);

create index userName
    on `order` (userName);

INSERT INTO caproject.`order` (orderQty, orderPrice, orderReview, orderTime, orderName, userName) VALUES (4, 299, 5, '2023-03-11 01:44:52', '.NET ML', 'testuser2');
INSERT INTO caproject.`order` (orderQty, orderPrice, orderReview, orderTime, orderName, userName) VALUES (1, 69, 5, '2023-03-17 05:25:57', '.NET Paypal', 'testuser1');
INSERT INTO caproject.`order` (orderQty, orderPrice, orderReview, orderTime, orderName, userName) VALUES (9, 49, 2, '2023-04-01 11:44:52', '.NET Logger', 'testuser2');
INSERT INTO caproject.`order` (orderQty, orderPrice, orderReview, orderTime, orderName, userName) VALUES (8, 99, 5, '2023-04-01 11:48:45', '.NET Charts', 'testuser1');
INSERT INTO caproject.`order` (orderQty, orderPrice, orderReview, orderTime, orderName, userName) VALUES (2, 69, 3, '2023-04-02 11:31:52', '.NET Paypal', 'testuser2');
INSERT INTO caproject.`order` (orderQty, orderPrice, orderReview, orderTime, orderName, userName) VALUES (8, 69, 5, '2023-04-02 11:44:52', '.NET Paypal', 'testuser1');
INSERT INTO caproject.`order` (orderQty, orderPrice, orderReview, orderTime, orderName, userName) VALUES (8, 49, 5, '2023-04-04 04:44:52', '.NET Logger', 'testuser2');
INSERT INTO caproject.`order` (orderQty, orderPrice, orderReview, orderTime, orderName, userName) VALUES (5, 199, 5, '2023-04-05 07:48:48', '.NET Numerics', 'testuser1');
INSERT INTO caproject.`order` (orderQty, orderPrice, orderReview, orderTime, orderName, userName) VALUES (2, 49, 2, '2023-04-06 11:44:41', '.NET Logger', 'testuser2');
INSERT INTO caproject.`order` (orderQty, orderPrice, orderReview, orderTime, orderName, userName) VALUES (8, 199, 5, '2023-04-06 23:44:52', '.NET Numerics', 'testuser1');
INSERT INTO caproject.`order` (orderQty, orderPrice, orderReview, orderTime, orderName, userName) VALUES (4, 299, 4, '2023-04-09 11:44:49', '.NET ML', 'testuser2');
INSERT INTO caproject.`order` (orderQty, orderPrice, orderReview, orderTime, orderName, userName) VALUES (8, 99, 5, '2023-04-09 21:44:52', '.NET Charts', 'testuser1');
INSERT INTO caproject.`order` (orderQty, orderPrice, orderReview, orderTime, orderName, userName) VALUES (3, 49, 5, '2023-04-11 11:33:52', '.NET Logger', 'testuser2');
INSERT INTO caproject.`order` (orderQty, orderPrice, orderReview, orderTime, orderName, userName) VALUES (2, 299, 5, '2023-04-11 11:44:22', '.NET ML', 'testuser1');
INSERT INTO caproject.`order` (orderQty, orderPrice, orderReview, orderTime, orderName, userName) VALUES (1, 299, 4, '2023-04-11 11:44:52', '.NET Analytics', 'testuser2');
INSERT INTO caproject.`order` (orderQty, orderPrice, orderReview, orderTime, orderName, userName) VALUES (2, 49, 5, '2023-04-12 11:44:19', '.NET Logger', 'testuser1');
INSERT INTO caproject.`order` (orderQty, orderPrice, orderReview, orderTime, orderName, userName) VALUES (6, 299, 4, '2023-04-12 11:44:52', '.NET Analytics', 'testuser2');
INSERT INTO caproject.`order` (orderQty, orderPrice, orderReview, orderTime, orderName, userName) VALUES (3, 199, 5, '2023-04-12 23:51:56', '.NET Numerics', 'testuser1');
INSERT INTO caproject.`order` (orderQty, orderPrice, orderReview, orderTime, orderName, userName) VALUES (8, 99, 5, '2023-04-13 11:44:52', '.NET Charts', 'testuser1');
INSERT INTO caproject.`order` (orderQty, orderPrice, orderReview, orderTime, orderName, userName) VALUES (4, 299, 1, '2023-04-13 11:44:52', '.NET ML', 'testuser2');
INSERT INTO caproject.`order` (orderQty, orderPrice, orderReview, orderTime, orderName, userName) VALUES (4, 299, 5, '2023-04-14 11:44:58', '.NET Analytics', 'testuser1');
INSERT INTO caproject.`order` (orderQty, orderPrice, orderReview, orderTime, orderName, userName) VALUES (4, 299, 2, '2023-04-15 09:09:20', '.NET Analytics', 'testuser2');
INSERT INTO caproject.`order` (orderQty, orderPrice, orderReview, orderTime, orderName, userName) VALUES (2, 99, 5, '2023-04-15 12:54:54', '.NET Charts', 'testuser1');
INSERT INTO caproject.`order` (orderQty, orderPrice, orderReview, orderTime, orderName, userName) VALUES (1, 49, 4, '2023-04-15 12:54:54', '.NET Logger', 'testuser2');
INSERT INTO caproject.`order` (orderQty, orderPrice, orderReview, orderTime, orderName, userName) VALUES (3, 99, 5, '2023-04-15 13:27:50', '.NET Charts', 'testuser1');
INSERT INTO caproject.`order` (orderQty, orderPrice, orderReview, orderTime, orderName, userName) VALUES (3, 49, 3, '2023-04-15 13:27:50', '.NET Logger', 'testuser2');
INSERT INTO caproject.`order` (orderQty, orderPrice, orderReview, orderTime, orderName, userName) VALUES (1, 199, 5, '2023-04-15 13:28:02', '.NET Numerics', 'testuser1');
INSERT INTO caproject.`order` (orderQty, orderPrice, orderReview, orderTime, orderName, userName) VALUES (1, 299, 5, '2023-04-15 15:58:32', '.NET Analytics', 'testuser2');
INSERT INTO caproject.`order` (orderQty, orderPrice, orderReview, orderTime, orderName, userName) VALUES (1, 99, 5, '2023-04-15 15:58:32', '.NET Charts', 'testuser1');
INSERT INTO caproject.`order` (orderQty, orderPrice, orderReview, orderTime, orderName, userName) VALUES (1, 49, 2, '2023-04-15 15:58:32', '.NET Logger', 'testuser2');
INSERT INTO caproject.`order` (orderQty, orderPrice, orderReview, orderTime, orderName, userName) VALUES (1, 49, 3, '2023-04-15 16:34:33', '.NET Logger', 'testuser1');
INSERT INTO caproject.`order` (orderQty, orderPrice, orderReview, orderTime, orderName, userName) VALUES (1, 199, 3, '2023-04-15 16:34:33', '.NET Numerics', 'testuser2');
INSERT INTO caproject.`order` (orderQty, orderPrice, orderReview, orderTime, orderName, userName) VALUES (4, 299, 4, '2023-04-15 16:43:21', '.NET Analytics', 'testuser1');
INSERT INTO caproject.`order` (orderQty, orderPrice, orderReview, orderTime, orderName, userName) VALUES (3, 299, 2, '2023-04-15 16:55:26', '.NET Analytics', 'testuser2');
INSERT INTO caproject.`order` (orderQty, orderPrice, orderReview, orderTime, orderName, userName) VALUES (4, 49, 3, '2023-04-15 19:44:43', '.NET Logger', 'testuser1');
INSERT INTO caproject.`order` (orderQty, orderPrice, orderReview, orderTime, orderName, userName) VALUES (2, 49, 5, '2023-04-15 19:47:12', '.NET Logger', 'testuser2');
INSERT INTO caproject.`order` (orderQty, orderPrice, orderReview, orderTime, orderName, userName) VALUES (2, 299, 2, '2023-04-15 20:24:30', '.NET Analytics', 'testuser1');
INSERT INTO caproject.`order` (orderQty, orderPrice, orderReview, orderTime, orderName, userName) VALUES (1, 99, 5, '2023-04-15 20:31:41', '.NET Charts', 'testuser2');
INSERT INTO caproject.`order` (orderQty, orderPrice, orderReview, orderTime, orderName, userName) VALUES (5, 49, 1, '2023-04-15 20:52:03', '.NET Logger', 'testuser1');
INSERT INTO caproject.`order` (orderQty, orderPrice, orderReview, orderTime, orderName, userName) VALUES (1, 69, 5, '2023-04-15 20:52:20', '.NET Paypal', 'testuser2');
INSERT INTO caproject.`order` (orderQty, orderPrice, orderReview, orderTime, orderName, userName) VALUES (1, 99, 3, '2023-04-15 20:58:47', '.NET Charts', 'testuser1');
INSERT INTO caproject.`order` (orderQty, orderPrice, orderReview, orderTime, orderName, userName) VALUES (2, 49, 5, '2023-04-15 20:59:09', '.NET Logger', 'testuser2');
INSERT INTO caproject.`order` (orderQty, orderPrice, orderReview, orderTime, orderName, userName) VALUES (3, 49, 4, '2023-04-16 10:18:43', '.NET Logger', 'testuser1');
INSERT INTO caproject.`order` (orderQty, orderPrice, orderReview, orderTime, orderName, userName) VALUES (2, 49, 5, '2023-04-16 10:21:14', '.NET Logger', 'testuser2');
INSERT INTO caproject.`order` (orderQty, orderPrice, orderReview, orderTime, orderName, userName) VALUES (1, 49, 5, '2023-04-16 10:21:29', '.NET Logger', 'testuser1');
INSERT INTO caproject.`order` (orderQty, orderPrice, orderReview, orderTime, orderName, userName) VALUES (1, 299, 2, '2023-04-16 10:25:14', '.NET ML', 'testuser2');
INSERT INTO caproject.`order` (orderQty, orderPrice, orderReview, orderTime, orderName, userName) VALUES (2, 199, 4, '2023-04-16 10:25:14', '.NET Numerics', 'testuser1');
INSERT INTO caproject.`order` (orderQty, orderPrice, orderReview, orderTime, orderName, userName) VALUES (2, 99, 5, '2023-04-16 14:25:44', '.NET Charts', 'testuser2');
INSERT INTO caproject.`order` (orderQty, orderPrice, orderReview, orderTime, orderName, userName) VALUES (2, 99, 3, '2023-04-16 14:35:31', '.NET Charts', 'testuser1');
INSERT INTO caproject.`order` (orderQty, orderPrice, orderReview, orderTime, orderName, userName) VALUES (3, 49, 5, '2023-04-16 14:35:31', '.NET Logger', 'testuser2');
INSERT INTO caproject.`order` (orderQty, orderPrice, orderReview, orderTime, orderName, userName) VALUES (2, 299, 2, '2023-04-17 09:20:43', '.NET Analytics', 'testuser1');
INSERT INTO caproject.`order` (orderQty, orderPrice, orderReview, orderTime, orderName, userName) VALUES (1, 49, 5, '2023-04-17 09:21:12', '.NET Logger', 'testuser1');
INSERT INTO caproject.`order` (orderQty, orderPrice, orderReview, orderTime, orderName, userName) VALUES (2, 99, 5, '2023-04-17 09:23:07', '.NET Charts', 'admin');
INSERT INTO caproject.`order` (orderQty, orderPrice, orderReview, orderTime, orderName, userName) VALUES (3, 49, 5, '2023-04-17 09:51:23', '.NET Logger', 'testuser1');
INSERT INTO caproject.`order` (orderQty, orderPrice, orderReview, orderTime, orderName, userName) VALUES (1, 99, 4, '2023-04-17 12:36:00', '.NET Charts', 'testuser2');
