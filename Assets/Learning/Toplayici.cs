using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toplayici : MonoBehaviour
{
    //prefab tanımlandı
    [SerializeField]
    GameObject yildizPrefab;

    List<GameObject> yildizlar = new List<GameObject>();

    //uzay gemimiz bu bileşene toplanacak yıldızı soracak
    //Yazacağımız property ise buna karşılık bir dönüş yapacak

    /// <summary>
    ///  Hedefteki yıldızı söyler
    /// </summary>
    public GameObject HedefYildiz
    {
        get
        {
            if (yildizlar.Count > 0)
            {
                //toplamaya ilk yıldızdan başlayacağı için
                return yildizlar[0];
            }
            else
            {
                return null;
                //boş cevap dön
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Vector3 position = Input.mousePosition;
            position.z = -Camera.main.transform.position.z;
            Vector3 oyunDunyasiPozisyon = Camera.main.ScreenToWorldPoint(position);
            // yıldız spawn olur olmaz listeye eklencek
            yildizlar.Add(Instantiate(yildizPrefab, oyunDunyasiPozisyon, Quaternion.identity));
        }
        
    }
    /// <summary>
    /// Parametre olarak gönderilen yıldızı yokeder
    /// </summary>
    /// <param name="yokEdilecekYildiz"></param>
    public void YildizYokEt(GameObject yokEdilecekYildiz)
    {
        //yokedilcek yıldız listten çıkarılmalı
        yildizlar.Remove(yokEdilecekYildiz);
        Destroy(yokEdilecekYildiz);
    }
}
