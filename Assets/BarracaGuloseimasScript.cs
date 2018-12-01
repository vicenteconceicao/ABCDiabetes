using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarracaGuloseimasScript : MonoBehaviour
{

    public Canvas CanvasGuloseimas;
    public Canvas CanvasCarneDeBoi;
    public Canvas CanvasFrango;
    public Canvas CanvasLinguiça;
    public Canvas CanvasOvo;
    public Canvas CanvasPresunto;


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

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            CanvasGuloseimas.gameObject.SetActive(false);

        }
    }
}