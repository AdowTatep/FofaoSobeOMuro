using System;
using UnityEngine;

public class OffsetController : MonoBehaviour
{
	public Material material;

	public Animator anim;

	private variables variables;

	private float offsete;

	private GameController gameController;

	private void Start()
	{
		this.gameController = Object.FindObjectOfType<GameController>();
		this.material.SetTextureOffset("_MainTex", new Vector2(0f, 0f));
		this.variables = Object.FindObjectOfType<variables>();
	}

	private void Update()
	{
		if (!this.gameController.pauseon && !this.gameController.dying)
		{
			this.offsete = this.material.GetTextureOffset("_MainTex").x + this.variables.offsetSpeed;
			this.material.SetTextureOffset("_MainTex", new Vector2(this.offsete, 0f));
			if (this.anim)
			{
				this.anim.SetFloat("speed", this.variables.offsetSpeed + 1f);
			}
		}
	}
}
