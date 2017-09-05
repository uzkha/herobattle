using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MenuInicialBatalhaHerois : MonoBehaviour {

    [SerializeField]
    private GameObject panelWhiteParceiro;

	[SerializeField]
	private GameObject panelIdealizado;

	// Use this for initialization
	void Start () {
        panelWhiteParceiro.SetActive(false);
		panelIdealizado.SetActive(false);
	}

    public void MostrarPanelParceiro()
    {
        panelWhiteParceiro.SetActive(true);
		panelIdealizado.SetActive(true);
    }

    public void ChamarMenuJogar()
    {
        SceneManager.LoadScene(2); // cena 1 - menu inicial batalha do herois
    }


}
