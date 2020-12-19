using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class soundManager : MonoBehaviour
{
    public AudioSource[] sources;
    public Slider soundSliderPause;

    private void Start()
    {
        soundSliderPause.value = PlayerPrefs.GetFloat("sound");

        for(int i = 0; i < sources.Length; i++)
            sources[i].volume = PlayerPrefs.GetFloat("sound");
    }

    // Update is called once per frame
    void Update()
    {

        soundSliderPause.maxValue = 1;
        soundSliderPause.minValue = 0;

        if (GameObject.FindWithTag("enemy") != null)
        {
            sources[1] = GameObject.FindWithTag("enemy").gameObject.GetComponent<AudioSource>();
        }
        
        
        
    }

    public void sliderSound()
    {
        for (int i = 0; i < sources.Length; i++)
        {

            sources[i].volume = soundSliderPause.value;
            
        }
       
    }
    

}
