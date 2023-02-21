using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DialogueModel
{
    private SerializableQueue<Dialogue> _dialogues;

    public event Action DialoguesEnded;

    public Dialogue GetNextDialogue()
    {
        if (_dialogues.Empty())
            DialoguesEnded?.Invoke();
        else
            return _dialogues.Dequeue();
        return null;
    }

    public void Init(SerializableQueue<Dialogue> dialogues)
    {
        _dialogues = dialogues;
        _dialogues.UpdateQueue();
    }
}
