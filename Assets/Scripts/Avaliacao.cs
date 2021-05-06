using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Avaliacao : MonoBehaviour {

    public Toggle tg;
    public string resposta1, resposta2, resposta3;
    public GameObject panel;
    public string url;
    public string s1;
    public string s2;
    public string s3;

    // Use this for initialization
    void Start()
    {
        resposta1 = "Não informado";
        resposta2 = "Não informado";
        resposta3 = "Não informado";

        SavePrefs1();
        SavePrefs2();
        SavePrefs3();

    }

    public void Toggle1()
    {
        resposta1 = tg.GetComponentInChildren<Text>().text;
        SavePrefs1();
    }

    public void Toggle2()
    {
        resposta2 = tg.GetComponentInChildren<Text>().text;
        SavePrefs2();

    }

    public void Toggle3()
    {
        resposta3 = tg.GetComponentInChildren<Text>().text;
        SavePrefs3();

    }


    public void Enviar()
    {
        //marca questionario como respondido
        PlayerPrefs.SetInt("Respondeu", 1);

        EnviarHttp();

        Destroy();

    }

    public void Destroy()
    {


        Destroy(panel.gameObject);
    }


    private void SavePrefs1()
    {
        PlayerPrefs.SetString("r1", resposta1);      
    }

    private void SavePrefs2()
    {
        PlayerPrefs.SetString("r2", resposta2);
    }

    private void SavePrefs3()
    {
        PlayerPrefs.SetString("r3", resposta3);
    }


    private void EnviarHttp()
    {
        s1 = PlayerPrefs.GetString("r1");
        s2 = PlayerPrefs.GetString("r2");
        s3 = PlayerPrefs.GetString("r3");

        url = "http://localhost/batalhadosherois/api/app?r1="+ s1 +"&r2=" + s2 + "&r3=" + s3;

        StartCoroutine(Http());
    }


    IEnumerator Http()
    {
        WWW www = new WWW(url);
        yield return www;
        /*Renderer renderer = GetComponent<Renderer>();
        renderer.material.mainTexture = www.texture;*/
    }
}
