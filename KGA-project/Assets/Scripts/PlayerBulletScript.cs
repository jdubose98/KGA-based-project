using UnityEngine;
using System.Collections;

public class PlayerBulletScript : MonoBehaviour {

    static float ProjectileLife = 2; // Projectile life in seconds
    [SerializeField] float ProjectileSpeed = 6; // Bullet speed
    float Timer = Time.time + ProjectileLife; // Kinda cheaty

    // Use this for initialization
    void Start () {
        Destroy(gameObject, 2);
	}
	
	// Update is called once per frame
	void Update () {
        var projectile = gameObject.GetComponent<Rigidbody2D>();
            projectile.transform.Translate(0, ProjectileSpeed * Time.deltaTime,0);

    }
}
