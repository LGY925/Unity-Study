using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTest : MonoBehaviour
{
	#region Device
	// <Device>
	// 특정한 장치를 기준으로 입력 감지
	// 특정한 장치의 입력을 감지하기 때문에 여러 플랫폼에 대응이 어려움

	private void InputByDevice()
	{
        // 키보드 입력 감지

        if(Input.GetKey(KeyCode.Space))         // 누르고 있는 동안 true
        {
			Debug.Log("Space key is perssing");
		}
        if (Input.GetKeyDown(KeyCode.Space))    // 눌렀을 떄 한번만 true
        {
			Debug.Log("Space key is down");
		}
        if (Input.GetKeyUp(KeyCode.Space))      //눌렀다 땟을때 한번만 true
        {
			Debug.Log("Space key is up");
		}

        // 마우스 입력감지

        if (Input.GetMouseButton(0)) 
		{ 
			Debug.Log("Mouse left button is pressing");
		}
        if (Input.GetMouseButtonDown(0))
		{ 
			Debug.Log("Mouse left button is down");
		}
        if (Input.GetMouseButtonUp(0)) 
		{ 
			Debug.Log("Mouse left button is up");
		}

	}
	#endregion
	
	
	// < InputManager >
	// 여러 장치의 입력을 입력매니저에 이름과 입력을 정의
	// 입력매니저의 이름으로 정의한 입력의 변경사항을 확인
	// 유니티 에디터의 Edit -> Project Settings -> Input Manager 에서 관리
	// 단, 유니티 초창기의 방식이기 때문에 키보드, 마우스, 조이스틱에 대한 장치만을 고려함

	private void InputByInputManager()
	{
		// 버튼 입력
		// Fire1 : 키보드(Left ctrl), 마우스(Left button), 조이스틱(Button0)으로 정의함
		if (Input.GetButton("Fire1"))
		{
			Debug.Log("Fire1 is pressing");
		}
		if (Input.GetButtonDown("Fire1"))
		{
			Debug.Log("Fire1 is down");
		}
		if (Input.GetButtonUp("Fire1"))
		{
			Debug.Log("Fire1 is up");
		}

		// 축 입력
		// Horizontal(수평) : 키보드(a,d / ←,→), 조이스틱(왼쪽 아날로그스틱 좌우)
		float x = Input.GetAxis("Horizontal");
		if (x != 0 )
		{
			Debug.Log($"Horizontal Axis {x}");
		}
		// Vertical(수직) : 키보드(w,s / ↑,↓), 조이스틱(왼쪽 아날로그스틱 상하)
		float y = Input.GetAxis("Vertical");
		if(y != 0 )
		{
			Debug.Log($"Vertical Axis{y}");
		}
	}
}