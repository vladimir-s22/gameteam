using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteButtonScript : MonoBehaviour {



    private Sprite soundOnImage;
    public Sprite soundOffImage;
    public Button mutingButton;
    private bool AudioisOn = true;
    public AudioSource audioSource;

    void Start() {
        mutingButton.image.sprite = soundOnImage;
    } 


    public void ButtonClicked() {
        if (AudioisOn) {
            mutingButton.image.sprite = soundOffImage;
            AudioisOn = false;
            audioSource.mute = true;
        } else {
            mutingButton.image.sprite = soundOnImage;
            AudioisOn = true;
            audioSource.mute = false;
        }
    }
}
