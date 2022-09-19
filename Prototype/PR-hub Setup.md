# Prototype Hub setup
```bash
# Create connect to prototype netværk script
echo "nmcli device wifi connect \"xpowertest\" hidden yes password xpowertest ifname wlan0" > ~/connect2test && chmod u+x connect2test
# Run connect to xpowertest
./connect2test
# Create show ip quick script
echo "ip -c addr show dev wlan0" > getip && chmod u+x getip
# Run show ip script
./getip
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
# Setup Firewall
ufw allow 80/tcp
ufw allow 443/tcp
ufw allow 22/tcp
ufw default deny incoming
ufw default allow outgoing
ufw enable
ufw status verbose
```