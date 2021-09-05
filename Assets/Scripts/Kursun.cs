using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kursun : MonoBehaviour
{
    //Ilk olarak gerisayimsayacina erişmek için bir obje oluşturalım
    GeriSayimSayaci geriSayimSayaci;

    // Start is called before the first frame update
    void Start()
    {
        // Tek işlem yapılacağından referansını almıyoruz
        GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 10), ForceMode2D.Impulse);
        //Gerisayimsayacinı kullanmak için
        geriSayimSayaci = gameObject.AddComponent<GeriSayimSayaci>();
        geriSayimSayaci.ToplamSure = 3;
        geriSayimSayaci.Calistir();

    }

    // Update is called once per frame
    void Update()
    {
        //Bu bölüm içerisinde geri sayım bitince objeyi yoketmemiz lazım
        if (geriSayimSayaci.Bitti)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Asteroid")
        {
            Destroy(gameObject);
        }
    }
}
