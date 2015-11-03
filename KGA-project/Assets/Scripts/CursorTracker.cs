﻿using UnityEngine;
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
        image.transform.position = Input.mousePosition;
        image.transform.Rotate(0, 0, Mathf.Deg2Rad*8);
    }
}
