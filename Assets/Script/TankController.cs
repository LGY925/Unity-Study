using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    
    [SerializeField] float moveSpeed;
    [SerializeField] float rotateSpeed;

    private void Update()
    {
        Move();
        Rotate();
    }

    private void Move()
    {
        float input = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward*moveSpeed*input*Time.deltaTime);
    }

    private void Rotate()
    {
        float input = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up,rotateSpeed*input*Time.deltaTime);
    }

}
