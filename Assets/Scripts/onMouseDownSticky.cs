using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class onMouseDownSticky : MonoBehaviour
{
    public static bool isInMenu = false;

    public GameObject menuOpened;
    public string desiredText; // changes with each sticky
    public TextMeshProUGUI textBox;
    public Transform player;
    public AudioSource sticky;

    private void OnMouseDown()
    {
        if ((Vector3.Distance(gameObject.transform.position, player.position) <= 2))
        {
            isInMenu = true;
            Time.timeScale = 0f;//pause game
            Cursor.lockState = CursorLockMode.Confined;
            menuOpened.SetActive(true);
            if (desiredText != "NULL") // if its null we just open the menu
            {
                sticky.Play();
                textBox.text = desiredText;
            }
        }
    }
}
