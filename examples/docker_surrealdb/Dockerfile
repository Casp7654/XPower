#& 1. Base Image
FROM debian:bullseye

#& 2. Config Image
RUN apt-get update && apt-get install curl -y
RUN curl -sSf https://install.surrealdb.com | sh

#& 3. Working directory
WORKDIR /surreal
RUN mkdir -p ./bin ./datastore

#& 4. Copy Source / Data
COPY ./backups ./datastore/backups

#& 5. Create Virtal folder
# Volume map point is set when running container
VOLUME [ "/surreal/datastore" ]

#& 6. Expose Ports in Container
EXPOSE 8000

#& 7. Compile / Setup Project
RUN ln -s /usr/local/bin/surreal ./bin/surreal
COPY ./img_cmd ./
RUN chmod u+x serve dbtest sql import export

#& 8. Done
#CMD [ "./bin/surreal", "start" ]
