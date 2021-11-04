using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// シーン遷移機能
/// </summary>
public class SceneChanger : MonoBehaviour
{
    /// <summary>
    /// 遷移先のシーン名
    /// </summary>
    [SerializeField]
    string sceneName = "";

    /// <summary>
    /// 決定ボタン名
    /// </summary>
    [SerializeField]
    string buttonNameSubmit = "Submit";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (buttonNameSubmit != "" && Input.GetButtonDown(buttonNameSubmit))
        {
            SceneChange();
        }
    }

    /// <summary>
    /// シーン遷移する
    /// </summary>
    public void SceneChange()
    {
        SceneManager.LoadScene(sceneName);
    }
}
