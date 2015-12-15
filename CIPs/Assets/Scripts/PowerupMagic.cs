using UnityEngine;
using System.Collections;

public class PowerupMagic : MonoBehaviour {

    [SerializeField] float BoosterPower = 20;

	void OnTriggerEnter2D(Collider2D hitObject)
    {
        var Controller = hitObject.GetComponentInParent<PlayerController_Spaceship>();
        if (hitObject.tag == "Player")
        {
            if (Controller.ShieldStrength + BoosterPower <= Controller.MaxShieldStrength)
                Controller.ShieldStrength = Controller.ShieldStrength + BoosterPower;
            else Controller.ShieldStrength = Controller.MaxShieldStrength;

            Destroy(gameObject, 1);
        }
    }
}
