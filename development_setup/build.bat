mkdir resource\volumes\webapi\backups
mkdir resource\volumes\hub\backups
mkdir resource\volumes\iot\backups

echo "Building WebApi"
docker build . --tag xpower-webapi --file "%cd%\resource\dockerfiles\webapi.Dockerfile"

echo "Building IoT Handler"
docker build . --tag xpower-iot_handler --file "%cd%\resource\dockerfiles\iot_handler.Dockerfile"

echo "Building Hosted PWA"
docker build . --tag xpower-hosted_pwa --file "%cd%\resource\dockerfiles\hosted_pwa.Dockerfile"

echo "Building Hub"
docker build . --tag xpower-hub --file "%cd%\resource\dockerfiles\hub.Dockerfile"

echo "Building IoT Device"
docker build . --tag xpower-iot --file "%cd%\resource\dockerfiles\iot.Dockerfile"

wsl --exec "docker rmi $(docker images --format '{{.ID\t{{.Tag}}' | grep '<none>' | awk '{print $1}')"
docker builder prune --force
docker image prune --force

echo "Setting up networks"
docker network create --driver bridge --subnet 172.32.0.0/24 --gateway 172.32.0.1 xpower-cloud
docker network create --driver bridge --subnet 172.64.0.0/24 --gateway 172.64.0.1 xpower-home