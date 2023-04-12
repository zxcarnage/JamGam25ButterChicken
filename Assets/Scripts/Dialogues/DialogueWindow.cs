using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;

public class DialogueWindow : MonoBehaviour
{
    [SerializeField] private TMP_Text _dialogueText;
    public TextAsset Story { get; set; }

    private Story _story;
    private DialogueFace[] _speakers;
    
    private Button _dialogueButton;
   

    private void Awake()
    {
        _speakers = GetComponentsInChildren<DialogueFace>();
        _dialogueButton = GetComponentInChildren<Button>();
    }

    private void OnEnable()
    {
        _dialogueButton.onClick.AddListener(ContinueDialogue);
        EnterDialogue();
    }

    private void OnDisable()
    {
        _dialogueButton.onClick.RemoveListener(ContinueDialogue);
    }

    private void EnterDialogue()
    {
        _story = new Story(Story.text);
        ContinueDialogue();
    }

    private void ContinueDialogue()
    {
        if (_story.canContinue)
        {
            _dialogueText.text = _story.Continue();
            HandleTags(_story.currentTags);
        }
        else
        {
            ExitDialogueMode();
        }
    }

    private void HandleTags(List<string> unparsedTags)
    {
        Dictionary<string, string> storyTags = ParseTags(unparsedTags);
        foreach (var pair in storyTags)
        {
            switch (pair.Key)
            {
                case "speaker":
                    ChooseSpeaker(pair.Value);
                    break;
            }
        }
    }

    private void ChooseSpeaker(string name)
    {
        foreach (var speaker in _speakers)
        {
            if (speaker.Name == name)
            {
                speaker.Highlight();
            }
            else
            {
                speaker.Unhighlight();
            }
        }
    }

    private Dictionary<string,string> ParseTags(List<string> unparsedTags)
    {
        Dictionary<string, string> storyTags = new Dictionary<string, string>();
        foreach (var unparsedTag in unparsedTags)
        {
            string[] tag = unparsedTag.Split(":");
            var key = tag[0].Trim();
            var value = tag[1].Trim();
            storyTags[key] = value;
        }

        return storyTags;
    }

    private void ExitDialogueMode()
    {
        _dialogueText.text = "";
        gameObject.SetActive(false);
    }
}
