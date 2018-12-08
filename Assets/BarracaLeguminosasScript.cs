using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarracaLeguminosasScript : MonoBehaviour
{

    public Canvas CanvasLeguminosas;
    public Canvas CanvasArroz;
    public Canvas CanvasBatata;
    public Canvas CanvasBatataDoce;
    public Canvas CanvasErvilha;
    public Canvas CanvasFeijão;
    public Canvas CanvasSoja;
    

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Encostou");
        if (other.gameObject.tag.Equals("Player"))
        {
            CanvasLeguminosas.gameObject.SetActive(true);
            CanvasArroz.gameObject.SetActive(true);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            CanvasLeguminosas.gameObject.SetActive(false);
            CanvasArroz.gameObject.SetActive(false);
            CanvasBatata.gameObject.SetActive(false);
            CanvasBatataDoce.gameObject.SetActive(false);
            CanvasErvilha.gameObject.SetActive(false);
            CanvasFeijão.gameObject.SetActive(false);
            CanvasSoja.gameObject.SetActive(false);


        }
    }
}