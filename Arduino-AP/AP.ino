#include <WiFi.h>


const char* ssid = "ESP32-AP";
const char* password = "123456789";

void setup() {
  Serial.begin(115200);

  WiFi.softAP(ssid, password);

  Serial.println("Punto de acceso configurado");
  Serial.print("IP del AP: ");
  Serial.println(WiFi.softAPIP());
}

void loop() {

}
