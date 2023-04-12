using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class DialogueSetup : MonoBehaviour
{
    [SerializeField] private DialogueView _view;
    [SerializeField] private SerializableQueue<Dialogue> _goodDialogues;
    [SerializeField] private SerializableQueue<Dialogue> _badDialogues;

    private DialoguePresenter _presenter;
    private DialogueModel _model;

    private void Awake()
    {
        _model = new DialogueModel();
        _model.Init(_goodDialogues, _badDialogues);
        _presenter = new DialoguePresenter(_model, _view);
    }

    public void SetupGoodDialogues()
    {
        _model.Init(_goodDialogues, _badDialogues);
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
