using UnityEngine;
using System.Collections;

public class PowerupMagic : MonoBehaviour {

    [SerializeField] float BoosterPower = 20;

	void OnTriggerEnter2D(Collider2D hitObject)
    {
        if (hitObject.Tag = "Player")
        {
            GameObject.GetComponentInParent<PlayerController_Spaceship>().ShieldStrength = ShieldStrength + BoosterPower;
        }
    }
}
