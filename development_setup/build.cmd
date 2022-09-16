# Setup Host
mkdir -p ./volumes/webapi/backups
mkdir -p ./volumes/hub/backups
mkdir -p ./volumes/iot/backups

# Build Images
echo -e "\nBuilding WebApi"
docker build . --tag xpower-webapi --file "./dockerfiles/webapi.Dockerfile"

echo -e "\nBuilding IoT Handler"
docker build . --tag xpower-iot_handler --file "./dockerfiles/iot_handler.Dockerfile"

echo -e "\nBuilding Hosted PWA"
docker build . --tag xpower-hosted_pwa --file "./dockerfiles/hosted_pwa.Dockerfile"

echo -e "\nBuilding Hub"
docker build . --tag xpower-hub --file "./dockerfiles/hub.Dockerfile"

echo -e "\nBuilding IoT Device"
docker build . --tag xpower-iot --file "./dockerfiles/iot.Dockerfile"4

# Cleanup
docker rmi $(docker images --format "{{.ID}}\t{{.Tag}}" | grep "<none>" | awk '{print $1}')
docker builder prune --force
docker image prune --force