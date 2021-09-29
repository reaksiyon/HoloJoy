using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadAdditiveScene : MonoBehaviour
{
    private void Start()
    {
        SceneManager.LoadScene("Level", LoadSceneMode.Additive);

        StartCoroutine(WaitForSceneLoad(SceneManager.GetSceneByName("Level")));
    }


    public IEnumerator WaitForSceneLoad(Scene scene)
    {
        while (!scene.isLoaded)
        {
            yield return null;
        }

        SceneManager.SetActiveScene(scene);
    }
}
