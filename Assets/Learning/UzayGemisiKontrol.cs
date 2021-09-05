using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UzayGemisiKontrol : MonoBehaviour
{
    const float hareketGucu = 5;

    //uzay gemisi toplama işlemine başladı ise hedefteki yıldız değişmeden
    //başka bir yıldıza gitmemeli bunu kontrol etmeliyiz.
    //toplama işlemi başladıktan sonra gemiye bir kez daha tıklasak bile
    //hedeften şaşmıcak
    bool topluyor = false;

    //hedefteki objeyi kontrol edebilmey için
    GameObject hedef;

    //fizik kuralları etki etmesi lazım
    Rigidbody2D myRigidbody2D;

    //toplayici classından
    Toplayici toplayici;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        toplayici = Camera.main.GetComponent<Toplayici>();
    }

    void OnMouseDown()
    {
        if(!topluyor)
        {
            GitVeTopla();
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        //gidilen yıldız hedefteki yıldız mı?
        if(other.gameObject == hedef)
        {
            toplayici.YildizYokEt(hedef);
            myRigidbody2D.velocity = Vector2.zero;
            GitVeTopla();
        }
    }

    void GitVeTopla()
    {
        hedef = toplayici.HedefYildiz;
        //Toplayici yıldız yok ise null değikeni döndürüyodu
        if(hedef != null)
        {
            //gidilecek yeri bulmak için aradaki uzaklığı hesaplamak lazım
            Vector2 gidilecekYer = new Vector2(hedef.transform.position.x 
                - transform.position.x, hedef.transform.position.y - transform.position.y);

            //iki notayı birleştirmek için normalini almak gerekmektedir.
            gidilecekYer.Normalize();
            //gidilecek yer belli olduktan sonra kuvvet eklemek gerekiyor
            myRigidbody2D.AddForce(gidilecekYer * hareketGucu, ForceMode2D.Impulse);

        }
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 position = transform.position;

        //float yatayInput = Input.GetAxis("Horizontal");
        //float dikeyInput = Input.GetAxis("Vertical");

        //if(yatayInput != 0)
        //{
        //    position.x += yatayInput * hareketGucu * Time.deltaTime;
        //    //deltaTimre her frame üzerinde hareketin gerçekleşmesini istediğimizden var
        //}
        //if(dikeyInput != 0)
        //{
        //    position.y += dikeyInput * hareketGucu * Time.deltaTime;
        //}

        //transform.position = position;
    }
}
