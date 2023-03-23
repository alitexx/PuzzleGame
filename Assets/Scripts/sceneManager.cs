using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour
{
    public AudioSource clickButton;
    public Image blackOutSquare;
    public Animator anim;

    public void endGame()
    {
        // close game
        clickButton.Play();
        Application.Quit();
    }
    public void loadLevel(string sceneName)
    {
        Debug.Log("Changing Scenes!");
        clickButton.Play();
        Cursor.lockState = CursorLockMode.Locked;
        //if (Time.deltaTime == 0f)
        //{
        //    Time.timeScale = 1f;
        //    Cursor.lockState = CursorLockMode.Locked;
        //}
        StartCoroutine(FadeBlackOutSquare(sceneName));
    }

    public IEnumerator FadeBlackOutSquare(string beginLevel = "")
    {
        anim.SetBool("Fade", true);
        yield return new WaitUntil(() => blackOutSquare.color.a == 1);
        Debug.Log(beginLevel);
        SceneManager.LoadScene(beginLevel);
    }
}
