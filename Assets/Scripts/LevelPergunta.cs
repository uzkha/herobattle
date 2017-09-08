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

                txPergunta.text = "Parabéns você está começando a aventura no Batalho dos Heróis. \n" +
                                  "Sua primeira missão é levar o Luizito em uma viagem em busca de medicamentos. Mas tenha atenção e tome cuidado com o Bacterino. \n" +
                                  "Ele vai querer estragar sua jornada, então desvie-se dele e capture o máximo de medicamento que conseguir! Vamos lá, boa sorte!";

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
