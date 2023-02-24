using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CookButtonAction : MonoBehaviour
{ 
    [SerializeField] private Image _shadeIngredientsImage;
    [SerializeField] private InitPickedIngredients _pickedIngredients;
    
    private Button _clickButton;

    private TMP_Text _buttonText;
    public event Action<List<Ingridient>> CookingEnded;
    private List<Ingridient> _ingredients;

    private void Awake()
    {
        _clickButton = GetComponent<Button>();
        _buttonText = _clickButton.GetComponentInChildren<TMP_Text>();
    }

    private void OnEnable()
    {
        _clickButton.onClick.AddListener(OnCookButtonClick);
    }

    private void OnDisable()
    {
        _clickButton.onClick.RemoveListener(OnCookButtonClick);
    }

    public void OnCookButtonClick()
    {
        if (_pickedIngredients == null)
            return;
        _shadeIngredientsImage.gameObject.SetActive(true);
        _buttonText.text = "In progress...";
        _clickButton.enabled =false;
        _ingredients = _pickedIngredients.GetPickedIngredients();
        StartCoroutine(CookingProcess());
    }

    private IEnumerator CookingProcess()
    {
        yield return new WaitForSecondsRealtime(3f);
        _buttonText.text = "Cooked";
        CookingEnded?.Invoke(_ingredients);
    }
}
