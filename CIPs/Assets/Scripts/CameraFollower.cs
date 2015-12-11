using UnityEngine;
using System.Collections;

public class CameraFollower : MonoBehaviour {

    [SerializeField]
    Transform Target;

	// Update is called once per frame
	void Update () {
        gameObject.transform.position = new Vector3(Target.transform.position.x, Target.transform.position.y, 0);
	}
}
