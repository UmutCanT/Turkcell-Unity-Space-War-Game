using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemiKontrol : MonoBehaviour
{
    //Geminin kurşun prefabini tanımasını istiyoruz.
    [SerializeField]
    GameObject kursunPrefab = default;

    //Patlama prefabini tanıtmak için
    [SerializeField]
    GameObject patlamaPrefab = default;

    const float hareketGucu = 10;

    //OyunKontrol Scriptini tanıtmak için
    OyunKontrol oyunKontrol;

    // Start is called before the first frame update
    void Start()
    {
        //Hangi objeya bağlıysa ordan çağrıyoruz.
        oyunKontrol = Camera.main.GetComponent<OyunKontrol>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;

        float yatayInput = Input.GetAxis("Horizontal");
        float dikeyInput = Input.GetAxis("Vertical");

        if (yatayInput != 0)
        {
            position.x += yatayInput * hareketGucu * Time.deltaTime;
            //deltaTimre her frame üzerinde hareketin gerçekleşmesini istediğimizden var
        }
        if (dikeyInput != 0)
        {
            position.y += dikeyInput * hareketGucu * Time.deltaTime;
        }

        transform.position = position;

        //Her Jump (Space) tuşuna basıldığında bu blok çalışacak
        if (Input.GetButtonDown("Jump"))
        {
            GameObject.FindGameObjectWithTag("Audio").GetComponent<SesKontrol>().Ates();
            //Lokasyon gerekmektedir. Kuşun uzay gemisinin konumunda spawn olcaktır.
            //Bu yüzden konumunu bir değişkene atamak gerekmektedir.
            //Bu scriptin ait olduğu objenin(Bu durumda uzay gemisi) kod bloğu çalıştığındaki konumu
            Vector3 kursunPozisyon = gameObject.transform.position;
            kursunPozisyon.y += 1;
            Instantiate(kursunPrefab, kursunPozisyon, Quaternion.identity);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Asteroid")
        {
            GameObject.FindGameObjectWithTag("Audio").GetComponent<SesKontrol>().GemiPatlama();
            oyunKontrol.OyunBitir();
            Instantiate(patlamaPrefab, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
