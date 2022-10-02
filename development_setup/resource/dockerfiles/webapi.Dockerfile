#& 1. Set Base Image
FROM debian:bullseye

#& 2. Set User
#USER root
run whoami

#& 3. Set Working directory
WORKDIR /root
RUN mkdir -p ./source

#& 4. Install Dependencies
RUN apt-get update && apt-get install -y psmisc screen
# SurrealDB
RUN apt-get install -y curl
RUN curl -sSf https://install.surrealdb.com | sh
RUN mkdir -p ./datastore
# C# Runtime || SDK
RUN apt-get install -y wget
RUN wget https://packages.microsoft.com/config/debian/11/packages-microsoft-prod.deb -O packages-microsoft-prod.deb && dpkg -i packages-microsoft-prod.deb && rm packages-microsoft-prod.deb
RUN apt-get update && apt-get install -y dotnet-sdk-6.0 dotnet-runtime-6.0 aspnetcore-runtime-6.0

#& 5. Expose Ports in Container
EXPOSE 80
EXPOSE 433
EXPOSE 8000

#& 6. Create Volume Paths
# Volume map point is set when running container
VOLUME [ "/srvadm/backups", "/srvadm/source" ]

#& 7. Copy Source / Data

#& 8. Add Custom Executables / Scripts
COPY ./resource/bin/webapi/* /usr/local/bin/
# Remember to make them executable for the user
RUN chmod u+x /usr/local/bin/*
RUN echo "ls /usr/local/bin" > commands && chmod u+x commands

#& 9. Compile / Setup Project

#& 10. Done
# Only needed if image is not a complete machine eg. gcc or c# image
#CMD [ "/usr/local/bin/import-db", "full", "&&", "/usr/local/bin/serve" ,"&"]
