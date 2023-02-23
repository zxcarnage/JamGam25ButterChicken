using System.Collections.Generic;
using UnityEngine;

public class AddListOfIngredientsOnScreen : MonoBehaviour
{
    [SerializeField] private List<Ingridient> _allIngredientList;
    [SerializeField] private GameObject _ingredientFieldPrefab;
    [SerializeField] private GameObject _fieldsContainer;

    public List<GameObject> AddIngredientFieldsToScreen()
    {
        List<GameObject> listContainer = new List<GameObject>();
        foreach (var ingredient in _allIngredientList)
        {
            _ingredientFieldPrefab.GetComponent<IngridientView>()._ingridient = ingredient;
            Instantiate(_ingredientFieldPrefab, _fieldsContainer.transform);
            listContainer.Add(_ingredientFieldPrefab);
        }
        return listContainer;
    }
}
