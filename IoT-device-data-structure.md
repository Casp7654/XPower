# Tech stack
The devices will communicate over sockets with the protocol mqtt v3.1.1

# Types
## Led
The IoT device will subscribe to /Led/*device_id* and /led/All
The published application is identified as Json

```Json
{
    "cmd": "on" // whether the led should be turned on or off.
}
```