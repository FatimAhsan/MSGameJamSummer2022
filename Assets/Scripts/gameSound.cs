using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameSound : MonoBehaviour
{
    private AudioSource _audioSource;
    public Slider volumeSlider;
    bool isAtSTart = true;

    void OnEnable()
    {
        //Register Slider Events
        volumeSlider.onValueChanged.AddListener(delegate { changeVolume(volumeSlider.value); });
    }
    //Called when Slider is moved
    void changeVolume(float sliderValue)
    {
        _audioSource.volume = sliderValue;
    }

    private void Awake()
    {
        if(gameObject.tag == "Music")
            DontDestroyOnLoad(transform.gameObject);
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayMusic()
    {
        if (_audioSource.isPlaying) return;
        Debug.Log(isAtSTart + "isSTart");
        if (isAtSTart)
        {
            _audioSource.Play();
            _audioSource.volume = (volumeSlider.value);
            isAtSTart = false;
        }
    }

    public void StopMusic()
    {
        _audioSource.Stop();
    }
}
