using UnityEngine;
using System.Collections;

public class Drive : MonoBehaviour {

    // **** Semi-private variables **** //

    // Properties for driving
    [SerializeField] float DriveSpeed;
    [SerializeField] float TurnSpeed;
    // Audio
    [SerializeField] AudioSource ThrottleInSource;
    [SerializeField] AudioSource ThrottleOutSource;
    [SerializeField] AudioSource SkidSource;

    // ****** Private variables ****** //
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
            if (forceMultiplier <= 1) {
                forceMultiplier = forceMultiplier + 0.01f;
                ThrottleInSource.volume = ThrottleInSource.volume + 0.05f;
                ThrottleOutSource.volume = ThrottleOutSource.volume - 0.025f;
            }
            else forceMultiplier = 1;
        }
        else
        {
            if (forceMultiplier > 0) {
                forceMultiplier = forceMultiplier / 3;
                ThrottleOutSource.volume = ThrottleOutSource.volume + 0.05f;
                ThrottleInSource.volume = ThrottleInSource.volume - 0.025f;
            }
            else if (forceMultiplier <= 0)
                forceMultiplier = 0; // safety net
        }

        ThrottleInSource.pitch = .8f + (speed * 4f); // Set pitch
        ThrottleOutSource.pitch = .8f + (speed * 4f); // Set pitch

        if (speed*5 > .8)
        {
            if (Input.GetAxisRaw("Horizontal") != 0)
            {
                SkidSource.volume = SkidSource.volume + 0.075f;
            }
            else
                SkidSource.volume = SkidSource.volume - 0.075f;
        }
        else
            SkidSource.volume = SkidSource.volume - 0.075f;
    }
}
