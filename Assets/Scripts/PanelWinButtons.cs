using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PanelWinButtons : MonoBehaviour {


    private Button btnMenu, btnProximo, btnNovamente;

    public static bool ativarBotao;

    private void Start()
    {
        btnMenu = GameObject.Find("Btn-Menu").GetComponent<Button>();
        btnNovamente = GameObject.Find("Btn-Novamente").GetComponent<Button>();
        btnProximo = GameObject.Find("Btn-Proxima").GetComponent<Button>();
    }


    private void Update()
    {
        setarButtonsAtivo();
    }

    public void setarButtonsAtivo()
    {

        if (ativarBotao)
        {

            btnMenu.interactable = true;
            btnNovamente.interactable = true;
            btnProximo.interactable = true;

            ativarBotao = false;
        }
    }


    public void chamarLevelManager(){
		SceneManager.LoadScene (7);
	}

	public void jogarNovamente(){
		SceneManager.LoadScene (GetCena.instance.fase);
	}

	public void proximaLevel(){
		SceneManager.LoadScene (7);
	}



}
