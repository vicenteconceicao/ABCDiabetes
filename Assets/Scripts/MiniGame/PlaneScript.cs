using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Bom"))
        {
            Destroy(collision.gameObject);
            var point = PlayerPrefs.GetInt("PlayerPoint");
            PlayerPrefs.SetInt("PlayerPoint", point - 10);
        }
        else if (collision.gameObject.tag.Equals("Ruim"))
        {
            Destroy(collision.gameObject);
        }
    }
}
