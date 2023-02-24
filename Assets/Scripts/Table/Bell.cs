using System;
using UnityEngine;
using UnityEngine.UI;

public class Bell : MonoBehaviour
{
    [SerializeField] private CanvasRenderer _dialoguePanel;
    [SerializeField] private GoodButterChicken _goodButterChicken;
    [SerializeField] private BadButterChicken _badButterChicken;
    [SerializeField] private DialogueView _dialogueView;

    private Button _bellButton;

    private void Awake()
    {
        _bellButton = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _bellButton.onClick.AddListener(OnBellClicked);
    }

    private void OnDisable()
    {
        _bellButton.onClick.RemoveListener(OnBellClicked);
    }

    private void Update()
    {
        if (!_goodButterChicken.gameObject.activeInHierarchy && !_badButterChicken.gameObject.activeInHierarchy)
            _bellButton.enabled = false;
        else
            _bellButton.enabled = true;
    }

    private void OnBellClicked()
    {
        _dialoguePanel.gameObject.SetActive(true);
        
        if (_goodButterChicken.gameObject.activeInHierarchy)
        {
            _dialogueView.SetGoodDialogues();
            _goodButterChicken.gameObject.SetActive(false);
        }
        else if(_badButterChicken.gameObject.activeInHierarchy)
        {
            _dialogueView.SetBadDialogues();
            _badButterChicken.gameObject.SetActive(false);
        }
        _bellButton.enabled = false;
    }
}
