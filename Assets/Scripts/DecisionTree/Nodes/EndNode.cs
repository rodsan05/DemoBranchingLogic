using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using XNode;

public class EndNode : BaseNode {

    #region Properties
    [Input] public int entry;
    #endregion

    #region References
    public string endingText;
    #endregion

    #region Methods
    public override void OnNodeEnter()
    {
        base.OnNodeEnter();
        GameManager.Instance.DecisionManager?.SetupEnding(endingText);
    }
    #endregion
}