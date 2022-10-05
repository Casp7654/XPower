export const environment = {
  production: true,
  mqttClientSettings: {
	  url:"broker.emqx.io",
	  port:8083,
	  path:"/mqtt",
    protocol: "wss"
  },
  apiServer : {
    url: "https://api.xpower.nordnetic.dk/"
  }
};
