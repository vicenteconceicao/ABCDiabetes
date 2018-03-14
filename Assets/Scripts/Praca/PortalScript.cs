using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalScript : MonoBehaviour
{
    public GameObject proximoPortal;

    public Canvas CheckPoint;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            if(proximoPortal != null)
            proximoPortal.gameObject.SetActive(true);
            CheckPoint.gameObject.SetActive(true);
        }
    }
}
