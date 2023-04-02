// Constants
const int bikePin = 8 ;     // Pin attached to bike's magnetic reed switch

// Setup and attaching an interrup
void setup() {
  pinMode(bikePin, INPUT_PULLUP);
  attachInterrupt(digitalPinToInterrupt(bikePin),push,FALLING);
  Serial.begin(9600);
}

// Heartbeat for serialport
void loop() {
  Serial.write((byte)0x00);
  Serial.flush();
  delay(10000);
}

// Function ran on each cycle of bike
void push()
{
  Serial.write("A");
  Serial.flush();
  delay(5);
}
