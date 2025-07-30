using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;

public class AnimatedButton : Button
{
    #region Properties
    private float selectedScale = 1.2f;
    private float scaleAnimDuration = 0.5f;
    #endregion

    #region Methods
    public override void OnSelect(BaseEventData eventData) 
    {
        base.OnSelect(eventData);

        transform.DOScale(new Vector3(selectedScale, selectedScale, selectedScale), scaleAnimDuration);
    }

    public override void OnSubmit(BaseEventData eventData)
    {
        base.OnSubmit(eventData);

        Sequence sequence = DOTween.Sequence();
        sequence.Append(transform.DOScale(Vector3.one, scaleAnimDuration / 2));
        sequence.Append(transform.DOScale(new Vector3(selectedScale, selectedScale, selectedScale), scaleAnimDuration / 2));
        sequence.Play();
    }

    public override void OnDeselect(BaseEventData eventData)
    {
        base.OnDeselect(eventData);

        transform.DOScale(Vector3.one, scaleAnimDuration);
    }

    protected override void OnDestroy()
    {
        DOTween.CompleteAll();
    }
    #endregion
}
