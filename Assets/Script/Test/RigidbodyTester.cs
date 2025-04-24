using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyTester : MonoBehaviour
{
    [SerializeField] Rigidbody rigid;
    [SerializeField] float xInput;
    [SerializeField] float power;
    private void Update()
    {
        xInput = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        // 1. 힘 가해주기 : 가속시키기
        rigid.AddForce(Vector3.right * xInput * power, ForceMode.Force);

        // 2. 속도 설정하기 : 속도를 원하는 대로 설정
        rigid.velocity = Vector3.right * power * xInput;

        // 3. 회전력 가해주기 : 가속시키기
        rigid.AddTorque(Vector3.up * xInput * power, ForceMode.Force);
        
        // 4. 회전속도 설정하기
        rigid.angularVelocity = Vector3.up * power * xInput;

    }
}