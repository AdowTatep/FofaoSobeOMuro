using System;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
	public Text scoreText;

	private float score;

	private variables variables;

	private void Start()
	{
		this.variables = Object.FindObjectOfType<variables>();
		this.score = 0f;
		base.Invoke("UpdateScore", this.variables.scoreCounter);
	}

	private void Update()
	{
	}

	private void UpdateScore()
	{
		this.score += 1f;
		this.scoreText.text = string.Empty + this.score + "m";
		base.Invoke("UpdateScore", this.variables.scoreCounter);
	}
}
