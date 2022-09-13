#& 1. Base Image
FROM debian:bullseye

#& 2. Config Image
RUN apt-get update && apt-get install curl -y
RUN curl -sSf https://install.surrealdb.com | sh

#& 3. Working directory
WORKDIR /usr/src
RUN mkdir -p ./bin ./app

#& 4. Copy Source
COPY ./app ./app

#& 5. Create Virtal folder
# Volume map point is set when running container
VOLUME [ "/usr/src/app" ]

#& 6. Expose Ports in Container
EXPOSE 8000

#& 7. Compile / Setup Project
RUN ln -s /usr/local/bin/surreal ./bin/surreal
COPY ./img_cmd ./
RUN chmod u+x serve dbtest

#& 8. Done
#RUN ./bin/surreal start --log debug --user root --pass root > ./logs/debug
#CMD [ "./bin/surreal", "start", "--log", "debug", "--user", "root", "--pass", "root" , "&"]
