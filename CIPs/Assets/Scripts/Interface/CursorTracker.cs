using UnityEngine;
using System.Collections;

public class CursorTracker : MonoBehaviour {

    [SerializeField]
    RectTransform image;

	// Use this for initialization
	void Start () {
        Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.timeScale != 0)
        {
            image.transform.position = Input.mousePosition;
            image.transform.Rotate(0, 0, Mathf.Deg2Rad * 8);
        }
        else
        {
            image.transform.position = new Vector3(Screen.width/2, Screen.height/2, 0);
        }
    }
}
