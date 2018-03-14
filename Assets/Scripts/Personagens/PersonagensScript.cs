using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PersonagensScript : MonoBehaviour
{

    public List<GameObject> BoysAvatarList;
    public List<GameObject> GirlsAvatarList;
    private List<GameObject> list;


    private Vector3 PlayerPosition;

    private int position;

    // Use this for initialization
    void Start()
    {
        Time.timeScale = 1;
        position = 0;
        PlayerPosition = GameObject.Find("Player").transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        // Ajustando volume de acordo com a configuração.
        var effectVol = PlayerPrefs.GetFloat("EffectVolume");
        //ClickSound.volume = effectVol;
    }

    public void SelectGenre(string genre)
    {

        var buffer = GameObject.Find("AvatarSelected");
        if (buffer != null)
        {
            Destroy(buffer);
        }

        if (genre.Equals("Meninos"))
        {
            list = BoysAvatarList;

        }
        else
        {
            list = GirlsAvatarList;
        }

        PlayerPrefs.SetString("Genero", genre);

        Debug.Log(genre);

        var SelectedObj = Instantiate(list[position], PlayerPosition, Quaternion.identity) as GameObject;
        SelectedObj.transform.Rotate(0, 180, 0);
        PlayerPrefs.SetInt("AvatarSelected", position);
        SelectedObj.name = "AvatarSelected";
    }

    public void NextAvatar()
    {
        Debug.Log("Next");
        position++;
        if (position == list.Count)
        {
            position = 0;
        }
        Destroy(GameObject.Find("AvatarSelected"));
        var obj = Instantiate(list[position], PlayerPosition, Quaternion.identity) as GameObject;
        obj.transform.Rotate(0, 180, 0);
        PlayerPrefs.SetInt("AvatarSelected", position);
        obj.name = "AvatarSelected";

    }

    public void BackAvatar()
    {
        Debug.Log("Back");
        position--;
        if (position < 0)
        {
            position = list.Count - 1;
        }
        Destroy(GameObject.Find("AvatarSelected"));
        var obj = Instantiate(list[position], PlayerPosition, Quaternion.identity) as GameObject;
        obj.transform.Rotate(0, 180, 0);
        PlayerPrefs.SetInt("AvatarSelected", position);
        obj.name = "AvatarSelected";
    }

}
