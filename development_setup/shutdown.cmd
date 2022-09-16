echo -e "\nStopping IoT Devices"
docker stop xpower-iot1
docker stop xpower-iot2
echo -e "\nStopping Hubs"
docker stop xpower-hub1

echo -e "\nStopping Hosted PWA"
docker stop xpower-hosted_pwa

echo -e "\nStopping IoT Handler"
docker stop xpower-iot_handler

echo -e "\nStopping WebApi"
docker stop xpower-webapi

echo -e "\nStopping Datastore"
docker stop xpower-datastore