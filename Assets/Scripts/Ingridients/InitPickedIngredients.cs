using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AddListOfIngredientsOnScreen))]
public class InitPickedIngredients : MonoBehaviour
{
    private IngridientView[] _allIngredients;
    private AddListOfIngredientsOnScreen _requiredIngredients;
    [SerializeField] private ContentSizeFitter _content;
    private List<Ingridient> _pickedIngredients;

    private void Awake()
    {
        _requiredIngredients = GetComponent<AddListOfIngredientsOnScreen>();
        _requiredIngredients.AddIngredientFieldsToScreen();
        Init();
    }

    private void Init()
    {
        _allIngredients = _content.GetComponentsInChildren<IngridientView>();
    }
    public List<Ingridient> GetPickedIngredients()
    {
        _pickedIngredients = new List<Ingridient>();

        foreach (var ingredient in _allIngredients)
            if (ingredient.GetComponentInChildren<Toggle>().isOn == true)
                _pickedIngredients.Add(ingredient.GetComponent<IngridientView>().Ingredient);

        foreach (var ingredient in _pickedIngredients)
            Debug.Log(ingredient.Name + "\n");
        return _pickedIngredients;
    }
}
