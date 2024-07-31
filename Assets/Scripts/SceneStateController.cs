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
        //載入場景
        LoadSceneName(sceneName);
        //結束前一個狀態結束
        m_State?.OnEnd();
        m_State = state;
    }
    /// <summary>
    /// 載入指定場景
    /// </summary>
    /// <param name="LoadSceneName"></param>
    private void LoadSceneName(string LoadSceneName)
    {
        if (LoadSceneName == null || LoadSceneName.Length == 0)
            return;
        SceneManager.LoadScene(LoadSceneName);
    }
    //場景載入中
    public void SceneStateUpdate()
    {
        //如果場景還沒載入完成，就不執行
        if (!SceneManager.GetActiveScene().isLoaded)
            return;
        //通知新的場景開始
        if (m_State != null && m_bRunBegin == false)
        {
            m_State.OnBegin();
            m_bRunBegin = true;
        }
        //執行當前場景的更新
        m_State?.OnUpdate();
    }
}
