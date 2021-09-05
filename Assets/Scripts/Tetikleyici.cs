using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tetikleyici : MonoBehaviour
{
    // Awake startdan da önce çağırılır aynı bu şekilde initiate 
    //işlemlerini hesaplamak için kullanılır
    void Awake()
    {
        EkranHesaplayicisi.Init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
