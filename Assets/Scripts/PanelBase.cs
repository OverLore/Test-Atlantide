using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelBase : MonoBehaviour
{
    protected CanvasGroup canvasGroup;
    public PanelTransiter panelTransiter;

    public bool isShown;

    protected virtual void Start()
    {
        panelTransiter = GetComponent<PanelTransiter>();
        canvasGroup = GetComponent<CanvasGroup>();

        panelTransiter.OnTransitionStart += () => OnTransitionStart();
        panelTransiter.OnTransitionComplete += () => OnTransitionComplete();

        SetCanvasVisibility(false);
    }

    protected virtual void OnTransitionStart()
    {
        SetCanvasVisibility(true);
    }

    protected virtual void OnTransitionComplete()
    {
        isShown = !isShown;

        SetCanvasVisibility(isShown);
    }

    public virtual void SetCanvasVisibility(bool visible)
    {
        canvasGroup.alpha = visible ? 1f : 0f;
        canvasGroup.interactable = visible;
        canvasGroup.blocksRaycasts = visible;
    }

    public virtual void Show()
    {
        if (!panelTransiter.IsReady)
            return;

        panelTransiter.StartTransition(PanelTransiter.TransitionType.SlideIn);
    }

    public virtual void Hide()
    {
        if (!panelTransiter.IsReady)
            return;

        panelTransiter.StartTransition(PanelTransiter.TransitionType.SlideOut);
    }
}
