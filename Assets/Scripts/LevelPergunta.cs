using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelPergunta : MonoBehaviour {

    [SerializeField]
    private Text txPergunta;

    private int fase;
    private int next;

    // Use this for initialization
    void Start() {

		fase = GetCena.instance.fase;
        montarPergunta();

    }

    void montarPergunta()
    {

   
        switch (fase) {

		case 5: // level 1

			txPergunta.text = "Parabéns você está começando a aventura no Batalha dos Heróis. \n" +
			"Nesta fase seu objetivo é capturar os medicamentos e desviar as bactérias. \n" +
			"Toque na tela para pular...Boa sorte!";

                break;



            default:

                txPergunta.text = "Ocorreu um problema. Por favor reinicie o jogo.";

                break;


        }


    }

    public void Continuar()
    {

        switch (fase)
        {

            case 5: // level 1
                next = 6;
                break;

            default:

                break;


        }

        SceneManager.LoadScene(next);

    }
	

}
