using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UserInterfaceLogic : MonoBehaviour {

    public bool GamePaused = false;

    [SerializeField]
    GameObject PauseMenu;
    [SerializeField]
    GameObject GameUI;

    bool PauseUIClosed = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        // Detect if the player pressed ESCAPE
        if (Input.GetKeyDown("escape"))
            if (GamePaused == false) // If not paused
                Pause(); // then we pause.
            else Resume(); // otherwise we'll resume the game.
    }

    public void Pause() { // quick and dirty way to get the game to pause
        PauseUIClosed = false; // show pause menu
        Cursor.visible = true; // show the cursor
        Time.timeScale = 0; // pause all physics
        GameUI.SetActive(false); // turns off the game UI
        PauseMenu.SetActive(true); // activates pause menu
        GamePaused = true; // toggle the bool
    }

    public void Resume () { // basically the opposite of Pause()
        PauseUIClosed = true;
        Cursor.visible = false;
        Time.timeScale = 1;
        GameUI.SetActive(true);
        PauseMenu.SetActive(false);
        GamePaused = false;
    }

    public void QuitOutFull()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit();
        #endif
    }

    public void HubQuit()
    {
        Application.LoadLevel(0);
    }
}
