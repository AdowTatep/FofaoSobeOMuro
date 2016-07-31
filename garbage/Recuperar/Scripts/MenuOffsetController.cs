using System;
using UnityEngine;

public class MenuOffsetController : MonoBehaviour
{
	public Material materialz;

	private float menoffsete;

	private void Start()
	{
	}

	private void Update()
	{
		this.menoffsete = this.materialz.GetTextureOffset("_MainTex").x + 0.0005f;
		this.materialz.SetTextureOffset("_MainTex", new Vector2(this.menoffsete, 0f));
	}
}
