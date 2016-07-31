using System;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
	public GameObject tutorialBox;

	public void Start()
	{
		Time.set_timeScale(1f);
	}

	public void PlayGame()
	{
		Application.LoadLevel("Game");
	}

	public void Tutorial()
	{
		this.tutorialBox.SetActive(true);
	}

	public void BackMenu()
	{
		this.tutorialBox.SetActive(false);
	}
}
