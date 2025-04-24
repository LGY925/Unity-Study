using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    [SerializeField] GameObject door;

    private bool IsdoorOpened => door.activeSelf == false;

    public void SwichAction()
    {
        if (IsdoorOpened)
        {
            Close();
        }
        else
        {
            Open();
        }
    }

    public void Open()
    {
        door.SetActive(false);
    }
    public void Close()
    {
        door.SetActive(true);
    }
}