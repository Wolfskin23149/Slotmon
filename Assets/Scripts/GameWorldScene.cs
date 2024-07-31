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
        //�C���@�ɪ�l��
    }
    public override void OnEnd()
    {
        Debug.Log("GameWorldScene OnEnd");
        //���}�C���@��
    }
    public override void OnUpdate()
    {
        //���a��J
        //�C���޿�
        //�e����s
        //�C����������
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            m_Controller.SetState(new MainMenuScene(m_Controller), "MainMenuScene");
        }
    }
}
