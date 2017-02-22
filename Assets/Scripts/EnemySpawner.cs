using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	public GameObject enemyGameObject;

	List<Enemy> instantiatedEnemies = new List<Enemy>();

	void Start ()
	{

		StartCoroutine(SpawnEnemies());
	}
	
	void Update ()
	{
		foreach (Enemy enemy in instantiatedEnemies)
		{
			enemy.Update();
		}
	}

	IEnumerator SpawnEnemies()
	{
		while (true)
		{
			Enemy newEnemy;

			if (Random.Range(0, 2) == 0) newEnemy = new BlueEnemy(enemyGameObject);
			else newEnemy = new RedEnemy(enemyGameObject);

			newEnemy.gameObject.transform.position = new Vector3(32f, -4f, 0f);
			instantiatedEnemies.Add(newEnemy);

			yield return new WaitForSeconds(2f);
		}
	}
}
