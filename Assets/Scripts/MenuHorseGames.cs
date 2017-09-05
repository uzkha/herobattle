using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MenuHorseGames : MonoBehaviour {

	[SerializeField]
	private GameObject txDevelopment;



	// Use this for initialization
	void Start () {
		txDevelopment.SetActive (false);
	}

	public void AtivarTexto(){
		txDevelopment.SetActive (true);
	}

    public void ChamarMenuInicialBatalhaHerois()
    {
        SceneManager.LoadScene(1); // cena 1 - menu inicial batalha do herois
    }

}
