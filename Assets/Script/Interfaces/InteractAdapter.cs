using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractAdapter : MonoBehaviour, IInteracable
{
    public UnityEvent OnInteracted;

    public void Interact()
    {
        OnInteracted?.Invoke();
    }
}