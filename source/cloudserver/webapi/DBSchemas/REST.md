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
```bash
SELECT * FROM user;
```
## Get Hubs
```bash
SELECT * FROM hub;
```
## Get UserHubs
```bash
SELECT * FROM user;
```

## Get PowerCops
```bash
SELECT * FROM user;
```