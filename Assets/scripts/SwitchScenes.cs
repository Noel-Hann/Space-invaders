using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScenes : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.DontDestroyOnLoad(gameObject);
    }

    public void LoadGameScene(string sceneName)
    {
        
        Debug.Log("button called this function");
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }
}
