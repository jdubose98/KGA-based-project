using UnityEngine;
using UnityEngine.UI;

public class LoadThisLevel : MonoBehaviour {

    [SerializeField] GameObject LoadCanvas;
    [SerializeField] Text PercentField;
    AsyncOperation AsyncLoad;

    // Normal freeze-y stuff
    public void LoadLevelByNumber(int SelectedLevel)
    { Application.LoadLevel(SelectedLevel); }
    public void LoadLevelByName(string SelectedLevel)
    { Application.LoadLevel(SelectedLevel); }
    // Async!
    public void LoadLevelAsyncByNumber(int SelectedLevel)
    {
        AsyncLoad = Application.LoadLevelAsync(SelectedLevel);
        LoadCanvas.SetActive(false);
        Time.timeScale = 1;
    }
    public void LoadLevelASyncByName(string SelectedLevel)
    { AsyncLoad = Application.LoadLevelAsync(SelectedLevel); }


    void Update()
    {
        if (AsyncLoad != null)
        {
            PercentField.text = AsyncLoad.progress.ToString() + "%";
        }
    }

}