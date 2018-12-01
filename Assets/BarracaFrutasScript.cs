using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarracaFrutasScript : MonoBehaviour {

    public Canvas CanvasFrutas;
    public Canvas CanvasLaranja;
    public Canvas CanvasAbacaxi;
    public Canvas CanvasBanana;
    public Canvas CanvasManga;
    public Canvas CanvasMorango;
    public Canvas CanvasMaça;
    public Canvas CanvasUva;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Encostou");
        if (other.gameObject.tag.Equals("Player"))
        {
            CanvasFrutas.gameObject.SetActive(true);
           
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            CanvasFrutas.gameObject.SetActive(false);
          
        }
    }
}
