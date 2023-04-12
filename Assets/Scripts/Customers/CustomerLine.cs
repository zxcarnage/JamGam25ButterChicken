using System;
using UnityEngine;

public class CustomerLine : MonoBehaviour
{
    [SerializeField] private Bell _bell;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.TryGetComponent(out Customer customer))
        {
            _bell.Customer = customer;
        }
    }
}