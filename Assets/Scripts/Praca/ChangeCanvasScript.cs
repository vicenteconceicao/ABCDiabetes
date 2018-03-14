using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCanvasScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChangeCanvas(GameObject NovoCanvas) {
        this.gameObject.SetActive(false);
        NovoCanvas.SetActive(true);
    }
}
