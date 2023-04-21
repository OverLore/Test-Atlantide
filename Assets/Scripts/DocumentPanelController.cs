using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DocumentPanelController : PanelBase
{
    [Header("References")]
    [SerializeField] private TMP_Text nameTxt;
    [SerializeField] private TMP_Text descriptionTxt;
    [SerializeField] private Image iconImg;
    [SerializeField] InventoryPanelController inventoryPanelController;

    private Document document;

    private void RefreshGraphics()
    {
        nameTxt.text = document ? document.documentName : string.Empty;
        descriptionTxt.text = document ? document.documentDescription : string.Empty;
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
