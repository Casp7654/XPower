echo -e "\nStarting IoT Device Container"
    docker run --rm -itd ^
    --network xpower-home ^
        --mount type=bind,src="%cd%/resource/symblnk/iot/",dst=/root/source/iot ^
        --mount type=bind,src="%cd%/resource/volumes/iot/backups/",dst=/root/backups ^
        --mount type=bind,src="%cd%/../source/IoTClient/",dst=/root/sourcecode/ ^
        --name xpower-iot1 ^
        xpower-iot