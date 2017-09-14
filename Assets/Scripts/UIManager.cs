using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

    public static UIManager instance;

    [SerializeField]
    private Text pontosUI, user, txtTempo, txtCoinLevel;

    public bool iniciarTempo;
	public float auxTempo;
	private int auxTempoSound;

	[SerializeField]
	private GameObject panelWin, panelPause;

    private Image imgStar1, imgStar2, imgStar3;

    private bool pause;

    private Button pauseBtn, pauseBtnPanel;


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

        /*BuscarDados();
        SetarDados();*/

    }

    void BuscarDados()
    {
        pontosUI = GameObject.Find("Coin").GetComponent<Text>();
        user = GameObject.Find("User").GetComponent<Text>();
        txtCoinLevel = GameObject.Find("TXT-Coins-level").GetComponent<Text>();
		txtTempo = GameObject.Find("TXT-Tempo").GetComponent<Text>();

        imgStar1 = GameObject.Find("Img-Star1Fill").GetComponent<Image>();
        imgStar2 = GameObject.Find("Img-Star2Fill").GetComponent<Image>();
        imgStar3 = GameObject.Find("Img-Star3Fill").GetComponent<Image>();


        panelWin   = GameObject.Find("PanelWin");
        panelPause = GameObject.Find("PanelPause");

        pauseBtnPanel = GameObject.Find("BtnPausePanel").GetComponent<Button>();
        pauseBtn      = GameObject.Find("BtnPause").GetComponent<Button>();

        pauseBtn.onClick.AddListener(Pause);
        pauseBtnPanel.onClick.AddListener(Pause);

        LigaDesligaPanel ();

		auxTempo = 5f;
		auxTempoSound = 5;
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

    public void AtualizarCoinsLevel(int coin)
    {
        txtCoinLevel.text = coin.ToString();
    }

    // Use this for initialization
    void Start () {
       
        //iniciarTempo = true;
		BuscarDados();
		SetarDados();
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
				GameManager.instance.gameStarted = true; // para classe GameManager inciar a fase
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

	public void chamarPanelWin(){
		//canvas.SetActive (true);
		panelWin.SetActive (true);

	}


    public void Pause()
    {
        if (pause == false) {

            panelPause.SetActive(true);
            Time.timeScale = 0;
            pause = true;

        }
        else
        {
            panelPause.SetActive(false);
            Time.timeScale = 1;
            pause = false;
        }

    }




    public void setarStar(int star)
    {
        if(star == 1)
        {
            imgStar1.fillAmount = 1;
        }else if(star == 2)
        {
            imgStar2.fillAmount = 1;
        }else if (star == 3)
        {
            imgStar3.fillAmount = 1;
        }

    }

    private IEnumerator DestroiTemporizador()
    {
        yield return new WaitForSeconds(1f);
        Destroy(txtTempo.gameObject);
    }

	void LigaDesligaPanel()
	{
		StartCoroutine(tempo());
	}

	IEnumerator tempo()
	{
		yield return new WaitForSeconds(0.001f);
		panelWin.SetActive(false);
		panelPause.SetActive (false);

	}
}
