using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    private static SceneChanger _instance;
    public static SceneChanger Instance => _instance;


    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// �V�[����ύX����
    /// </summary>
    /// <param name="sceneName">�V�[���̖��O</param>
    public void SceneChange(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

}
