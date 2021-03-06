﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggPool : MonoBehaviour {

	public int eggPoolSize = 5;
	public GameObject eggPrefab;
	public float spawnRate = 10f;
	public float eggMin = -1f;
	public float eggMax = 5f;
	public float eggXMin = 15f;
	public float eggXMax = 30f;

	private GameObject[] egg;
	private Vector2 objectPoolPosition = new Vector2(-15f, -25f);
	private float timeSinceLastSpawn;
	private int currentegg = 0;

	void Start()
	{
		egg = new GameObject[eggPoolSize];
		for (int i = 0; i < eggPoolSize; i++) {

			egg [i] = (GameObject)Instantiate (eggPrefab, objectPoolPosition, Quaternion.identity);

		}
	}

	void Update()
	{		
		timeSinceLastSpawn += Time.deltaTime;

		if(timeSinceLastSpawn >= spawnRate && GameController.instance.gameOver == false )
		{
			timeSinceLastSpawn = 0;
			float spawnYPosition = Random.Range (eggMin, eggMax);
			float spawnXPosition = Random.Range (eggXMin, eggXMax);
			egg [currentegg].transform.position = new Vector2 (spawnXPosition, spawnYPosition);
			currentegg++;
			if (currentegg >= eggPoolSize) {

				currentegg = 0;
			}
		}
	}

}
