using System;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class DialogueView : MonoBehaviour
{
    [SerializeField] private Character[] _characters = new Character[2];
    [SerializeField] private TMP_Text _dialogueText;
    private Button _dialogueClick;
    private bool _nextCharacter = false;
    
    public event Action Click;

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
        transform.parent.gameObject.SetActive(false);
    }

    public void SetText(Dialogue dialogue)
    {
        _dialogueText.text = dialogue.DialogueText.ToString();
    }

    public void ChangeCharacter()
    {
        var nextIndex = _nextCharacter ? 0 : 1;
        var currentIndex = _nextCharacter ? 1 : 0;
        _characters[nextIndex].Highlight();
        _characters[currentIndex].UnHighlight();
        _nextCharacter = !_nextCharacter;
    }

    public void InitCharacters()
    {
        var nextIndex = _nextCharacter ? 0 : 1;
        var currentIndex = _nextCharacter ? 1 : 0;
        _characters[currentIndex].Highlight();
        _characters[nextIndex].UnHighlight();
    }

    private void OnClick()
    {
        Click?.Invoke();
    }
}
