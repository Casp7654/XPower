# Docker Development Environment Setup

There's a lot of easier ways to setup Docker Environments,
but to get a fully configurable environment,
we'll be building each Image, making custom Networks
and make some docker scripts to get everything up and running like we want it.

---

# Dockerfiles

The dockerfiles can be found in the relative path:`./dockerfiles`
and are names after what part of the setup they're handling.

The files are as of writing this:

```
webapi.Dockerfile           Cloud WebApi Application
datastore.Dockerfile        Cloud Database
hosted_pwa.Dockerfile       Cloud Hosted PWA
iot_handler.Dockerfile      Cloud IoThandler
hub.Dockerfile              Hub Application
iot.Dockerfile              Simulated IoT Device (Linux Debian)
devdock-setup.yaml          Compose File
```

_Note: The WebClient is only illutrated here as the hosted PWA._

---

# Network

As for the Network we're gonna set up 2 Networks to seperate the "`Home Network`" (for devices in the simulated house) from the `Cloud Network` (Externally hosted Cloud -- scalable).

Network Matrix:

| Network Name  | Subnet        |
| ------------- | ------------- |
| Home Network  | 172.0.0.0/24  |
| Cloud Network | 172.16.0.0/24 |

| Device Hostname | Network Name  | Ip addr        | Used Ports |
| --------------- | ------------- | -------------- | ---------- |
| webapi          | Cloud Network | 172.16.0.2/24  | 80,443     |
| datastore       | Cloud Network | 172.16.0.4/24  | 8000       |
| iot-handler     | Cloud Network | 172.16.0.3/24  | 80,443     |
| hosted-pwa      | Cloud Network | 172.16.0.17/24 | 80,443     |
| hub             | Home Network  | 172.0.0.254/24 | 80,443     |
| iot⁺            | Home Network  | 172.0.0.#⁺/24  | -          |

\_Note: the Iot's has last byte in the ipaddr after the added numbering (more on this later).

---

# Naming rules

The naming of **Images**, **Containers** and **Volumes** are gonna follow the dockerfiles, with the added prefix `xpower-*` eg. `xpower-webapi` | `xpower-hosted_pwa`.

In the case of multiple **Containers** and/or **Volumes** made by the same image, the naming is gonna add numbering. eg. container:`xpower-iot1` | Volume:`xpower-hub1`.

_Note: These naming rules is for ease of filtering, searching, managing and more within docker_

---

# Setting up the Environment

Be Sure to have `docker` and `docker-compose` installed on the machine.

---

# Running the environment

Run the script `Boot Environment.cmd`

## Environment?

Open an independent terminal and let the `dockerlist.cmd` script run in the background to keep track of the environment containers, volumes and images. (Windows pending, use Docker Desktop for now) .

## Access the Applications

The Applications should be accessible by the ip/hostnames:port of the devices (ref:Network).

## Interacting with the Containers

**BE SURE** the environment is running, then open a new terminal and run the `Open.cmd` followed by the hostname to gain ssh access to the running docker container like so `Open.cmd "xpower/xpower-db"`.

Within the `Hub`, `IoT`and `Datastore` container's _`/usr/local/bin`_ folder there are scripts to handle stuff like _import/export_ for datastore, _poweron/powerof_, _connectToHub/setDiscovery_ for hub and iot and much more. These can be run from any directory like this ``[root@iot1 ~ ]$ connectToHub 172.0.0.14``.

## Stopping the containers in the environment

In a terminal run `Shutdown.cmd`.

---

# CleanUp

**!! IMPORTANT !!**

Doing this will remove the:

- Docker Networks
- Docker Images
- Docker Volumes (ALL CONTAINER DATA)

To remove something individually, contact Casper or read the docs.

**Be SURE** the environment is down (run the `Shutdown.cmd`), then in a terminal run the `IKNOWWHATIMDOING.cmd` script.

---
