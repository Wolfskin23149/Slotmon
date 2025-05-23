using UnityEngine;
public class StartScene : SceneState
{
    public StartScene(SceneStateController controller) : base(controller)
    {
        StateName = "StartScene";
    }
    public override void OnBegin()
    {
        Debug.Log("StartScene OnBegin");
        //開始遊戲資料載入及初始化
    }
    public override void OnUpdate()
    {
        Debug.Log("StartScene OnUpdate");
        //判斷是否載入完成
        //載入完成後切換到下一個場景
        m_Controller.SetState(new MainMenuScene(m_Controller), "MainMenuScene");
    }
}
