using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Launcher : MonoBehaviour
{
    public void GameStart()
    {
        StartCoroutine("WaitAndGo");
    }

    public void GameExit()
    {
        Application.Quit();
    }

    IEnumerator WaitAndGo()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("ChooseStage");
    }
}
