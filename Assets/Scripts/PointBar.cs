﻿using TMPro;
using UnityEngine;

public class PointBar : MonoBehaviour
{
	public TMP_Text pointText;
	private int point = 0; 
	public void IncreasePoint(int amount)
	{
		point += amount;
		UpdatePointText();

		GameManager.instance.IncreaseScore(amount);
        GameManager.instance.IncreaseSpeed();
    }

    void UpdatePointText()
	{
		if (pointText != null)
		{
			pointText.text = point.ToString();
		}
	}
}
