using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ButterChicken : MonoBehaviour
{
    [SerializeField] private CookButtonAction _cookingButton;
    [SerializeField] private Transform _butterChicken;
    [SerializeField] private Transform _failedButterChicken;
    [SerializeField] private List<Ingridient> _receipt;

    private void OnEnable()
    {
        _cookingButton.CookingEnded += CookDish;
    }

    private void OnDisable()
    {
        _cookingButton.CookingEnded -= CookDish;
    }

    private bool TryCookDish(List<Ingridient> ingredients)
    {
        return _receipt.All(ingredients.Contains) && _receipt.Count == ingredients.Count;
    }

    private void CookDish(List<Ingridient> ingridients)
    {
        if (TryCookDish(ingridients))
            _butterChicken.gameObject.SetActive(true);
        else
            _failedButterChicken.gameObject.SetActive(true);
    }
}
