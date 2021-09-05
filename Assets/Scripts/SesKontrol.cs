using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SesKontrol : MonoBehaviour
{
    //Unity ses dosyaları için AudioClip Classını kullanır.
    [SerializeField]
    AudioClip asteroidPatlama = default;

    [SerializeField]
    AudioClip gemiPatlama = default;

    [SerializeField]
    AudioClip ates = default;

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    //Bu fonksiyonları ilgili scriptlerde tanınır hale getirip orada çağırmamız gerek


    public void AsteroidPatlama()
    {
        //Asteroid patladığı (çağırıldığı) zaman sadece bir kez çalıcak
        audioSource.PlayOneShot(asteroidPatlama, 0.3f);
    }

    public void GemiPatlama()
    {
        //Gemi patladığı (çağırıldığı) zaman sadece bir kez çalıcak
        audioSource.PlayOneShot(gemiPatlama);
    }

    public void Ates()
    {
        //Lazerler ateşlendiğinde çalınacak
        //İkinci parametreye değer girilerek ses kısılabilir
        audioSource.PlayOneShot(ates, 0.2f);
    }
}
