using UnityEngine;
public class MainMenuScene : SceneState
{
    public MainMenuScene(SceneStateController controller) : base(controller)
    {
        StateName = "MainMeneScene";
    }
    //�}�l���
    public override void OnBegin()
    {
        Debug.Log("MainMeneScene OnBegin");
        //�}�l�C����Ƹ��J�Ϊ�l��
        //�q�\�O�_���UPLAY
    }
    public override void OnUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnStartGameClick();

        }
    }
    //�}�l�s�C��
    private void OnStartGameClick()
    {
        Debug.Log("MainMeneScene OnStartGameClick");
        m_Controller.SetState(new GameWorldScene(m_Controller), "GameWorldScene");
    }
}
