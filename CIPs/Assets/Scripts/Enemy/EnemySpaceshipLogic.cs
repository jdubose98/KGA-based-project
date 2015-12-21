using UnityEngine;
using System.Collections;

public class EnemySpaceshipLogic : MonoBehaviour {

    public int EnemyHealth = 10; // How much health this enemy has -- public so we can actually damage the enemy
    public int RotationCorrectionValue; //Because we're odd
    [SerializeField] float EnemySpeed = 10; // How fast this enemy moves (TBC)
    [SerializeField] Transform player; // The player's position
    [SerializeField] float EnemyFireRate = 2; // How much of a delay between bullets the enemy has
    [SerializeField] int EnemyProjectileSpeed = 5; // actually i can't use this now
    [SerializeField] GameObject BulletPrefab; // The prefab of the bullet this enemy fires
    [SerializeField] Transform BulletSourceZone; // Refers to the empty gameobject used to spit them out
    [SerializeField] AudioSource FireSound; // Refers to their pew sounds
    [SerializeField] AudioSource DieSound; // Refers to when they go boom
    bool Dead = false; // Death state
    float capturedTime; // So it's accessible by everything in the script
    [SerializeField] bool UseLongHealthBar = false;
    [SerializeField] GameObject HealthbarPrefabShort;
    [SerializeField] GameObject HealthbarPrefabLong;


    void Awake () {
        capturedTime = Time.time; // Init capturedTime
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        if (UseLongHealthBar == true)
            { var healthBar = Instantiate(HealthbarPrefabLong);
            healthBar.GetComponent<HealthbarTracker>().TargetedObject = gameObject.transform;
            healthBar.GetComponent<HealthbarTracker>().LoggedHealth = EnemyHealth;
        }
        else
            { var healthBar = Instantiate(HealthbarPrefabShort);
            healthBar.GetComponent<HealthbarTracker>().TargetedObject = gameObject.transform;
            healthBar.GetComponent<HealthbarTracker>().LoggedHealth = EnemyHealth;
        }

    }

	void Update () {
        if (EnemyHealth <= 0 && !Dead) // If their health is 0 or below and they're not dead yet...
        {
            Dead = true; // He's dead jim
        }
        else if (!Dead) // If the enemy is not dead
        {

            var dir = player.transform.position - transform.position; // Where we need to look
            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + RotationCorrectionValue; // Bringing back the copypasta! Does the math to rotate towards the player
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward); // I hate quaternions

            if (Time.time - capturedTime > EnemyFireRate) // Is the enemy ready to fire?
            {
                capturedTime = Time.time; // Reset our timer
                FireSound.Play(); // Play the sound
                Rigidbody2D projectileClone; // WHY DIDN'T I THINK OF THIS EARLIER AAAAAAAAGH NOW ALL MY PROBLEMS ARE SOLVED (no they're not)
                projectileClone = Instantiate(BulletPrefab, BulletSourceZone.position, BulletSourceZone.rotation) as Rigidbody2D; // create the new projectile


                //if (projectileClone != null)
                //{
                //    Debug.Log("There's a reference here");
                //    if (projectileClone.GetComponent<EnemyBulletScript>() != null)
                //        projectileClone.GetComponent<EnemyBulletScript>().ProjectileSpeed = EnemyProjectileSpeed; //DANGIT IT DOESN'T WORK
                //}
                //else Debug.LogWarning("There appears to be no bullet script here");

            }
        }
        else if (Dead)
        {
            // Todo: Make the enemy blow up into a satisfying shower of bits and pieces.
            Destroy(gameObject);
        }


	}
}
