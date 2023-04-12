using System;
using UnityEngine;
using UnityEngine.UI;

public class Bell : MonoBehaviour
{
    [SerializeField] private DialogueWindow _dialogueWindow;
    [SerializeField] private GoodButterChicken _goodButterChicken;
    [SerializeField] private BadButterChicken _badButterChicken;

    public Customer Customer { get; set; }
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
        if (_goodButterChicken.gameObject.activeInHierarchy)
        {
            _dialogueWindow.Story = Customer.GoodStory;
            _goodButterChicken.gameObject.SetActive(false);
        }
        else if(_badButterChicken.gameObject.activeInHierarchy)
        {
            _dialogueWindow.Story = Customer.BadStory;
            _badButterChicken.gameObject.SetActive(false);
        }
        _dialogueWindow.gameObject.SetActive(true);
        _bellButton.enabled = false;
    }
}
