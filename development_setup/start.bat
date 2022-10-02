echo -e "\nStarting HUB Container"
    docker run --rm -itd ^
        --network xpower-home --ip 172.64.0.254 ^
        --mount type=bind,src="%cd%/resource/symblnk/hub/",dst=/root/source/hub ^
        --mount type=bind,src="%cd%/resource/volumes/hub/backups/",dst=/root/backups ^
        --mount type=bind,src="%cd%/../source/hub/",dst=/root/sourcecode/ ^
        --name xpower-hub ^
        xpower-hub

echo -e "\nStarting web api Container"
docker run --rm -itd ^
        --network xpower-cloud --ip 172.32.0.2 ^
        --mount type=bind,src="%cd%/resource/volumes/webapi/backups",dst=/root/backups ^
        --mount type=bind,src="%cd%/../source/cloudserver/webapi",dst=/root/sourcecode/ ^
        --name xpower-webapi ^
        xpower-webapi

echo -e "\nStarting Hosted PWA Container"
    docker run --rm -itd ^
        --network xpower-cloud --ip 172.32.0.4 ^
        --mount type=bind,src="%cd%/resource/symblnk/pwa/",dst=/root/source/pwa ^
        --mount type=bind,src="%cd%/../source/webclient/XPower_WebClient",dst=/root/sourcecode/ ^
        --name xpower-hosted_pwa ^
        xpower-hosted_pwa

echo -e "\nStarting IoT Device Container"
    docker run --rm -itd ^
    --network xpower-home ^
        --mount type=bind,src="%cd%/resource/symblnk/iot/",dst=/root/source/iot ^
        --mount type=bind,src="%cd%/resource/volumes/iot/backups/",dst=/root/backups ^
        --mount type=bind,src="%cd%/../source/IoTClient/",dst=/root/sourcecode/ ^
        --name xpower-iot1 ^
        xpower-iot