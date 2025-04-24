using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleBehaviour<T> : MonoBehaviour where T : MonoBehaviour
{
	private static T instance;
	public static T Instance { get { return instance; } }

	public static void CreateInstance()
	{
		if (instance == null)
		{
			T prefab = Resources.Load<T>("GameManager");
			instance = Instantiate(prefab);
			DontDestroyOnLoad(instance.gameObject);
		}
	}

	public static void ReleaseInstance()
	{
		if (instance != null)
		{
			Destroy(instance.gameObject);
			instance = null;
		}
	}
}