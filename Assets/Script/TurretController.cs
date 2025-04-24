using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TurretController : MonoBehaviour 
{
	[SerializeField] Shooter shooter;
	private Transform turret;
	[SerializeField] float moveSpeed;



    private void Update()
	{
		Move();
		shooter.FireActing();
	}


    public void Move() 
	{
		turret = this.transform;
		Vector3 Tank = transform.localPosition;
        float y;
		if (Input.GetKey(KeyCode.Q))
		{
			y = Time.deltaTime;
			turret.Rotate(Tank, moveSpeed*y);
            
        }
		else if (Input.GetKey(KeyCode.E))
		{
			y = - Time.deltaTime;
            turret.Rotate(Tank, moveSpeed * y);
        }
		

    }
		
		

    
}