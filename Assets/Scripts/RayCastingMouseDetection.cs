using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class RayCastingMouseDetection : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;
    string pastHit = "IAMASTRING";
    [SerializeField] TextMeshProUGUI item1, item2, item3, item4, item5;
    [SerializeField] Canvas winGUI;
    [SerializeField] GameObject pauseManager;
    public AudioSource Correct;
    public AudioSource WinAudio;
    public AudioSource Incorrect;

    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 3f))
        {
            
            // if the last item was an item, and the current item is not an item
            if ((pastHit.Substring(0, 4) == "ITEM") && (pastHit.Substring(4, 2) != ((string)hit.collider.name).Substring(4, 2)))
            {
                //Debug.Log(GameObject.Find(pastHit));
                try
                {
                    (GameObject.Find(pastHit).GetComponent<Outline>().OutlineWidth) = 0f;
                } catch
                {
                    pastHit = hit.collider.name;
                }
            }
            else if (((string)hit.collider.name).Substring(0, 4) == "ITEM")
            { // if it hits an item
                (hit.collider.GetComponent<Outline>().OutlineWidth) = 10f;
                if (Input.GetMouseButtonDown(0)) // player has clicked this object
                {
                    // an item has been clicked, send value to itemClicked
                    itemClicked(Int32.Parse(((string)hit.collider.name).Substring(4, 2)));
                }
            }
            pastHit = hit.collider.name;
        }
    }


    // item value vvv corresponds with the key,
    // if the key = the item value and is actively
    // sought after then the player found the item

    public void itemClicked(int itemLocation)
    {
        int valueFoundAt = -1; // used for position
        for (int i = 0; i < itemManager.randomNumbers.Length; i++)
        {
            if (itemManager.randomNumbers[i] == itemLocation) // if one of the ints we pulled is equal to the passed in int
            {
                // item has been found!
                valueFoundAt = i;
                break;
            }
        }
        if (valueFoundAt != -1)
        {
            itemFound(valueFoundAt); // theres a lot that needs to happen, use a new function
            
        }
        else
        {
            (hit.collider.GetComponent<Outline>().OutlineColor) = Color.red;
            Incorrect.Play();
            // maybe play an error sound or smth
        }
    }

    public void itemFound(int valueFoundAt) // only fires when an item is found, removes it from the list
    {
        itemManager.randomNumbers[valueFoundAt] = -1;
        hit.collider.gameObject.SetActive(false);
        //hit.collider.gameObject.GetComponent<MeshRenderer>().enabled = true;
        // play a happy sfx or someone crossing something out. or both lol
        //Correct.Play();
        switch (valueFoundAt)
        {
            case 0:
                item1.fontStyle = FontStyles.Strikethrough;
                break;
            case 1:
                item2.fontStyle = FontStyles.Strikethrough;
                break;
            case 2:
                item3.fontStyle = FontStyles.Strikethrough;
                break;
            case 3:
                item4.fontStyle = FontStyles.Strikethrough;
                break;
            case 4:
                item5.fontStyle = FontStyles.Strikethrough;
                break;
        }
        // find out how to grab an item from the workspace; dont delete, hide.
        globalVariables.itemsCollected++;
        if (globalVariables.itemsCollected >= 5)
        {// game has been won!
            WinAudio.Play();

            // win script fires when this is set to active
            winGUI.gameObject.SetActive(true);
            pauseManager.SetActive(false); // disabling it means that the player cannot pause right now
        }
        else
        {
            Correct.Play();
        }
    }
}