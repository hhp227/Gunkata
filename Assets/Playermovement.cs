using UnityEngine;
using System.Collections;

public class Playermovement : MonoBehaviour {

	public float movePower = 1f;
	public float jumpPower = 1f;

	Rigidbody2D rigid;
	Animator animator;

	Vector3 movement;
	bool isJumping = false;

	//---------------------------------------------------[Override Function]
	//Initialization
	void Start ()
	{
		rigid = gameObject.GetComponent<Rigidbody2D> ();
		animator = gameObject.GetComponentInChildren<Animator> ();
	}

	//Graphic & Input Updates	
	void Update ()
	{
        if (Input.GetAxisRaw ("Horizontal") < 0) {
			animator.SetInteger("Direction", -1);
		}

        else if (Input.GetAxisRaw ("Horizontal") > 0) {
            animator.SetInteger("Direction", 1);
        }

        if (Input.GetButtonDown ("Jump")) {
			isJumping = true;
		}
	}

	//Physics engine Updates
	void FixedUpdate ()
	{
		Move ();
		Jump ();
	}

	//---------------------------------------------------[Movement Function]

	void Move ()
	{		
		Vector3 moveVelocity= Vector3.zero;

		if (Input.GetAxisRaw ("Horizontal") < 0) {
			moveVelocity = Vector3.left;
		}
			
		else if(Input.GetAxisRaw ("Horizontal") > 0){
			moveVelocity = Vector3.right;
        }	

		transform.position += moveVelocity * movePower * Time.deltaTime;
	}

	void Jump ()
	{
		if (!isJumping)
			return;

		//Prevent Velocity amplification.
		rigid.velocity = Vector2.zero;

		Vector2 jumpVelocity = new Vector2 (0, jumpPower);
		rigid.AddForce (jumpVelocity, ForceMode2D.Impulse);

		isJumping = false;
	}
}
//����