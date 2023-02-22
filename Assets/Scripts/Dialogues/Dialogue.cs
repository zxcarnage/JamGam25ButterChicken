using System;
using UnityEngine;

[Serializable]
public class Dialogue
{
    [SerializeField] public Character Character;
    
    [TextArea(0,10)] 
    [SerializeField] public string DialogueText;
}
