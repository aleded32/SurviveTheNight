using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    public Text noteText;
    public int notesCollected;
    public int notescollectedMax;
    public GameObject player;

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        notesCollected = player.GetComponent<noteCollection>().notesCollected;
        notescollectedMax = player.GetComponent<noteCollection>().MaxNotesCollected;
        noteText.text = "Notes: " + notesCollected.ToString() + "/" + notescollectedMax.ToString();
    }
}
