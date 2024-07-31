public class SceneState
{
    //���A�W��
    private string m_StateName = "SceneState";
    public string StateName
    {
        get { return m_StateName; }
        set { m_StateName = value; }
    }
    //�����
    protected SceneStateController m_Controller = null;

    //�غc��
    public SceneState(SceneStateController controller)
    {
        m_Controller = controller;
    }

    /// <summary>
    /// �i�J���������A��
    /// </summary>
    public virtual void OnBegin()
    {
    
    }
    /// <summary>
    /// �����b���������A
    /// </summary>
    public virtual void OnUpdate()
    {
    
    }
    /// <summary>
    /// ���}���������A
    /// </summary>
    public virtual void OnEnd()
    {
    
    }
    public override string ToString()
    {
        return string.Format("[SceneState: StateName={0}]", StateName);
    }
}
