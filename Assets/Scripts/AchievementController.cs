using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementController : MonoBehaviour
{
	bool achieved = false;

	public void UnlockAchievement()
	{
		if (!achieved) StartCoroutine(ShowAchievement());
	}

	IEnumerator ShowAchievement()
	{
		while (transform.position.y < -3.5f)
		{
			transform.Translate(0f, 0.01f, 0f);
			yield return null;
		}
		yield return new WaitForSeconds(2f);
		SpriteRenderer sr = GetComponent<SpriteRenderer>();
		while (sr.color.a > 0)
		{
			sr.color = Color.Lerp(sr.color, new Color(1f, 1f, 1f, 0f), 0.001f);
			yield return null;
		}
	}
}
