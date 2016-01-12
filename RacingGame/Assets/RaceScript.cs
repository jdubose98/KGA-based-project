using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RaceScript : MonoBehaviour {

    //Players
    [SerializeField] GameObject Player1;
    [SerializeField] GameObject Player2;

    //Checkpoints
    [SerializeField] GameObject StartPoint;
    [SerializeField] GameObject Checkpoint1;
    [SerializeField] GameObject Checkpoint2;
    [SerializeField] GameObject Checkpoint3;
    [SerializeField] GameObject Checkpoint4;
    [SerializeField] GameObject Checkpoint5;
    [SerializeField] GameObject Checkpoint6;

    //GUIs
    [SerializeField] Text Player1Position;
    [SerializeField] Text Player2Position;
    [SerializeField] Text Player1Time;
    [SerializeField] Text Player2Time;

    [SerializeField] GameObject StartCount3;
    [SerializeField] GameObject StartCount2;
    [SerializeField] GameObject StartCount1;
    [SerializeField] GameObject StartGo;

    //Sounds
    [SerializeField] AudioSource TickClip;
    [SerializeField] AudioSource GoClip;
    [SerializeField] AudioSource CheckpointClip;


    int State = 0; // 0 is unit, 1 is 3, 5 is GO

    // Use this for initialization
    void Start () {
        StartCoroutine(RaceStarter());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator RaceStarter() {
        if (State < 5) {
            State = State + 1;
            switch (State) {
                case 1:
                    TickClip.Play();
                    StartCount3.SetActive(true);
                    break;
                case 2:
                    TickClip.Play();
                    StartCount3.SetActive(false);
                    StartCount2.SetActive(true);
                    break;
                case 3:
                    TickClip.Play();
                    StartCount2.SetActive(false);
                    StartCount1.SetActive(true);
                    break;
                case 4:
                    GoClip.Play();
                    StartCount1.SetActive(false);
                    StartGo.SetActive(true);
                    break;
                default:
                    break;
            }
        }
        else {
            StartGo.SetActive(false);
            Player1.GetComponent<Drive>().enabled = true;
            Player2.GetComponent<Drive>().enabled = true;
        }
        if (State <= 5)
        {
            yield return new WaitForSeconds(1);
            StartCoroutine(RaceStarter());
        }
        

    }
}
