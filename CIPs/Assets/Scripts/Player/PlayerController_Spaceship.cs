using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController_Spaceship : MonoBehaviour {

    // Define player variables
    public bool Shielded = false; // Duh
    public float ShieldStrength = 40; // How much "power" the shield has
    [SerializeField] float MaxShieldStrength = 40;
    [SerializeField] float ShieldDecayRate = .1f; // How much shield we steal every "tick" defined in the tickrate
    [SerializeField] float ShieldDecayTickrate = 1f; // Per second decay rate, for finer tuning

    // Uncategorized
    [SerializeField] float PlayerSpeed = 1f; // The speed of the player
	public int PlayerDamageLevel = 0; // The damage state of the player's craft (up to 3)

    // Sprite renderers
    [SerializeField] SpriteRenderer ThrusterRenderer;
    [SerializeField] SpriteRenderer ShieldRenderer;
    [SerializeField] SpriteRenderer DamageOverlay;

	// Projectile info
	[SerializeField] float FireSpeed = 0.5f; // Player's fire speed per second
	[SerializeField] Rigidbody2D ProjectilePrefab;
	[SerializeField] Transform ProjectileSourceZone;
	private float lastFiredTime = 0; // Sets this variable up early on

	// Define sounds
	[SerializeField] AudioSource FireSound;
	[SerializeField] AudioSource ShieldHitSound;
	[SerializeField] AudioSource PlayerDeathSound;
    [SerializeField] AudioSource ThrusterSound;

    // GUI
    [SerializeField] GameObject GUIOverlay;
    [SerializeField] Image ShieldBar;

    // Colliders
    [SerializeField] Collider2D ShieldCollider;

    //Particles
    [SerializeField] ParticleSystem ShieldEmitter;
    [SerializeField] ParticleSystem FireEmitter;

    // Others
    int lerpDelay = 1;
    bool DecayCoroutineRunning = false;



	// Use this for initialization
	void Start () {
        StartCoroutine(ShieldDecayAndUpdate(ShieldDecayTickrate, ShieldDecayRate, ShieldBar));
        DecayCoroutineRunning = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (GUIOverlay.GetComponent<UserInterfaceLogic>().GamePaused == false) // Checks to see if the game is paused
        {

            if (ShieldStrength > 0 && DecayCoroutineRunning == false && Shielded == true) // Is shield down and no coroutine running?
            {
                StartCoroutine(ShieldDecayAndUpdate(ShieldDecayTickrate, ShieldDecayRate, ShieldBar));
            }

            if (Input.GetButtonDown("Fire1")) // checks to see if the player is firing
            { 
                float curTime = Time.time; // captures the current time
                if ((curTime - lastFiredTime) > FireSpeed)
                { // determines if it's been long enough so we can fire again
                    FireSound.Play(); // pew!
                    Rigidbody2D projectile; // variable to hold onto it
                    projectile = Instantiate(ProjectilePrefab, ProjectileSourceZone.position, ProjectileSourceZone.rotation) as Rigidbody2D; // makes the projectile
                    projectile.AddForce(ProjectileSourceZone.forward * 10000, ForceMode2D.Impulse); // throws the projectile forwards
                    projectile.GetComponent<PlayerBulletScript>().ProjectileSpeed = 12; // sets the bullet speed on the script
                }
            }

            // Control player and camera movement
            var vector = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0); // Gets a new vector using the axes we're moving on.
            {
                transform.position = transform.position + (PlayerSpeed * vector.normalized * Time.deltaTime); // normalized vector (no cheating!) is mult. by the speed variable, then mult. by deltaTime to keep the speed consistent even under lag.
                Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, transform.position + new Vector3(0, 0, -10), lerpDelay); // Camera tracks the player
            }

            // Handle displaying of thruster tail
            if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0) // Choosing raw because it cuts the thruster out and in instantly
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
            float angle = (Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg) - 90; // i admit to copypasta on this line. the -90 corrects the rotation
                                                                            // programmers who actually took math classes made math libraries for us people...
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward); // grabs our quaternion so we can rotate the character in world space.
        }
	}

    IEnumerator ShieldDecayAndUpdate(float m_rateTime, float m_rateDamage, Image guiBar)
    {
        if (ShieldStrength >= 0) { 
            ShieldStrength = ShieldStrength - m_rateDamage; // Slowly nibble away at the shield
            ShieldBar.fillAmount = ShieldStrength / MaxShieldStrength;
            yield return new WaitForSeconds(m_rateTime);
            StartCoroutine(ShieldDecayAndUpdate(ShieldDecayTickrate,ShieldDecayRate,ShieldBar));
        }

        if (ShieldStrength <= 0)
        {
            ShieldStrength = 0;
            Shielded = false;
            ShieldRenderer.enabled = false;
            ShieldCollider.enabled = false;
            ShieldEmitter.Play();
            yield return new WaitForSeconds(0.2f);
            ShieldEmitter.Stop();
        }
    }
}
