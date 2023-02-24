using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DialogueModel
{
    private SerializableQueue<Dialogue> _goodDialogues;
    private SerializableQueue<Dialogue> _badDialogues;
    private SerializableQueue<Dialogue> _dialogues;
    private Dialogue _currentDialogue;
    private Dialogue _previousDialogue;

    public SerializableQueue<Dialogue> Dialogues => _dialogues;

    public event Action DialoguesEnded;
    public event Action<Dialogue> CharacterChanged;

    public Dialogue GetNextDialogue()
    {
        if (_dialogues.Empty())
            DialoguesEnded?.Invoke();
        else
        {
            _previousDialogue = _previousDialogue == null? _dialogues.Peek() : _currentDialogue;
            _currentDialogue = _dialogues.Dequeue();
            TryChangeCharacter(_currentDialogue);
            return _currentDialogue;
        }
        return null;
    }

    private void TryChangeCharacter(Dialogue currentDialogue)
    { 
        CharacterChanged?.Invoke(currentDialogue);
    }

    public void Init(SerializableQueue<Dialogue> goodDialogues, SerializableQueue<Dialogue> badDialogues)
    {
        _goodDialogues = goodDialogues;
        _badDialogues = badDialogues;
        _goodDialogues.UpdateQueue();
        _badDialogues.UpdateQueue();
    }

    public void SetGoodDialogues()
    {
        _dialogues = _goodDialogues;
    }

    public void SetBadDialogues()
    {
        _dialogues = _badDialogues;
    }
}
