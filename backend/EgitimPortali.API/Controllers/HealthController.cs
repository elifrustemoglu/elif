using Microsoft.AspNetCore.Mvc;
using System;

namespace staj_uygulamasi.Controllers
{
    [ApiController]
    [Route("api/health")]
    public class HealthController : ControllerBase
    {
       
        [HttpGet]
        public IActionResult GetHealth()
        {
            return Ok(new
            {
                Status = "Healthy",
                Project = "Eğitim ve Etkinlik Duyuru Portalı API",
                Timestamp = DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss")
            });
        }

      
        [HttpGet("hello")]
        public IActionResult GetHello()
        {
            return Ok(new
            {
                Message = "Merhaba! İlk Web API endpoint'i çalışıyor."
            });
        }
    }
}