using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static PanelTransiter;

public class DocumentElement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Image documentIcon;
    [SerializeField] private Image newIcon;

    public Document document { get; private set; }

    private DocumentPanelController documentPanelController;

    public void SetDocument(Document document)
    {
        this.document = document;

        RefreshGraphics();
    }

    public void RefreshGraphics()
    {
        documentIcon.sprite = document.documentIcon;
        newIcon.color = InventorySaver.Instance.IsNew(document) ? Color.white : Color.clear;
    }

    public void SetDocumentPanelController(DocumentPanelController documentPanelController)
    {
        this.documentPanelController = documentPanelController;
    }

    public void OnClick()
    {
        documentPanelController.ShowDocument(document);
    }
}
