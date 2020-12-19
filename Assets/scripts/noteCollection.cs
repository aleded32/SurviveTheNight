using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class noteCollection : MonoBehaviour
{

    public GameObject[] noteArray;
    int[] layer;
    List<int> layerMask;
    public float raycastLength;
    public MeshGenerator meshGen;

    public int notesCollected;
    public int MaxNotesCollected;

    Transform note;
    GameObject gNotes;

    // Start is called before the first frame update
    void Start()
    {
        layer = new int[]
        {
            12,
            13,
            14,
            15,
            16
        };

        layerMask = new List<int>
        {
            1 << 12,
            1 << 13,
            1 << 14,
            1 << 15,
            1 << 16
        };
        noteArray = new GameObject[5];
        for(int i = 0; i < 5; i++)
        { 
            noteArray[i] = meshGen.objectList[i];
            noteArray[i].layer = layer[i];
        }

        MaxNotesCollected = 5;
        notesCollected = 0;
        

    }
    // Update is called once per frame
    void FixedUpdate()
    {
       
        RaycastHit hit;
        for (int i = 0; i < layerMask.Count; i++)
        {
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, raycastLength, layerMask[i]))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * raycastLength, Color.red);
                note = hit.transform;
                gNotes = note.GetChild(0).gameObject;
                if (Input.GetKeyDown(KeyCode.E) || Input.GetButtonDown("Bbutton"))
                {
                    gNotes.SetActive(false);
                    notesCollected++;
                    layerMask.Remove(layerMask[i]);
                }

            }
            else
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * raycastLength, Color.white);
            }
        }

        if (notesCollected >= MaxNotesCollected)
        {
            SceneManager.LoadScene("winScreen", LoadSceneMode.Single);
        }
    }


    bool isNoteCollected(GameObject gnotes)
    {
        if (gnotes.activeSelf == false)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
