using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance;
	public bool gameStart;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    // Use this for initialization
    void Start () {
        ScoreManager.instance.GameStartScoreM();

        //level 1 sai liberado
        PlayerPrefs.SetInt("Level1", 1);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
