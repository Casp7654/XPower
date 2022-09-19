# CloudServer Install Script

````bash
# Update Package Repo
apt-get update && apt-get upgrade -y
# Install default programs
apt-get install -y sudo curl wget rsync
# Firewall
apt-get install -y ufw
# Git
apt-get install -y git
# Editors
apt-get install -y nano neovim
# Docker
sudo apt-get install -y ca-certificates gnupg lsb-release
sudo mkdir -p /etc/apt/keyrings
curl -fsSL https://download.docker.com/linux/debian/gpg | sudo gpg --dearmor -o /etc/apt/keyrings/docker.gpg
echo "deb [arch=$(dpkg --print-architecture) signed-by=/etc/apt/keyrings/docker.gpg] https://download.docker.com/linux/debian $(lsb_release -cs) stable" | sudo tee /etc/apt/sources.list.d/docker.list > /dev/null
sudo apt-get update && sudo apt-get install docker-ce docker-ce-cli containerd.io docker-compose-plugin
sudo systemctl enable containerd && sudo systemctl enable docker
sudo systemctl start containerd && sudo systemctl start docker
sudo groupadd docker
# Setup Firewall
ufw allow 80/tcp
ufw allow 443/tcp
ufw allow 22/tcp
ufw default deny incoming
ufw default allow outgoing
ufw enable
ufw status verbose
# Add User (and add dockergrp to user)
adduser xpower
sudo usermod -aG docker xpower
# Install WebServer Dependencies
apt-get install -y nodejs npm
apt-get install -y python3
apt-get install -y php
curl -sSf https://install.surrealdb.com | sh
````
