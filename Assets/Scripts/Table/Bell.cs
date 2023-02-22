using System;
using UnityEngine;
using UnityEngine.UI;

public class Bell : MonoBehaviour
{
    [SerializeField] private CanvasRenderer _dialoguePanel;
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

    private void OnBellClicked()
    {
        _dialoguePanel.gameObject.SetActive(true);
    }
}
