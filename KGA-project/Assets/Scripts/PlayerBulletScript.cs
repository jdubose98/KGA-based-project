using UnityEngine;
using System.Collections;

public class PlayerBulletScript : MonoBehaviour {

    static float ProjectileLife = 2; // Projectile life in seconds
    public float ProjectileSpeed = 6; // Bullet speed
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

    void OnTriggerEnter(Collider hit)
    {
        if (hit.tag == "Enemy" || hit.tag == "MapObject")
        {
            if (hit.tag == "Enemy")
            {
                //logic to deal damage goes here.
            }
            Destroy(gameObject);
        }
    }
}
