using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float maxSpeed = 2.5f;
	Animator animator;
	bool facingRight = false;

	void Awake () {
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

		float move = Input.GetAxis("Horizontal");
		animator.SetFloat("moveSpeedx", Mathf.Abs (move));
		rigidbody2D.velocity = new Vector2(move * maxSpeed, rigidbody2D.velocity.y);
		if ((move < 0 && !facingRight) || (move > 0 && facingRight))
			Flip();

		float move2 = Input.GetAxis("Vertical");
		animator.SetFloat("moveSpeedy", move2);
		rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, move2 * maxSpeed);

	}

	void Flip()
	{
		facingRight = !facingRight;
		Vector3 nextScale = transform.localScale;
		nextScale.x *= -1f;
		transform.localScale = nextScale;
	}
}
