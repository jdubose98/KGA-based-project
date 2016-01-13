using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Drive : MonoBehaviour {

    // **** Semi-private variables **** //

    // Properties for driving
    [SerializeField] float DriveSpeed;
    [SerializeField] float TurnSpeed;
    // Audio
    [SerializeField] AudioSource ThrottleInSource;
    [SerializeField] AudioSource ThrottleOutSource;
    [SerializeField] AudioSource SkidSource;
    [SerializeField] AudioSource HornClip;
    [SerializeField] float EnginePitch;

    // Other
    [SerializeField] ParticleSystem TireSmoke;
    [SerializeField] bool IsPlayer2;

    // UI
    [SerializeField]
    Image GaugeFiller;

    // ****** Private variables ****** //
    float forceMultiplier;
    public float speed;
    Vector3 lastPosition;
    string SelectedPlayerAxisH;
    string SelectedPlayerAxisV;

    // Use this for initialization
    void Start () {

        ThrottleInSource.Play();
        ThrottleOutSource.Play();
        SkidSource.Play();
        if (IsPlayer2)
        {
            SelectedPlayerAxisH = "Player 2 Turn";
            SelectedPlayerAxisV = "Player 2 Drive";
        }
        else
        {
            SelectedPlayerAxisH = "Player 1 Turn";
            SelectedPlayerAxisV = "Player 1 Drive";
        }
	}
	
    void FixedUpdate()
    {
        speed = (transform.position - lastPosition).magnitude;
        lastPosition = transform.position;
    }

	// Update is called once per frame
	void Update () {
        gameObject.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2 (0, DriveSpeed * Input.GetAxis(SelectedPlayerAxisV)*forceMultiplier)); // Controls speed
        gameObject.transform.Rotate(new Vector3(0, 0, TurnSpeed * -Input.GetAxis(SelectedPlayerAxisH) * Time.deltaTime)*(speed*5)); // Gets turn speed, multiplies by horizontal ais input for steering, then smooths with deltatime

        if (Input.GetAxis(SelectedPlayerAxisV) != 0)
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

        ThrottleInSource.pitch = .8f + (speed * 4f) * EnginePitch; // Set pitch
        ThrottleOutSource.pitch = .8f + (speed * 4f) * EnginePitch; // Set pitch

        GaugeFiller.fillAmount = .08f + (speed * 3.8f);

        if (speed * 5 > .8)
        {
            if (Input.GetAxisRaw(SelectedPlayerAxisH) != 0)
            {
                SkidSource.volume = SkidSource.volume + 0.075f;
                TireSmoke.Play();
            }
            else {
                SkidSource.volume = SkidSource.volume - 0.075f;
                TireSmoke.Stop(); }
        }
        else{
            SkidSource.volume = SkidSource.volume - 0.075f;
            TireSmoke.Stop();
        }

        //Horn
        if (Input.GetKeyDown(KeyCode.LeftShift) && !IsPlayer2)
                HornClip.Play();
        if (Input.GetKeyDown(KeyCode.RightShift) && IsPlayer2)
                HornClip.Play();
    }
}
