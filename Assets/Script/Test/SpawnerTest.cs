using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class SpawnerTest : MonoBehaviour
{
    public GameObject prefab;

    // public GameObject makeOne;
    

    private void Update()
    {

        if(Input.GetKeyUp(KeyCode.Z))
        {
            Spawn();
        }
        if (Input.GetKeyUp(KeyCode.X))
        {
            Destroy();
        }
    }
    public void Spawn()
    {
        //makeOne = new GameObject("Spawned GameObject");
        Instantiate(prefab, new Vector3(5f,5f,5f),Quaternion.identity);
    }

    public void Destroy()
    {
        Destroy(prefab, 3);
    }    
}
