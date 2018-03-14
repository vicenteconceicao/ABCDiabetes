using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InicioScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        if (!PlayerPrefs.HasKey("SoundActive")) {
            PlayerPrefs.SetString("SoundActive", "true");
        }

        if (!PlayerPrefs.HasKey("MusicVolume"))
        {
            PlayerPrefs.SetFloat("MusicVolume", 1f);
        }

        if (!PlayerPrefs.HasKey("EffectVolume"))
        {
            PlayerPrefs.SetFloat("EffectVolume", 1f);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnExitGame() {
        Debug.Log("Quit Game!");
        Application.Quit();
    }
}
