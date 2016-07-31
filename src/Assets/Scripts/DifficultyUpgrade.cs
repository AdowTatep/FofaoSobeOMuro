using System;
using UnityEngine;

public class DifficultyUpgrade : MonoBehaviour
{
	private variables variables;

	private GameController gameController;

	private void Start()
	{
		this.gameController = Object.FindObjectOfType<GameController>();
		this.variables = Object.FindObjectOfType<variables>();
		base.InvokeRepeating("ChangeDiff", this.variables.diffChangeTime, this.variables.diffChangeTime);
	}

	public void ChangeDiff()
	{
		if (!this.gameController.pauseon && !this.gameController.dying)
		{
			if (this.variables.scoreCounter > this.variables.maxscoreCounter)
			{
				this.variables.scoreCounter -= this.variables.diffMultiplier * 200f;
			}
			if (this.variables.spawnObsRate > -this.variables.maxspawnObsRate)
			{
				this.variables.spawnObsRate -= this.variables.diffMultiplier * 200f;
			}
			if (this.variables.obsMoveSpeed < this.variables.maxobsMoveSpeed)
			{
				this.variables.obsMoveSpeed += this.variables.diffMultiplier * 100f;
			}
			if (this.variables.offsetSpeed < this.variables.maxoffsetSpeed)
			{
				this.variables.offsetSpeed += this.variables.diffMultiplier;
			}
		}
	}
}
