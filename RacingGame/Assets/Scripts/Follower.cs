using UnityEngine;
using System.Collections;

public class Follower : MonoBehaviour {

    [SerializeField] Transform Target; // Object we're following (in this case the player)
    float smoothingFactor; // Multiplier for zoom rate

	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    void Update() {
        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, new Vector3(Target.position.x, Target.position.y, -10), 1f); // Tween camera position

        if (5.25f + (2.25f * smoothingFactor) > 7.25) // Is our zoom size greater than 7.25?
            gameObject.GetComponent<Camera>().orthographicSize = 7.25f; // Hard cap on camera zoom to prevent jittering
        else
            gameObject.GetComponent<Camera>().orthographicSize = 5.25f + (2.25f * smoothingFactor); // Otherwise zoom as normal

        smoothingFactor = Target.GetComponent<Drive>().speed*5; // Finds out our smoothing factor
	}
}
