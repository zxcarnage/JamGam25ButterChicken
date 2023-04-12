using System;
using UnityEngine;
using UnityEngine.UI;

public class DialogueFace : MonoBehaviour
{
    [SerializeField] private string _name;

    public string Name => _name;

    private Image _image;

    private void OnEnable()
    {
        _image = GetComponent<Image>();
    }

    public void Unhighlight()
    {
        _image.color = new Color(1, 1, 1, 0);
    }

    public void Highlight()
    {
        _image.color = new Color(1, 1, 1, 1);
    }
}
