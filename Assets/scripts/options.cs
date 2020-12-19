using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class options : MonoBehaviour
{


    float senX;
    float senY;
    float sound;

    public Slider senXslider;
    public Slider senYslider;
    public Slider soundSlider;


    private void Start()
    {

        if (PlayerPrefs.GetFloat("senX") != senXslider.value)
        {
            senXslider.value = PlayerPrefs.GetFloat("senX");
        }
        else
        {
            senXslider.value = 2;
        }

        if (PlayerPrefs.GetFloat("senY") != senYslider.value)
        {
            senYslider.value = PlayerPrefs.GetFloat("senY");
        }
        else
        {
            senYslider.value = 2;
        }

        if (PlayerPrefs.GetFloat("sound") != soundSlider.value)
        {
            soundSlider.value = PlayerPrefs.GetFloat("sound");
        }
        else
        {
            soundSlider.value = 1;
        }

       

       
        
       
    }

 

    public void senXfunc()
    {
        senX = senXslider.value;
        PlayerPrefs.SetFloat("senX", senX);
    }

    public void senYfunc()
    {
        senY = senYslider.value;
        PlayerPrefs.SetFloat("senY", senY);
    }

    public void soundfunc()
    {
        sound = soundSlider.value;
        PlayerPrefs.SetFloat("sound", sound);
    }


}
