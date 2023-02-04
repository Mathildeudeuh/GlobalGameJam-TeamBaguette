using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class BeginTheGame : MonoBehaviour
{
    [SerializeField] private string gameSceneName;

    public void OpenNextScene()
    {
        SceneManager.LoadScene(gameSceneName, LoadSceneMode.Single);
    }
}