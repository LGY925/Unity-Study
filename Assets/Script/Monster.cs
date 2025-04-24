using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour, IDamgable
{
    [Header("Component")]
    [SerializeField] Transform eyeTransform;

    [Header("Property")]
    [SerializeField] float sightRange;
    [SerializeField] float moveSpeed;
    [SerializeField] int hp;
    public int HP { get { return hp;  } private set { hp = value; } }

    [SerializeField] GameObject target;

    private void Update()
    {
        if (target != null)
        {
            Trace();
        }
    }

    private void Trace()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime);
        transform.LookAt(target.transform.position);
    }
   
    public void TakeDamage (GameObject dealer, int damage)
    {
        Debug.Log($"{gameObject.name} 이/가 {dealer.name}에게 {damage} 피해를 받았습니다");
        HP -= damage;
        if (hp <= 0)
        {
            Die();
        }
    }


    public void Die()
    {
        Manager.Game.score += 1;
        Destroy(gameObject);
        
    }
}
