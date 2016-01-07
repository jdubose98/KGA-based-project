using UnityEngine;
using System.Collections;

public class Drive : MonoBehaviour {

    [SerializeField] float DriveSpeed;
    [SerializeField] float TurnSpeed;
    float forceMultiplier;
    public float speed;
    Vector3 lastPosition;

    // Use this for initialization
    void Start () {
	
	}
	
    void FixedUpdate()
    {
        speed = (transform.position - lastPosition).magnitude;
        lastPosition = transform.position;
    }

	// Update is called once per frame
	void Update () {
        gameObject.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2 (0, DriveSpeed * Input.GetAxis("Vertical")*forceMultiplier));
        gameObject.transform.Rotate(new Vector3(0, 0, TurnSpeed * -Input.GetAxis("Horizontal") * Time.deltaTime));

        if (Input.GetAxis("Vertical") != 0)
        {
            if (forceMultiplier <= 1)
                forceMultiplier = forceMultiplier + 0.01f;
            else forceMultiplier = 1;
        }
        else
        {
            if (forceMultiplier > 0)
                forceMultiplier = forceMultiplier / 3;
            else if (forceMultiplier <= 0)
                forceMultiplier = 0; // safety net
        }
    }
}
