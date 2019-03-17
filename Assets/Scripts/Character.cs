using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

	// Get rigidbody collider to allow for movement
	private Rigidbody2D rb;

	[Tooltip("Player movement speed.")]
	public float playerSpeed = 5f;
	[Tooltip("Player jump velocity.")]
	public float jumpForce = 15f;
	[Tooltip("Flip speed. [0.1,2]")]
	public float flipSpeed = 0.4f;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		MovePlayerLeftOrRight();
	}

	/// <summary>
	///  Moves the player left and right between bounds when left and right keys are pressed
	/// </summary>
	private void MovePlayerLeftOrRight()
	{
		Vector3 previousPos = this.transform.position;
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			//Flip player like piece of paper
			if (this.transform.localScale.x >= -1f)
			{
				//Flip slowly
				this.transform.localScale = new Vector3(this.transform.localScale.x - flipSpeed, 1f, 1f);
			}
			else {
				this.transform.localScale = new Vector3(-1f, 1f, 1f);
			}
			this.transform.localScale = new Vector3(-1f, 1f, 1f);
			//Move Player left
			this.transform.position = new Vector3(previousPos.x - playerSpeed * Time.deltaTime, this.transform.position.y, this.transform.position.z);
		}
		else if (Input.GetKey(KeyCode.RightArrow))
		{
			//Flip player like piece of paper
			if (this.transform.localScale.x <= 1f)
			{
				//Flip slowly
				this.transform.localScale = new Vector3(this.transform.localScale.x + flipSpeed, 1f, 1f);
			}
			else {
				this.transform.localScale = new Vector3(1f, 1f, 1f);
			}
			this.transform.localScale = new Vector3(1f, 1f, 1f);
			this.transform.position = new Vector3(previousPos.x + playerSpeed * Time.deltaTime, this.transform.position.y, this.transform.position.z);
		}
		else {
			//If they stop continue in direction of movement
			//Flip player like piece of paper
			if (this.transform.localScale.x >= 0f)
			{
				this.transform.localScale = new Vector3(1f, 1f, 1f);
			}
			else {
				this.transform.localScale = new Vector3(-1f, 1f, 1f);
			}
		}
		if (Input.GetKeyDown(KeyCode.Space))
		{
			if (Mathf.Abs(rb.velocity.y - 0f) <= 0.01f)
			{
				rb.velocity = transform.TransformDirection(Vector2.up) * jumpForce;
			}
		}
	}
}
