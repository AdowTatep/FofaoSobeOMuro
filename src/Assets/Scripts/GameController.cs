using System;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
	public GameObject playing;

	public GameObject paused;

	public GameObject final;

	public Text scoreDeath;

	public Text scorePause;

	public Text scoreAt;

	public Text pauseDeath;

	public Text endDeath;

	private PlayerController playerCont;

	private int numberOfDeaths;

	public bool dying;

	private variables variables;

	public bool pauseon;

	public AudioSource[] soundEff;

	private float defscoreCounter;

	private float defspawnObsRate;

	private float defobsMoveSpeed;

	private float defoffsetSpeed;

	private void Start()
	{
		this.variables = Object.FindObjectOfType<variables>();
		this.playerCont = Object.FindObjectOfType<PlayerController>();
		this.numberOfDeaths = PlayerPrefs.GetInt("numberOfDeaths", 0);
		this.defscoreCounter = 0.03f;
		this.defspawnObsRate = 2f;
		this.defobsMoveSpeed = 0.16f;
		this.defoffsetSpeed = 0.8f;
	}

	public void Pause()
	{
		this.pauseon = !this.pauseon;
		if (this.pauseon)
		{
			this.playing.SetActive(false);
			this.paused.SetActive(true);
			Time.set_timeScale(0f);
			this.scorePause.text = this.scoreAt.text;
			this.pauseDeath.text = this.numberOfDeaths.ToString();
		}
		else
		{
			this.playing.SetActive(true);
			this.paused.SetActive(false);
			Time.set_timeScale(1f);
		}
	}

	public void Death()
	{
		this.dying = true;
		this.playerCont.anim.SetTrigger("died");
		base.Invoke("DeathCall", 1f);
	}

	public void DeathCall()
	{
		this.numberOfDeaths++;
		PlayerPrefs.SetInt("numberOfDeaths", this.numberOfDeaths);
		this.scoreDeath.text = this.scoreAt.text;
		this.endDeath.text = this.numberOfDeaths.ToString();
		this.final.SetActive(true);
		this.playing.SetActive(false);
		Time.set_timeScale(0f);
	}

	public void Reset()
	{
		Application.LoadLevel(Application.get_loadedLevel());
		Time.set_timeScale(1f);
		this.variables.scoreCounter = this.defscoreCounter;
		this.variables.spawnObsRate = this.defspawnObsRate;
		this.variables.obsMoveSpeed = this.defobsMoveSpeed;
		this.variables.offsetSpeed = this.defoffsetSpeed;
	}

	public void Menu()
	{
		Application.LoadLevel("Menu");
	}

	public void PlaySound(int audioNum)
	{
		this.soundEff[audioNum].Play(0uL);
	}
}
