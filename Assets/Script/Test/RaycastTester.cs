using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class RaycastTester : MonoBehaviour
{
    private void Update()
    {
        // 래이캐스트 : 시작위치에서 방향으로 레이저를 발사하여 부딫히는 충돌체를 감지
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hitInfo, 10f))
        {
            // 레이저에 닿은 충돌체가 있다
            Debug.Log(hitInfo.collider.gameObject.name);
            Debug.DrawLine(transform.position, hitInfo.point, Color.green);
        }
        else
        {
            // 레이저에 닿은 충돌체가 없다
            Debug.Log("Lost Collider");
            Debug.DrawLine(transform.position, transform.position + transform.forward * 10f, Color.red);
        }
        
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 3f);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.forward * 10);
    }

}