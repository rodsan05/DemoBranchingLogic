using UnityEngine;

public class DecisionTreeController : MonoBehaviour
{
    #region References
    [SerializeField]
    private DecisionGraph decisionGraph;
    #endregion

    #region Methods
    private void InitializeGraph() 
    {
        decisionGraph.current = decisionGraph.nodes.Find(n => n is RootNode) as BaseNode;
        decisionGraph.current.InitializeNode(this);
    }

    private void StepGraph() 
    {
        if (decisionGraph.current.Evaluate())
        {
            decisionGraph.current.OnNodeExit();

            BaseNode nextNode;

            if (decisionGraph.current is DecisionNode decisionNode)
            {
                nextNode = decisionNode.GetOutputPort("choice " + decisionNode.choiceIdx).node as BaseNode;
            }

            else
            {
                nextNode = decisionGraph.current.GetOutputPort("exit").node as BaseNode;
            }

            decisionGraph.current = nextNode;
            decisionGraph.current.InitializeNode(this);
            decisionGraph.current.OnNodeEnter();
        }

        decisionGraph.current.OnNodeUpdate();
    }

    private void Awake()
    {
        InitializeGraph();
    }

    private void Update()
    {
        StepGraph();
    }
    #endregion
}
