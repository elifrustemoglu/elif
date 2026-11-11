using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;
using EgitimPortali.Core;
using EgitimPortali.API.Services;
using Microsoft.Extensions.Logging.Abstractions;

namespace EgitimPortali.Tests
{
    public class EventServiceTests
    {
        private readonly ITestOutputHelper _output;

        public EventServiceTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public async Task EtkinlikAramaTesti()
        {
            var repository = new EventRepository();
            var logger = NullLogger<EventService>.Instance;
            var service = new EventService(repository, logger);

            var sonuc = await service.TumEtkinlikleriGetirAsync(
                search: "Git", categoryId: null, fromDate: null, toDate: null,
                sortBy: "date", sortOrder: "asc", page: 1, pageSize: 10);

            _output.WriteLine($"Toplam {sonuc.TotalRecords} etkinlik bulundu.");
            _output.WriteLine("--- Listelenen Etkinlikler ---");
            foreach (var etkinlik in sonuc.Data)
            {
                _output.WriteLine($"Başlık: {etkinlik.Title} | Kategori ID: {etkinlik.Id}");
            }

            Assert.NotNull(sonuc);
            Assert.Equal(1, sonuc.TotalRecords);
            Assert.Contains("Git", sonuc.Data[0].Title);
        }

        [Fact]
        public async Task EtkinlikArama_OlmayanKelimeGirilirse_BosListeDonmeli()
        {
            var repository = new EventRepository();
            var logger = NullLogger<EventService>.Instance;
            var service = new EventService(repository, logger);

            var sonuc = await service.TumEtkinlikleriGetirAsync(
                search: "xyz123",
                categoryId: null,
                fromDate: null,
                toDate: null,
                sortBy: "date",
                sortOrder: "asc",
                page: 1,
                pageSize: 10);

            _output.WriteLine("--- UÇ DURUM (EDGE CASE) TESTİ ---");
            _output.WriteLine("Aranan Kelime: 'xyz123'");
            _output.WriteLine($"Bulunan Toplam Kayıt: {sonuc.TotalRecords}");

            if (sonuc.Data.Count == 0)
            {
                _output.WriteLine("Sonuç: Sistem çökmedi ve beklendiği gibi boş liste döndü! ");
            }

            Assert.NotNull(sonuc);
            Assert.Empty(sonuc.Data);
            Assert.Equal(0, sonuc.TotalRecords);
        }

        [Fact]
        public async Task KategoriFiltresi_DogruCalismali()
        {
            var repository = new EventRepository();
            var logger = NullLogger<EventService>.Instance;
            var service = new EventService(repository, logger);

            var sonuc = await service.TumEtkinlikleriGetirAsync(
                search: null,
                categoryId: 1,
                fromDate: null,
                toDate: null,
                sortBy: "date",
                sortOrder: "asc",
                page: 1,
                pageSize: 10);

            _output.WriteLine("--- KATEGORİ FİLTRELEME TESTİ ---");
            _output.WriteLine($"Seçilen Kategori ID: 1");
            _output.WriteLine($"Bulunan Etkinlik Sayısı: {sonuc.TotalRecords}");
            foreach (var etkinlik in sonuc.Data)
            {
                _output.WriteLine($"- {etkinlik.Title} (Kategori: {etkinlik.Id})");
            }

            Assert.NotNull(sonuc);
            Assert.True(sonuc.TotalRecords > 0);
            Assert.All(sonuc.Data, e => Assert.Equal(1, e.Id));
        }
        [Fact]
        public async Task EtkinlikArama_TarihFiltresi_SadeceIlgiliTarihtekileriGetirmeli()
        {
            var repository = new EventRepository();
            var logger = NullLogger<EventService>.Instance;
            var service = new EventService(repository, logger);

            var bugun = DateTime.UtcNow;
            var ucGunSonrasi = bugun.AddDays(3);

            var sonuc = await service.TumEtkinlikleriGetirAsync(
                search: null,
                categoryId: null,
                fromDate: bugun,
                toDate: ucGunSonrasi,
                sortBy: "date",
                sortOrder: "asc",
                page: 1,
                pageSize: 10);

            _output.WriteLine("--- TARİH FİLTRELEME TESTİ ---");
            _output.WriteLine($"Filtre Aralığı: {bugun:dd.MM.yyyy} - {ucGunSonrasi:dd.MM.yyyy}");
            _output.WriteLine($"Bulunan Etkinlik Sayısı: {sonuc.TotalRecords}");
            foreach (var etkinlik in sonuc.Data)
            {
                _output.WriteLine($"- {etkinlik.Title} (Tarih: {etkinlik.StartDate:dd.MM.yyyy})");
            }

            Assert.NotNull(sonuc);
            Assert.Equal(1, sonuc.TotalRecords);
            Assert.All(sonuc.Data, e => Assert.True(e.StartDate >= bugun && e.StartDate <= ucGunSonrasi));
        }
    }
}