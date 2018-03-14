using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlicoseScript : MonoBehaviour {

    public Slider slider;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

        slider.value = PlayerPrefs.GetInt("PlayerPoint") / 50.0f;
		
	}
}
