using UnityEngine;
using System.Collections;

public class PlayerController_Spaceship : MonoBehaviour {

    //Define player variables
    public bool Shielded = false; // Duh
    public int ShieldStrength = 3; // How much "power" the shield has
    [SerializeField] float ShieldDecayRate = .1f; // How much shield we steal every "tick" defined in the tickrate
    [SerializeField] float ShieldDecayTickrate = 1f; // Per second decay rate, for finer tuning

    // Uncategorized
    [SerializeField] float PlayerSpeed = 1f; // The speed of the player
	public int PlayerDamageLevel = 0; // The damage state of the player's craft (up to 3)
    [SerializeField] SpriteRenderer ThrusterRenderer;
    [SerializeField] SpriteRenderer ShieldRenderer;
    [SerializeField] SpriteRenderer DamageOverlay;

	// Projectile stuff ok
	[SerializeField] float FireSpeed = 0.5f; // Player's fire speed per second
	[SerializeField] Rigidbody2D ProjectilePrefab;
	[SerializeField] Transform ProjectileSourceZone;
	private float lastFiredTime = 0; // Sets this variable up early on

	// Define sounds
	[SerializeField] AudioSource FireSound;
	[SerializeField] AudioSource ShieldHitSound;
	[SerializeField] AudioSource PlayerDeathSound;
    [SerializeField] AudioSource ThrusterSound;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1")) { // checks to see if the player is firing
			// Debug.Log ("Fire button is down"); // Debug - prune before the finished product!
			float curTime = Time.time; // captures the current time
			if ((curTime - lastFiredTime) > FireSpeed){ // determines if it's been long enough so we can fire again
                FireSound.Play(); // pew!
				Rigidbody2D projectile; // variable to hold onto it
				projectile = Instantiate(ProjectilePrefab, ProjectileSourceZone.position, ProjectileSourceZone.rotation) as Rigidbody2D; // makes the projectile
				projectile.AddForce(ProjectileSourceZone.forward*10000,ForceMode2D.Impulse); // throws the projectile forwards
                projectile.GetComponent<PlayerBulletScript>().ProjectileSpeed = 8; // sets thhe bullet speed on the script
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
            if (!ThrusterSound.isPlaying)
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
        float angle = (Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg) -90; // i admit to copypasta on this line. the -90 corrects the rotation
                                                                       // programmers who actually took math classes made math libraries for us people...
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward); // grabs our quaternion so we can rotate the character in world space.

	}

}
