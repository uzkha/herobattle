using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

	//musicas
	public AudioClip[] clips;
	public AudioSource musicaBG;

	//sons efeitos
	public AudioClip[] clipsFX;
	public AudioSource sonsFX;

    //controle mute
    public bool soundMute;

	public static AudioManager instance;

	private void Awake()
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

	}

	// Update is called once per frame
	void Update () {
		if (!musicaBG.isPlaying && GetCena.instance.fase > 1 && soundMute == false)
		{
			musicaBG.clip = getRandom();
			musicaBG.Play();
		}
        
	}

	AudioClip getRandom()
	{
		return clips[Random.Range(0, clips.Length)];
	} 

	public void SonsFXToca(int index)
	{
		sonsFX.clip = clipsFX[index];
		sonsFX.Play();
	}

    public void Mute()
    {
        if(soundMute == false)
        {
            soundMute = true;
            musicaBG.mute = true;
            sonsFX.mute = true;
        }
        else
        {
            soundMute = false;
            musicaBG.mute = false;
            sonsFX.mute = false;
        }
    }
}
