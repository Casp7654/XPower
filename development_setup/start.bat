docker run --rm -itd --name xpower-iot_handler --mount type=bind,src="%cd%/sourcecode/handler",dst=/root/source/handler xpower-iot_handler
docker run --rm -itd --name xpower-webapi --mount type=bind,src="%cd%/volumes/webapi/backups",dst=/root/backups --mount type=bind,src="%cd%/sourcecode/webapi",dst=/root/source/webapi xpower-webapi
docker run --rm -itd --name xpower-pwa --mount type=bind,src="$(pwd)/sourcecode/pwa",dst=/root/source/pwa xpower-pwa
docker run --rm -itd --name xpower-hub1 --mount type=bind,src="$(pwd)/volumes/hub/backups",dst=/root/backups --mount type=bind,src="$(pwd)/sourcecode/hub",dst=/root/source/hub xpower-hub
docker run --rm -itd --name xpower-iot1 --mount type=bind,src="$(pwd)/volumes/iot/backups",dst=/root/backups --mount type=bind,src="$(pwd)/sourcecode/iot",dst=/root/source/iot xpower-iot
docker run --rm -itd --name xpower-iot2 --mount type=bind,src="$(pwd)/volumes/iot/backups",dst=/root/backups --mount type=bind,src="$(pwd)/sourcecode/iot",dst=/root/source/iot xpower-iot
