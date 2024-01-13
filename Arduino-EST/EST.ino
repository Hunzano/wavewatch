#include <WiFi.h>
#include <HTTPClient.h>

const char* ssid = "ESP32-AP";
const char* password = "123456789";

const char* serverName = "http://192.168.4.3:7207/Esp32Data";

// Reemplaza con los valores que desees enviar
int rssi = 0;
String esp32MacAddress = WiFi.macAddress();
String wifiSsid = "ESP32-AP";

void setup() {
  Serial.begin(115200);
  
  // Conectar a WiFi
  WiFi.begin(ssid, password);
  while (WiFi.status() != WL_CONNECTED) {
    delay(500);
    Serial.println("Conectando a WiFi...");
  }
  Serial.println("Conectado a WiFi");
}

void loop() {
  // Obtener RSSI de la red WiFi
  rssi = WiFi.RSSI();

  if(WiFi.status() == WL_CONNECTED){
    HTTPClient http;

    http.begin(serverName);
    http.addHeader("Content-Type", "application/json");

    // Formatear los datos en JSON
    String httpRequestData = "{\"Rssi\":" + String(rssi) + ",\"Esp32MacAddress\":\"" + esp32MacAddress + "\",\"WifiSsid\":\"" + wifiSsid + "\"}";
    Serial.print("Enviando datos: ");
    Serial.println(httpRequestData);

    // Enviar solicitud POST
    int httpResponseCode = http.POST(httpRequestData);

    if (httpResponseCode > 0) {
      String response = http.getString();
      Serial.println(httpResponseCode);
      Serial.println(response);
    }
    else {
      Serial.print("Error en HTTP Request: ");
      Serial.println(httpResponseCode);
    }

    http.end();
  }
  else {
    Serial.println("Error en la conexión WiFi");
  }

  delay(500); 
}

