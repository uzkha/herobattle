using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

    public UIManager instance;

    [SerializeField]
    private Text pontosUI, user;

    private void Awake()
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

        SceneManager.sceneLoaded += Carrega;

        BuscarDados();
        SetarDados();

    }

    void BuscarDados()
    {
        pontosUI = GameObject.Find("Coin").GetComponent<Text>();
        user = GameObject.Find("User").GetComponent<Text>();
    }


    void Carrega(Scene cena, LoadSceneMode modo)
    {

        BuscarDados();
        SetarDados();
    }

    void SetarDados()
    {
        pontosUI.text = "0";
        user.text = UsuarioManager.instance.getUsuarioNome();
    }

    void AtualizarCoins(int coin)
    {
        pontosUI.text = coin.ToString();
    }


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
