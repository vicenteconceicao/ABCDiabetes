using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarracaGuloseimasScript : MonoBehaviour
{

    public Canvas CanvasGuloseimas;
    public Canvas CanvasBalinha;
    public Canvas CanvasCookies;
    public Canvas CanvasBolacha;
    public Canvas CanvasBrigadeiro;
    public Canvas CanvasRefrigerante;


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
            CanvasGuloseimas.gameObject.SetActive(true);
            CanvasBalinha.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            CanvasGuloseimas.gameObject.SetActive(false);
            CanvasBalinha.gameObject.SetActive(false);
            CanvasCookies.gameObject.SetActive(false);
            CanvasBolacha.gameObject.SetActive(false);
            CanvasBrigadeiro.gameObject.SetActive(false);
            CanvasRefrigerante.gameObject.SetActive(false);

        }
    }
}