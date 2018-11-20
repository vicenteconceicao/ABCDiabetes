using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrutasCanvas : MonoBehaviour
{
    public Canvas CanvasFrutas;

    public List<Canvas> FrutasList;

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