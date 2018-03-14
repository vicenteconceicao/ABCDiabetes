using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour
{

    public AudioSource EffectSound;
    public AudioSource MusicSound;

    public bool UseMusicSound;
    public bool UseEffectSound;

    // Use this for initialization
    void Start()
    {
        if (UseMusicSound) { MusicSound.gameObject.SetActive(PlayerPrefs.GetString("SoundActive").Equals("True"));}
        // Ativando ou Desativando o som de Acordo com a configuração
        if (UseEffectSound) { EffectSound.gameObject.SetActive(PlayerPrefs.GetString("SoundActive").Equals("True")); }
       
    }

    // Update is called once per frame
    void Update()
    {
        // Adicionando valores dos volumes nas configurações
        EffectSound.volume = PlayerPrefs.GetFloat("EffectVolume");
        MusicSound.volume = PlayerPrefs.GetFloat("MusicVolume");

        if (UseMusicSound) { MusicSound.gameObject.SetActive(PlayerPrefs.GetString("SoundActive").Equals("True")); }
        // Ativando ou Desativando o som de Acordo com a configuração
        if (UseEffectSound) { EffectSound.gameObject.SetActive(PlayerPrefs.GetString("SoundActive").Equals("True")); }
    }


    public void OnClickSound()
    {
        PlayerPrefs.SetString("SoundActive", (!PlayerPrefs.GetString("SoundActive").Equals("True")).ToString());
        Debug.Log(PlayerPrefs.GetString("SoundActive"));
    }
}
