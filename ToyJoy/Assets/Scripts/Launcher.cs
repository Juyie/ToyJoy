using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Launcher : MonoBehaviour
{
    public void GameStart()
    {
        SceneManager.LoadScene("ChooseStage");
    }

    public void GameExit()
    {
        Application.Quit();
    }
}
