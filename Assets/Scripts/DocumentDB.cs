using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class is loaded before all other classes 
//Modifiable in Project Settings => Script Execution Order
//This is used to prevent from initiate any class before the database has been loaded
public class DocumentDB : MonoBehaviour
{
    public static DocumentDB Instance;

    private List<Document> documents = new List<Document>();

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        Object[] loadedDocuments = Resources.LoadAll("Scriptables/Documents", typeof(Document));

        foreach (Document document in loadedDocuments)
            documents.Add(document);

        Debug.Log($"Successfully loaded {documents.Count} documents");
    }

    public Document GetDocument(string documentId)
    {
        return Instantiate(documents.Find(document => document.documentId == documentId));
    }

    public List<Document> GetAllDocument()
    {
        List<Document> allDocuments = new List<Document>();

        foreach (Document document in documents)
            allDocuments.Add(Instantiate(document));

        return allDocuments;
    }

    public int GetDocumentCount()
    {
        return documents.Count;
    }

    public void AddDocument(Document document)
    {
        documents.Add(document);
    }

    public void RemoveDocument(Document document)
    {
        documents.Remove(document);
    }

    public void ClearDocuments()
    {
        documents.Clear();
    }

    public void PrintDocuments()
    {
        foreach (Document document in documents)
            Debug.Log(document.documentId);
    }
}
