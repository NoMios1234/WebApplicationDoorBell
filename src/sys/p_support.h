#include <SPIFFSEditor.h>
#include <sys/stream_support.h>
#include "esp_camera.h"
// Подключаем библиотеку для работы с HTTP-протоколом
#include <HTTPClient.h>

AsyncWebServer server(80);

#define FILE_PHOTO "/photo.jpg"
boolean takeNewPhoto = false;

void html_pages()
{
  p_index_html();
  page_update();
  title_update();
  menu_update();
  page_support();
  page_post();
  reboot_page();
  page_custom();
  getCapture();
  savePhoto();
}

void load_camera()
{
  // OV2640 camera module
  camera_config_t config;
  config.ledc_channel = LEDC_CHANNEL_0;
  config.ledc_timer = LEDC_TIMER_0;
  config.pin_d0 = Y2_GPIO_NUM;
  config.pin_d1 = Y3_GPIO_NUM;
  config.pin_d2 = Y4_GPIO_NUM;
  config.pin_d3 = Y5_GPIO_NUM;
  config.pin_d4 = Y6_GPIO_NUM;
  config.pin_d5 = Y7_GPIO_NUM;
  config.pin_d6 = Y8_GPIO_NUM;
  config.pin_d7 = Y9_GPIO_NUM;
  config.pin_xclk = XCLK_GPIO_NUM;
  config.pin_pclk = PCLK_GPIO_NUM;
  config.pin_vsync = VSYNC_GPIO_NUM;
  config.pin_href = HREF_GPIO_NUM;
  config.pin_sscb_sda = SIOD_GPIO_NUM;
  config.pin_sscb_scl = SIOC_GPIO_NUM;
  config.pin_pwdn = PWDN_GPIO_NUM;
  config.pin_reset = RESET_GPIO_NUM;
  config.xclk_freq_hz = 20000000;
  config.pixel_format = PIXFORMAT_JPEG;

  if (psramFound()) {
      config.frame_size = FRAMESIZE_UXGA;
      config.jpeg_quality = 10;
      config.fb_count = 2;
  } else {
      config.frame_size = FRAMESIZE_SVGA;
      config.jpeg_quality = 12;
      config.fb_count = 1;
  }
  // Camera init
  esp_err_t err = esp_camera_init(&config);
  if (err != ESP_OK) {
      Serial.printf("Camera init failed with error 0x%x", err);
      ESP.restart();
  }
}

// Check if photo capture was successful
bool checkPhoto( fs::FS &fs ) {
  File f_pic = fs.open( FILE_PHOTO );
  unsigned int pic_sz = f_pic.size();
  return ( pic_sz > 100 );
}

void capturePhotoSaveSpiffs( ) {
  camera_fb_t * fb = NULL; // pointer
  bool ok = 0; // Boolean indicating if the picture has been taken correctly

    do {
      // Take a photo with the camera
      Serial.println("Taking a photo...");

      fb = esp_camera_fb_get();
      if (!fb) {
        Serial.println("Camera capture failed");
        return;
      }

      // Photo file name
      Serial.printf("Picture file name: %s\n", FILE_PHOTO);
      File file = SPIFFS.open(FILE_PHOTO, FILE_WRITE);

      // Insert the data in the photo file
      if (!file) {
        Serial.println("Failed to open file in writing mode");
      }
      else {
        file.write(fb->buf, fb->len); // payload (image), payload length
        Serial.print("The picture has been saved in ");
        Serial.print(FILE_PHOTO);
        Serial.print(" - Size: ");
        Serial.print(file.size());
        Serial.println(" bytes");
      }
      // Close the file
      file.close();
      esp_camera_fb_return(fb);

      // check if file has been correctly saved in SPIFFS
      ok = checkPhoto(SPIFFS);
    } while ( !ok );

    /*
    HTTPClient http;

    String serverPath =  "http://" + WiFi.localIP().toString() + "/";
    Serial.println(serverPath);
    // Your Domain name with URL path or IP address with path
    http.begin(serverPath.c_str());

    // Send HTTP GET request
    int httpResponseCode = http.GET();
    if (httpResponseCode>0) {
      Serial.print("HTTP Response code: ");
      Serial.println(httpResponseCode);
      String payload = http.getString();
      Serial.println(payload);
    }
    else {
      Serial.print("Error code: ");
      Serial.println(httpResponseCode);
    }
    // Free resources
    http.end();*/
    //make_page(3);
}

