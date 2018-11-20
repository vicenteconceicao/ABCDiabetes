using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmissorScript : MonoBehaviour
{
    public List<GameObject> AlimentosCafe;
    public List<GameObject> AlimentosAlmoco;
    public List<GameObject> AlimentosLanche;
    
    private int RandleTime;
    private int TipoRefeicao;
    private int alimento;

    private float TimeInicial;

    // Use this for initialization
    void Start()
    {
        TimeInicial = Time.time;
        RandleTime = 1;
        TipoRefeicao = PlayerPrefs.GetInt("TipoRefeicao"); // 0 - Café, 1 - Almoço, 2- Lanche.
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - TimeInicial > RandleTime)
        {
            RandleTime = Random.Range(1, 4);

            // Tempo Atual
            TimeInicial = Time.time;

            // Pegando Posição do Emissor
            var pos = transform.localPosition;

            // Gerando uma posição aleatória 
            pos.x = Random.Range(-17, 17);

            switch(TipoRefeicao)
            {
                case 0: // Café.
                    alimento = Random.Range(0, AlimentosCafe.Count);
                    Instantiate(AlimentosCafe[alimento], pos, Quaternion.identity);
                    break;
                case 1: // Almoço.
                    alimento = Random.Range(0, AlimentosAlmoco.Count);
                    Instantiate(AlimentosAlmoco[alimento], pos, Quaternion.identity);
                    break;
                case 2: // Lanche.
                    alimento = Random.Range(0, AlimentosLanche.Count);
                    Instantiate(AlimentosLanche[alimento], pos, Quaternion.identity);
                    break;
            }
        }
    }
}

