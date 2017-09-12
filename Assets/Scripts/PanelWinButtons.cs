using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelWinButtons : MonoBehaviour {


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
