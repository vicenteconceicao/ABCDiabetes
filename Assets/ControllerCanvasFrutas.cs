using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerCanvasFrutas : MonoBehaviour {

    public List<Canvas> ListCanvas;
    public GameObject Alimentos;

    private int position;
    private int qtdCanvas;

    // Use this for initialization
    void Start () {
        position = 0;
        ListCanvas[position].gameObject.SetActive(true);
        qtdCanvas = ListCanvas.Count;
        Alimentos = GameObject.Find("Alimento");
        print(Alimentos);
            
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void NextCanvas() {
        ListCanvas[position].gameObject.SetActive(false);
        position++;
        if (position == ListCanvas.Count)
        {
            position = 0;
        }
        ListCanvas[position].gameObject.SetActive(true);
    }

    public void BackCanvas()
    {
        ListCanvas[position].gameObject.SetActive(false);
        position--;
        if (position < 0)
        {
            position = ListCanvas.Count-1;
        }
        ListCanvas[position].gameObject.SetActive(true);
  
    }
}
