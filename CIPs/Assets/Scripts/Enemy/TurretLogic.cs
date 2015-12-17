using UnityEngine;
using System.Collections;

public class TurretLogic : MonoBehaviour {
    [SerializeField] Transform player; // The player's position
    [SerializeField] float EnemyFireRate = 2f; // How much of a delay between bullets the enemy has
    [SerializeField] GameObject BulletPrefab; // The prefab of the bullet this enemy fires
    [SerializeField] AudioSource FireSound; // Refers to their pew sounds
    [SerializeField] Transform BulletSourceZone;
    [SerializeField] Transform BulletSourceZone2;
    bool Dead = false; // Death state
    float capturedTime; // So it's accessible by everything in the script
    int bulletTick = 0;

    // Use this for initialization
    void Start () {
        InvokeRepeating("SpamFire",1,EnemyFireRate);
    }
	
	// Update is called once per frame
	void Update () {
        var dir = player.transform.position - transform.position; // Where we need to look
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90; // Bringing back the copypasta! Does the math to rotate towards the player
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward); // I hate quaternions

        
    }

    void SpamFire()
    {
        for (int i = 0; i <= 10; i++)
        {
                if (bulletTick == 0 && (Time.time > capturedTime - EnemyFireRate))
                { // odd tick
                capturedTime = Time.time;
                    FireSound.Play(); // Play the sound
                    gameObject.transform.Rotate(0, 0, Random.Range(2, 2));
                    Rigidbody2D projectileClone; // WHY DIDN'T I THINK OF THIS EARLIER AAAAAAAAGH NOW ALL MY PROBLEMS ARE SOLVED (no they're not)
                    projectileClone = Instantiate(BulletPrefab, BulletSourceZone.position, BulletSourceZone.rotation) as Rigidbody2D;
                    bulletTick = 1;
                } // create the new projectile
                else
                {
                // even tick
                capturedTime = Time.time;
                    FireSound.Play(); // Play the sound
                    gameObject.transform.Rotate(0, 0, Random.Range(2, 2));
                    Rigidbody2D projectileClone;
                    projectileClone = Instantiate(BulletPrefab, BulletSourceZone2.position, BulletSourceZone2.rotation) as Rigidbody2D;
                    bulletTick = 0;
            }
        }
    }
}
