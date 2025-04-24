using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectMean : MonoBehaviour
{
    
    /****************************************************************\
     * 게임오브젝트 (GameObject)
     * 
     * 씬을 구성하는 오브젝트이며 게임에 존재하는 모든 오브젝트는 게임오브젝트
     * 씬에 존재하여 육안에 보이는 물체 또는 육안으로 보이지 않는 기능을 위한 구성품
     * 게임오브젝트만으로는 독자적인 기능이 없음
     * 실직적인 기능은 컴포넌트들이 수행
     * 게임오브젝트는 컴포넌트들을 가지기 위한 컨테이너
    \****************************************************************/

    /****************************************************************\
     * 컴포넌트 (Component)
     * 
     * 특정한 기능을 수행할 수 있도록 구성한 작은 기능적 단위
     * 게임오브젝트의 작동과 관련한 부품
     * 게임오브젝트에 추가, 삭제하는 방식의 조립형 부품
    \****************************************************************/



    /****************************************************************\
     * MonoBehaviour
     * 
     * 컴포넌트가 기본클래스로 하는 클래스로 유니티 스크립트가 파생되는 기본 클래스
     * 게임오브젝트에 스크립트를 컴포넌트로서 연결할 수 있는 구성을 제공
    \****************************************************************/

    public GameObject target;
    public Transform camTransform;
    public Camera camComponent;


    void Start()
    {
        Debug.Log($"이 게임오브젝트의 이름{gameObject.name}");
        Debug.Log($"이 게임오브젝트의 활성화 여부{gameObject.activeSelf}");
        Debug.Log($"이 게임오브젝트의 레이어 활성화 여부{gameObject.layer}");
        Debug.Log($"이 게임오브젝트의 태그{gameObject.tag}");
        Debug.Log($"이 게임오브젝트의 정적상태 여부 여부{gameObject.isStatic}");

        target = GameObject.FindGameObjectWithTag("MainCamera");
        camTransform = target.transform;
        camComponent = target.GetComponent<Camera>();

        target.AddComponent<Rigidbody>();

        Destroy(gameObject);
        Destroy(camComponent);
    }


}

