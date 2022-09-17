docker run --rm -itd --name xpower-iot_handler --mount type=bind,src="%cd%\resource\winlnk\handler",dst=/root/source/handler xpower-iot_handler
docker run --rm -itd --name xpower-webapi --mount type=bind,src="%cd%\resource\volumes\webapi\backups",dst=/root/backups --mount type=bind,src="%cd%\resource\winlnk\webapi",dst=/root/source/webapi xpower-webapi
docker run --rm -itd --name xpower-pwa  --mount type=bind,src="%cd%\resource\winlnk/pwa",dst=/root/source/pwa xpower-hosted_pwa
docker run --rm -itd --name xpower-hub1 --mount type=bind,src="%cd%\resource\volumes/hub/backups",dst=/root/backups --mount type=bind,src="%cd%\resource\winlnk\hub",dst=/root/source/hub xpower-hub
docker run --rm -itd --name xpower-iot1 --mount type=bind,src="%cd%\resource\volumes/iot/backups",dst=/root/backups --mount type=bind,src="%cd%\resource\winlnk\iot",dst=/root/source/iot xpower-iot
docker run --rm -itd --name xpower-iot2 --mount type=bind,src="%cd%\resource\volumes/iot/backups",dst=/root/backups --mount type=bind,src="%cd%\resource\winlnk\iot",dst=/root/source/iot xpower-iot
