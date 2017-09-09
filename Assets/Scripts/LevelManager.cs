using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    [System.Serializable]
    public class Level
    {
        public string levelText;
        public bool habilitado;
        public int desbloqueado;
        public bool txtAtivo;

    }


    public GameObject botao;
    public Transform localBtn;
    public List<Level> levelList;
    public Text usuario;
    public Text score;

    public Sprite starOne;
    public Sprite starTwo;
    public Sprite starThree;

    void ListaAdd()
    {
        foreach (Level level in levelList)
        {
            GameObject btnNovo = Instantiate(botao) as GameObject;
            BotaoLevel btnNew = btnNovo.GetComponent<BotaoLevel>();

            btnNew.levelTxtBtn.text = "\n" + level.levelText;

            if (PlayerPrefs.GetInt("Level" + level.levelText) == 1)
            {
                level.desbloqueado = 1;
                level.habilitado = true;
                level.txtAtivo = true;

                

                if(PlayerPrefs.HasKey("Level"+ level.levelText + "star")){

                    int star = PlayerPrefs.GetInt("Level" + level.levelText + "star");

                  

                    if (star == 1)
                    {
                        btnNew.GetComponent<Image>().overrideSprite = starOne;
                       
                    }
                    else if(star == 2)
                    {
                        btnNew.GetComponent<Image>().overrideSprite = starTwo;
                    }
                    else if(star >= 3)
                    {
                        btnNew.GetComponent<Image>().overrideSprite = starThree;
                    }

                }

            }
          


            btnNew.desbloqueadoBtn = level.desbloqueado;
            btnNew.GetComponent<Button>().interactable = level.habilitado;
            btnNew.GetComponentInChildren<Text>().enabled = level.txtAtivo;
            btnNew.GetComponent<Button>().onClick.AddListener(() => ClickLevel("Level" + level.levelText));

            btnNovo.transform.SetParent(localBtn, false);
        }
    }

    void ClickLevel(string level)
    {
        SceneManager.LoadScene(level);
    }

    // Use this for initialization
    void Start()
    {

        //provisorio
        //PlayerPrefs.SetInt("Level1star", 3);

        //deletar player prefs
        //PlayerPrefs.DeleteAll();
        ListaAdd();

        usuario.text = UsuarioManager.instance.getUsuarioNome();
        score.text = ScoreManager.instance.GetScore().ToString();
    }


    void Awake()
    {
        //destroy gamemanager e ui manager
        /*Destroy(GameObject.Find("GameManager(Clone)"));
        Destroy(GameObject.Find("UIManager(Clone)"));*/
    }
}
