using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using UnityEngine.SceneManagement;
public class ExtraYarnCommands : MonoBehaviour
{
    [SerializeField] DialogueRunner runner;
    
    // Start is called before the first frame update
    void Awake()
    {
        runner.AddCommandHandler<string>("UnityScene", DoUnitySceneChange);
        runner.AddCommandHandler<string>("pause", DoPause);
    }

    void DoUnitySceneChange(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    void DoPause(string time)
    {
       float seconds = float.Parse(time);
    }
}
