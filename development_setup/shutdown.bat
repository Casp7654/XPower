echo "Stopping IoT Devices"
docker stop xpower-iot1
docker stop xpower-iot2

echo "\nStopping Hubs"
docker stop xpower-hub1

echo "\nStopping Hosted PWA"
docker stop xpower-hosted_pwa

echo "\nStopping IoT Handler"
docker stop xpower-iot_handler

echo "\nStopping WebApi"
docker stop xpower-webapi

echo "\nStopping Datastore"
docker stop xpower-datastore