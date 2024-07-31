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
        //秨﹍笴栏戈更の﹍て
    }
    public override void OnUpdate()
    {
        Debug.Log("StartScene OnUpdate");
        //耞琌更ЧΘ
        //更ЧΘち传初春
        m_Controller.SetState(new MainMenuScene(m_Controller), "MainMenuScene");
    }
}
