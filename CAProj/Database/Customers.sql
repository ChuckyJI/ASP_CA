create table Customers
(
    userName varchar(20) charset utf8mb3 not null
        primary key,
    userPwd  varchar(20) charset utf8mb3 not null,
    userId   int                         null
);

create index Customers
    on Customers (userId);

INSERT INTO caproject.Customers (userName, userPwd, userId) VALUES ('admin', 'admin', 0);
INSERT INTO caproject.Customers (userName, userPwd, userId) VALUES ('testuser1', 'testuser1', 1);
INSERT INTO caproject.Customers (userName, userPwd, userId) VALUES ('testuser2', 'testuser2', 2);
