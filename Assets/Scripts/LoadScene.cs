using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void OnClickPlay()
    {
        SceneManager.LoadScene("GUI", LoadSceneMode.Single);
    }

    public void OnGameEnd()
    {
        SceneManager.LoadScene("LoginScreen", LoadSceneMode.Single);
    }
}
