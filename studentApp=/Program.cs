
using System.Threading.Channels;

List<Ogrenci> ogrenciler = new List<Ogrenci>(); // Yeni bir öğrenci listesi oluşturuluyor.
while (true) // Sonsuz bir döngü olarak yapılandırılmış. "Çıkış yap" seçeneğini seçene kadar sürekli tekrar eder.
{
    Console.Clear(); // Komut ekranı temizler ve temiz bir menü gösterir.
    Console.WriteLine("Öğrenci Tönetim Uygulaması"); // Console. WriteLine komutları ile ana menü seçenekleri ekrana yazdırılır.
    Console.WriteLine("1-Öğrenci Ekle");
    Console.WriteLine("2-Öğrenci Güncell");
    Console.WriteLine("3-Öğrenci Sil");
    Console.WriteLine("4-Öğrencileri Listele");
    Console.WriteLine("5-Çıkış Yap");
    Console.Write("Seçimini Yap: "); // Kullanıcıdan bir seçim yapması istenir ve seçim değeri (secim) olarak kaydedilir.
    int secim = int.Parse(Console.ReadLine());

    switch (secim) // Kullanıcının yaptığın seçime göre ilgili metot çağrılır. Örneğin kullanıcı 1'i seçerse "OğrenciEkle(oğrenciler);" metodu çalışır ve yeni bir öğrenci eklenir.
    {
        case 1:
            OgrenciEkle(ogrenciler);
            break;

        case 2:
            OgrenciGuncelle(ogrenciler);
            break;

        case 3:
            OgrenciSil(ogrenciler);
            break;

        case 4:
            OgrencileriListele(ogrenciler);
            break;

        case 5:
            Console.WriteLine("Çıkış Yapılıyor..."); // Bu seçenek ile programdan çıkılır.
            return;

        default:
            Console.WriteLine("Geçersiz Seçim!");
            break;
    }
    Console.WriteLine("Devam etmek için bir tuşa basın.");
    Console.ReadKey();
}

static void OgrenciEkle(List<Ogrenci> ogrenciler) // Bu metot, kullanıcıdan yeni bir öğrencinin blgilerini alıp, bu bilgileri listeye eklemek için kullanılır.
{
    Console.Write("Öğrenci Numarası: "); // Kullanıcıdan öğrenci numarası, adı, soyadı ve yaşı bilgileri istenir.
    int numara = int.Parse(Console.ReadLine());
    Console.Write("Öğrenci Adı: ");
    string ad = Console.ReadLine();
    Console.Write("Öğrenci Soyadı: ");
    string soyad = Console.ReadLine();
    Console.Write("Öğrenci Yaşı: ");
    int yas = int.Parse(Console.ReadLine());

    ogrenciler.Add(new Ogrenci { Numara = numara, Ad = ad, Soyad = soyad, Yas = yas }); // Yeni bir "Ogrenci" nesnesi oluşturulur.
    Console.WriteLine("Öğrenci başarıyla eklendi.");
}
static void OgrenciGuncelle(List<Ogrenci> ogrenciler) // Bu metot, mevcut bir öğrencinin bilgilerini gğncellemek için kullanılır.
{
    Console.WriteLine("Güncellemek istediğiniz öğrencinin numarasını giriniz: "); // Kullanıcıdan güncellemek istediği öğrencinin numarasını sorar.
    int numara = int.Parse(Console.ReadLine());

    Ogrenci ogrenci = ogrenciler.Find(o => o.Numara == numara); // Find metodu ile listeden bu numaraya sahip olan öğrenci bulunur.
    if (ogrenci != null)                                   // Eğer öğrenci bulunursa kullanıcıdan yeni ad, soyad ve yaş bilgileri alınır ve bu bilgilerle öğrenci güncellenir.
    {
        Console.WriteLine("Yeni Adı: ");
        ogrenci.Ad = Console.ReadLine();
        Console.WriteLine("Yeni Soyadı: ");
        ogrenci.Soyad = Console.ReadLine();
        Console.WriteLine("Yeni Yaşı: ");
        ogrenci.Yas = int.Parse(Console.ReadLine());
        if (true)
        {
            string deger = "Öğrenci Bilgileri Başarıyla Güncellenmiştir."; //Öğrenci bilgileri başarıyla güncellenirse, kullanıcıya bu durum bildirilir.
            Console.WriteLine(deger);
        }
    }
    else
        Console.WriteLine("Öğrenci bulunamadı."); // Eğer belirtilen numaraya sahip bir öğrenci yoksa, "Öğrenci bulunamadı" mesajı verilir.
}
static void OgrenciSil(List<Ogrenci> ogrenciler) // Bu metot öğrenciyi  silmek için kullanılır.
{
    Console.WriteLine("Silmek istediğiniz öğrencinin numarasını giriniz: "); // Kullanıcıdan numara al.
    int numara = int.Parse(Console.ReadLine());

    Ogrenci ogrenci = ogrenciler.Find(o => o.Numara == numara); // Find metodu ile öğrenciler listesinden bu numaraya sahip olan öğrenciyi buluyor.
    if (numara != null)     // Eğer öğrenci bulunmuşsa remove metodu ile öğrenci listeden siliniyor ve kullanıcıya silme işleminin başarılı olduğu bildiriliyor.
    {
        ogrenciler.Remove(ogrenci);
        Console.WriteLine("Öğrenci başarıyla silinmiştir.");
    }
    else Console.WriteLine("Öğrenci bulunamadı"); // Eğer öğrenci bulunmazsa, kullanıcıya "Öğrenci bulunamadı" mesajı veriliyor.
}
static void OgrencileriListele(List<Ogrenci> ogrenciler) // Bu metot, öğrenci listesindeki tüm öğrencilerin bilgilerini ekrana yazdırmak için kullanılır.
{
    Console.WriteLine("Öğrenci Listesi:"); // Önce "Öğrenci Listesi" başlığını ekrana yazdırır.
    foreach (Ogrenci o in ogrenciler) // foreach döngüsü ile listedeki her bir öğrenci için, öğrenci bilgilerini ekrana yazar.
        Console.WriteLine($"Ad: {o.Ad} \nSoyad: {o.Soyad} \nYaş {o.Yas} \nNumara: {o.Numara}");
}


/* 1.Soru : Bu projede, öğrenci sınıfı öğrencilerin bilgilerini tutmak amacıyla kullanılmış. 
Her bir öğrenciye ait olan numara, ad, soyad ve yaş gibi bilgiler bu sınıfın içinde yer alır.*/
