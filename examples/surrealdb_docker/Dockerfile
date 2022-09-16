#& 1. Base Image
FROM debian:bullseye

#& 2. Set User
USER root

#& 3. Set Working directory
WORKDIR /root
RUN mkdir -p ./datastore ./bin

#& 4. Install Dependencies
RUN apt-get update
RUN apt-get install curl -y
RUN curl -sSf https://install.surrealdb.com | sh

#& 5. Expose Ports in Container
EXPOSE 8000

#& 6. Create Virtal folder
# Volume map point is set when running container
VOLUME [ "/root/backups" ]

#& 7. Copy Source / Data
COPY ./backups ./backups

#& 8. Add Custom Executables / Scripts
COPY ./img_cmd /root/bin
# Remember to make them executable for the user
RUN chmod u+x /root/bin/*

#& 9. Compile / Setup Project

#& 10. Done
# Only needed if image is not a complete machine eg. gcc or c# image
#CMD [ "./bin/", "start" ]
