create table products
(
    itemName        varchar(20) charset utf8mb3  not null
        primary key,
    itemPrice       float                        not null,
    itemReview      float                        null,
    itemID          mediumtext                   not null,
    itemDescription varchar(200) charset utf8mb3 not null
);

create index item_name
    on products (itemName);

create index item_price
    on products (itemPrice);

INSERT INTO caproject.products (itemName, itemPrice, itemReview, itemID, itemDescription) VALUES ('.NET Analytics', 299, 4, '00000000001', 'Performs data mining and analytics easily in .NET.');
INSERT INTO caproject.products (itemName, itemPrice, itemReview, itemID, itemDescription) VALUES ('.NET Charts', 99, 3, '00000000002', 'Brings powerful charting capabilities to your .NET applications.');
INSERT INTO caproject.products (itemName, itemPrice, itemReview, itemID, itemDescription) VALUES ('.NET Logger', 49, 5, '00000000003', 'Logs and aggregates events easily in your .NET apps.');
INSERT INTO caproject.products (itemName, itemPrice, itemReview, itemID, itemDescription) VALUES ('.NET ML', 299, 3, '00000000004', 'Supercharged .NET machine learning libraries.');
INSERT INTO caproject.products (itemName, itemPrice, itemReview, itemID, itemDescription) VALUES ('.NET Numerics', 199, 2, '00000000005', 'Powerful numerical methods for your .NET simulations.');
INSERT INTO caproject.products (itemName, itemPrice, itemReview, itemID, itemDescription) VALUES ('.NET Paypal', 69, 3, '00000000006', 'Integrate your .NET apps with Paypal the easy way!');
