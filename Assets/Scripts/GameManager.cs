using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance;
    public bool gameStarted;
    public bool gameEnd;
    public int pontos;
    public int pontosLevel;
    public int pontosAux;
    private int star;

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

		gameStart ();
    }

	void gameStart(){
		
		ScoreManager.instance.GameStartScoreM();

		//level 1 sai liberado
		PlayerPrefs.SetInt("Level1", 1);

		UIManager.instance.iniciarTempo = true;

	}

    // Use this for initialization
    void Start() {
		gameStart ();
    }

    // Update is called once per frame
    void Update() {

        if (gameEnd == true)
        {
            contarPontosLevel();
        }


        if (Input.GetKeyUp(KeyCode.Escape))
        {
            SceneManager.LoadScene(7);
        }

    }

    void contarPontosLevel()
    {
        pontos = pontos - 5;
        pontosLevel += 5;

        AudioManager.instance.SonsFXToca(3);

        if (pontos < 0)
        {
            pontos = 0;
        }

        if (pontosLevel > pontosAux)
        {
            pontosLevel = pontosAux;
        }

        UIManager.instance.AtualizarCoins(pontos);
        UIManager.instance.AtualizarCoinsLevel(pontosLevel);

        if (pontos <= 0)
        {
            gameEnd = false;

            if (pontosAux < 1400)
            {
                AudioManager.instance.SonsFXToca(6);
                UIManager.instance.setarStar(1);
                star = 1;

            }
            else if (pontosAux >= 1400 && pontosAux <= 2000)
            {
                AudioManager.instance.SonsFXToca(6);
                UIManager.instance.setarStar(1);
                AudioManager.instance.SonsFXToca(6);
                UIManager.instance.setarStar(2);
                star = 2;
            }
            else if (pontosAux > 2000)
            {
                AudioManager.instance.SonsFXToca(6);
                UIManager.instance.setarStar(1);
                AudioManager.instance.SonsFXToca(6);
                UIManager.instance.setarStar(2);
                AudioManager.instance.SonsFXToca(6);
                UIManager.instance.setarStar(3);
                star = 3;
            }

            atualizarMoedasPlayer();
            atualizarLevel();

            //libera botoes
            PanelWinButtons.ativarBotao = true;
        }

    }

    void atualizarLevel()
    {

        if (PlayerPrefs.HasKey("Level" + GetCena.instance.getCenaIndex() + "star"))
        {
            int auxStar = PlayerPrefs.GetInt("Level" + GetCena.instance.getCenaIndex() + "star");

            if (star > auxStar)
            {
                PlayerPrefs.SetInt("Level" + GetCena.instance.getCenaIndex() + "star", star);
            }

        }
        else
        {
            PlayerPrefs.SetInt("Level" + GetCena.instance.getCenaIndex() + "star", star);
        }

    }

    void atualizarMoedasPlayer()
    {
        pontosLevel = ScoreManager.instance.GetScore();
        pontosAux += pontosLevel;

        ScoreManager.instance.SalvaMoedas(pontosAux);
    }

   
}
