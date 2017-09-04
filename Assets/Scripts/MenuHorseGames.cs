using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

}
