using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Experimental.GlobalIllumination;

public class UnityEventTester : MonoBehaviour
{
    public UnityEvent<float> myEvent;

    public UnityAction<float> myAction;
   

    private void Awake()
    {

        myEvent.AddListener(myAction);

        myEvent.RemoveListener(myAction);

    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.K))
        {
            myEvent.Invoke(10f);
        }
    }
}