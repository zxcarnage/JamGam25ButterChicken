using UnityEngine;

public class DialoguePresenter
{
    private DialogueView _view;
    private DialogueModel _model;

    public DialoguePresenter(DialogueModel model, DialogueView view)
    {
        _view = view;
        _model = model;
    }

    public void Enable()
    {
        _view.GoodDialoguesSetted += _model.SetGoodDialogues;
        _view.BadDialoguesSetted += _model.SetBadDialogues;
        _view.DialogueStarted += OnDialogueStarted;
        _view.Click += OnViewClicked;
        _model.CharacterChanged += _view.ChangeCharacter;
        _model.DialoguesEnded += _view.OnDialogueEnded;
    }

    public void Disable()
    {
        _view.Click -= OnViewClicked;
        _model.CharacterChanged -= _view.ChangeCharacter;
        _model.DialoguesEnded -= _view.OnDialogueEnded;
        _view.GoodDialoguesSetted -= _model.SetGoodDialogues;
        _view.BadDialoguesSetted -= _model.SetBadDialogues;
        _view.DialogueStarted -= OnDialogueStarted;
    }

    private void OnDialogueChanged(Dialogue dialogue)
    {
        if (dialogue == null)
            return;
        _view.SetText(dialogue);
    }

    private void OnDialogueStarted()
    {
        _view.InitCharacters(_model.Dialogues.Peek());
        _view.SetText(_model.GetNextDialogue());
    }
    
    private void OnViewClicked()
    {
        var dialogue = _model.GetNextDialogue();
        OnDialogueChanged(dialogue);
    }
}
