using System;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
	public Transform[] obstacles = new Transform[3];

	public float[] obsTrack = new float[3];

	private variables variables;

	private void Start()
	{
		this.variables = Object.FindObjectOfType<variables>();
		this.Spawn();
	}

	private void Spawn()
	{
		int num = Random.Range(0, 3);
		int num2 = Random.Range(0, this.obstacles.Length);
		Object.Instantiate(this.obstacles[num2], new Vector3(base.get_transform().get_position().x, base.get_transform().get_position().y, this.obsTrack[num]), this.obstacles[num2].get_transform().get_rotation());
		base.Invoke("Spawn", this.variables.spawnObsRate);
	}

	public void SetTrack1Obstacle()
	{
		this.obsTrack[0] = base.get_gameObject().get_transform().get_position().z;
	}

	public void SetTrack2Obstacle()
	{
		this.obsTrack[1] = base.get_gameObject().get_transform().get_position().z;
	}

	public void SetTrack3Obstacle()
	{
		this.obsTrack[2] = base.get_gameObject().get_transform().get_position().z;
	}
}
