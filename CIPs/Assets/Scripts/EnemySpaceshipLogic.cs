using UnityEngine;
using System.Collections;

public class EnemySpaceshipLogic : MonoBehaviour {

    public int EnemyHealth = 10;
    [SerializeField] float EnemySpeed = 10;
    [SerializeField] int BulletSpeed;
    [SerializeField] Transform player;
    [SerializeField] float EnemyFireRate = 2;
    [SerializeField] GameObject BulletPrefab;
    [SerializeField] Transform BulletSourceZone;
    [SerializeField] AudioSource FireSound;
    [SerializeField] AudioSource DieSound;
    bool Dead = false;
    float capturedTime;
    // Use this for initialization
    void Awake () {
        capturedTime = Time.time;
    }
	
	// Update is called once per frame
	void Update () {
        if (EnemyHealth <= 0 && !Dead) // If their health is 0 or below and they're not dead yet...
        {
            Dead = true; // He's dead jim
        }
        else if (!Dead) // If the enemy is not dead
        {

            var dir = player.transform.position - transform.position; // Where we need to look
            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + 90; // Bringing back the copypasta! Does the math to rotate towards the player
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward); // I hate quaternions

            if (Time.time - capturedTime > EnemyFireRate) // Is the enemy ready to fire?
            {
                capturedTime = Time.time;
                Debug.Log("Fired");
                FireSound.Play();
                Rigidbody2D projectileClone = Instantiate(BulletPrefab, BulletSourceZone.position, BulletSourceZone.rotation) as Rigidbody2D; // create the new projectile
                projectileClone.GetComponent<EnemyBulletScript>().ProjectileSpeed = 4;
                //projectile.transform.Rotate(0,0,Mathf.Deg2Rad*180);
                //projectile.AddForce(BulletSourceZone.forward * 10000, ForceMode2D.Impulse); // go this way!
            }
        }
        else if (Dead)
        {
            // Exploderize the guy!
        }


	}
}
