using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.TimeZoneInfo;

public class PanelTransiter : MonoBehaviour
{
    public enum TransitionType
    {
        SlideIn,
        SlideOut
    }

    [Header("References")]
    [SerializeField] private RectTransform panelRectTransform;

    [Header("Settings")]
    [SerializeField] private float transitionTime = 0.5f;

    private Vector2 startPosition;
    private Vector2 endPosition;

    private bool isTransitioning = false;

    public bool IsReady => !isTransitioning;

    public Action OnTransitionStart;
    public Action OnTransitionComplete;

    private void Start()
    {
        startPosition = new Vector2(0f, -Screen.height);
        endPosition = new Vector2(0f, 0f);

        panelRectTransform.anchoredPosition = startPosition;
    }

    public void StartTransition(TransitionType type)
    {
        if (isTransitioning)
            return;

        StartCoroutine(MakeTransition(type));
    }

    private IEnumerator MakeTransition(TransitionType type)
    {
        isTransitioning = true;

        OnTransitionStart?.Invoke();

        Vector2 from = type == TransitionType.SlideIn ? startPosition : endPosition;
        Vector2 to = type == TransitionType.SlideIn ? endPosition : startPosition;

        float transitionTimer = 0f;
        float transitionProgress = 0f;
        while (transitionTimer < transitionTime)
        {
            transitionTimer += Time.deltaTime;
            transitionProgress = (1 - Mathf.Cos(transitionTimer / transitionTime * Mathf.PI)) * .5f;
            
            panelRectTransform.anchoredPosition = Vector3.Slerp(from, to, transitionProgress);

            yield return null;
        }

        panelRectTransform.anchoredPosition = to;

        isTransitioning = false;

        OnTransitionComplete?.Invoke();
    }
}
