using XNode;

public class BaseNode : Node
{
    #region References
    protected DecisionTreeController decisionTreeController;
    #endregion

    #region Methods
    public virtual bool Evaluate()
	{
		return true;
	}

	public virtual void InitializeNode(DecisionTreeController _decisionTreeController) 
	{
		decisionTreeController = _decisionTreeController;
	}

	public virtual void OnNodeEnter() 
	{
	}

	public virtual void OnNodeExit() 
	{
	}

	public virtual void OnNodeUpdate() 
	{
	}
    #endregion
}