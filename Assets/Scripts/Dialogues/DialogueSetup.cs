using System;
using System.Collections.Generic;
using UnityEngine;

public class DialogueSetup : MonoBehaviour
{
    [SerializeField] private DialogueView _view;
    [SerializeField] private SerializableQueue<Dialogue> _dialogues;

    private DialoguePresenter _presenter;
    private DialogueModel _model;

    private void Awake()
    {
        _model = new DialogueModel();
        _model.Init(_dialogues);
        _presenter = new DialoguePresenter(_model, _view);
    }

    private void OnEnable()
    {
        _presenter.Enable();
    }

    private void OnDisable()
    {
        _presenter.Disable();
    }
}
