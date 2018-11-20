using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PracaScript : MonoBehaviour
{

    public List<GameObject> BoysAvatarList;
    public List<GameObject> GirlsAvatarList;

    private Vector3 PlayerPosition;


    void Start()
    {
        // Posição para instanciar os personagens
        PlayerPosition = GameObject.Find("Player").transform.position;

        GameObject player;

        //INSTANCIANDO O PERSONAGEM SELECIONADO NA SCENE ANTERIOR 
        if (PlayerPrefs.GetString("Genero").Equals("Meninos"))
        {
            player = Instantiate(BoysAvatarList[PlayerPrefs.GetInt("AvatarSelected")], PlayerPosition, Quaternion.identity) as GameObject;
            player.name = "AvatarSelected";
        }
        else
        {
            player = Instantiate(GirlsAvatarList[PlayerPrefs.GetInt("AvatarSelected")], PlayerPosition, Quaternion.identity) as GameObject;

        }
        player.transform.Rotate(new Vector3(0, 90, 0));
        player.name = "AvatarSelected";
        var cam = player.GetComponentInChildren<Camera>();
        cam.gameObject.AddComponent<AudioListener>();
        player.AddComponent<NavMeshAgent>();
    }

    // 0 - Café, 1 - Almoço, 2- Lanche.
    public void SelectPrato(int prato)
    {
        PlayerPrefs.SetInt("TipoRefeicao", prato);
    }
}
