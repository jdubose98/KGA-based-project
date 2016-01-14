using UnityEngine;
using System.Collections;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

    [SerializeField] AudioMixer MasterMixer;

    [SerializeField] Slider MasterSlider;
    [SerializeField] Slider SkidSlider;
    [SerializeField] Slider MusicSlider;
    [SerializeField] Slider HornSlider;
    [SerializeField] Slider EngineSlider;

    public void MixerUpdate()
    {
        MasterMixer.SetFloat("EngineVol", EngineSlider.value);
        MasterMixer.SetFloat("MasterVol", MasterSlider.value);
        MasterMixer.SetFloat("SkidVol", SkidSlider.value);
        MasterMixer.SetFloat("HornVol", HornSlider.value);
        MasterMixer.SetFloat("MusicVol", MusicSlider.value);
    }

    public void Restart()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    public void Quit()
    {
        Application.Quit();
    }

}

