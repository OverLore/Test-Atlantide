using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPanelController : PanelBase
{
    [Header("References")]
    [SerializeField] Transform documentsGrid;
    [SerializeField] GameObject documentElementPrefab;
    [SerializeField] DocumentPanelController documentPanelController;

    private List<DocumentElement> documentElements = new List<DocumentElement>();

    public override void Show()
    {
        base.Show();

        RefreshList();
    }

    public override void Hide()
    {
        if (!panelTransiter.IsReady || !documentPanelController.panelTransiter.IsReady || documentPanelController.isShown)
            return;

        panelTransiter.StartTransition(PanelTransiter.TransitionType.SlideOut);
    }

    public void UnlockDocument(Document document)
    {
        InventorySaver.Instance.UpdateDocument(document, true);

        RefreshList();
    }

    public void UnlockRandomDocument()
    {
        Document document = DocumentDB.Instance.GetRandomLockedDocument();

        if (document == null)
            return;

        UnlockDocument(document);
    }

    public void RefreshList()
    {
        ClearList();

        foreach (var document in DocumentDB.Instance.GetAllUnlockedDocument())
        {
            DocumentElement documentElement = Instantiate(documentElementPrefab, documentsGrid).GetComponent<DocumentElement>();

            documentElement.SetDocument(document);
            documentElement.SetDocumentPanelController(documentPanelController);
        }
    }

    private void ClearList()
    {
        int childs = documentsGrid.childCount;
        for (int i = childs - 1; i >= 0; i--)
        {
            Destroy(documentsGrid.GetChild(i).gameObject);
        }
    }
}
