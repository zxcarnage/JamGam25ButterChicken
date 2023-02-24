using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class Character : MonoBehaviour
{
    [SerializeField] private string _characterName;
    [SerializeField] private Image _image;

    public string CharacterName => _characterName;

    public void Highlight()
    {
        _image.color = new Color(255, 255, 255, 1f);
    }

    public void UnHighlight()
    {
        _image.color = new Color(255, 255, 255, 0f);
    }
}
