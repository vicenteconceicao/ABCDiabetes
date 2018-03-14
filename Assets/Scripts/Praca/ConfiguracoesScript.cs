using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfiguracoesScript : MonoBehaviour {

    public InputField NomeJogador;

    public Slider Musica;
    public Slider Efeito;

	// Use this for initialization
	void Start () {

        if (PlayerPrefs.HasKey("NomeJogador"))
        {
            NomeJogador.text = PlayerPrefs.GetString("NomeJogador");
            Musica.value = PlayerPrefs.GetFloat("MusicVolume");
            Efeito.value = PlayerPrefs.GetFloat("EffectVolume");
        }
		
	}
	
	// Update is called once per frame
	void Update () {
        PlayerPrefs.SetString("NomeJogador", NomeJogador.text);
        PlayerPrefs.SetFloat("MusicVolume", Musica.value);
        PlayerPrefs.SetFloat("EffectVolume", Efeito.value);
    }
}
