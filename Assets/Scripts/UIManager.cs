using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

    public static UIManager instance;

    [SerializeField]
    private Text pontosUI, user, txtTempo;

    public bool iniciarTempo;
    public float auxTempo = 5f;
    private int auxTempoSound = 5;


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

    public void AtualizarCoins(int coin)
    {
        pontosUI.text = coin.ToString();
    }


    // Use this for initialization
    void Start () {
        txtTempo = GameObject.Find("TXT-Tempo").GetComponent<Text>();
        iniciarTempo = true;
    }
	
	// Update is called once per frame
	void Update () {

        //carrega contagem de tempo para inicio do jogo
        if (iniciarTempo == true && auxTempo > 0)
        {   

            auxTempo -= Time.deltaTime;            

            if(auxTempo < 1)
            {
                iniciarTempo = false;
                GameManager.instance.gameStart = true; // para classe GameManager inciar a fase
                txtTempo.text = "Começar";

                StartCoroutine(DestroiTemporizador());

            }
            else
            {
                
                txtTempo.text = auxTempo.ToString("0");
            }

            if (auxTempoSound !=  (int) auxTempo)
            {
                AudioManager.instance.SonsFXToca(2);
                auxTempoSound = (int)auxTempo;
            }
          

        }
		
	}


    private IEnumerator DestroiTemporizador()
    {
        yield return new WaitForSeconds(1f);
        Destroy(txtTempo.gameObject);
    }
}
