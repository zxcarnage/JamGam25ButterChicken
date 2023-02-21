using UnityEngine;
using UnityEngine.UI;

public class IngridientView : MonoBehaviour
{
    [SerializeField] private Ingridient _ingridient;

    [SerializeField] private Image _image;
    [SerializeField] private Text _name;
    [SerializeField] private bool _isPicked;

    private void Start()
    {
        _image.sprite = _ingridient.Icon;
        _name.text = _ingridient.Name;
        _isPicked = _ingridient.IsPicked;
    }
}
