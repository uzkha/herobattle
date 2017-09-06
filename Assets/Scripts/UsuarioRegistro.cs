using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UsuarioRegistro : MonoBehaviour {

    [SerializeField]
    private InputField inputNome, inputIdade;
	[SerializeField]
	private GameObject txtError;

	private string nome;
	private string idade;

	void Start(){
		txtError.SetActive (false);
	}

    public void Enviar()
    {

		nome  = inputNome.text;
		idade = inputIdade.text.ToString();

		if (nome == "" || idade == "") {
			txtError.SetActive (true);			
		} else {
			UsuarioManager.instance.setUsuarioNome (nome);
			UsuarioManager.instance.setUsuarioIdade (int.Parse (idade));

			SceneManager.LoadScene(4);
		}
    }
   
}
