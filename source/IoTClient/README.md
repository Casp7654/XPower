# XPower Mock IoT Client

## Description
This project is used to mock a IoT client. The client will have a basic IoT client where the broker(hub) can send data to.

Mqtt clients which can be added by running the program.
The clients will be saved into client file, so when started again will load the clients saved clients.

The clients can control led, by specifying the pin.

The client has the possibility, to turn of for GPIO.

- Architechure: rPi(Arm)
- OperativSystem: Raspbian(Debian10)
- Language: Python3
- Type: Application
- Dependencies: `python3`

## Directory Structure
```
README.md           This file.
LICENSE             Lawyering up.
setup.py            Package and distribution management.
requirements.txt    Development dependencies.
Makefile            Generic management tasks.
src/__init__.py     Program entrypoint
src/*.py            Python files related to current project.
.gitignore          Specific ignores
```