using UnityEngine;
using System.Collections;

public class PlayerController_Spaceship : MonoBehaviour {

	//Define player variables
	public float PlayerSpeed = 1f; // The speed of the player
	public int DamageLevel = 0; // The damage state of the player's craft (up to 3)
	public bool Shielded = false; // Duh
	public int ShieldStrength = 3; // How much "power" the shield has
	public float TimeLeftOnShield = 10f; // A hard limit
	public float ShieldDecayRate = .1f; // How much shield we steal every "tick" defined in the tickrate
	public float ShieldDecayTickrate = 1f; // Per second decay rate, for finer tuning

	// Define sounds
	public AudioSource FireSound;
	public AudioSource ShieldHitSound;
	public AudioSource PlayerDeathSound;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1")) {
			Debug.Log ("Fire button is down");
		}
		else if (Input.GetAxis ("Vertical") !=0 || Input.GetAxis ("Horizontal") !=0 )
		{
			transform.Translate(0,Input.GetAxis("Vertical")*PlayerSpeed,0);
			transform.Translate(Input.GetAxis("Horizontal")*PlayerSpeed,0,0);
		}
	}

}
