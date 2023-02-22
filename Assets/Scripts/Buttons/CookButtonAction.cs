using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CookButtonAction : MonoBehaviour
{ 
    [SerializeField] private Image _shadeIngredientsImage;
    [SerializeField] private Button _clickButton;

    private Text _buttonText;
    public event Action<List<Ingridient>> CookingEnded;
    private InitPickedIngredients _pickedIngredients;
    private List<Ingridient> _ingredients;

    private void Awake()
    {
        _pickedIngredients = GetComponent<InitPickedIngredients>();
        _buttonText = _clickButton.GetComponentInChildren<Text>();
    }
    public void OnCookButtonClick()
    {
        _shadeIngredientsImage.gameObject.SetActive(true);
        _buttonText.text = "In progress...";
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
