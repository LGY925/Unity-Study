using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public new string name;

    public void Talk()
    {
        Debug.Log($"{name} : �ȳ��ϼ���!");
    }

    public void Die()
    {
        Debug.Log($"{name} : ����!");
        Destroy(gameObject);
    }
}
