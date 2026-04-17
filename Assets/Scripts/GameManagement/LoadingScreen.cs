using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour
{
    public GameObject loadingScreen;//UI GameObject of lodaing screen

    public void LoadScene(int sceneID)
    {
        StartCoroutine(LoadSceneAsync(sceneID));
    }

    IEnumerator LoadSceneAsync(int sceneID)
    {
        AsyncOperation Operation = SceneManager.LoadSceneAsync(sceneID);

        loadingScreen.SetActive(true);

        while (!Operation.isDone)
        {
            float progressionValue = Mathf.Clamp01(Operation.progress / 0.9f);//to use if there is a loading bar 

            yield return null;
        }

        loadingScreen.SetActive(false);

        Operation.allowSceneActivation = true;
    }
}
