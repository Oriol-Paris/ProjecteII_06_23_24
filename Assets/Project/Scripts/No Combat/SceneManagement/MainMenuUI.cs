using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    public Canvas MainMenuCanvas;
    public Canvas startGameCanvas;
    public void StartGame()
    {

        StartCoroutine(StartingGame());

    }

    IEnumerator StartingGame()
    {
        MainMenuCanvas.gameObject.SetActive(false);
        startGameCanvas.gameObject.SetActive(true);

        float timePassed = 0.0f;
        float maxTime = 2.0f;
        while(timePassed < maxTime && !Input.anyKey)
        {
            timePassed += Time.deltaTime;
            yield return null;
        }

        SceneManager.LoadSceneAsync(1);
    }
}
