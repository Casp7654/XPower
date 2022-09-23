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

-- Create HomeGroup
insert into homegroup {id:1, name:"default"};
-- Relate User to Homegroup
-- Syntax: relate [TABLE]:[ID]->[RELATIONTABLE]->[TABLE]:[ID];
relate user:1->usergroups->homegroup:1;
-- Get Specifik User's HomeGroups
select id, ->usergroups->homegroup as usergroups from user:1;

-- Create Hub
insert into hub {id:1, name:"hub1", private_addr:"172.64.0.3", public_addr:"172.32.0.2" };
-- Relate Homegroup to Hub
-- Syntax: relate [TABLE]:[ID]->[RELATIONTABLE]->[TABLE]:[ID];
relate homegroup:1->grouphubs->hub:1;
-- Get Specifik Homegroup's Hubs
select id, ->grouphubs->hub as hubs from homegroup:1;

-- Get Specifik User's Homegroups and their hubs
-- Syntax: ->[RELATIONTABLE]->[TABLE](:[ID])->[RELATIONTABLE]->[TABLE](:[ID]);
select id, ->usergroups->homegroup->grouphubs->hub as userhubs from user:1;
```