void getCapture()
{
  server.on("/capture", HTTP_ANY, [](AsyncWebServerRequest * request) {
    capturePhotoSaveSpiffs();
    //request->send(200, F("text/plain"), "Фото сделано!");
    AsyncWebServerResponse *response = request->beginResponse_P(200, F("text/html"), template_default, template_default_len);
    response->addHeader(F("Content-Encoding"), F("gzip"));
    request->send(response);
  }); 
}

void savePhoto()
{
  server.on("/saved-photo", HTTP_ANY, [](AsyncWebServerRequest * request) {
    request->send(SPIFFS, FILE_PHOTO, "image/jpg", false);
  }); 
}

void page_update()
{
  server.on("/echo", HTTP_ANY, [](AsyncWebServerRequest *request) { // сюда JS стучится за данными для БЛАНКА
    int page = request->arg("p").toInt();
    current_page = page;
    DEBG(String(F("Page num: ")) + String(page));
    make_page(page); // Получение контента для страницы, по номеру страницы
    request->send(200, F("text/plain"), page_content);
    page_content = "";
    DEBG("RAM: " + String(ESP.getFreeHeap()));
  });
}

void title_update()
{
  server.on("/title", HTTP_ANY, [](AsyncWebServerRequest *request) { // сюда JS стучится за данными для БЛАНКА
    int page = request->arg("p").toInt();
    request->send(200, F("text/plain"), e_menu[page]);
  });
}

void menu_update()
{
  server.on("/menu", HTTP_ANY, [](AsyncWebServerRequest *request) { // сюда JS стучится за данными для БЛАНКА
    int page = request->arg("p").toInt();
    make_menu(page);
    request->send(200, F("text/plain"), menu_content);
    menu_content = "";
  });
}

void reboot_page()
{
  server.on("/reboot", HTTP_ANY, [](AsyncWebServerRequest *request) {
    request->send(200, F("text/plain"), "OK");
    save_flag = true;
    save_param();
    ESP.restart();
  });
}

void page_custom()
{
  server.on("/custom", HTTP_ANY, [](AsyncWebServerRequest *request) {
    int params = request->params();
    AsyncWebParameter *p;
    for (int i = 0; i < params; i++)
    {
      p = request->getParam(i);
      DEBG(String(p->name() + ": " + String(p->value())));
      if (p->name() == "play")
      {
        mp3_setup(p->value());
      }
        
      if (p->name() == "del")
      {
        SPIFFS.remove(p->value());
          AsyncWebServerResponse *response = request->beginResponse_P(200, F("text/html"), template_default, template_default_len);
          response->addHeader(F("Content-Encoding"), F("gzip"));
          request->send(response);
      }   
    }
    request->send(200, F("text/plain"), F("test!"));
  });
}

void page_post()
{
  server.on("/post", HTTP_ANY, [](AsyncWebServerRequest *request) {
    int params = request->params();
    AsyncWebParameter *p;
    for (int i = 0; i < params; i++)
    {
      p = request->getParam(i);
      write_param(p->name(), p->value());
      DEBG(String(p->name() + ": " + String(p->value())));
    }
    request->send(200, F("text/plain"), F("Настройки сохранены!"));
    save_flag = true;
    gpio_setup();
  });
}

void p_index_html()
{
  server.on("/", HTTP_ANY, [](AsyncWebServerRequest *request) {
    AsyncWebServerResponse *response = request->beginResponse_P(200, F("text/html"), template_default, template_default_len);
    response->addHeader(F("Content-Encoding"), F("gzip"));
    request->send(response);
  });
}

