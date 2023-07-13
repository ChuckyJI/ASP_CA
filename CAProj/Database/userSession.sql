create table userSession
(
    userSessionId varchar(60) charset utf8mb3 not null
        primary key,
    userSid       int                         not null,
    constraint usersession_ibfk_1
        foreign key (userSid) references Customers (userId)
);

create index userSid
    on userSession (userSid);

INSERT INTO caproject.userSession (userSessionId, userSid) VALUES ('2e439486-d4bd-499c-a4bf-1bd5c483b396', 1);
INSERT INTO caproject.userSession (userSessionId, userSid) VALUES ('8807a097-7edc-4df6-ae90-ea4fa1cebe63', 1);
INSERT INTO caproject.userSession (userSessionId, userSid) VALUES ('9bd7cf6e-dc38-4305-9651-93d4c1c8b2ca', 1);
INSERT INTO caproject.userSession (userSessionId, userSid) VALUES ('b48ce5c4-77a6-4a58-8164-3e23a39f2d5e', 1);
