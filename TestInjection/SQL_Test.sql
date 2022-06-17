create database test
use test
drop table account
create table account(
    ID VARCHAR(20) PRIMARY KEY,
    PASSWORDA VARCHAR(20) not null,
)
select * from account
INSERT INTO account VALUES ('hoangthai','xuanthai')

select * from account where ID = 'thaideptrai' and PASSWORDA = '' or 1=1 --'