using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = new GameObject("GameManager").AddComponent<GameManager>();
            }
            return instance;
        }
    }

    static GameManager instance;
    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public bool isFailed = false;

    public void GameFailEnd()
    {
        isFailed = true;

        SceneManager.LoadScene("游戏结束");
    }

    public void GameWinEnd()
    {
        isFailed = false;
        SceneManager.LoadScene("游戏结束");
    }
}
