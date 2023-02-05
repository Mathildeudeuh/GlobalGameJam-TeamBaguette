using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Supercherie : MonoBehaviour
{
    [SerializeField] private string gameSceneName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
                SceneManager.LoadScene(gameSceneName, LoadSceneMode.Single);

        }
    }
}
