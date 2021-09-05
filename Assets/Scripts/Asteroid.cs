using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    //Patlama efekti için
    //Explosion prefabini editör içinde asteroidlerin üzerine ekliyoruz.
    [SerializeField]
    GameObject patlamaPrefab = default;

    //Instance oluşturuyoruz erişim için
    OyunKontrol oyunKontrol;

    // Start is called before the first frame update
    void Start()
    {
        //Bir kuvvet ekleyebilmemiz için rigidbody2d bileşenine ihtiyacımız var
        Rigidbody2D rb2d = GetComponent<Rigidbody2D>();
       
        //Main camera üzerinde olduğundan
        oyunKontrol = Camera.main.GetComponent<OyunKontrol>();

        // Asğaıya doğru farklı yöndlerde ve hızlarda hareket etmesini istiyoruz.
        float yon = Random.Range(0f, 1.0f);
        if(yon < 0.5)
        {
            rb2d.AddForce(new Vector2(Random.Range(-2.5f, -1f), Random.Range(-2.5f, -1f)), ForceMode2D.Impulse);
            //bir float değer bekliyor random olmasını istediğimizden yon değişkenini kullanabiliriz.
            rb2d.AddTorque(yon * 5f);
        }
        else
        {
            rb2d.AddForce(new Vector2(Random.Range(1f, 2.5f), Random.Range(-2.5f, -1f)), ForceMode2D.Impulse);
            //farklı yöne gittiğinden tersi biçimde dönmesini istiyoruz.
            rb2d.AddTorque(-yon * 5f);
        }
        
    }

    // Lazaerler asteroide çarpınca tetiklenmesi için

    /// <summary>
    /// Lazer değişkeni
    /// </summary>
    /// <param name="col"></param>
    void OnTriggerEnter2D(Collider2D col)
    {
        //Triggerlayan birden fazla obje olabilir kursun objesinin triggerladığından emin olmak için
        if(col.gameObject.tag == "Kursun")
        {
            //Asteroid yok olmadan önce çağırılmasını istiyoruz
            //tag kullandığımız için;
            GameObject.FindGameObjectWithTag("Audio").GetComponent<SesKontrol>().AsteroidPatlama();
            //Yokolan asteroidlerin kurşun onlara değdiğinde takibini yapmak mantıklı olacaktır.
            oyunKontrol.AsteroidYokOldu(gameObject);
            AsteroidYokEt();
        }
    }

    //Asteroidlerin hepsinin oyuncu kaybedince de yok olmasını istiyoruz.
    //Bu yüzden lazerle yokettiğimiz asteroidlerin yoketme işlemini ayrı methoda almak akıllıca olur
    //Çünkü iki farklı yerde kullanacağız
    public void AsteroidYokEt()
    {
        //Patlama efektinin asteroid üzerinde oluşması için
        Instantiate(patlamaPrefab, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

}
