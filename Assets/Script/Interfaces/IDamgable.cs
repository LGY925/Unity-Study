using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IDamgable
{
	public GameObject gameObject { get; }
	public void TakeDamage(GameObject dealer, int damage);

}