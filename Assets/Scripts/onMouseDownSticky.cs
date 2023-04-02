using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class onMouseDownSticky : MonoBehaviour
{
    public GameObject menuOpened;
    public string desiredText; // changes with each sticky
    public TextMeshProUGUI textBox;
    public Transform player;

    private void OnMouseDown()
    {
        if ((Vector3.Distance(gameObject.transform.position, player.position) <= 2))
        {
            Time.timeScale = 0f;//pause game
            Cursor.lockState = CursorLockMode.Confined;
            menuOpened.SetActive(true);
            if (desiredText != null) // if its null we just open the menu
            {
                textBox.text = desiredText;
            }
        }
    }
}
