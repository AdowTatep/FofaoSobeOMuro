using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	private byte trackAtual = 1;

	public Animator anim;

	private GameController gameContro;

	public Vector3[] track = new Vector3[3];

	private SpecialController special;

	private void Start()
	{
		this.gameContro = Object.FindObjectOfType<GameController>();
		this.special = Object.FindObjectOfType<SpecialController>();
	}

	private void Update()
	{
		if (!this.gameContro.dying)
		{
			if (Input.GetButtonDown("Up"))
			{
				this.SendUp();
			}
			else if (Input.GetButtonDown("Down"))
			{
				this.SendDown();
			}
		}
	}

	private void SendUp()
	{
		if (this.trackAtual == 0)
		{
			this.special.LaunchSpecial();
		}
		if (this.trackAtual > 0)
		{
			this.trackAtual -= 1;
			base.get_gameObject().get_transform().set_position(this.track[(int)this.trackAtual]);
		}
	}

	private void SendDown()
	{
		if (this.trackAtual < 2)
		{
			this.trackAtual += 1;
			base.get_gameObject().get_transform().set_position(this.track[(int)this.trackAtual]);
		}
	}

	public void SetTrack1Position()
	{
		this.track[0] = base.get_gameObject().get_transform().get_position();
	}

	public void SetTrack2Position()
	{
		this.track[1] = base.get_gameObject().get_transform().get_position();
	}

	public void SetTrack3Position()
	{
		this.track[2] = base.get_gameObject().get_transform().get_position();
	}
}
