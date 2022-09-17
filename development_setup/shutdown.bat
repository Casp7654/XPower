echo "Stopping IoT Devices"
docker stop xpower-iot
docker stop xpower-iot1
docker stop xpower-iot2
docker stop xpower-iot3
echo "Stopping Hubs"
docker stop xpower-hub
docker stop xpower-hub1
docker stop xpower-hub2
docker stop xpower-hub3
echo "Stopping Hosted PWA"
docker stop xpower-hosted_pwa
docker stop xpower-pwa
echo "Stopping IoT Handler"
docker stop xpower-iot_handler
echo "Stopping WebApi"
docker stop xpower-webapi
