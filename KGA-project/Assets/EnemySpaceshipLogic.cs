using UnityEngine;
using System.Collections;

public class EnemySpaceshipLogic : MonoBehaviour {

    public int EnemyHealth = 10;
    [SerializeField] float EnemySpeed = 10;
    [SerializeField] Transform player;
    [SerializeField] float EnemyFireRate = 2;
    [SerializeField] GameObject BulletPrefab;
    [SerializeField] Transform BulletSourceZone;
    [SerializeField] AudioSource FireSound;
    bool Dead = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (EnemyHealth <= 0 && !Dead) // If their health is 0 or below and they're not dead yet...
        {
            Dead = true; // He's dead jim
        }
        if (!Dead) // If the enemy is not dead
        {
            transform.LookAt(player); // Rotate towards the player with laser accuracy
            var capturedTime = Time.time;
            if (Time.time - capturedTime > EnemyFireRate)
            {
                FireSound.Play();
                Rigidbody2D projectile;
                projectile = Instantiate(BulletPrefab, BulletSourceZone.position, BulletSourceZone.rotation) as Rigidbody2D;
                projectile.AddForce(BulletSourceZone.forward * 10000, ForceMode2D.Impulse);
                projectile.GetComponent<PlayerBulletScript>().ProjectileSpeed = 8;
            }
        }
        else if (Dead)
        {
            // Exploderize the guy!
        }


	}
}
