using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class noteCollection : MonoBehaviour
{

    public GameObject[] noteArray;
    int[] layer;
    int[] layerMask;
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

        layerMask = new int[]
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
        Debug.Log(notesCollected);
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, raycastLength, layerMask[0]))
        {
           Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * raycastLength, Color.red);
           note = hit.transform;
           gNotes = note.GetChild(0).gameObject;
            if (Input.GetKeyDown(KeyCode.E))
            {
                gNotes.SetActive(false);
                notesCollected++;
            }
                
        }
        else if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, raycastLength, layerMask[1]))
        {
          Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * raycastLength, Color.red);
           note = hit.transform;
           gNotes = note.GetChild(0).gameObject;
            if (Input.GetKeyDown(KeyCode.E) && !isNoteCollected(gNotes))
            {
                gNotes.SetActive(false);
                notesCollected++;
            }
               

        }
        else if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, raycastLength, layerMask[2]))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * raycastLength, Color.red);
            note = hit.transform;
            gNotes = note.GetChild(0).gameObject;
            if (Input.GetKeyDown(KeyCode.E) && !isNoteCollected(gNotes))
            {
                gNotes.SetActive(false);
                notesCollected++;
            }
        }
        else if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, raycastLength, layerMask[3]))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * raycastLength, Color.red);
            note = hit.transform;
            gNotes = note.GetChild(0).gameObject;
            if (Input.GetKeyDown(KeyCode.E) && !isNoteCollected(gNotes))
            {
                gNotes.SetActive(false);
                notesCollected++;
            }
        }
        else if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, raycastLength, layerMask[4]))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * raycastLength, Color.red);
            note = hit.transform;
            gNotes = note.GetChild(0).gameObject;
            if (Input.GetKeyDown(KeyCode.E) && !isNoteCollected(gNotes))
            {
                gNotes.SetActive(false);
                notesCollected++;
            }
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * raycastLength, Color.white);
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
