using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EkranHesaplayicisi
{
    static float sol;
    static float sag;
    static float ust;
    static float alt;

    /// <summary>
    /// Ekranın sol kısmının koordinatlarını verir
    /// </summary>
    public static float Sol
    {
        get
        {
            return sol;
        }
    }

    /// <summary>
    /// Ekranın sağ kısmının koordinatlarını verir
    /// </summary>
    public static float Sag
    {
        get
        {
            return sag;
        }
    }

    /// <summary>
    /// Ekranın üst kısmının koordinatlarını verir
    /// </summary>
    public static float Ust
    {
        get
        {
            return ust;
        }
    }

    /// <summary>
    /// Ekranın sol kısmının koordinatlarını verir
    /// </summary>
    public static float Alt
    {
        get
        {
            return alt;
        }
    }
    // static bir class olduğu için herhangi bir oyun objesine atamamıza gerek yok 
    //sadece bir tetikleyici gerekmektedir.
    public static void Init()
    {
        float ekranZekseni = -Camera.main.transform.position.z;
        Vector3 solAltKose = new Vector3(0, 0, ekranZekseni);
        Vector3 sagUstKose = new Vector3(Screen.width, Screen.height, ekranZekseni);
        //ekranın solt alt köşesinin 0,0 olduğu kesin ama sağ üst köşesini hangi ekranda 
        //açacağını bilmedğimizden ekran değerlerini almamız lazım.

        //Yukardakiler pixel olarak ekran değerleri bir de bize oyun dünyası değerleri lazım
        Vector3 solAltKoseOyunDunyasi = Camera.main.ScreenToWorldPoint(solAltKose);
        Vector3 sagUstKoseOyunDunyasi = Camera.main.ScreenToWorldPoint(sagUstKose);

        //bu değerleri oluşturduğumuz değişkenlere atayalım
        sol = solAltKoseOyunDunyasi.x;
        sag = sagUstKoseOyunDunyasi.x;
        ust = sagUstKoseOyunDunyasi.y;
        alt = solAltKoseOyunDunyasi.y;
    }
}
