using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arkaplan : MonoBehaviour
{
    //Mesh randerer componentına dışardan ulaşmak istiyoruz.
    MeshRenderer meshRenderer;

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //offset.y değeri zamanla değişeceğinden update içine yazıyoruz
        //Her zaman artışında 0.1f kadar artan bir y değeri
        float y = 0.1f * Time.time;
        meshRenderer.material.SetTextureOffset("_MainTex", new Vector2(0, y));
    }
}
