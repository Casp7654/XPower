docker stop surreal-be
docker build -t surrealdb .
docker run --rm -itd --name surreal-be -p 8000:8000 --mount type=bind,src="%cd%/backups",dst=/root/backups surrealdb
