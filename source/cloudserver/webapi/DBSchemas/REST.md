# WebApi SurrealDB Rest Calls

```bash
curl -X POST \
	 -u "root:root" \
	 -H "NS: xpower" \
	 -H "DB: webapi" \
	 -H "Content-Type: application/json" \
	 -d "%SQL%" \
	 http://localhost:8000/sql
```

## Db Explaination
```sql
-- Create User
insert into user {id:1, firstname:'john', lastname:'doe', email:'heste@test.dk', username:"johnboi"};
-- Get all Users
SELECT * FROM user;
-- Get Specifik User
-- syntax select [FIELDS] from [TABLE]:[ID];
select * from user:1;
-- OR
select * from user where id = user:1;

-- Create Home
insert into home {id:1, name:"default"};
-- Relate User to Home
-- Syntax: relate [TABLE]:[ID]->[RELATIONTABLE]->[TABLE]:[ID];
relate user:1->homeusers->home:1;
-- Get Specifik User's Home id
select ->homeusers->home as homeusers from user:1;
-- Get Specifik User's Home data
select ->homeusers->home.* as homeusers from user:1;
-- Get Home Relation Information based on user's homes
select * from homeusers where in outside (select ->homeusers as homeusers from user:1);

-- Create Hub with home
insert into hub {id:1, name:"hub1", private_addr:"172.64.0.3", public_addr:"172.32.0.2", home:home:1};
-- OR add later with
update hub:1 set home = home:1;
-- this is a one to many relation

-- Get Specifik Hub data
select * from hub:1;
-- get specifik Hub's Home data
select home.* from hub:1;
-- Get All Hubs from a specifik User's homes
select * from hub where home outside (select ->homeusers->home from user:1 )
-- This is a bit tricky to explain....

```

## Test Data

```sql
insert into user {id:1, firstname:'john', lastname:'doe', email:'heste@test.dk', username:"johnboi"};
insert into user {id:2, firstname:'jane', lastname:'doe', email:'heste@test.dk', username:"janegurl"};
insert into home {id:1, name:"default"};
insert into home {id:2, name:"default"};
relate user:1->usergroups->home:1;
relate user:2->usergroups->home:2;
insert into hub {id:1, name:"hub1", private_addr:"172.64.0.11", public_addr:"172.32.0.2", home:home:1};
insert into hub {id:2, name:"hub2", private_addr:"172.64.0.12", public_addr:"172.32.0.2", home:home:1 };
insert into hub {id:3, name:"hub3", private_addr:"172.64.0.13", public_addr:"172.32.0.2", home:home:2 };
insert into hub {id:4, name:"hub4", private_addr:"172.64.0.14", public_addr:"172.32.0.2", home:home:2 };
```