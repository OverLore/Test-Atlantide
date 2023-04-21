using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DocumentElement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Image documentIcon;

    public Document document { get; private set; }

    public void SetDocument(Document document)
    {
        this.document = document;
        documentIcon.sprite = document.documentIcon;
    }

    public void OnClick()
    {
        //TODO: Open in vizualizer

        Debug.Log("Document " + document.documentName + " clicked!");
    }
}
