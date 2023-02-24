using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class LabelLGBT : MonoBehaviour
{
    [SerializeField] private float _intensivity;
    [SerializeField] private List<Color> _colors;
    
    private TMP_Text _text;

    private void OnEnable()
    {
        _text = GetComponent<TMP_Text>();
        StartCoroutine(DoRainbowTransitions());
    }

    private IEnumerator DoRainbowTransitions()
    {
        while(true)
            foreach (var color in _colors)
            {
                var tweener = _text.DOColor(color, _intensivity);
                yield return new WaitForSeconds(_intensivity);
            }
    }
    
}
