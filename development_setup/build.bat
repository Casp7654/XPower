mkdir resource\volumes\webapi\backups
mkdir resource\volumes\hub\backups
mkdir resource\volumes\iot\backups

echo "Building WebApi"
docker build . --tag xpower-webapi --file ".\dockerfiles\webapi.Dockerfile"

echo "Building IoT Handler"
docker build . --tag xpower-iot_handler --file ".\dockerfiles\iot_handler.Dockerfile"

echo "Building Hosted PWA"
docker build . --tag xpower-hosted_pwa --file ".\dockerfiles\hosted_pwa.Dockerfile"

echo "Building Hub"
docker build . --tag xpower-hub --file ".\dockerfiles\hub.Dockerfile"

echo "Building IoT Device"
docker build . --tag xpower-iot --file ".\dockerfiles\iot.Dockerfile"

wsl --exec "docker rmi $(docker images --format '{{.ID\t{{.Tag}}' | grep '<none>' | awk '{print $1}')"
docker builder prune --force
docker image prune --force