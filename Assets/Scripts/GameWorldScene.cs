using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWorldScene : SceneState
{
    public GameWorldScene(SceneStateController controller) : base(controller)
    {
        StateName = "GameWorldScene";
    }

    public override void OnBegin()
    {
        Debug.Log("GameWorldScene OnBegin");
        //遊戲世界初始化
    }
    public override void OnEnd()
    {
        Debug.Log("GameWorldScene OnEnd");
        //離開遊戲世界
    }
    public override void OnUpdate()
    {
        //玩家輸入
        //遊戲邏輯
        //畫面更新
        //遊戲結束條件
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            m_Controller.SetState(new MainMenuScene(m_Controller), "MainMenuScene");
        }
    }
}
