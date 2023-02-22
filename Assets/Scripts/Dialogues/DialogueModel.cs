using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DialogueModel
{
    private SerializableQueue<Dialogue> _dialogues;
    private Dialogue _currentDialogue;
    private Dialogue _previousDialogue;
    
    public event Action DialoguesEnded;
    public event Action CharacterChanged;

    public Dialogue GetNextDialogue()
    {
        if (_dialogues.Empty())
            DialoguesEnded?.Invoke();
        else
        {
            _previousDialogue = _previousDialogue == null? _dialogues.Peek() : _currentDialogue;
            _currentDialogue = _dialogues.Dequeue();
            TryChangeCharacter();
            return _currentDialogue;
        }
        return null;
    }

    private void TryChangeCharacter()
    {
        if (_dialogues.Empty() || _previousDialogue.Character.name != _currentDialogue.Character.name)
        {
            CharacterChanged?.Invoke();
        }
    }

    public void Init(SerializableQueue<Dialogue> dialogues)
    {
        _dialogues = dialogues;
        _dialogues.UpdateQueue();
    }
}
