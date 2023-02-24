using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;

public class Customer : MonoBehaviour
{
    [SerializeField] private float _animationDuration;
    [SerializeField] private Vector3 _target;

    public event Action CustomerLeaved;
    public void GoAway()
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
