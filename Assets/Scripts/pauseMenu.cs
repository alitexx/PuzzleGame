using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseMenu : MonoBehaviour
{
    public GameObject ui;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            togglePause();
        }
    }
    public void togglePause()
    {
        if (onMouseDownSticky.isInMenu == false)
        {
            ui.SetActive(!ui.activeSelf);

            if (ui.activeSelf)
            {
                Time.timeScale = 0f;
                Cursor.lockState = CursorLockMode.Confined;
            }
            else
            {
                Time.timeScale = 1f;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }
}
