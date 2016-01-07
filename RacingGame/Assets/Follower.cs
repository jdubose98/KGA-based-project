using UnityEngine;
using System.Collections;

public class Follower : MonoBehaviour {

    [SerializeField] Transform Target;
    float smoothingFactor;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, new Vector3 (Target.position.x, Target.position.y, -10),1f);
        gameObject.GetComponent<Camera>().orthographicSize = 5.25f + (2.25f * smoothingFactor);

        smoothingFactor = Target.GetComponent<Drive>().speed*5;
	}
}
