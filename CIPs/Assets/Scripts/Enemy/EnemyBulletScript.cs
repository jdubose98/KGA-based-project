using UnityEngine;
using System.Collections;

public class EnemyBulletScript : MonoBehaviour {

    [SerializeField] int BulletDamage = 1;
    public int ProjectileSpeed = 4;

	// Use this for initialization
	void Start () {
        Destroy(gameObject, 5);
	}
	
	// Update is called once per frame
	void Update () {
        var projectile = gameObject.GetComponent<Rigidbody2D>();
        projectile.transform.Translate(0, ProjectileSpeed * Time.deltaTime, 0);
    }

    void OnCollisionEnter2D(Collision2D hit)
    {
        if (hit.gameObject.tag == "Player")
        {
            if (hit.gameObject.GetComponent<PlayerController_Spaceship>().Shielded == true)
                hit.gameObject.GetComponent<PlayerController_Spaceship>().ShieldStrength = hit.gameObject.GetComponent<PlayerController_Spaceship>().ShieldStrength - BulletDamage;
            Destroy(gameObject);
        }
        else if (hit.gameObject.tag == "MapObject")
            Destroy(gameObject);
    }
}
