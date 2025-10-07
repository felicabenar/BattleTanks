using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [SerializeField]
    private String currentScene;
    public String playerName;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        Init();
    }

    void Init()
    {
        if (SceneManager.sceneCount < 2)
            SceneManager.LoadScene("01Menu", LoadSceneMode.Additive);
    }

    public void SetSceneName(string name)
    {
        if (SceneManager.sceneCount > 1)
            SceneManager.UnloadSceneAsync(currentScene);
        SceneManager.LoadScene(name, LoadSceneMode.Additive);
        currentScene = name;
    }

    public void PlayerName()
    {
        playerName = name;
    }

}
