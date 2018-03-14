using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class MobileInput : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler {

	private Image BackgroundImage;
	private Image JoystickButton;
	private Vector3 InputVector;
    public Vector2 DefaultSizeBackground;
    public Vector2 DefaultSizeJoystick;

    // ATRIBUTOS DE CONFIGURAÇÃO
    private float ControlSize;
    private float ControlSide;
    private float SpeedControl;

	void OnEnable(){

        Debug.Log("Mobile Enable - "+DateTime.Now);

		ControlSize = PlayerPrefs.GetFloat ("ControlSize");
        ControlSide = PlayerPrefs.GetInt("ControlSide");
        SpeedControl = PlayerPrefs.GetFloat("SpeedControl");

        BackgroundImage = GetComponent<Image>();
        JoystickButton = transform.GetChild(0).GetComponent<Image>();

        // Tamanho do Controle
        BackgroundImage.rectTransform.sizeDelta = new Vector2(ControlSize * 300 + DefaultSizeBackground.x
            , ControlSize * 300 + DefaultSizeBackground.y);
        JoystickButton.rectTransform.sizeDelta = new Vector2(ControlSize * 300 + DefaultSizeJoystick.x
            , ControlSize * 300 + DefaultSizeJoystick.y);

        if (ControlSide == 0)
        {
            BackgroundImage.rectTransform.anchoredPosition = (new Vector2(BackgroundImage.rectTransform.sizeDelta.x, 0));
        }
    }

	// Use this for initialization
	void Start () {
        Debug.Log("Mobile Input Start");
        ControlSide = PlayerPrefs.GetInt("ControlSide");
	}
    


	// Update is called once per frame
	void Update () {

	}

	public virtual void OnDrag(PointerEventData data){

		Vector2 pos;
		if (RectTransformUtility.ScreenPointToLocalPointInRectangle (BackgroundImage.rectTransform
			, data.position
			, data.pressEventCamera
			, out pos)) 
		{
			pos.x = (pos.x / BackgroundImage.rectTransform.sizeDelta.x);
			pos.y = (pos.y / BackgroundImage.rectTransform.sizeDelta.y);

			InputVector = new Vector3 (pos.x*2 + 1, 0, pos.y*2 -1 );
			InputVector = (InputVector.magnitude > 1.0) ? InputVector.normalized : InputVector;

			Debug.Log (InputVector);

			// Movendo a imagem do Joystick
			JoystickButton.rectTransform.anchoredPosition = 
				new Vector3(InputVector.x * (BackgroundImage.rectTransform.sizeDelta.x/20)
					,InputVector.z * BackgroundImage.rectTransform.sizeDelta.y/20);
		}
	}

	public virtual void OnPointerDown(PointerEventData data){
		OnDrag (data);
	}

	public virtual void OnPointerUp(PointerEventData data){
		InputVector = Vector3.zero;
		JoystickButton.rectTransform.anchoredPosition = Vector3.zero;
	}

	public float Horizontal(){
		if (InputVector.x != 0) {
			return InputVector.x * SpeedControl * 2;
		} else {
			return Input.GetAxis ("Horizontal") * SpeedControl * 2;
		}
	}

	public float Vertical(){
		if (InputVector.z != 0) {
			return InputVector.z * SpeedControl / 2;
		} else {
			return Input.GetAxis ("Vertical") * SpeedControl / 2;
		}
	}

}
