public class SceneState
{
    //狀態名稱
    private string m_StateName = "SceneState";
    public string StateName
    {
        get { return m_StateName; }
        set { m_StateName = value; }
    }
    //控制者
    protected SceneStateController m_Controller = null;

    //建構者
    public SceneState(SceneStateController controller)
    {
        m_Controller = controller;
    }

    /// <summary>
    /// 進入此場景狀態時
    /// </summary>
    public virtual void OnBegin()
    {
    
    }
    /// <summary>
    /// 維持在此場景狀態
    /// </summary>
    public virtual void OnUpdate()
    {
    
    }
    /// <summary>
    /// 離開此場景狀態
    /// </summary>
    public virtual void OnEnd()
    {
    
    }
    public override string ToString()
    {
        return string.Format("[SceneState: StateName={0}]", StateName);
    }
}
