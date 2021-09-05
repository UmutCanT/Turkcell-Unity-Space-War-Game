using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SiraliYokEdici : MonoBehaviour
{
    [SerializeField]
    GameObject asteroidPrefab;

    //ikinci olarak geminin konum bilgisine ihtiyacımız var
    GameObject uzayGemisi;

    List<GameObject> asteroidList;

    //sıralı yokedici sistemde her seferinde hedefte bir obje olmalı
    GameObject hedefAsteroid;

    // Start is called before the first frame update
    void Start()
    {
        //tagi kullanıyoruz
        uzayGemisi = GameObject.FindGameObjectWithTag("Player");
        asteroidList = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //mouse pozisyonunu alalım
            Vector3 position = Input.mousePosition;
            position.z = -Camera.main.transform.position.z;
            position = Camera.main.ScreenToWorldPoint(position);

            //Değişkene alarak spawnlamak için
            GameObject asteroid = Instantiate(asteroidPrefab, position, Quaternion.identity);
            //objeyi varettikten sonra listin içine kaydedelim
            asteroidList.Add(asteroid);
        }

        if (Input.GetMouseButtonDown(1))
        {
            HedefiYokEt();
        }
    }
    /// <summary>
    /// En yakın asteroidi obje olarak döndürüyoruz.
    /// </summary>
    /// <returns></returns>
    GameObject EnYakinAsteroid()
    {
        GameObject enYakinAsteroid;
        float enYakinMesafe;

        if(asteroidList.Count == 0)
        {
            return null;
        }else
        {
            enYakinAsteroid = asteroidList[0];
            enYakinMesafe = MesafeOlcer(enYakinAsteroid); 
        }
        //bu iki koddaki mantık  ilk önlistedeki bir asteroidi en yakın kabul ediyoruz.
        //sonrasında ise foreach ile liste içindeki her asteroid ile karşılaştırıyoruz.
        //bunun sonucunda en yakın asteroidi buluyoruz. Sorting 

        foreach (GameObject asteroid in asteroidList)
        {
            float mesafe = MesafeOlcer(asteroid);
            if(mesafe < enYakinMesafe)
            {
                enYakinMesafe = mesafe;
                enYakinAsteroid = asteroid;
            }
        }

        return enYakinAsteroid;
    }



    //public yapıldı çünkü ilk asteroid yokedilten sonra
    //sıralı şekilde yoketme devam edilmesi için bu method dışarıdan çağırılcak
    public void HedefiYokEt()
    {
        hedefAsteroid = EnYakinAsteroid();
        if(hedefAsteroid != null)
        {
            //yokEdici classı içerisindeki public methodunu çağırdık
            hedefAsteroid.GetComponent<YokEdici>().AsteroidYokEdici(1);
            asteroidList.Remove(hedefAsteroid);
        }
    }

    //uzay gemisi ile hedef arasındaki mesafeyi aldık
    float MesafeOlcer(GameObject hedef)
    {
        return Vector3.Distance(uzayGemisi.transform.position, hedef.transform.position);
    }
}

