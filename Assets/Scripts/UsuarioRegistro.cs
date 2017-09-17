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
    public string url;

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

            EnviarHttp();          

			UsuarioManager.instance.setUsuarioNome (nome);
			UsuarioManager.instance.setUsuarioIdade (int.Parse (idade));

            //SceneManager.LoadScene(4);
            ChamarCena();
		}
    }

    private void ChamarCena()
    {
        StartCoroutine(Cena());
    }

    private void EnviarHttp()
    {

        url = "http://caminhodaluzpf.org.br/batalhadosherois/api/registro?usuario=" + nome;

        StartCoroutine(Http());
    }

    IEnumerator Cena()
    {
        yield return new WaitForSeconds(1f);
        
		SceneManager.LoadScene(4);
    }


    IEnumerator Http()
    {
        
        WWW www = new WWW(url);       
        yield return www;

        //Renderer renderer = GetComponent<Renderer>();
        //renderer.material.mainTexture = www.texture;
    }

}


