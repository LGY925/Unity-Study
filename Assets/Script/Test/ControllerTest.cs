using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public Rigidbody body;
    public float jumpPower;
    public float movePower;


    private void Start()
    {
        // 시작할떄 호출됨
        Debug.Log("Start!");
        body.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Debug.Log("왼쪽 눌렸음");
            body.AddForce(Vector3.left * movePower, ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Debug.Log("오른쪽 눌렸음");
            body.AddForce(Vector3.right * movePower, ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Debug.Log("위 눌렸음");
            body.AddForce(Vector3.forward * movePower, ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            Debug.Log("아래 눌렸음");
            body.AddForce(Vector3.back * movePower, ForceMode.Impulse);
        }

        // 동작중에 계속 호출됨
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("점프가 눌렸음");
            body.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        }
    }
}
