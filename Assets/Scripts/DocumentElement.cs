using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static PanelTransiter;

public class DocumentElement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Image documentIcon;

    public Document document { get; private set; }

    private DocumentPanelController documentPanelController;

    public void SetDocument(Document document)
    {
        this.document = document;
        documentIcon.sprite = document.documentIcon;
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
