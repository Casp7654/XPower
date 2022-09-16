#!/bin/bash
# Run Images (RAW DOCKERFILES)

docker run --rm -itd \
    xpower-iothandler \
    --mount type=bind,src="$(pwd)/sourcecode/handler",dst=/root/source/handler \
    --name xpower-iothandler
#    --mount type=bind,src="$(pwd)/volumes/handler/backups",dst=/root/backups \

docker run --rm -itd \
    xpower-webapi \
    --mount type=bind,src="$(pwd)/volumes/webapi/backups",dst=/root/backups \
    --mount type=bind,src="$(pwd)/sourcecode/webapi",dst=/root/source/webapi \
    --name xpower-webapi

docker run --rm -itd \
    xpower-pwa \
    --mount type=bind,src="$(pwd)/sourcecode/pwa",dst=/root/source/pwa \
    --name xpower-pwa
#    --mount type=bind,src="$(pwd)/volumes/pwa/backups",dst=/root/backups \

docker run --rm -itd \
    xpower-hub \
    --mount type=bind,src="$(pwd)/volumes/hub/backups",dst=/root/backups \
    --mount type=bind,src="$(pwd)/sourcecode/hub",dst=/root/source/hub \
    --name xpower-hub1

docker run --rm -itd \
    xpower-iot \
    --mount type=bind,src="$(pwd)/volumes/iot/backups",dst=/root/backups \
    --mount type=bind,src="$(pwd)/sourcecode/iot",dst=/root/source/iot \
    --name xpower-iot1

docker run --rm -itd \
    xpower-iot \
    --mount type=bind,src="$(pwd)/volumes/iot/backups",dst=/root/backups \
    --mount type=bind,src="$(pwd)/sourcecode/iot",dst=/root/source/iot \
    --name xpower-iot2
