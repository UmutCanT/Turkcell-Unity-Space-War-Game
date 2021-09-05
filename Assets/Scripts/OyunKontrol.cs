using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OyunKontrol : MonoBehaviour
{
    //uzay Gemimizi tanıması için
    [SerializeField]
    GameObject uzayGemisiPrefab;

    //Birden fazla aynı türden game object için
    [SerializeField]
    List<GameObject> asteroidPrefabs = new List<GameObject>();

    //ürettiğimiz asteroidleri listede tutmak için
    List<GameObject> asteroidList = new List<GameObject>();

    //Spawnlama işlemini bir değişkene atıyoruz.
    //Diğer methodlarda da işimize yarayacağı için start içinde değilde
    //Burada yapıyoruz.
    GameObject uzayGemisi;

    //SerializeField ile her seferinde kod üzerinde değişiklik yapmadan 
    //Zorluk seviyesini editörden değiştirebiliriz.

    //Oyunun zorluğunu ayarlamak için değişken
    [SerializeField]
    int zorluk = 1;
    //Asteroidin üretimi için zorluk çarpanı
    [SerializeField]
    int carpan = 5;

    //UIKontrol Scriptini tanıması için
    UIKontrol uikontrol;

    // Start is called before the first frame update
    void Start()
    {
        //İki scriptde main camera üzerinde olduğundan direk getcomponent yazabilirim.
        uikontrol = GetComponent<UIKontrol>();
    }

    //Daha öne Start içinde bulunan kodları buraya alıyoruz.
    //Oyuna başlaya tıklayınva aktive olması için
     public void OyunuBaslat()
    {
        //Oyun başlayınca bu method çağrılacağından buraya UIKontrol içindeki methodu taşıyoruz.
        uikontrol.OyunBasladi();
        //uzay gemisi spawnlamak için
        uzayGemisi = Instantiate(uzayGemisiPrefab);
        //Konumunu belirlemek için
        uzayGemisi.transform.position = new Vector3(0, EkranHesaplayicisi.Alt + 1.5f);

        // Şimdilik 5 tane asteroid üretilmesini isteyelim
        AsteroidUret(5);
    }

    void AsteroidUret(int adet)
    {
        //her bir asteroidin konumu için position vektor oluşturuyoruz.
        Vector3 position = new Vector3();

        //Kaç tane asteroid üretmemizi söyleyen değişkenimiz var ondan for döngüsü kullanıyoruz
        for (int i = 0; i < adet; i++)
        {
            //Kamerayı refarans alarak oluşturuyoruz.
            position.z = -Camera.main.transform.position.z;
            //Bu değeri oyun dünyası kordinatlarına çevirelim
            position = Camera.main.ScreenToWorldPoint(position);
            //Ekranın solundan sağına doğru farklı yerlerde spawnlanmasını istediğimizden
            position.x = Random.Range(EkranHesaplayicisi.Sol, EkranHesaplayicisi.Sag);
            position.y = EkranHesaplayicisi.Ust - 1;

            // Artık belirtilen konumlarda asteroidimizi spawnlayabiliriz.
            // Bizim 3 farklı asteroidimiz var ondan bunların random spwanlanmasını istediğimizden
            //random.range kullanıyoruz.
            // Ayarladığımız pozisyonu ikinci parametre olarak koyuyoruz.
            // Son olarak rotasyonunda değişiklik istemediğimiz için Quaternion.identity
            GameObject asteroid = Instantiate(asteroidPrefabs[Random.Range(0, 3)], position, Quaternion.identity);

            // Şimdi bizim ekranda kaç tane asteroid olduğunu bilmemiz gerekiyor. 
            // Bunun için yine en başta List oluşturuyoruz.
            // Dikkat et prefab değil gameobject olarak sayıyı bilmemiz gerekiyor.
            asteroidList.Add(asteroid);
        }
    }

    //Yok olan asteroidlerin takibini yapmak için
    public void AsteroidYokOldu(GameObject asteroid)
    {
        //UIKontrol zaten bu scriptde tanımlanmıştı
        //Her asteroid yok olduğunda BUradan puanı güncellenebilir.
        uikontrol.AsteroidYokOldu(asteroid);
        // Yokedilen asteroidleri listin içinden çıkarmamız lazım
        asteroidList.Remove(asteroid);
        //Zorluk derecesini otomatik ayarlamak için
        if(asteroidList.Count <= zorluk)
        {
            zorluk++;
            AsteroidUret(zorluk * carpan);
        }
    }

    public void OyunBitir()
    {
        //Listedeki tüm elemanlar için aynı işlemi uyguluyoruz.
        foreach (GameObject asteroid in asteroidList)
        {
            asteroid.GetComponent<Asteroid>().AsteroidYokEt();
        }
        //Tüm asteroidler yokolduğundan listeyi boşaltıyoruz.
        asteroidList.Clear();
        //Oyun bitince zorluk değerini sıfırlamamız lazım
        zorluk = 1;
        //UIdaki değişiklikler
        uikontrol.OyunBitti();
    }
}
