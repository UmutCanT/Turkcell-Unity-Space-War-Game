using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Learning : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        UzayGemisi gemi1 = new UzayGemisi(Random.Range(80, 100));
        UzayGemisi gemi2 = new UzayGemisi(Random.Range(80, 100), "Gri");

        gemi1.Yavaslatici();
        gemi2.Yavaslatici();

        if(gemi1.MaksimumHiz > gemi2.MaksimumHiz)
        {
            Debug.Log("Kazanan Gemi1");
        }else if(gemi1.MaksimumHiz < gemi2.MaksimumHiz)
        {
            Debug.Log("Kazanan Gemi2");
        }
        else
        {
            Debug.Log("Berabere");
        }

        //int saldiranDusman = 10;
        //bool saldiriDevam = true;

        //while (saldiriDevam)
        //{
        //    saldiranDusman--;
        //    if(saldiranDusman < 3)
        //    {
        //        saldiriDevam = false;
        //    }
        //    Debug.Log("Saldırı altındayız. Düşman sayısı: " + saldiranDusman);
        //}

        //do
        //{
        //    saldiranDusman--;
        //    if (saldiranDusman < 3)
        //    {
        //        saldiriDevam = false;
        //    }
        //    Debug.Log("Saldırı altındayız. Düşman sayısı: " + saldiranDusman);
        //} while (saldiriDevam);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
