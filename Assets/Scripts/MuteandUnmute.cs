using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteandUnmute : MonoBehaviour
{
    public Sprite unmute;
    public Sprite mute;
    public Button muteButton;
    private bool isOn = true;


    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        mute = muteButton.image.sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonClicked() 
    {
        if (isOn) 
        {
            muteButton.image.sprite = unmute;
            isOn = false;
            audioSource.mute = true;
        }
        else 
        {
            muteButton.image.sprite = mute;
            isOn = true;
            audioSource.mute = false;
        }
    }
}
