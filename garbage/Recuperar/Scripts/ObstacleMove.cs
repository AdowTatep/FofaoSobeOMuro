using System;
using UnityEngine;

public class ObstacleMove : MonoBehaviour
{
	private Vector3 pos;

	public float desPos;

	private GameController gameCont;

	private variables variables;

	private void Start()
	{
		this.variables = Object.FindObjectOfType<variables>();
		this.gameCont = Object.FindObjectOfType<GameController>();
	}

	private void Update()
	{
		if (!this.gameCont.pauseon && !this.gameCont.dying)
		{
			base.get_transform().set_position(new Vector3(base.get_transform().get_position().x - this.variables.obsMoveSpeed, base.get_transform().get_position().y, base.get_transform().get_position().z));
			if (base.get_transform().get_position().x < this.desPos)
			{
				Object.Destroy(base.get_gameObject());
			}
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		this.gameCont.Death();
	}
}
