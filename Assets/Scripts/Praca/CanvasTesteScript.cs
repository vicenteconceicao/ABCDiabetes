using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasTesteScript : MonoBehaviour {

    public GameObject portais;
    public GameObject neusa;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClickTesteButton()
    {
        portais.SetActive(!portais.active);
        neusa.SetActive(!neusa.active);

    }
}
