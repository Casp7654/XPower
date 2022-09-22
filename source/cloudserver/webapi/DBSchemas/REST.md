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

## Get Users
```sql
-- Get all
SELECT * FROM user;
-- get specifik
select * from user:1;
-- syntax select [FIELDS] from [TABLE]:[ID];
select * from user:1;
```
