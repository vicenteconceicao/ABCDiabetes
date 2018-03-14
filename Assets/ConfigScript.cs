using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfigScript : MonoBehaviour
{
    public Canvas CanvasConfiguracao;
    public InputField PlayerName;
    public Toggle MalePlayer;
    public Toggle FemalePlayer;
    public InputField PlayerAge;
    public Toggle AlphabetizedPlayer;
    public Toggle NoAlphabetizedPlayer;
    public Dropdown Interaction;
    public Toggle LeftControllerPlayer;
    public Toggle RightControllerPlayer;
    public Scrollbar TextSize;
    public Scrollbar ControlSize;
    public Scrollbar SpeedControl;

    private void OnEnable()
    {
        Debug.Log("OnEnable");

        if (!PlayerPrefs.HasKey("PlayerName"))
        {
            PlayerPrefs.SetString("PlayerName", "Jogador");
        }
        if (!PlayerPrefs.HasKey("PlayerGender"))
        {
            PlayerPrefs.SetString("PlayerGender", "Masculino");
        }
        if (!PlayerPrefs.HasKey("PlayerAge"))
        {
            PlayerPrefs.SetString("PlayerAge", "0");
        }
        if (!PlayerPrefs.HasKey("PlayerAlphabetized"))
        {
            PlayerPrefs.SetString("PlayerAlphabetized", "True");
        }
        // 0 para uma mão e 1 para duas mãos.
        if (!PlayerPrefs.HasKey("ControlType"))
        {
            PlayerPrefs.SetInt("ControlType", 0);
        }
        // 0 Esquerda e 1 Direita.
        if (!PlayerPrefs.HasKey("ControlSide"))
        {
            PlayerPrefs.SetInt("ControlSide", 0);
        }
        if (!PlayerPrefs.HasKey("TextSize"))
        {
            PlayerPrefs.SetFloat("TextSize", 5);
        }
        if (!PlayerPrefs.HasKey("ControlSize"))
        {
            PlayerPrefs.SetFloat("ControlSize", 5);
        }
        if (!PlayerPrefs.HasKey("SpeedControl"))
        {
            PlayerPrefs.SetFloat("SpeedControl", 5);
        }
    }


    // Use this for initialization
    void Start()
    {
        Debug.Log("OnStart");

        PlayerName.text = PlayerPrefs.GetString("PlayerName");
        MalePlayer.isOn = PlayerPrefs.GetString("PlayerGender").Equals("Masculino");
        FemalePlayer.isOn = !MalePlayer.isOn;
        PlayerAge.text = PlayerPrefs.GetString("PlayerAge");
        AlphabetizedPlayer.isOn = PlayerPrefs.GetString("PlayerAlphabetized").Equals("True");
        NoAlphabetizedPlayer.isOn = !AlphabetizedPlayer.isOn;
        LeftControllerPlayer.isOn = PlayerPrefs.GetInt("ControlSide") == 0;
        RightControllerPlayer.isOn = !LeftControllerPlayer.isOn;
        Interaction.value = PlayerPrefs.GetInt("ControlType");
        TextSize.value = PlayerPrefs.GetFloat("TextSize");
        ControlSize.value = PlayerPrefs.GetFloat("ControlSize");
        SpeedControl.value = PlayerPrefs.GetFloat("SpeedControl");
        Interaction.value = PlayerPrefs.GetInt("PlayerHands");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnDisable()
    {
        Debug.Log("OnDisable");

        PlayerPrefs.SetString("PlayerName", PlayerName.text);
        if (MalePlayer.isOn)
        {
            PlayerPrefs.SetString("PlayerGender", "Masculino");
        }
        else
        {
            PlayerPrefs.SetString("PlayerGender", "Feminino");
        }
        PlayerPrefs.SetString("PlayerAge", PlayerAge.text);
        PlayerPrefs.SetString("PlayerAlphabetized", AlphabetizedPlayer.isOn.ToString());
        PlayerPrefs.SetInt("PlayerHands", Interaction.value);

        if (LeftControllerPlayer.isOn)
        {
            PlayerPrefs.SetInt("ControlSide", 0);
        }
        else
        {
            PlayerPrefs.SetInt("ControlSide", 1);
        }

        PlayerPrefs.SetFloat("TextSize", TextSize.value);
        PlayerPrefs.SetFloat("ControlSize", ControlSize.value);
        PlayerPrefs.SetFloat("SpeedControl", SpeedControl.value);
        PlayerPrefs.SetInt("ControlType", Interaction.value);
    }

    public void OnSelectGenre(int id)
    {
        if (id == 0)
        {
            FemalePlayer.isOn = !MalePlayer.isOn;
        }
        else
        {
            MalePlayer.isOn = !FemalePlayer.isOn;
        }

    }

    public void OnSelectAlphabetized(int id)
    {
        if (id == 0)
        {
            NoAlphabetizedPlayer.isOn = !AlphabetizedPlayer.isOn;
        }
        else
        {
            AlphabetizedPlayer.isOn = !NoAlphabetizedPlayer.isOn;
        }

    }

    public void OnSelectHandSide(int id)
    {
        if (id == 0)
        {
            RightControllerPlayer.isOn = !LeftControllerPlayer.isOn;
        }
        else
        {
            LeftControllerPlayer.isOn = !RightControllerPlayer.isOn;
        }
    }
}
