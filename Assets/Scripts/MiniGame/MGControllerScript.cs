using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MGControllerScript : MonoBehaviour {

    Animator animator;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
	}

    // Update is called once per frame
    void FixedUpdate() {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 10.0f * 1;
        //svar z = Input.GetAxis("Vertical") * Time.deltaTime * 5.0f * 1;

       
        //transform.Rotate(0, x, 0);


        if (Input.GetAxis("Horizontal") > 0)
        {
            transform.localEulerAngles = new Vector3(0, -90, 0);
            transform.Translate(0, 0, x);
        }
        else if(Input.GetAxis("Horizontal") < 0)
        {
            transform.localEulerAngles = new Vector3(0, 90, 0);
            transform.Translate(0, 0, -x);
        }

            if (x != 0)
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
    }

}
