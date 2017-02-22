using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public GameObject achievement;

	GameObject mainCamera;

	Rigidbody2D rigidBody;
	Animator animator;

	float speed = 10f;
	float jumpForce = 2000f;

	void Start ()
	{
		mainCamera = Camera.main.gameObject;
		rigidBody = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
	}

	void Update ()
	{
		mainCamera.transform.position = new Vector3(Mathf.Clamp(transform.position.x, 0f, 20f), mainCamera.transform.position.y, mainCamera.transform.position.z);
	}

	void FixedUpdate ()
	{
		float direction = Input.GetAxis("Horizontal");
		rigidBody.velocity = new Vector2(direction * speed, rigidBody.velocity.y);
		if (direction != 0)
		{
			animator.SetBool("isRunning", true);
			transform.localScale = new Vector3(Mathf.Sign(direction), 1f, 1f);
		}
		else
		{
			animator.SetBool("isRunning", false);
		}

		RaycastHit2D hit = Physics2D.Raycast((Vector2)transform.position + Vector2.down * 0.01f, Vector2.down, 0.01f);

		if (Input.GetAxis("Jump") > 0 && hit.collider != null)
		{
			rigidBody.AddForce(new Vector2(0f, jumpForce));
		}

		if (hit.collider != null)
		{
			animator.SetBool("isJumping", false);
			Rigidbody2D colliderRigi;
			if ((colliderRigi = hit.collider.GetComponent<Rigidbody2D>()) != null)
			{
				rigidBody.velocity += colliderRigi.velocity;
				achievement.GetComponent<AchievementController>().UnlockAchievement();
			}
		}
		if (hit.collider == null)
			animator.SetBool("isJumping", true);
	}
}