void handleUpload(AsyncWebServerRequest *request, String filename, size_t index, uint8_t *data, size_t len, bool final)
{
  struct uploadRequest
  {
    uploadRequest *next;
    AsyncWebServerRequest *request;
    File uploadFile;
    uint32_t fileSize;
    uploadRequest()
    {
      next = NULL;
      request = NULL;
      fileSize = 0;
    }
  };
  static uploadRequest uploadRequestHead;
  uploadRequest *thisUploadRequest = NULL;

  if (!index)
  {
    String toFile = filename;
    if (request->hasParam("dir", true))
    {
      AsyncWebParameter *p = request->getParam("dir", true);
      DBG_OUTPUT_PORT.println("dir param: " + p->value());
      toFile = p->value();
      if (!toFile.endsWith("/"))
        toFile += "/";
      toFile += filename;
    }
    if (!toFile.startsWith("/"))
      toFile = "/" + toFile;

    if (SPIFFS.exists(toFile))
      SPIFFS.remove(toFile);
    thisUploadRequest = new uploadRequest;
    thisUploadRequest->request = request;
    thisUploadRequest->next = uploadRequestHead.next;
    uploadRequestHead.next = thisUploadRequest;
    thisUploadRequest->uploadFile = SPIFFS.open(toFile, "w");
    DBG_OUTPUT_PORT.println("Upload: START, filename: " + toFile);
  }
  else
  {
    thisUploadRequest = uploadRequestHead.next;
    while (thisUploadRequest->request != request)
      thisUploadRequest = thisUploadRequest->next;
  }

  if (thisUploadRequest->uploadFile)
  {
    for (size_t i = 0; i < len; i++)
    {
      thisUploadRequest->uploadFile.write(data[i]);
    }
    thisUploadRequest->fileSize += len;
  }

  if (final)
  {
    thisUploadRequest->uploadFile.close();
    DBG_OUTPUT_PORT.print("Upload: END, Size: ");
    DBG_OUTPUT_PORT.println(thisUploadRequest->fileSize);
    uploadRequest *linkUploadRequest = &uploadRequestHead;
    while (linkUploadRequest->next != thisUploadRequest)
      linkUploadRequest = linkUploadRequest->next;
    linkUploadRequest->next = thisUploadRequest->next;
    delete thisUploadRequest;
    request->redirect("/");
  }
}

const char *http_username = "admin";
const char *http_password = "admin";

void page_support(){

  server.on("/css/bootstrap.min.css", HTTP_ANY, [](AsyncWebServerRequest *request) {
    AsyncWebServerResponse *response = request->beginResponse_P(200, F("text/plain"), bootstrap_css, bootstrap_css_len);
    response->addHeader(F("Content-Encoding"), F("gzip"));
    request->send(response);
  });

  server.on("/js/bubbly_bg.js", HTTP_GET, [](AsyncWebServerRequest *request) {
    AsyncWebServerResponse *response = request->beginResponse_P(200, F("application/javascript"), bubbly_bg_js, bubbly_bg_js_len);
    response->addHeader(F("Content-Encoding"), F("gzip"));
    request->send(response);
  });

  server.on("/images/logo.svg", HTTP_GET, [](AsyncWebServerRequest *request) {
    AsyncWebServerResponse *response = request->beginResponse_P(200, F("image/svg+xml"), logo_svg, logo_svg_len);
    response->addHeader(F("Content-Encoding"), F("gzip"));
    request->send(response);
  });

  server.on("/favicon.ico", HTTP_ANY, [](AsyncWebServerRequest *request) {
    AsyncWebServerResponse *response = request->beginResponse_P(200, F("image/svg+xml"), favicon, favicon_len);
    response->addHeader(F("Content-Encoding"), F("gzip"));
    request->send(response);
  });

  server.on("/upload", HTTP_POST, [](AsyncWebServerRequest *request) {
    request->send(200);
  },
            handleUpload);
  server.begin();
}