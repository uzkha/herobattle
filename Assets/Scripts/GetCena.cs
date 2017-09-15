using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GetCena : MonoBehaviour {

	public int fase = -1;

	public static GetCena instance;

    [SerializeField]
    private GameObject UIManagerGo, GameManagerGo;        
		
	private float orthoSize = 5;

	[SerializeField]
	private float aspect = 1.75f;

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

		SceneManager.sceneLoaded += VerificaFase;
	}


	void VerificaFase(Scene cena, LoadSceneMode modo)
	{

		fase = SceneManager.GetActiveScene().buildIndex;

        if (fase != 0 && fase != 1 && fase != 2 && fase != 3 && fase != 4 && fase != 5 && fase != 7)
        {
            Instantiate(UIManagerGo);
            Instantiate(GameManagerGo);

            //Camera.main.projectionMatrix = Matrix4x4.Ortho(-orthoSize*aspect, orthoSize * aspect, -orthoSize, orthoSize, Camera.main.nearClipPlane, Camera.main.farClipPlane);

        }

            Camera.main.projectionMatrix = Matrix4x4.Ortho(-orthoSize * aspect, orthoSize * aspect, -orthoSize, orthoSize, Camera.main.nearClipPlane, Camera.main.farClipPlane);
    }

    public int getCenaIndex()
    {

        int indexFase = 0;

        switch (fase) {

            case 6:
                indexFase = 1;
                break;
        }

        return indexFase;
    }
}
