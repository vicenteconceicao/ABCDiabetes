using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointScript : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        PlayerPrefs.SetInt("PlayerPoint", 25);

        PlayerPrefs.SetInt("Laranjas", 0);
        PlayerPrefs.SetInt("Abacaxis", 0);
        PlayerPrefs.SetInt("Balinhas", 0);
        PlayerPrefs.SetInt("Chocolates", 0);
        PlayerPrefs.SetInt("Cookies", 0);

        PlayerPrefs.SetInt("ErrorTouch", 0);
        PlayerPrefs.SetInt("SuccessTouch", 0);

    }

    // Update is called once per frame
    void Update()
    {
        // Acesso guiado
        if (PlayerPrefs.GetInt("ControlType") == 2)
        {
            // Desativando BoxCollider do personagem
            gameObject.GetComponent<BoxCollider>().enabled = false;

            var point = PlayerPrefs.GetInt("PlayerPoint");

            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    Debug.Log(hit.transform.name);

                    if (hit.transform.CompareTag("Bom"))
                    {
                        Destroy(hit.transform.gameObject);
                        //PlayerPrefs.SetInt("PlayerPoint", point - 1);
                        Debug.Log(PlayerPrefs.GetInt("PlayerPoint"));
                        PlayerPrefs.SetInt("SuccessTouch", PlayerPrefs.GetInt("SuccessTouch") + 1);
                    }
                    else if (hit.transform.CompareTag("Ruim"))
                    {
                        Destroy(hit.transform.gameObject);
                        PlayerPrefs.SetInt("PlayerPoint", point + 10);
                        Debug.Log(PlayerPrefs.GetInt("PlayerPoint"));
                        PlayerPrefs.SetInt("SuccessTouch", PlayerPrefs.GetInt("SuccessTouch") + 1);
                    }
                    else {
                        PlayerPrefs.SetInt("ErrorTouch", PlayerPrefs.GetInt("ErrorTouch") + 1);
                    }
                    // Pontuando as frutas;
                    var nomeAlimento = hit.transform.gameObject.name;
                    if (nomeAlimento.Contains("Laranja"))
                    {
                        PlayerPrefs.SetInt("Laranjas", PlayerPrefs.GetInt("Laranjas") + 1);
                    }
                    if (nomeAlimento.Contains("Abacaxi"))
                    {
                        PlayerPrefs.SetInt("Abacaxis", PlayerPrefs.GetInt("Abacaxis") + 1);
                    }

                    if (nomeAlimento.Contains("Balinha"))
                    {
                        PlayerPrefs.SetInt("Balinhas", PlayerPrefs.GetInt("Balinhas") + 1);
                    }
                    if (nomeAlimento.Contains("Chocolate"))
                    {
                        PlayerPrefs.SetInt("Chocolates", PlayerPrefs.GetInt("Chocolates") + 1);
                    }

                    if (nomeAlimento.Contains("Cookies"))
                    {
                        PlayerPrefs.SetInt("Cookies", PlayerPrefs.GetInt("Cookies") + 1);
                    }
                }
            }
        }
        else
        {
            // Ativando BoxCollider do personagem
            gameObject.GetComponent<BoxCollider>().enabled = true;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        var point = PlayerPrefs.GetInt("PlayerPoint");

        if (collision.gameObject.tag.Equals("Bom"))
        {

            Destroy(collision.gameObject);
            //PlayerPrefs.SetInt("PlayerPoint", point - 1);
            Debug.Log(PlayerPrefs.GetInt("PlayerPoint"));
        }
        else if (collision.gameObject.tag.Equals("Ruim"))
        {

            Destroy(collision.gameObject);
            PlayerPrefs.SetInt("PlayerPoint", point + 10);
            Debug.Log(PlayerPrefs.GetInt("PlayerPoint"));
        }

        // Pontuando as frutas;
        var nomeAlimento = collision.gameObject.name;
        if (nomeAlimento.Contains("Laranja"))
        {
            PlayerPrefs.SetInt("Laranjas", PlayerPrefs.GetInt("Laranjas") + 1);
        }
        if (nomeAlimento.Contains("Abacaxi"))
        {
            PlayerPrefs.SetInt("Abacaxis", PlayerPrefs.GetInt("Abacaxis") + 1);
        }

        if (nomeAlimento.Contains("Balinha"))
        {
            PlayerPrefs.SetInt("Balinhas", PlayerPrefs.GetInt("Balinhas") + 1);
        }
        if (nomeAlimento.Contains("Chocolate"))
        {
            PlayerPrefs.SetInt("Chocolates", PlayerPrefs.GetInt("Chocolates") + 1);
        }

        if (nomeAlimento.Contains("Cookies"))
        {
            PlayerPrefs.SetInt("Cookies", PlayerPrefs.GetInt("Cookies") + 1);
        }
    }
}
