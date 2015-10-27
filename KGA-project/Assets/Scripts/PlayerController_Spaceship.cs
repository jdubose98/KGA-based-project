using UnityEngine;
using System.Collections;

public class PlayerController_Spaceship : MonoBehaviour {

    //Define player variables
    public bool Shielded = false; // Duh
    public int ShieldStrength = 3; // How much "power" the shield has
    public float TimeLeftOnShield = 10f; // A hard limit
    public float ShieldDecayRate = .1f; // How much shield we steal every "tick" defined in the tickrate
    public float ShieldDecayTickrate = 1f; // Per second decay rate, for finer tuning

    // Uncategorized
    public float PlayerSpeed = 1f; // The speed of the player
	public int DamageLevel = 0; // The damage state of the player's craft (up to 3)
    public SpriteRenderer ThrusterRenderer;
    public SpriteRenderer ShieldRenderer;
    public SpriteRenderer DamageOverlay;

	// Projectile stuff ok
	public float FireSpeed = 0.5f; // Player's fire speed per second
	public Rigidbody2D ProjectilePrefab;
	public Transform ProjectileSourceZone;
	private float lastFiredTime = 0; // Sets this variable up early on

	// Define sounds
	public AudioSource FireSound;
	public AudioSource ShieldHitSound;
	public AudioSource PlayerDeathSound;
    public AudioSource ThrusterSound;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1")) { // checks to see if the player is firing
			Debug.Log ("Fire button is down"); // just debugging
			float curTime = Time.time; // captures the current time
			if ((curTime - lastFiredTime) > FireSpeed){ // determines if it's been long enough so we can fire again
				//Rigidbody2D projectile;
				//projectile = Instantiate(ProjectilePrefab, ProjectileSourceZone.position, ProjectileSourceZone.rotation) as Rigidbody2D;
				//projectile.AddForce(ProjectileSourceZone.forward*100,ForceMode2D.Impulse);
			}
		}

        // Control player movement
        var vect = new Vector3(Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"), 0); // Gets a new vector using the axes we're moving on.
		{
			transform.position = transform.position + (PlayerSpeed * vect.normalized * Time.deltaTime); // normalized vector (no cheating!) is mult. by the speed variable, then mult. by deltaTime to keep the speed consistent even under lag.
            Camera.main.transform.position = transform.position + (PlayerSpeed * vect.normalized * Time.deltaTime) + new Vector3 (0,0,-10); // tracks the player
        }

        // Handle displaying of thruster tail
        if (Input.GetAxisRaw ("Horizontal") != 0 || Input.GetAxisRaw ("Vertical") != 0) // Choosing raw because it cuts the thruster out and in instantly
        {
            ThrusterRenderer.enabled = true;
            if (ThrusterSound.isPlaying)
            ThrusterSound.Play();
        }
        else
        {
            ThrusterRenderer.enabled = false;
            if (ThrusterSound.isPlaying)
                ThrusterSound.Stop();
        }

        // Rotate player towards cursor
        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 dir = Input.mousePosition - pos;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg; // i admit to copypasta on this line.
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

	}

}
