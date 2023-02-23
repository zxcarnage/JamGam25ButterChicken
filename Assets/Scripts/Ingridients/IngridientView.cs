using UnityEngine;
using UnityEngine.UI;

public class IngridientView : MonoBehaviour
{
    [SerializeField] public Ingridient _ingridient;

    [SerializeField] private Image _image;
    [SerializeField] private Text _name;

    public Ingridient Ingredient => _ingridient;
    private void Start()
    {
        _image.sprite = _ingridient.Icon;
        _name.text = _ingridient.Name;
    }
}
