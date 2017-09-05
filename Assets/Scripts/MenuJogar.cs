using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
       
        if (btnSoundOnClicked == false)
        {
            btnSoundOn.gameObject.GetComponent<Image>().enabled = true;
            btnSoundOff.gameObject.GetComponent<Image>().enabled = false;
            btnSoundOnClicked = true;
        }
        else
        {
            btnSoundOn.gameObject.GetComponent<Image>().enabled = false;
            btnSoundOff.gameObject.GetComponent<Image>().enabled = true;
            btnSoundOnClicked = false;           
        }
    }
}
