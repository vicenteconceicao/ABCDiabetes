using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarracaCarnesScript : MonoBehaviour
{

    public Canvas CanvasCarnes;
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
            CanvasCarnes.gameObject.SetActive(true);
            CanvasCarneDeBoi.gameObject.SetActive(true);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            CanvasCarnes.gameObject.SetActive(false);
            CanvasCarneDeBoi.gameObject.SetActive(false);
            CanvasFrango.gameObject.SetActive(false);
            CanvasLinguiça.gameObject.SetActive(false);
            CanvasOvo.gameObject.SetActive(false);
            CanvasPresunto.gameObject.SetActive(false);

        }
    }
}