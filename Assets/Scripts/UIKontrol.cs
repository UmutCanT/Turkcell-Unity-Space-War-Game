using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Text classını tanıtmak için
using UnityEngine.UI;

public class UIKontrol : MonoBehaviour
{
    [SerializeField]
    GameObject oyunAdiText = default;

    [SerializeField]
    GameObject oyunBittiText = default;

    [SerializeField]
    Text puanText = default;

    [SerializeField]
    GameObject oynaButon = default;

    //Puanın kaydedilceği değişken
    int puan;


    // Start is called before the first frame update
    void Start()
    {
        //Oyun başladığında bu UI elementlerinin gözükmemesi için
        oyunBittiText.gameObject.SetActive(false);
        puanText.gameObject.SetActive(false);
    }

    public void OyunBasladi()
    {
        //Oyun bitip bidaha başlayınca puanda önceki değer gözükmektedir.
        puan = 0;
        oyunAdiText.gameObject.SetActive(false);
        oynaButon.gameObject.SetActive(false);
        //Oyun başlayınca puan sekmesinin görünür hale gelmesi
        puanText.gameObject.SetActive(true);
        //Oyun tekrar başlayınca start methodu çağrılmadığından
        //Oyun bitti yazısı ekrandan silinmez
        oyunBittiText.gameObject.SetActive(false);
        PuaniGuncelle();
    }

    public void OyunBitti()
    {
        oyunBittiText.gameObject.SetActive(true);
        oynaButon.gameObject.SetActive(true);
    }

    //Puan objesini text olarak tanımlanmasının nedeni 
    //Methodun içinde string gönderebiliriz
    void PuaniGuncelle()
    {
        //String türünde veri beklemektedir.
        //Ayrıca TOString methodunu kullanmaya gerek yok
        //Stringin arkasına + olarak yazdığımızdan otomatik olarak çeviri yapılıyor zaten
        puanText.text = "SCORE: " + puan;
    }

    /// <summary>
    /// Vurulan asteroide göre puanın değişmesini istiyoruz.
    /// </summary>
    /// <param name="asteroid"></param>
    public void AsteroidYokOldu(GameObject asteroid)
    {
        //Dikkat edilirse Stringler charların birleşiminden oluşan arraylerdir.
        //Asteroidlerimizde ilk 8 harf aynı 9. karakterde tiplerine göre numara verilmiştir.
        //Buna bakılarak farklı asteroidlere farklı puan düzenekleri sağlanabilir.
        //Index 0'dan başladığından 8. karaktere bakıyoruz.
        switch (asteroid.gameObject.name[8])
        {
            case '1':
                puan += 5;
                PuaniGuncelle();
                break;
            case '2':
                puan += 10;
                PuaniGuncelle();
                break;
            case '3':
                puan += 15;
                PuaniGuncelle();
                break;
            default:
                break;
        }
    }
}
