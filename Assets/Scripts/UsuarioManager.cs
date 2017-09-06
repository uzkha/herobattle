using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UsuarioManager : MonoBehaviour {


    public static UsuarioManager instance;    
    
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public string getUsuarioNome()
    {
        return PlayerPrefs.GetString("UsuarioNome"); ;
    }


    public int getUsuarioIdade()
    {
        return PlayerPrefs.GetInt("UsuarioIdade"); 
    }

    public void setUsuarioNome(string nome)
    {
        PlayerPrefs.SetString("UsuarioNome", nome);
    }

    public void setUsuarioIdade(int idade)
    {
        PlayerPrefs.SetInt("UsuarioIdade", idade);
    }

    public bool UsuarioExiste()
    {
        return PlayerPrefs.HasKey("UsuarioNome");
    }
}
