using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class keypad : MonoBehaviour
{
    public GameObject winMenu;
    string Code = "4059";
    string Nr = null;
    int NrIndex = 0;
    public TextMeshProUGUI UiText = null;

    public void CodeFunction(string Numbers)
    {
        NrIndex++;
        Nr = Nr + Numbers;
        UiText.text = Nr;

        if (NrIndex >= 6)
        {
            fullWipe();
        }

    }
    public void Enter()
    {
        if (Nr == Code)
        {
            Time.timeScale = 0f;//pause game
            winMenu.SetActive(true);
        } else
        {
            fullWipe();
        }
    }
    public void Delete()
    {
        NrIndex--;
        Nr = Nr.Substring(0, Nr.Length - 1);
        UiText.text = Nr;
    }
    private void fullWipe()
    {
        NrIndex = 0;
        Nr = null;
        UiText.text = Nr;
    }
}