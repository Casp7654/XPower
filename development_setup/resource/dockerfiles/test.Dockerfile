#& 1. Set Base Image
FROM debian:bullseye

#& 2. Set User
USER root

#& 3. Set Working directory
WORKDIR /root
RUN mkdir -p ./source

#& 4. Install Dependencies
RUN apt-get update
#* Python
RUN apt-get install -y python3
#* SurrealDB
RUN apt-get install -y curl
RUN curl -sSf https://install.surrealdb.com | sh
#* C# .NET v6.0 Runtime
RUN apt-get install -y wget
RUN wget https://packages.microsoft.com/config/debian/11/packages-microsoft-prod.deb -O packages-microsoft-prod.deb && dpkg -i packages-microsoft-prod.deb && rm packages-microsoft-prod.deb
RUN apt-get update && apt-get install -y dotnet-sdk-6.0  dotnet-runtime-6.0 aspnetcore-runtime-6.0
RUN mkdir -p ./datastore
#* Node js v16 LTS
RUN apt-get install -y curl git
RUN curl -fsSL https://deb.nodesource.com/setup_lts.x | bash -
RUN apt-get install -y nodejs
RUN npm install -g npm && npm cache verify && npm install -g @angular/cli@latest
#* Mosquitto - Mqtt Client
# link: https://github.com/eclipse/mosquitto
#RUN apt-get install -y git
#RUN git clone https://github.com/eclipse/mosquitto.git
#* HIVEMQ - Mqtt Broker

#& 5. Expose Ports in Container
EXPOSE 80
EXPOSE 443

#& 6. Create Volume Paths
# Volume map point is set when running container
VOLUME [ "/root/backups", "/root/source" ]

#& 7. Copy Source / Data
COPY ./source ./source

#& 8. Add Custom Executables / Scripts
COPY ./bin/app/* /usr/local/bin/
# Remember to make them executable for the user
RUN chmod u+x /usr/local/bin/*

#& 9. Compile / Setup Project
RUN buildApp

#& 10. Done
# Only needed if image is not a complete machine eg. gcc or c# image
CMD [ "startApp" ]
