using System;
using UnityEngine;

public class StartDialogueSetup : MonoBehaviour
{
    [SerializeField] private DialogueSetup _dialogueSetup;
    [SerializeField] private DialogueView _dialogueView;
    private void OnEnable()
    {
        StartDialogue();
    }

    private void StartDialogue()
    {
        _dialogueSetup.SetupGoodDialogues();
        _dialogueView.SetGoodDialogues();
    }
}
