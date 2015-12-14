using UnityEngine;
using System.Collections;

public class PlayerBulletScript : MonoBehaviour {

    static float ProjectileLife = 2; // Projectile life in seconds
    public float ProjectileSpeed = 12; // Bullet speed
    float Timer = Time.time + ProjectileLife; // Kinda cheaty
    [SerializeField] int ProjectileDamage = 9000; // Time for noscopes!

    // Use this for initialization
    void Start () {
        Destroy(gameObject, ProjectileLife);
	}
	
	// Update is called once per frame
	void Update () {
        var projectile = gameObject.GetComponent<Rigidbody2D>();
            projectile.transform.Translate(0, ProjectileSpeed * Time.deltaTime,0);
    }

    void OnCollisionEnter2D(Collision2D hit)
    {
        Debug.Log("We got a hit from object " + hit.gameObject.name);
        if (hit.gameObject.tag == "Enemy" || hit.gameObject.tag == "MapObject")
        {
            if (hit.gameObject.tag == "Enemy")
            {
                hit.gameObject.GetComponent<EnemySpaceshipLogic>().EnemyHealth = hit.gameObject.GetComponent<EnemySpaceshipLogic>().EnemyHealth - ProjectileDamage;
            }
            Destroy(gameObject); // This destroys regardless of whether we hit a map object or not
        }
        else Debug.Log("That wasn't an object to destroy myself on");
    }
}
