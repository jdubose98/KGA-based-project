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

    void OnCollisionEnter(Collision2D hit)
    {
        if (hit.gameObject.tag == "Enemy" || hit.gameObject.tag == "MapObject")
        {
            if (hit.gameObject.tag == "Enemy")
            {
                hit.gameObject.GetComponent<EnemySpaceshipLogic>().EnemyHealth = hit.gameObject.GetComponent<EnemySpaceshipLogic>().EnemyHealth - ProjectileDamage;
            }
            Destroy(gameObject);
        }
    }
}
