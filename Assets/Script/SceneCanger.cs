using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneCanger : MonoBehaviour
{
    public void CangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void AddSecne(string sceneName)
    {
        SceneManager.LoadScene(sceneName,LoadSceneMode.Additive);
    }
    public void ChangeSceneASync(string sceneName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        operation.allowSceneActivation = true;
        bool isLoaded =operation.isDone;
        float progress = operation.progress;
        operation.completed += (oper) => { };

    }

    // <씬 언로드>
    // 로딩되어 있는 씬을 언로드 시키는 방법
    public void UnloadScene(string sceneName)
    {
        Scene scene = SceneManager.GetSceneByName(sceneName);
        if (scene.isLoaded == true)
        {
            SceneManager.UnloadSceneAsync(scene);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player")
            return;
        SceneManager.LoadSceneAsync("StageScene2", LoadSceneMode.Additive);
       
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag != "Player")
            return;
        SceneManager.UnloadSceneAsync("StageScene2");
    }

    public void GameOver()
    {
        SceneManager.LoadScene("TitleScene");
    }

}
