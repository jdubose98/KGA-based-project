using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UserInterfaceLogic : MonoBehaviour {

    public bool GamePaused = false;

    [SerializeField]
    GameObject PauseMenu;
    [SerializeField]
    GameObject GameUI;

    [SerializeField]
    Button ResumeButton;

    bool PauseUIClosed = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("escape"))
        {
            if (PauseUIClosed == true)
            {
                PauseUIClosed = false;
                Cursor.visible = true;
                Time.timeScale = 0;
                GameUI.SetActive(false);
                PauseMenu.SetActive(true);
                GamePaused = true;
            }
            ResumeButton.onClick.AddListener(Resume);
        }
    }
    void Resume () {
        {
            PauseUIClosed = true;
            Cursor.visible = false;
            Time.timeScale = 1;
            GameUI.SetActive(true);
            PauseMenu.SetActive(false);
            GamePaused = false;
        }
    }
}
