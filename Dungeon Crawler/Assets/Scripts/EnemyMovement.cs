using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
	public GameObject player;
	public float moveSpeed = 4f;
	public float aggroDistance = 5f;
	private bool aggro = false;

    // Update is called once per frame
    void Update()
    {
		if(aggro)
		{
			transform.position = Vector2.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
		}
		else
		{
			aggro = setAggro();
		}
    }
	
	private bool setAggro()
	{
		float distance = Vector2.Distance(player.transform.position, transform.position);
		//Debug.Log("Distance between player and enemy: " + distance);
		
		if(distance <= aggroDistance)
			return true;
		else
			return false;
	}
}
