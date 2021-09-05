using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HareketKontrol : MonoBehaviour
{
    //Yarım olmasının sebebi mause imlecinin ortada olması 
    float colliderBoyYarim;
    float colliderEnYarim;

    // Start is called before the first frame update
    void Start()
    {
        //bir objeyi random hızla hareket ettirir
        GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-5, 5), Random.Range(-5, 5)), ForceMode2D.Impulse);
        //hitboxun ölçülerini almak
        BoxCollider2D collider = GetComponent<BoxCollider2D>();
        colliderBoyYarim = collider.size.y / 2;
        colliderEnYarim = collider.size.x / 2;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("obaaa");
    }

    // Update is called once per frame
    void Update()
    {
        // Asteroid mause imlecini takip etsin
        //Vector3 position = Input.mousePosition;
        //position.z = -Camera.main.transform.position.z;
        //position = Camera.main.ScreenToWorldPoint(position);

        //transform.position = position;
        //EkrandaKal();
    }

    //objenin ekranda kalmasını sağla
    void EkrandaKal()
    {
        Vector3 position = transform.position;
        if(position.x - colliderEnYarim < EkranHesaplayicisi.Sol)
        {
            position.x = EkranHesaplayicisi.Sol + colliderEnYarim;
        }else if(position.x + colliderEnYarim > EkranHesaplayicisi.Sag)
        {
            position.x = EkranHesaplayicisi.Sag - colliderEnYarim; 
        }
        if (position.y + colliderBoyYarim > EkranHesaplayicisi.Ust)
        {
            position.y = EkranHesaplayicisi.Ust - colliderEnYarim;
        }
        else if(position.y - colliderBoyYarim < EkranHesaplayicisi.Alt)
        {
            position.y = EkranHesaplayicisi.Alt + colliderBoyYarim;
        }           
        transform.position = position;
    }
}
