using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class DocumentPanelController : PanelBase
{
    [Header("References")]
    [SerializeField] private TMP_Text nameTxt;
    [SerializeField] private TMP_Text descriptionTxt;
    [SerializeField] private TMP_Text dateTxt;
    [SerializeField] private Image iconImg;
    [SerializeField] InventoryPanelController inventoryPanelController;

    private Document document;

    private void RefreshGraphics()
    {
        DateTime date = new DateTime(InventorySaver.Instance.GetDocument(document).obtainedOn);

        nameTxt.text = document ? document.documentName : string.Empty;
        descriptionTxt.text = document ? document.documentDescription : string.Empty;
        dateTxt.text = document ? $"Le {date.ToString("dd/MM/yy")}" : string.Empty;
        iconImg.sprite = document ? document.documentIcon : null;
        iconImg.color = document ? Color.white : Color.clear;
    }

    protected override void OnTransitionComplete()
    {
        base.OnTransitionComplete();

        if (isShown)
        {
            InventorySaver.Instance.UpdateDocument(document, false);

            inventoryPanelController.RefreshList();

            Debug.Log("Refresh");
        }
    }

    public void ShowDocument(Document document)
    {
        this.document = document;

        RefreshGraphics();

        Show();
    }

    public void HideDocument()
    {
        document = null;

        Hide();
    }
}
