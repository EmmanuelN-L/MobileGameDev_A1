using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXPlaying : MonoBehaviour
{
    public AudioSource Fire1;
    public AudioSource ClickUI;
    public AudioSource Music1;

    public void PlayMusic1()
    {
        Music1.Play();
    }
    public void PlayFire1()
    {
        Fire1.Play();
    }
    public void PlayClickUI()
    {
        ClickUI.Play();
    }

}
