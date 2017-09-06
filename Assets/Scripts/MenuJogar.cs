using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuJogar : MonoBehaviour {

    private Animator panelBack;
    private Animator panelCredits;
    private bool btnConfClicked;
    private bool btnCreditsClicked;
    private bool btnSoundOnClicked = true;

    [SerializeField]
    private Button btnSoundOn;
    [SerializeField]
    private Button btnSoundOff;



    private void Start()
    {
        btnSoundOff.gameObject.GetComponent<Image>().enabled = false;
    }


    public void ClickedOnConf()
    {

        //som toque botao
        AudioManager.instance.SonsFXToca(1);

        panelBack = GameObject.FindGameObjectWithTag("panelBackConf").GetComponent<Animator>();

        if (btnConfClicked == false)
        {
            panelBack.Play("Panel-Conf-Inicial");
            btnConfClicked = true;
        }
        else
        {
            panelBack.Play("Panel-Conf-Inicial-Inverse");
            btnConfClicked = false;
        }
    }


    public void ClickedOnCredits()
    {

        //som toque botao
        AudioManager.instance.SonsFXToca(1);

        panelCredits = GameObject.FindGameObjectWithTag("panelConfCredits").GetComponent<Animator>();

        if (btnCreditsClicked == false)
        {
            panelCredits.Play("Painel-Creditos");
            btnCreditsClicked = true;
        }
        else
        {
            panelCredits.Play("Painel-Creditos-Inverse");
            btnCreditsClicked = false;
        }
    }

    public void ClickedOnSound()
    {

        //som toque botao
        AudioManager.instance.SonsFXToca(1);
        AudioManager.instance.Mute();

        if (btnSoundOnClicked == false)
        {
            btnSoundOn.gameObject.GetComponent<Image>().enabled = true;
            btnSoundOff.gameObject.GetComponent<Image>().enabled = false;
            btnSoundOnClicked = true;
            AudioManager.instance.SonsFXToca(1);
        }
        else
        {
            btnSoundOn.gameObject.GetComponent<Image>().enabled = false;
            btnSoundOff.gameObject.GetComponent<Image>().enabled = true;
            btnSoundOnClicked = false;
        }
    }

    public void ClickedOnJogar()
    {
        //som toque botao
        AudioManager.instance.SonsFXToca(1);

		//forcar para teste
		PlayerPrefs.DeleteAll();


        //verifica se ja existe usuario registrado
        if (UsuarioManager.instance.UsuarioExiste())
        {
            print("Nome: " + UsuarioManager.instance.getUsuarioNome() + " idade: " + UsuarioManager.instance.getUsuarioIdade().ToString());
        } else {// usuario nao existe
            SceneManager.LoadScene(3); // cena 1 - menu inicial batalha do herois             
        }

    }
}
