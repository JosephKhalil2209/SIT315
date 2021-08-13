//PIR sensor to LED light code
int ledPin = 13;
int inputPin = 2;
int pirState = LOW;
int val = 0;
int bledPin = 12;
int ldrPin = A0;
void setup()
{
    pinMode(ledPin, OUTPUT);//telling us that the led will turn on later on
    pinMode(inputPin, INPUT_PULLUP); //tells us that the sensor takes in data
    pinMode(bledPin, OUTPUT);
    pinMode(ldrPin, INPUT);
    attachInterrupt(digitalPinToInterrupt(inputPin), interruptChange, RISING);
    Serial.begin(9600); //Starting the serial monitor
}

void loop()
{
    digitalWrite(ledPin, val);
    int ldrStatus = analogRead(ldrPin);   //read the status of the LDR value

    //check if the LDR status is <= 300
    //if it is, the LED is HIGH

    if (ldrStatus <= 300)
    {

        digitalWrite(bledPin, HIGH);               //turn LED on
        Serial.println("It is dark in your Room, here is the light");

    }
    else
    {

        digitalWrite(bledPin, LOW);    //turn LED off
        Serial.println("Its tooooo bright, light off lets save power");
    }

    delay(5000);

}
//The code found in this interrupt tells us that when a person is
//sensed; the light goes on, then when sensed again the light goes off
void interruptChange()
{
    if (val == LOW)
    {
        val = HIGH;
        Serial.println("LIGHT IS BEING TURNED ON");
    }
    else
    {
        val = LOW;
        Serial.println("GOOD NIGHT, LIGHT IS TURNING OFF");
    }

}


