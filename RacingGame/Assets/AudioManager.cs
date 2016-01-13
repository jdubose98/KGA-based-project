using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour {

    [SerializeField] AudioMixer Mixer;

	public void SetMixerVolumeA(float volume)
    {
        Mixer.SetFloat("EngineVol", volume);
    }

    public void SetMixerVolumeB(float volume)
    {
        Mixer.SetFloat("SkidVol", volume);
    }

    public void SetMixerVolumeC(float volume)
    {
        Mixer.SetFloat("MusicVol", volume);
    }


    public void SetMixerVolumeD(float volume)
    {
        Mixer.SetFloat("HornVol", volume);
    }

    public void SetMixerVolumeE(float volume)
    {
        Mixer.SetFloat("MasterVol", volume);
    }

}

