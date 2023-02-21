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
        _view.Click += OnViewClicked;
        _model.DialoguesEnded += _view.OnDialogueEnded;
    }

    public void Disable()
    {
        _view.Click -= OnViewClicked;
        _model.DialoguesEnded -= _view.OnDialogueEnded;
    }

    private void OnDialogueChanged(Dialogue dialogue)
    {
        if (dialogue == null)
            return;
        _view.SetText(dialogue);
    }

    private void OnViewClicked()
    {
        var dialogue = _model.GetNextDialogue();
        OnDialogueChanged(dialogue);
    }
}
