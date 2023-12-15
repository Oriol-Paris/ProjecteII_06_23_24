using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CombatEndScreen : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //if(SceneManager.GetActiveScene().buildIndex == 0) {
                SceneManager.LoadScene(1, LoadSceneMode.Additive);
            //}
        }
    }
}
