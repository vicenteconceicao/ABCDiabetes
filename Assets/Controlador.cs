using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controlador : MonoBehaviour
{
    private Vector2 touchOrigin = -Vector2.one;

    // Animator
    private Animator animator;
    public bool HasAnimator;

    // Controle
    private MobileInput LeftJoystick;
    private MobileInput RightJoystick;

    // ATRIBUTOS PARA TESTE
    public bool Control3D;

    // ATRIBUTOS DE ACESSIBILIDADE.

    // Velocidade do Controle.
    private float SpeedControl;
    // Quantidades de mãos para Controle 
    private int Hands;
    // Lado das mãos para Controle
    private int ControlSide;


    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        LeftJoystick = GameObject.Find("LeftControl").GetComponentInChildren<MobileInput>() as MobileInput;
        RightJoystick = GameObject.Find("RightControl").GetComponentInChildren<MobileInput>() as MobileInput;
    }

    // Use this when Script is enable.
    void OnEnable()
    {
        Debug.Log("Enable Controlador");
        // Configuração de Velocidade do Controle.
        SpeedControl = PlayerPrefs.GetFloat("SpeedControl");

        // Pengando valor relacionado à quantidade de mãos utilizado no controle.
        Hands = PlayerPrefs.GetInt("PlayerHands");
    }
    // Update is called once per frame
    void Update()
    {
        var interaction = PlayerPrefs.GetInt("ControlType");
        float eixoX = 0;
        float eixoY = 0;

        // Interação por Controle Virtual - 0
        if (interaction == 0)
        {
            // Caso selecionado uma mão - 0 , deverá receber qual delas é utilizada pelo jogador.
            ControlSide = PlayerPrefs.GetInt("ControlSide");
            LeftJoystick.gameObject.SetActive(ControlSide == 0);
            RightJoystick.gameObject.SetActive(ControlSide == 1);

            

            if (ControlSide == 0)
            {
                eixoX = LeftJoystick.Horizontal();
                eixoY = LeftJoystick.Vertical();
            }
            else if (ControlSide == 1)
            {
                eixoX = RightJoystick.Horizontal();
                eixoY = RightJoystick.Vertical();
            }
            if (Control3D)
            {
                if (eixoX != 0 || eixoY != 0)
                {
                    transform.Translate(0, 0, eixoY);
                    transform.Rotate(0, eixoX, 0);
                }

            }
            else
            {
                if (eixoX > 0)
                {
                    transform.localEulerAngles = new Vector3(0, -90, 0);
                    transform.Translate(0, 0, eixoX / 4);
                }
                else if (eixoX < 0)
                {
                    transform.localEulerAngles = new Vector3(0, 90, 0);
                    transform.Translate(0, 0, -eixoX / 4);
                }
            }
        }
        // Interação por dispositivos externos (Cabo UTG ou Bluetooth) - 1
        else if (interaction == 1)
        {
            SpeedControl = PlayerPrefs.GetFloat("SpeedControl");

            // Ocultando controles
            LeftJoystick.gameObject.SetActive(false);
            RightJoystick.gameObject.SetActive(false);

            // Pegando valores de entrada dos controles
            eixoX = Input.GetAxis("Horizontal") * SpeedControl * 2;
            eixoY = Input.GetAxis("Vertical") * SpeedControl / 2;

            // Controle 3D
            if (Control3D)
            {
                if (eixoX != 0 || eixoY != 0)
                {
                    transform.Translate(0, 0, eixoY);
                    transform.Rotate(0, eixoX, 0);
                }

            }
            else
            // Controle 2D
            {
                if (eixoX > 0)
                {
                    transform.localEulerAngles = new Vector3(0, -90, 0);
                    transform.Translate(0, 0, eixoX / 4);
                }
                else if (eixoX < 0)
                {
                    transform.localEulerAngles = new Vector3(0, 90, 0);
                    transform.Translate(0, 0, -eixoX / 4);
                }
            }

        }
        // Interação de forma Guiada - 2
        else if (interaction == 2)
        {
            // Ocultando controles
            LeftJoystick.gameObject.SetActive(false);
            RightJoystick.gameObject.SetActive(false);

        }

        if (HasAnimator)
        {
            if (eixoX != 0 || eixoY != 0)
            {
                animator.SetBool("isWalking", true);
            }
            else
            {
                animator.SetBool("isWalking", false);
            }
        }
    }



}
