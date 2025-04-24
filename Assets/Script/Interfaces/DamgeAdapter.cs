using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class DamageAdapter : MonoBehaviour, IDamgable
{
    public UnityEvent<GameObject, int> OnDamaged;
    public void TakeDamage(GameObject dealer, int damage)
    {
        OnDamaged?.Invoke(dealer, damage);
    }
}