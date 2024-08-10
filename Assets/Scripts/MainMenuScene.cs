using UnityEngine;
public class MainMenuScene : SceneState
{
    public MainMenuScene(SceneStateController controller) : base(controller)
    {
        StateName = "MainMeneScene";
    }
    //開始選單
    public override void OnBegin()
    {
        Debug.Log("MainMeneScene OnBegin");
        //開始遊戲資料載入及初始化
        //訂閱是否按下PLAY
    }
    public override void OnUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnStartGameClick();

        }
    }
    //開始新遊戲
    private void OnStartGameClick()
    {
        Debug.Log("MainMeneScene OnStartGameClick");
        m_Controller.SetState(new GameWorldScene(m_Controller), "GameWorldScene");
    }
}
