using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullet : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] Rigidbody rigid;
    // public BulletPool returnPool;
    [SerializeField] float returnTime;
    private float timer;

    [Header("Propertis")]
    [SerializeField] GameObject hitEffetPrefap;
    public int attackPoint;

    private void OnEnable()
    {
        timer = returnTime;
    }
    private void Update()
    {
        /*
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            ReturnPool();
        }
        */
    }

    /*
    public void ReturnPool()
    {
        if (returnPool == null)
        {
            Destroy(gameObject);
        }
        else
        {
            returnPool.ReturnPool(this);
        }
    }
    */
    //private void OnCollisionEnter(Collision collision)
    //{
    //    ReturnPool();
    //    Instantiate(hitEffetPrefap, transform.position, transform.rotation);
    //
    //    IDamgable damgable = collision.gameObject.GetComponent<IDamgable>();
    //    if (damgable != null)
    //    {
    //        Attack(damgable);
    //    }
    //}
    private void OnCollisionEnter(Collision collision)
    {
        
        Instantiate(hitEffetPrefap, transform.position, transform.rotation);

        IDamgable damgable = collision.gameObject.GetComponent<IDamgable>();
        if (damgable != null)
        {
            Attack(damgable);
        }
        Destroy(gameObject);
    }
    private void Attack(IDamgable damgable)
    {
        damgable.TakeDamage(gameObject, attackPoint);
    }
}