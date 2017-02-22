using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
	Rigidbody2D rigidBody;
	
	float speed = 5f;
	float originalX;

	void Start()
	{
		originalX = transform.position.x;
		rigidBody = GetComponent<Rigidbody2D>();
		rigidBody.velocity = new Vector2(speed, 0f);
	}

	void FixedUpdate()
	{
		if (transform.position.x >= originalX + 3.99f)
		{
			rigidBody.velocity = new Vector2(-speed, 0f);
		}
		if (transform.position.x <= originalX + 0.01f)
		{
			rigidBody.velocity = new Vector2(speed, 0f);
		}
	}
}
