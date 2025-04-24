using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using Unity.VisualScripting;
using UnityEngine;

public class SerializationMean : MonoBehaviour
{

    /****************************************************************\
     * 직렬화 (Serialization)
     * 
     * 데이터 구조 또는 게임오브젝트 상태를 보관하고 관리하는 기법
     * 인스펙터 창에서 오브젝트의 직렬화된 멤버변수 값을 보여줌
     * 이를 이용하여 소스코드의 수정 없이 유니티 에디터에서 값을 변경 가능
    \****************************************************************/
    
    // C# Type
    public bool boolValue;
    public int intValue;
    public float floatValue;
    public string stringValue;

    // Unity Type
    public Vector3 vector3;
    public Vector3Int vector3Int;
    public Vector2 vector2;
    public Vector2Int vector2Int;
    public Color color;
    public Rect rect;
    public LayerMask layerMask;
    public AnimationCurve curve;
    public Gradient gradient;
    
    // 열거형
    public ForceMode mode;

    // 직렬화 가능한 필드의 배열 및 List<T>
    public int[] array;
    public List<int> list;

    [Header("Reference")]
    // Object Type
    public new GameObject gameObject;
    public new Transform transform;
    public new Rigidbody rigidbody;
    public new Collider collider;

    // <어트리뷰트>
    // 클래스, 속성 또는 함수 위에 명시하여 특별한 동작을 나타낼 수 있는 마커

    [Space(30)]

    [Header("Unity Attribute")]

    [SerializeField]
    private int privateValue;

    [HideInInspector]
    public int publicValue;

    [Range(0, 10)]
    public float rangeValue;

    [TextArea(3, 5)]
    public string textField;

    [Serializable] // 구조체에 직렬화 가능 속성을 포함
    public struct StructType
    {
        public int value1;
        public string value2;
    }
    public StructType structField;

    [Serializable] // 클래스에 직렬화 가능 속성을 포함
    public class ClassType
    {
        public int value1;
        public string value2;
    }
    public ClassType classField;
    
    

    /****************************************************************\
     * 유니티 메시지 함수
     * 
     * 유니티가 보내는 메시지에 반응하는 함수
     * MonoBehaviour 클래스에 메시지와 같은 이름의 함수가 반응
     * 스크립트는 유니티 엔진이 보내는 메시지를 받아 사건 타이밍을 확인
     * 메시지 함수에서 자신의 행동을 정의하여 기능을 구성
    \****************************************************************/

    // 함수 : 기능



    private void Awake()
    {
        // 스크립트가 씬에 포함되었을 때 1회 호출
        // 스크립트가 비활성화 되어 있는 경우에도 호출됨

        // 역할 : 스크립트가 필요로 하는 초기화 작업 진행
        //        (외부 게임상황과 무관한 초기화 작업)

        Debug.Log("Awake");
    }

    private void Start()
    {
        // 스크립트가 씬에 처음으로 Update하기 직전에 1회 호출
        // 스크립트가 비활성화 되어 있는 경우 호출되지 않음

        // 역할 : 스크립트가 필요로 하는 초기화 작업 진행
        //        (외부 게임상황이 필요한 초기화 작업)

       Debug.Log("Start");
    }

    private void OnEnable()
    {
        // 스크립트가 활성화될 때마다 호출

        // 역할 : 스크립트가 활성화 되었을 때 작업 진행

        Debug.Log("OnEnable");
    }

    private void OnDisable()
    {
        // 스크립트가 비활성화될 때마다 호출

        // 역할 : 스크립트가 비활성화 되었을 때 작업 진행

        Debug.Log("OnDisable");
    }

    private void Update()
    {
        // 게임의 프레임 처음마다 호출

        // 역할 : 핵심 게임 로직 구현

        Debug.Log("Udpate");
    }

    private void LateUpdate()
    {
        // 게임의 프레임 마지막마다 호출
        // 씬의 모든 게임오브젝트의 Update가 진행된 후 호출

        // 역할 : 게임프레임의 진행 결과가 필요한 동작이 있는 기능 구현

        Debug.Log("LateUpdate");
    }

    private void FixedUpdate()
    {
        // 일정한 시간(기본 1초에 50번) 마다 호출
        // Update와 다르게 프레임당 연산과 단위시간이 일정
        // 물리엔진과 같이 게임의 프레임과 무관하게 일정해야 하는 작업에 사용
        // 게임로직 등 연산이 많은 작업을 FixedUpdate에 구현하지 않아야 함

        // 역할 : 물리엔진 작업 진행

        Debug.Log("FixedUdpate");
    }

    private void OnDestroy()
    {
        // 스크립트가 씬에서 삭제되었을 때 1회 호출

        // 역할 : 스크립트가 필요로 하는 마무리 작업 진행

        Debug.Log("OnDestroy");
    }


}
