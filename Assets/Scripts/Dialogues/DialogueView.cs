using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class DialogueView : MonoBehaviour
{
    [SerializeField] private Customer _customer;
    [SerializeField] private List<Character> _characters;
    [SerializeField] private TMP_Text _dialogueText;
    private Button _dialogueClick;

    public event Action Click;

    public event Action GoodDialoguesSetted;
    public event Action BadDialoguesSetted;
    public event Action DialogueStarted;

    private void Awake()
    {
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
        _customer.GoAway();
        transform.parent.gameObject.SetActive(false);
    }

    public void SetText(Dialogue dialogue)
    {
        _dialogueText.text = dialogue.DialogueText.ToString();
    }

    public void ChangeCharacter(Dialogue nextDialogue)
    {
        InitCharacters(nextDialogue);
    }

    public void InitCharacters(Dialogue dialogue)
    {
        var onCharacter = _characters.Find(x => x.CharacterName == dialogue.Character.CharacterName);
        var offCharacter = _characters.Find(x => x.CharacterName != dialogue.Character.CharacterName);
        onCharacter.Highlight();
        offCharacter.UnHighlight();
    }

    public void SetGoodDialogues()
    {
        GoodDialoguesSetted?.Invoke();
        DialogueStarted?.Invoke();
    }

    public void SetBadDialogues()
    {
        BadDialoguesSetted?.Invoke();
        DialogueStarted?.Invoke();
    }
    
    private void OnClick()
    {
        Click?.Invoke();
    }
}
