using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onMouseDownExitMenu : MonoBehaviour
{
    public GameObject menu;
    public void endMenu()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
        menu.SetActive(false);
    }
}
