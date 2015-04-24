﻿using UnityEngine;
using System.Collections;

public class GameOverManager : MonoBehaviour {

	
	public PlayerHealth playerHealth;       // Reference to the player's health.
	public float restartDelay = 3f;         // Time to wait before restarting the level
	
	
	Animator anim;                          // Reference to the animator component.
	float restartTimer;                     // Timer to count up to restarting the level
	GameObject player;
	
	void Awake ()
	{
		// Set up the reference.

		player = GameObject.FindGameObjectWithTag ("Prey");
		playerHealth = player.GetComponent <PlayerHealth> ();
		anim = GetComponent <Animator> ();
	}
	
	
	void Update ()
	{
		// If the player has run out of health...
		if(playerHealth.currentHealth <= 0)
		{
			// ... tell the animator the game is over.
			anim.SetTrigger ("GameOver");

			// .. increment a timer to count up to restarting.
			restartTimer += Time.deltaTime;
			
			// .. if it reaches the restart delay...
			if(restartTimer >= restartDelay)
			{
				// .. then reload the currently loaded level.
				Application.LoadLevel(Application.loadedLevel);
			}

		}
	}
}