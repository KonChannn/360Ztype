using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverDisplay : MonoBehaviour
{
    public void Setup()
    {
        gameObject.SetActive(true);
    }

    public void GoStartMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("StartMenu");
    }
}
