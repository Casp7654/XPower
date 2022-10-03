echo -e "\nStarting HUB Container"
    docker run --rm -itd ^
        --network xpower-home --ip 172.64.0.254 ^
        --mount type=bind,src="%cd%/../source/hub/src",dst=/root/source ^
        --mount type=bind,src="%cd%/resource/volumes/hub/backups",dst=/root/backups ^
        --name xpower-hub ^
        -p 1883:1883/tcp ^
        xpower-hub

echo -e "\nStarting web api Container"
docker run --rm -itd ^
        --network xpower-cloud --ip 172.32.0.2 ^
        --mount type=bind,src="%cd%/resource/volumes/webapi/backups",dst=/root/backups ^
        --mount type=bind,src="%cd%/../source/cloudserver/webapi/XPowerApi/XPowerApi",dst=/root/source ^
        --name xpower-webapi ^
        -P ^
        xpower-webapi

echo -e "\nStarting Hosted PWA Container"
    docker run --rm -itd ^
        --network xpower-cloud --ip 172.32.0.4 ^
        --mount type=bind,src="%cd%/../source/webclient/XPower_WebClient",dst=/root/source ^
        --name xpower-hosted_pwa ^
        -p 8080:80 ^
        xpower-hosted_pwa

echo -e "\nStarting IoT Device Container"
    docker run --rm -itd ^
    --network xpower-home ^
        --mount type=bind,src="%cd%/../source/IoTClient",dst=/root/source ^
        --name xpower-iot1 ^
        xpower-iot