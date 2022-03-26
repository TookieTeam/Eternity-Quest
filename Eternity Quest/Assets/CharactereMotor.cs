using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactereMotor : MonoBehaviour {

    // animation du perso
    Animation animation;

    // vitesse de déplacement
    public float walkSpeed;
    public float runSpeed;
    public float strafeSpeed;
    public float turnSpeed;

    // Inputes
    public string inputFront;
    public string inputBack;
    public string inputLeft;
    public string inputRight;

    public Vector3 jumpSpeed;
    CapsuleCollider playerCollider;



    void Start () {
        animation = gameObject.GetComponent<Animation>();
        playerCollider = gameObject.GetComponent<CapsuleCollider>();
	}

    public bool IsGrounded()
    {
        return Physics.CheckCapsule(playerCollider.bounds.center, new Vector3(playerCollider.bounds.center.x, playerCollider.bounds.min.y - 0.1f, playerCollider.bounds.center.z), 0.09f);
       
    }

	void Update () {
        // si on avance
		if(Input.GetKey(inputFront) && !Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(0,0, walkSpeed * Time.deltaTime);
            animation.Play("walk");
        }

        // si on avance
        if (Input.GetKey(inputFront) && Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(0, 0, runSpeed * Time.deltaTime);
            animation.Play("run");
        }

        // si on recule
        if (Input.GetKey(inputBack))
        {
            transform.Translate(0, 0, -(walkSpeed / 2) * Time.deltaTime);
            animation.Play("walk");
        }
        // rotation left
        if (Input.GetKey(inputLeft))
        {
            transform.Rotate(0, -turnSpeed * Time.deltaTime, 0);   
        }

        // rotation right
        if (Input.GetKey(inputRight))
        {
            transform.Rotate(0, turnSpeed * Time.deltaTime, 0);
        }

       

        // si aucune action alors animation afk
        if (!Input.GetKey(inputFront) && !Input.GetKey(inputBack))
        {
            animation.Play("idle");
        }

        // pour sauter
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // préparation du saut
            Vector3 v = gameObject.GetComponent<Rigidbody>().velocity;
            v.y = jumpSpeed.y;

            // execution du saut
            gameObject.GetComponent<Rigidbody>().velocity = jumpSpeed;
         
        }

    }
}
