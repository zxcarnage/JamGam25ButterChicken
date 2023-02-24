using System.Collections.Generic;
using UnityEngine;

public class AddListOfIngredientsOnScreen : MonoBehaviour
{
    [SerializeField] private List<Ingridient> _allIngredientList;
    [SerializeField] private GameObject _ingredientFieldPrefab;
    [SerializeField] private GameObject _fieldsContainer;

   // private List<GameObject> _listContainer;

    public void AddIngredientFieldsToScreen()
    {
        //_listContainer = new List<GameObject>();
        foreach (var ingredient in _allIngredientList)
        {
            _ingredientFieldPrefab.GetComponent<IngridientView>()._ingridient = ingredient;
            Instantiate(_ingredientFieldPrefab, _fieldsContainer.transform);
            //_listContainer.Add(_ingredientFieldPrefab);
        }
    }

    /*public List<GameObject> GetAllIngredientPannels()
    {

        return _listContainer;
    }*/
}
