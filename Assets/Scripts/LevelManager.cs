using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevalManager : MonoBehaviour
{

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

    void ListaAdd()
    {
        foreach (Level level in levelList)
        {
           /* GameObject btnNovo = Instantiate(botao) as GameObject;
            BotaoLevel btnNew = btnNovo.GetComponent<BotaoLevel>();

            btnNew.levelTxtBtn.text = level.levelText;

            if (PlayerPrefs.GetInt("Level" + btnNew.levelTxtBtn.text) == 1)
            {
                level.desbloqueado = 1;
                level.habilitado = true;
                level.txtAtivo = true;

            }*/


           /* btnNew.desbloqueadoBtn = level.desbloqueado;
            btnNew.GetComponent<Button>().interactable = level.habilitado;
            btnNew.GetComponentInChildren<Text>().enabled = level.txtAtivo;
            btnNew.GetComponent<Button>().onClick.AddListener(() => ClickLevel("Level" + btnNew.levelTxtBtn.text));

            btnNovo.transform.SetParent(localBtn, false);*/
        }
    }

    void ClickLevel(string level)
    {
        SceneManager.LoadScene(level);
    }

    // Use this for initialization
    void Start()
    {

        //deletar player prefs
        //PlayerPrefs.DeleteAll();
        ListaAdd();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Awake()
    {
        //destroy gamemanager e ui manager
       /* Destroy(GameObject.Find("GameManager(Clone)"));
        Destroy(GameObject.Find("UIManager(Clone)"));*/
    }
}
