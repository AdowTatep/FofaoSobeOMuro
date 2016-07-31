using System;
using UnityEngine;
using UnityEngine.UI;

public class SpecialController : MonoBehaviour
{
	private variables variables;

	private GameController gameCont;

	public GameObject noMuro;

	public GameObject noJogo;

	public int specialDuration;

	public Image specialBar;

	public bool specialDisp;

	public bool onSpecial;

	public Animator anim;

	private float actscoreCounter;

	private float actspawnObsRate;

	private float actobsMoveSpeed;

	private float actoffsetSpeed;

	private void Start()
	{
		this.variables = Object.FindObjectOfType<variables>();
		this.gameCont = Object.FindObjectOfType<GameController>();
	}

	private void Update()
	{
		if (!this.gameCont.soundEff[0].get_isPlaying() && this.specialBar.fillAmount == 1f && !this.gameCont.pauseon && !this.gameCont.dying)
		{
			this.gameCont.PlaySound(0);
		}
		this.specialBar.fillAmount += this.variables.specialBarFill * Time.get_deltaTime();
		if (this.specialBar.fillAmount == 1f && !this.gameCont.pauseon && !this.gameCont.dying)
		{
			this.specialDisp = true;
			this.anim.SetBool("specialOn", true);
		}
		else
		{
			this.anim.SetBool("specialOn", false);
		}
		if (this.onSpecial)
		{
			this.specialBar.fillAmount -= this.variables.specialBarFill * (Time.get_deltaTime() * 5f);
			if (this.specialBar.fillAmount == 0f)
			{
				this.SpecialOff();
			}
			if (Input.GetButtonDown("Jump"))
			{
				this.specialBar.fillAmount += 0.06f;
			}
		}
	}

	public void LaunchSpecial()
	{
		if (this.specialDisp)
		{
			this.onSpecial = true;
			this.noJogo.SetActive(false);
			this.noMuro.SetActive(true);
			base.Invoke("SpecialOff", (float)this.specialDuration);
			this.specialBar.fillAmount = 0.3f;
			this.actscoreCounter = this.variables.scoreCounter;
			this.actspawnObsRate = this.variables.spawnObsRate;
			this.actobsMoveSpeed = this.variables.obsMoveSpeed;
			this.actoffsetSpeed = this.variables.offsetSpeed;
		}
	}

	public void SpecialOff()
	{
		this.specialDisp = false;
		this.onSpecial = false;
		this.noJogo.SetActive(true);
		this.noMuro.SetActive(false);
		if (this.specialBar.fillAmount >= 0.75f)
		{
			this.gameCont.PlaySound(1);
			this.variables.scoreCounter = this.actscoreCounter * 4f;
			this.variables.spawnObsRate = this.actspawnObsRate * 1.3f;
			this.variables.obsMoveSpeed = this.actobsMoveSpeed / 4f;
			this.variables.offsetSpeed = this.actoffsetSpeed / 4f;
		}
		this.specialBar.fillAmount = 0f;
	}
}
