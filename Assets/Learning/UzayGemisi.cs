using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UzayGemisi
{
    /// <summary>
    /// Geminin MAX hız limiti
    /// </summary>
    int maksimumHiz;
    //Public yapılırsa oyunun ortasında Max hız limitini kullanıcı iki katına çıkarabilir.


    /// <summary>
    /// Uzay Gemisinin rengi
    /// </summary>
    string renk;

    /// <summary>
    /// MAX Hız değerini döner
    /// </summary>
    public int MaksimumHiz
    {
        get { return maksimumHiz; }
    }

    /// <summary>
    /// Geminin rengini döner
    /// </summary>
    public string Renk
    {
        get { return renk; }
    }

    /// <summary>
    /// Max hız ve rengi yazınız
    /// </summary>
    /// <param name="maksimumHiz"></param>
    /// <param name="renk"></param>
    public UzayGemisi(int maksimumHiz, string renk)
    {
        //yukardaki süslü parantezdeki değişkenleri ilk belirlediğimiz fieldlara atamamız lazım.
        //this."Fieldlardaki değişken" = "Parametre olarak girilen değişken"
        this.maksimumHiz = maksimumHiz;
        this.renk = renk;
    }

    /// <summary>
    /// Max hız yazınız
    /// </summary>
    /// <param name="maksimumHiz"></param>
    public UzayGemisi(int maksimumHiz)
    {
        //Kullanıcının sadece uzay gemisi rengine bağlı olmadan bir uzay gemisi oluşturmak istedğini düşünelim
        //Bu durumda ya ilk constructorda bir default değer verilir.
        //örn: string renk = 'kırmızı'
        //Ya da bu şekilde ikinci bir constructor oluşturulur.
        this.maksimumHiz = maksimumHiz;
    }


    //class kullanıcıları tarafından (learning.cs) çağrılabilmesi için public
    /// <summary>
    /// Uzay gemisi hızlandırma
    /// </summary>
    public void Hizlandirici()
    {
        maksimumHiz += Random.Range(5, 20);
        Debug.Log("Hızlandıktan sonra: " + maksimumHiz);
    }

    /// <summary>
    /// Uzay gemisi yavaşlatma
    /// </summary>
    public void Yavaslatici()
    {
        maksimumHiz -= Random.Range(40, 80);
        Debug.Log("Yavaşladıktan sonra: " + maksimumHiz);
    }
}
