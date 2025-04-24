using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneMean : MonoBehaviour
{
    /*******************************************************************************************
     * �� (Scene)
     * 
     * ����Ƽ���� ���ӿ��带 �����ϴ� ����
     * ������Ʈ�� ���ϴ� ����ŭ ���� ������ �� �ְ� ����ȯ�� ���� �ٸ� ���ӿ��带 �ҷ��� �� ����
     * ���� ���� �̿��Ͽ� ���� ���� ���ÿ� ���� ���� ���ӿ��忡�� ��뵵 ������
     ********************************************************************************************/

    // <���� ����>
    // ����Ƽ���� ���� ���� ����ϱ� ���ؼ� ���� �������� ���� �����ؾ� ��
    // ���� �������� ������ ���� ���� ���� ������� ������


    // <�� ��ȯ>
    // ������Ʈ�� ���Ե� �ٸ� ���� �ε��ϰ� ������ ���� ������ ������
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }


    // <�� �߰�>
    // ������Ʈ�� ���Ե� �ٸ� ���� �ε��ϰ� ������ ���� ������ ������
    public void AddScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
    }


    // <�񵿱� �� �ε�>
    // �� �ε��� ��׶���� �����Ͽ� ���� �� ������ �������ϴ� �񵿱� ���
    public void ChangeSceneASync()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync("SceneName");

        operation.allowSceneActivation = true;      // �� �ε� �Ϸ�� �ٷ� �� ��ȯ�� �����ϴ��� ����
        bool isLoaded = operation.isDone;           // �� �ε��� �ϷῩ�� Ȯ��
        float progress = operation.progress;        // �� �ε��� ����� Ȯ��
        operation.completed += (oper) => { };       // �� �ε��� �Ϸ�� ������ �̺�Ʈ �߰�
    }

    // <�� ��ε�>
    // �ε��Ǿ� �ִ� ���� ��ε� ��Ű�� ���
    public void UnloadScene()
    {
        Scene scene = SceneManager.GetSceneByName("sceneName");
        if (scene.isLoaded == true)
        {
            SceneManager.UnloadSceneAsync(scene);
        }
    }



    // <Don't destroy on load>
    // ���� ��ȯ���� ���ŵ��� �ʱ� ���ϴ� ���ӿ�����Ʈ�� ��� �������� �ʴ� ���� ���ӿ�����Ʈ�� �߰��ϴ� ����� ���
    // Don't destroy on load ���� ��� �� ��ȯ ���� �߿� �������� ����
    public void SetDontDestroyOnLoad()
    {
        DontDestroyOnLoad(gameObject);
    }
}