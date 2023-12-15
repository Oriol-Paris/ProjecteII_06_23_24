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

        yield return new WaitForSeconds(2f);

        SceneManager.LoadSceneAsync(1);
    }
}
