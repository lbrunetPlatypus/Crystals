using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {
	public GameObject Maxim;
	public float maxSpeed = 2.5f;
	Animator maximAnimator;
	bool facingRight = false;
	
	void Awake () {
		maximAnimator = Maxim.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		float horizontal= Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");

		//Maxim Animation
		maximAnimator.SetFloat("moveSpeedx", Mathf.Abs (horizontal));
		Maxim.rigidbody2D.velocity = new Vector2(horizontal * maxSpeed, Maxim.rigidbody2D.velocity.y);
		if ((horizontal < 0 && !facingRight) || (horizontal > 0 && facingRight))
			Flip();

		maximAnimator.SetFloat("moveSpeedy", vertical);
		Maxim.rigidbody2D.velocity = new Vector2(Maxim.rigidbody2D.velocity.x, vertical * maxSpeed);
		
	}
	
	void Flip()
	{
		facingRight = !facingRight;
		Vector3 nextScale = Maxim.transform.localScale;
		nextScale.x *= -1f;
		Maxim.transform.localScale = nextScale;
	}
}
