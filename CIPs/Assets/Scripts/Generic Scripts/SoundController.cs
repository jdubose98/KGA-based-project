using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.Collections;

public class SoundController : MonoBehaviour {

    [SerializeField] AudioMixer MasterMixer;

    [SerializeField] Slider MusicSlider;
    [SerializeField] Slider SFXSlider;

    public void MixerUpdate()
    {
        MasterMixer.SetFloat("MusicVol", MusicSlider.value);
        MasterMixer.SetFloat("SFXVol", SFXSlider.value);
    }
}
