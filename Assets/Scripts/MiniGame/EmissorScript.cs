using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmissorScript : MonoBehaviour
{

    public List<GameObject> AlimentosBons;
    public List<GameObject> AlimentosRuins;

    private int RandleTime;

    private float TimeInicial;

    // Use this for initialization
    void Start()
    {
        TimeInicial = Time.time;
        RandleTime = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - TimeInicial > RandleTime)
        {
            RandleTime = Random.Range(1, 4);

            // Valor randômico para Alimentos Bons = 1, Ruins = 0
            var randon = Random.Range(0, 2);

            // Tempo Atual
            TimeInicial = Time.time;

            // Pegando Posição do Emissor
            var pos = transform.localPosition;

            // Gerando uma posição aleatória 
            pos.x = Random.Range(-17, 17);

            var aBons = Random.Range(0, AlimentosBons.Count);
            var aRuins = Random.Range(0, AlimentosRuins.Count);

            if (randon == 1)
            {
                Instantiate(AlimentosBons[aBons], pos, Quaternion.identity);
            }
            else {
                Instantiate(AlimentosRuins[aRuins], pos, Quaternion.identity);
            }
        }
    }
}

