docker run --rm -itd --name surreal-be -p 8000:8000 --mount type=bind,src="%cd%/backups",dst=/surreal/datastore/backups surrealdb
