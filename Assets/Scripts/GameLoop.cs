using System;
using UnityEngine;

public class GameLoop : MonoBehaviour
{
    public static GameLoop Instance => _instance;
    private static GameLoop _instance = null;

    private readonly SceneStateController m_SceneStateController = new();
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        _instance = this;
        DontDestroyOnLoad(gameObject);
        //設定隨機種子
        UnityEngine.Random.InitState((int)DateTime.Now.Ticks);
    }
    void Start()
    {
        //Game Initialization
        m_SceneStateController.SetState(new StartScene(m_SceneStateController), "StartScene");
    }
    void Update()
    {
        m_SceneStateController.SceneStateUpdate();
        //Player Input
        //GameLogic Update
        //UI Update
    }
}
