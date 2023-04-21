using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DocumentPanelController : PanelBase
{
    private Document document;

    public void ShowDocument(Document document)
    {
        this.document = document;

        Show();
    }

    public void HideDocument()
    {
        document = null;

        Hide();
    }
}
