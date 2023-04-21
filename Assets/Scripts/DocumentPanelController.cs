using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DocumentPanelController : MonoBehaviour
{
    private CanvasGroup canvasGroup;
    private PanelTransiter panelTransiter;

    private Document document;

    private void Start()
    {
        panelTransiter = GetComponent<PanelTransiter>();

        panelTransiter.OnTransitionStart += () => SetCanvasVisibility(true);
        panelTransiter.OnTransitionComplete += () => SetCanvasVisibility(false);


        canvasGroup.alpha = 0f;
    }

    public void SetCanvasVisibility(bool visible)
    {
        canvasGroup.alpha = visible ? 1f : 0f;
    }

    public void ShowDocument(Document document)
    {
        if (!panelTransiter.IsReady)
            return;

        this.document = document;

        panelTransiter.StartTransition(PanelTransiter.TransitionType.SlideIn);
    }

    public void HideDocument()
    {
        if (!panelTransiter.IsReady)
            return;

        document = null;

        panelTransiter.StartTransition(PanelTransiter.TransitionType.SlideOut);
    }
}
