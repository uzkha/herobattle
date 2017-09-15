using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectUrl : MonoBehaviour {

    void start()
    {
        StartCoroutine(Start());
    }

    public string url = "http://images.earthcam.com/ec_metros/ourcams/fridays.jpg";
    IEnumerator Start()
    {
        WWW www = new WWW(url);
        yield return www;
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.mainTexture = www.texture;
    }
}
