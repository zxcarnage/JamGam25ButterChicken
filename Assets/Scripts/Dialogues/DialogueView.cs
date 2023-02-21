using System;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class DialogueView : MonoBehaviour
{
    private TMP_Text _dialogueText;
    private Button _dialogueClick;

    public event Action Click;

    private void Awake()
    {
        _dialogueText = GetComponentInChildren<TMP_Text>();
        _dialogueClick = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _dialogueClick.onClick.AddListener(OnClick);
    }

    private void OnDisable()
    {
        _dialogueClick.onClick.RemoveListener(OnClick);
    }

    public void OnDialogueEnded()
    {
        transform.parent.gameObject.SetActive(false);
    }

    public void SetText(Dialogue dialogue)
    {
        _dialogueText.text = dialogue.DialogueText.ToString();
    }

    private void OnClick()
    {
        Click?.Invoke();
    }
}
