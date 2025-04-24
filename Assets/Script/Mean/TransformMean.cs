using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformMean : MonoBehaviour
{

    /****************************************************************\
     * 트랜스폼 (Transform)
     * 
     * 게임오브젝트의 위치, 회전, 크기를 저장하는 컴포넌트
     * 게임오브젝트의 부모-자식 상태를 저장하는 컴포넌트
     * 게임오브젝트는 반드시 하나의 트랜스폼 컴포넌트를 가지고 있으며 추가 & 제거할 수 없음
    \****************************************************************/




    [SerializeField] float moveSpeed;
    [SerializeField] Transform target;
    [SerializeField] float rate;
    [SerializeField] float rotateSpeed;

    private void Start()
    {
        Application.targetFrameRate = 30;
    }
    private void Update()
    {
        #region Position

        // 1. 벡터를 이용한 위치 설정
        transform.position = new Vector3(1, 2, 3);

        // 2. 방향으로 이동시키기

        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        // 3. 목적지로 이동시기키
        transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed);

        // 4. 보간해서 이동시키기
        transform.position = Vector3.Lerp(transform.position, target.position, rate);
        #endregion

        #region rotation

        // 1. 회전 직접 지정 : Euler를 이용하여 Quaternion으로 변환하여 사용 권장
        transform.rotation = Quaternion.Euler(0, 60, 0);

        // 1-1. 오일러를 쿼터니언으로 변환
        Quaternion a = Quaternion.Euler(0, 60, 0);

        // 1-2. 쿼터니언을 오일러로 변환
        Vector3 v = transform.rotation.eulerAngles;

        // 1-3. 방향 백터를 쿼터니언으로 변환
        Quaternion c = Quaternion.LookRotation(Vector3.right);

        // 1-4. 현재 회전을 방향백터로 변환
        Vector3 d = transform.right;

        // 2. 축을 기준으로 회전시키기
        transform.Rotate(Vector3.forward, rotateSpeed* Time.deltaTime);

        // 3. 지점을 기준으로 회전
        transform.RotateAround(target.position, Vector3.up, rotateSpeed * Time.deltaTime);

        // 4. 지점을 바라보도록 회전
        transform.LookAt(target.position);
        #endregion

        #region
        // 월드 기준
        Vector3 worldPosition = transform.position;
        Quaternion worldRotation = transform.rotation;

        // 로컬 기준
        Vector3 localPosition = transform.localPosition;
        Quaternion localRotation = transform.localRotation;

        #endregion
    }


}
