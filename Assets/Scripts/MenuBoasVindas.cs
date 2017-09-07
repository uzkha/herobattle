using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuBoasVindas : MonoBehaviour {

    [SerializeField]
    private GameObject txtBoasVindas;

    string texto;

    // Use this for initialization
    void Start() {

        texto = "Olá " + UsuarioManager.instance.getUsuarioNome() + ", eu sou o Luizito. Seja bem vindo(a) ao Batalha dos Heróis." +
                "\n Vamos ser parceiros nesta aventura! \n Você está pronto para começar?";

        //txtBoasVindas = GameObject.Find ("TXT-BoasVindas");
        txtBoasVindas.GetComponent<Text>().text = texto;

    }

    public void Continuar()
    {
        SceneManager.LoadScene(5);
    }
	

}
