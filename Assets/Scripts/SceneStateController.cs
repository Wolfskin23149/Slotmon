using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneStateController
{
    private SceneState m_State;
    private bool m_bRunBegin = false;
    public SceneStateController() {}

    public void SetState(SceneState state , string sceneName)
    {
        Debug.Log("SetState: " + state.ToString());
        m_bRunBegin = false;
        //���J����
        LoadSceneName(sceneName);
        //�����e�@�Ӫ��A����
        m_State?.OnEnd();
        m_State = state;
    }
    /// <summary>
    /// ���J���w����
    /// </summary>
    /// <param name="LoadSceneName"></param>
    private void LoadSceneName(string LoadSceneName)
    {
        if (LoadSceneName == null || LoadSceneName.Length == 0)
            return;
        SceneManager.LoadScene(LoadSceneName);
    }
    //�������J��
    public void SceneStateUpdate()
    {
        //�p�G�����٨S���J�����A�N������
        if (!SceneManager.GetActiveScene().isLoaded)
            return;
        //�q���s�������}�l
        if (m_State != null && m_bRunBegin == false)
        {
            m_State.OnBegin();
            m_bRunBegin = true;
        }
        //�����e��������s
        m_State?.OnUpdate();
    }
}
