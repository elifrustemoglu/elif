namespace EgitimPortali.Core;

public static class EtkinlikDurumYardımcısı
{
    public static string DurumEtiketiAl(DateTime etkinlikTarihi)
    {
        if (etkinlikTarihi >= DateTime.UtcNow)
        {
            return "Yaklaşan";
        }
        else
        {
            return "Geçmiş";
        }
    }
    public static string TarihiBicimlendir(DateTime etkinlikTarihi)
    {
        return etkinlikTarihi.ToString("dd.MM.yyyy HH:mm");
    }
}
