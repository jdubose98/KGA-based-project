using UnityEngine;

public class LoadThisLevel : MonoBehaviour {
	public void LoadLevelByNumber(int SelectedLevel)
    { Application.LoadLevel(SelectedLevel); }
    public void LoadLevelByName(string SelectedLevel)
    { Application.LoadLevel(SelectedLevel); }
}

// the world's smallest script ever. why