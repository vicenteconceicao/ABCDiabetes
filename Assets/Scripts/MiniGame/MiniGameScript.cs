using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class MiniGameScript : MonoBehaviour {

    public List<GameObject> BoysAvatarList;
    public List<GameObject> GirlsAvatarList;
    
    private float tempo;

    private Vector3 PlayerPosition;

    //Canvas Pontos
    public Canvas endGame;
    public Text pontosLaranja;
    public List<GameObject> laranjas;
    public Text pontosAbacaxi;
    public List<GameObject> abacaxis;
    public Text pontosBalinha;
    public List<GameObject> balinhas;
    public Text pontosCookie;
    public List<GameObject> cookies;
    public Text pontosChocolate;
    public List<GameObject> chocolates;

    public Text ErrorTouch;
    public Text SuccessTouch;

    public Text NomeJogador;

    public Text PontuacaoTotal;

    public Text TempoRestante;


    // Use this for initialization
    void Start () {

        tempo = (Mathf.CeilToInt(Time.time));

        // Posição para instanciar os personagens
        PlayerPosition = GameObject.Find("Player").transform.position;

        //INSTANCIANDO O PERSONAGEM SELECIONADO NA SCENE ANTERIOR 
        GameObject player;

        if (PlayerPrefs.GetString("Genero").Equals("Meninos"))
        {
            player = Instantiate(BoysAvatarList[PlayerPrefs.GetInt("AvatarSelected")], PlayerPosition, Quaternion.identity) as GameObject;
        }
        else
        {
            player = Instantiate(GirlsAvatarList[PlayerPrefs.GetInt("AvatarSelected")], PlayerPosition, Quaternion.identity) as GameObject;

        }
        player.name = "AvatarSelected";
        var rb = player.gameObject.GetComponent<Rigidbody>();
        var cam = player.GetComponentInChildren<Camera>();
        cam.gameObject.SetActive(false);
        player.AddComponent<PointScript>();
        var controle = player.GetComponentInChildren<Controlador>();
        controle.Control3D = false;
        player.AddComponent<NavMeshAgent>();
        
    }
	
	// Update is called once per frame
	void Update () {
        TempoRestante.text = (60 - (Mathf.CeilToInt(Time.time) - tempo)).ToString();
        if ( Mathf.CeilToInt(Time.time) - tempo == 60)
        {
            EndGame();
        }
    }

    private void EndGame() {
        pontosLaranja.text = PlayerPrefs.GetInt("Laranjas").ToString();
        pontosAbacaxi.text = PlayerPrefs.GetInt("Abacaxis").ToString();
        pontosBalinha.text = PlayerPrefs.GetInt("Balinhas").ToString();
        pontosCookie.text = PlayerPrefs.GetInt("Cookies").ToString();
        pontosChocolate.text = PlayerPrefs.GetInt("Chocolates").ToString();

 

        NomeJogador.text = PlayerPrefs.GetString("PlayerName");
        var ponto = 25 - PlayerPrefs.GetInt("PlayerPoint");

        PontuacaoTotal.text = ponto.ToString();

        ErrorTouch.text = PlayerPrefs.GetInt("ErrorTouch").ToString();
        SuccessTouch.text = PlayerPrefs.GetInt("SuccessTouch").ToString();

        endGame.gameObject.SetActive(true);
    }
}
