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
        //�}�l�C����Ƹ��J�Ϊ�l��
    }
    public override void OnUpdate()
    {
        Debug.Log("StartScene OnUpdate");
        //�P�_�O�_���J����
        //���J�����������U�@�ӳ���
        m_Controller.SetState(new MainMenuScene(m_Controller), "MainMenuScene");
    }
}
