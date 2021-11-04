using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// シーン遷移機能
/// </summary>
public class SceneChanger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// シーン遷移する
    /// </summary>
    /// <param name="sceneName">遷移先のシーン名</param>
    public void SceneChange(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
