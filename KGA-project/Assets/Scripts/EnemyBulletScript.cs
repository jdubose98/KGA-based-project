using UnityEngine;
using System.Collections;

public class EnemyBulletScript : MonoBehaviour {

    [SerializeField] int BulletDamage = 1;
    public int ProjectileSpeed = 4;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        var projectile = gameObject.GetComponent<Rigidbody2D>();
        projectile.transform.Translate(0, ProjectileSpeed * Time.deltaTime, 0);
    }

    void OnTriggerEnter(Collider hit)
    {
        if (hit.tag == "Player")
        {
            if (hit.GetComponent<PlayerController_Spaceship>().Shielded == true)
                hit.GetComponent<PlayerController_Spaceship>().ShieldStrength = hit.GetComponent<PlayerController_Spaceship>().ShieldStrength - BulletDamage;
        }
    }
}
