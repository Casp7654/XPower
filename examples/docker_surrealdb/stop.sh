echo -e "stopping container..."
docker stop surreal-be
echo -e "removing container"
docker rm surreal-be
echo "done...!"