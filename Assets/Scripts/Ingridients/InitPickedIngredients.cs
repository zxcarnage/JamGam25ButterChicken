using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AddListOfIngredientsOnScreen))]
public class InitPickedIngredients : MonoBehaviour
{
    private List<GameObject> _allIngredients;
    private AddListOfIngredientsOnScreen _requiredIngredients;

    private void Awake()
    {
        _requiredIngredients = GetComponent<AddListOfIngredientsOnScreen>();
        _allIngredients = new List<GameObject>();
        _allIngredients = _requiredIngredients.AddIngredientFieldsToScreen();
    }

    public List<Ingridient> GetPickedIngredients()
    {
        List<Ingridient> pickedIngredients = new List<Ingridient>();

        foreach (var ingredient in _allIngredients)
            if (ingredient.GetComponentInChildren<Toggle>().isOn == true)
                pickedIngredients.Add(ingredient.GetComponent<IngridientView>().Ingredient);

            return pickedIngredients;
    }
}
