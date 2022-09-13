#if [ "$1" == "make" ]; then
    #docker pull surrealdb/surrealdb:latest
    #touch applog
#fi
docker run --rm -itd \
    --name surreal-be \
    -p 8000:8000 \
    --mount type=bind,src=$(pwd)/app,dst=/usr/src/app \
    surrealdb
