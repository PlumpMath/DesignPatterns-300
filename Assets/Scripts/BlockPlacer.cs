using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockPlacer : MonoBehaviour
{
	public GameObject block;

	List<GameObject> blocks = new List<GameObject>();

	void Start ()
	{
		
	}

	void Update ()
	{
		if (Input.GetMouseButtonDown(0))
		{
			GameObject newBlock = Instantiate(block);
			Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			newBlock.transform.position = new Vector3(Mathf.Round(pos.x + 0.5f) - 0.5f, Mathf.Round(pos.y + 0.5f) - 0.5f, 0f);
			blocks.Add(newBlock);
		}
		if (Input.GetMouseButtonDown(1) && blocks.Count > 0)
		{
			Destroy(blocks[blocks.Count - 1]);
			blocks.RemoveAt(blocks.Count - 1);
		}
	}
}
