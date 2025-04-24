using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
public class BulletPool : MonoBehaviour 
{
    [SerializeField] List<Bullet> pool = new List<Bullet>();
    [SerializeField] Bullet prefab;
    [SerializeField] int size;

    private void Awake()
    {
        for (int i = 0; i < size; i++)
        {
            Bullet instance = Instantiate(prefab);
            instance.gameObject.SetActive(false);
            pool.Add(instance);
        }

    }
    public Bullet GetPool(Vector3 position, Quaternion rotation)
    {
        if (pool.Count == 0)
        {
            return Instantiate(prefab, position, rotation);
        }
        Bullet instance = pool[pool.Count - 1];
        pool.RemoveAt(pool.Count - 1);

        instance.returnPool = this;
        instance.transform.position = position;
        instance.transform.rotation = rotation;
        instance.gameObject.SetActive(true);

        return instance;
    }
    public void ReturnPool(Bullet instance)
    {
        instance.gameObject.SetActive(false);
        pool.Add(instance);
    }
}
*/