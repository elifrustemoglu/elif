# ContactMessage Validation (400 Bad Request) Örnekleri

POST /api/contact-messages uç noktasına gönderilen geçersiz istekler ve API'nin döndürdüğü 400 Bad Request yanıtları aşağıda listelenmiştir:

--------------------------------------------------

1. ÖRNEK: Zorunlu Alanın Boş Bırakılması ([Required])

Gönderilen Hatalı İstek (Request Body):
{
  "fullName": "",
  "email": "ornek@mail.com",
  "subject": "Etkinlik Hakkında",
  "message": "Etkinlik katılım şartları hakkında bilgi almak istiyorum."
}

Dönen Yanıt (Response - 400 Bad Request):
{
  "type": "https://tools.ietf.org/html/rfc9110#section-15.5.1",
  "title": "One or more validation errors occurred.",
  "status": 400,
  "errors": {
    "FullName": [
      "Ad-Soyad alanı zorunludur."
    ]
  }
}

--------------------------------------------------

2. ÖRNEK: Geçersiz E-Posta Formatı ([EmailAddress])

Gönderilen Hatalı İstek (Request Body):
{
  "fullName": "Ahmet Yılmaz",
  "email": "gecersiz-email-adresi",
  "subject": "Kayıt Sorunu",
  "message": "Etkinliğe kayıt olurken sistemde hata alıyorum."
}

Dönen Yanıt (Response - 400 Bad Request):
{
  "type": "https://tools.ietf.org/html/rfc9110#section-15.5.1",
  "title": "One or more validation errors occurred.",
  "status": 400,
  "errors": {
    "Email": [
      "Geçerli bir email adresi giriniz."
    ]
  }
}

--------------------------------------------------

3. ÖRNEK: Minimum Karakter Sınırının Altında Kalması ([MinLength])

Gönderilen Hatalı İstek (Request Body):
{
  "fullName": "Ahmet Yılmaz",
  "email": "ahmet@mail.com",
  "subject": "Merhabalar",
  "message": "Kısa"
}

Dönen Yanıt (Response - 400 Bad Request):
{
  "type": "https://tools.ietf.org/html/rfc9110#section-15.5.1",
  "title": "One or more validation errors occurred.",
  "status": 400,
  "errors": {
    "Message": [
      "Mesaj alanı en az 10 karakter olmalıdır."
    ]
  }
}