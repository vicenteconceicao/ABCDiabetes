using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlimentosCanvasScript : MonoBehaviour
{
    public Canvas CanvasAlimentosFrutas;

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
        if (other.gameObject.tag.Equals("Player"))
        {
            CanvasAlimentosFrutas.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            CanvasAlimentosFrutas.gameObject.SetActive(false);
        }
    }
}