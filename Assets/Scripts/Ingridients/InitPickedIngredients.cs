using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitPickedIngredients : MonoBehaviour
{
    [SerializeField] private List<GameObject> _allIngredients;

    public List<Ingridient> GetPickedIngredients()
    {
        List<Ingridient> pickedIngredients = new List<Ingridient>();

        foreach (var ingredient in _allIngredients)
            if (ingredient.GetComponentInChildren<Toggle>().isOn == true)
                pickedIngredients.Add(ingredient.GetComponent<IngridientView>().ingridient);

            return pickedIngredients;
    }
}
