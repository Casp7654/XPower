# SurrealDB Docker Example

[Link to the SurrealDB Documentation](https://surrealdb.com/docs)

---

## Handling Docker Container

In this example the BASEIMAGE used is the `debian:bullseye` to utilize a complete linux ENV. (there is a `rust:latest` & a `surrealdb/surrealdb:latest` docker image which COULD be used...)

To build the container there is a couple of thing to be done, all of which have been simplified in the files:

- Dockerfile
- build.bat
- run.bat
- stop.bat

_note¹: the `rebuild.bat` is just a quick chain of the other bash files_

---

## Interact With SurrealDB

**If using the docker image:**

Run the `$ ./interact.bat`, or the Windows equivelent, to gain access to the running Docker container.
Then run the sql REPL by typing `$ ./sql`

**if NOT using the docker image:**

run the sql REPL by typing:
```bash
surreal sql --conn http://[IP:PORT] --user [USER] --pass [pass] --ns [NAMESPACE] --db [DATABASE] [--pretty]
```
eg.
```bash
surreal sql --conn http://127.0.0.1:8000 --user root --pass root --ns test --db test --pretty
```

### Test Interactions

Inside the sql REPL you can now follow [The documentation for DDL and DML](https://surrealdb.com/docs/surrealql/statements)

### Test QL

```sql
> create testtable:test1 set name = "test";

// Output: [{"result":[{"id":"testtable:test1","name":"test1"}],"status":"OK","time": "125.02µs"}]

> select * from testtable;

// Output: [{"result":[{"id":"testtable:test1","name":"test1"}],"status":"OK","time": "41.61µs"}]

> update testtable:test1 set name = "test2";

// Output: [{"result":[{"id":"testtable:test1","name":"test2"}],"status":"OK","time": "102.845µs"}]
```

---
