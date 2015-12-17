using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthbarTracker : MonoBehaviour {

    public Transform TargetedObject;
    public int LoggedHealth = 33;
    [SerializeField] Image Fill;

	// Use this for initialization
	void Start () {
	}

    // Update is called once per frame
    void FixedUpdate() {
        if (TargetedObject != null) { 
            gameObject.transform.position = TargetedObject.transform.position + new Vector3(0, -1, 0);
            Fill.fillAmount = (float)TargetedObject.GetComponent<EnemySpaceshipLogic>().EnemyHealth / LoggedHealth; }
        else Destroy(gameObject);
	}
}
