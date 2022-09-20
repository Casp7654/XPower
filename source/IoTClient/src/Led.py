from gpiozero import LED

class Led:
    def __init__(self, gpio : int) -> None:
        """Constructor for led"""
        self.set_gpio(gpio)

    def set_gpio(self, gpio : int) -> None:
        """Sets the gpio pin number and turns it off

        Args:
            gpio (int): The gpio pin number
        """
        if gpio < 0: return
        self.__pin = gpio
        self.__gpio = LED(gpio)
        self.__turned_on = False

    def get_pin(self) -> int:
        """
        Returns:
            int: The pin number.
        """
        return self.__pin

    def set_state(self, turn_on : bool) -> None:
        """Sets the state of the led to be turned on or not

        Args:
            turn_on (bool): The new state
        """
        if turn_on:
            self.__gpio.on()
        else:
            self.__gpio.off()

        self.__turned_on = turn_on

    def get_state(self) -> bool:
        """ Returns:
            bool: The current state of the led
        """
        return self.__turned_on
