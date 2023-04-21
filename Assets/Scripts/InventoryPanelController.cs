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

    protected override void Start()
    {
        base.Start();

        foreach (var document in DocumentDB.Instance.GetAllDocument())
        {
            DocumentElement documentElement = Instantiate(documentElementPrefab, documentsGrid).GetComponent<DocumentElement>();
            
            documentElement.SetDocument(document);
            documentElement.SetDocumentPanelController(documentPanelController);
        }
    }
}
