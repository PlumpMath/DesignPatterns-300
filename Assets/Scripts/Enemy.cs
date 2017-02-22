using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy
{
	public GameObject gameObject;
	protected float speed;

	public Enemy(GameObject gameObject)
	{
		this.gameObject = Object.Instantiate(gameObject);
	}

	public Enemy(GameObject gameObject, float speed)
	{
		this.gameObject = Object.Instantiate(gameObject);
		this.speed = speed;
	}

	public void Update()
	{
		gameObject.transform.Translate(-speed, 0f, 0f);
	}

	public Enemy Clone()
	{
		return new Enemy(gameObject, speed);
	}
}

public class BlueEnemy : Enemy
{
	public BlueEnemy(GameObject gameObject) : base (gameObject)
	{
		speed = 0.05f;
		this.gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
	}
}

public class RedEnemy : Enemy
{
	public RedEnemy(GameObject gameObject) : base(gameObject)
	{
		speed = 0.1f;
		this.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
	}
}