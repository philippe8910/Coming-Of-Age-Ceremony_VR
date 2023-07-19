using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Speaker
{
    SevenMM,
    Player
}

[CreateAssetMenu(fileName = "DialogData", menuName = "ScriptableObject/DialogData")]
public class DialogData : ScriptableObject
{
    public float gapTimer;
    public List<DialogDataDetail> dialogDataDetails;
}

[System.Serializable]
public class DialogDataDetail
{
    public string ID;
    public Vector3 dialogPosition;
    public Vector3 dialogRotation;
    public List<SentenceDetail> sentenceDetails;
}


[System.Serializable]
public class SentenceDetail
{
    public Speaker speaker;
    public string sentence;
}