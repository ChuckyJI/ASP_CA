create table cart
(
    cartName varchar(20) charset utf8mb3 not null
        primary key,
    cartQty  int                         not null,
    constraint cart_ibfk_1
        foreign key (cartName) references products (itemName)
);

