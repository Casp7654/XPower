#& 1. Set Base Image
FROM debian:bullseye

#& 2. Set User
USER root

#& 3. Set Working directory
WORKDIR /root
RUN mkdir -p ./source

#& 4. Install Dependencies
RUN apt-get update
# Python
RUN apt-get install python3 -y
RUN apt install python3-pip -y

#& 5. Expose Ports in Container
EXPOSE 80
EXPOSE 443

#& 6. Create Volume Paths
# Volume map point is set when running container
VOLUME [ "/root/backups", "/root/source" ]

#& 7. Copy Source / Data

#& 8. Add Custom Executables / Scripts
COPY ./resource/bin/iot/* /usr/local/bin/
# Remember to make them executable for the user
RUN chmod u+x /usr/local/bin/*

#& 9. Compile / Setup Project
RUN pip3 install paho-mqtt gpiozero readchar


#& 10. Done
# Only needed if image is not a complete machine eg. gcc or c# image
#CMD [ "./bin/", "start" ]
