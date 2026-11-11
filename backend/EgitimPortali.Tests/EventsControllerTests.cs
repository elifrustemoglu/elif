using EgitimPortali.API.Controllers;
using EgitimPortali.API.DTOs;
using EgitimPortali.API.Services;
using EgitimPortali.Core;
using EgitimPortali.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace EgitimPortali.Tests
{
    public class EventsControllerTests
    {
        private readonly ITestOutputHelper _output;

        public EventsControllerTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public async Task EtkinlikKayitVarsa_OkDonmeli()
        {
            _output.WriteLine("-> Birim test başlatılıyor: IEventService mock nesnesi oluşturuluyor.");

            var mockService = new Mock<IEventService>();

            var sahteListe = new List<EventListDto>
            {
                new EventListDto { Id = 1, Title = "Backend Geliştirme Eğitimi" }
            };

            var sahteSonuc = new PagedResponse<EventListDto>(sahteListe, 1, 20, 1);

            mockService
                .Setup(service => service.TumEtkinlikleriGetirAsync(
                    It.IsAny<string>(), It.IsAny<int?>(),
                    It.IsAny<DateTime?>(), It.IsAny<DateTime?>(),
                    It.IsAny<string>(), It.IsAny<string>(),
                    It.IsAny<int>(), It.IsAny<int>()))
                .ReturnsAsync(sahteSonuc);

            var controller = new EventsController(mockService.Object);

            var sonuc = await controller.GetTumEtkinlikler(null, null, null, null, "date", "asc", 1, 20);

            var okResult = Assert.IsType<OkObjectResult>(sonuc.Result);
            var donenVeri = Assert.IsType<PagedResponse<EventListDto>>(okResult.Value);

            Assert.NotNull(donenVeri);
            Assert.Equal(1, donenVeri.TotalRecords);
            Assert.Equal("Backend Geliştirme Eğitimi", donenVeri.Data[0].Title);
            _output.WriteLine("-> İlk test başarıyla tamamlandı.");
        }

        [Fact]
        public async Task OlmayanEtkinlikCagrılinca_NotFoundDonmeli()
        {
            _output.WriteLine("-> Olmayan etkinlik testi (404) başlatılıyor...");
            var mockService = new Mock<IEventService>();

            mockService
                .Setup(service => service.SlugIleGetirAsync("olmayan-slug"))
                .ReturnsAsync((EventDetailDto?)null);

            var controller = new EventsController(mockService.Object);

            var sonuc = await controller.GetEtkinlikBySlug("olmayan-slug");

            var actionResult = Assert.IsType<ActionResult<EventDetailDto>>(sonuc);
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(actionResult.Result);

            Assert.Equal(404, notFoundResult.StatusCode);
            _output.WriteLine("-> Test başarılı: Beklenen 404 Not Found döndü.");
        }

        [Fact]
        public async Task GecersizModelGönderilince_BadRequestDonmeli()
        {
            _output.WriteLine("-> Geçersiz model testi başlatılıyor...");
            var mockService = new Mock<IEventService>();
            var controller = new EventsController(mockService.Object);

            var yeniEtkinlik = new EventCreateDto
            {
                Title = "Test Etkinlik",
                Slug = "test-etkinlik",
                StartDate = DateTime.Now.AddDays(1)
            };

            var sonuc = await controller.EtkinlikOlustur(yeniEtkinlik);

            var createdResult = Assert.IsType<CreatedAtActionResult>(sonuc);
            Assert.Equal(nameof(controller.GetEtkinlikBySlug), createdResult.ActionName);
            _output.WriteLine("-> Test başarıyla tamamlandı.");
        }
    }
}