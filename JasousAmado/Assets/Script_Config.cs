using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class Script_Config : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider volumeSlider;
    private bool foundSlider = false;
    private float volume;

    // Start is called before the first frame update
    void Awaken()
    {
        FindVolumeSlider();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FindVolumeSlider()
    {
        if (GameObject.FindWithTag("volumeSlider") != null && foundSlider == false)
        {
            Debug.Log("FOUND volume slider");
            volumeSlider = GameObject.FindWithTag("volumeSlider").GetComponent<Slider>();
            volumeSlider.value = 0.98f;
            SetVolume(0.98f);
            foundSlider = true;
        }
        if (GameObject.FindWithTag("volumeSlider") == null && foundSlider == true)
        {
            foundSlider = false;
        }

    }

    public void SetVolume(float volume)
    {
        Debug.Log("volume atual: "+ volume);
        //audioMixer.SetFloat("mixerAudio", volume);
        audioMixer.SetFloat("mixerAudio", Mathf.Log10(volume) * 20);
    }

}
