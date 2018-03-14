using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerScript : MonoBehaviour
{

    Animator animator;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 50.0f * 1;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 5.0f * 1;

        transform.Translate(0, 0, z);
        transform.Rotate(0, x, 0);

        if (x != 0 || z != 0)
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
       
    }
}
