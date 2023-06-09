using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewDocument", menuName = "Scriptables/Document")]
public class Document : ScriptableObject
{
    [Header("General")]
    public string documentName;
    public string documentId;
    [TextArea] public string documentDescription;
    public Sprite documentIcon;

    [System.Serializable]
    public class DocumentData
    {
        public string id;
        public bool isNew;
        public long obtainedOn;
    }
}
