using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.Playables;
using static Document;

public class InventorySaver : MonoBehaviour
{
    public static InventorySaver Instance;

    private List<DocumentData> documentDatas = new List<DocumentData>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        Load();
    }

    public void UpdateDocument(Document document, bool isNew)
    {
        if (documentDatas == null)
            documentDatas = new List<DocumentData>();

        DocumentData documentData = GetDocument(document);

        if (documentData == null)
        {
            documentData = new DocumentData();

            documentData.id = document.documentId;
            documentData.obtainedOn = System.DateTime.Now.Ticks;

            documentDatas.Add(documentData);
        }

        documentData.isNew = isNew;

        Save();
    }

    public bool IsUnlocked(Document document)
    {
        if (documentDatas == null)
            return false;

        return documentDatas.Exists(x => x.id == document.documentId);
    }

    public bool IsNew(Document document)
    {
        if (documentDatas == null)
            return false;

        return documentDatas.Exists(x => x.id == document.documentId && x.isNew);
    }

    public void OrderByDate()
    {
        documentDatas.Sort((x, y) => y.obtainedOn.CompareTo(x.obtainedOn));
    }

    public List<DocumentData> GetSortedDocuments()
    {
        OrderByDate();

        return documentDatas;
    }

    public void Save()
    {
        if (documentDatas == null)
            documentDatas = new List<DocumentData>();

        OrderByDate();

        using (StreamWriter sw = new StreamWriter(Application.persistentDataPath + "/save.dat"))
        {
            sw.WriteLine(JsonHelper.ToJson(documentDatas));
        }
    }

    public void Load()
    {
        using (StreamReader sw = new StreamReader(Application.persistentDataPath + "/save.dat"))
        {
            string lines = sw.ReadToEnd();

            documentDatas = JsonHelper.FromJson<DocumentData>(lines);
        }

        OrderByDate();
    }

    public DocumentData GetDocument(Document document)
    {
        return documentDatas.Find(x => x.id == document.documentId);
    }
}
