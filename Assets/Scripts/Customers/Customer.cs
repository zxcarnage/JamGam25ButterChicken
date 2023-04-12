using System;
using UnityEngine;
using DG.Tweening;

public class Customer : MonoBehaviour
{
    [SerializeField] private TextAsset _goodStory;
    [SerializeField] private TextAsset _badStory;
    [SerializeField] private Sprite _portretteView;
    
    [Header("Animation")]
    [SerializeField] private Vector3 _target;
    [SerializeField] private float _animationDuration;

    public TextAsset GoodStory => _goodStory;
    public TextAsset BadStory => _badStory;
    
    public event Action CustomerLeaved;

    private void Start()
    {
        GoIn();
    }

    private void GoIn()
    {
        var tween = transform.DOMoveX(_target.x, _animationDuration);
        tween.OnComplete(() => CustomerLeaved?.Invoke());
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, _target);
    }
}
