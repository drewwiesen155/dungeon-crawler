using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	private Animator anim;
	
	private float dirX = 0;
	private float dirY = 0;
	private float deltaX = 0;
	private float deltaY = 0;
	private int moveSpeed = 5;
	private float maxDiagonal = 3.536f; //Max diagonal distance based on moveSpeed (Pythag/2)
	
	private enum Facing {left, right, up, down}
    // Start is called before the first frame update
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
		dirX = Input.GetAxisRaw("Horizontal");
		dirY = Input.GetAxisRaw("Vertical");
		
		deltaX = dirX * moveSpeed;
		deltaY = dirY * moveSpeed;
		
		//Set max Diagonal Speed. Avoid OG Doom speedrun bug
		if(dirX > 0 && dirY > 0)
		{
			deltaX = maxDiagonal;
			dirY = maxDiagonal;
		}
		else if(dirX > 0 && dirY < 0)
		{
			deltaX = maxDiagonal;
			dirY = -1 * maxDiagonal;
		}
		else if(dirX < 0 && dirY > 0)
		{
			deltaX = -1 * maxDiagonal;
			dirY = maxDiagonal;
		}
		else if(dirX < 0 && dirY < 0)
		{
			deltaX = -1 * maxDiagonal;
			dirY = -1 * maxDiagonal;
		}
		
		//Debug.Log("DirX: " + dirX + "\tDirY: " + dirY);
		transform.position = new Vector2(transform.position.x + (deltaX * Time.deltaTime), transform.position.y + (deltaY * Time.deltaTime));
		UpdateSprite();
    }
	
	private void UpdateSprite()
	{
		Facing playerDirection;
		
		if(dirX > 0f)
		{
			playerDirection = Facing.right;
		}
		else if(dirX < 0f)
		{
			playerDirection = Facing.left;
		}
		else if(dirY > 0f)
		{
			playerDirection = Facing.up;
		}
		else
		{
			playerDirection = Facing.down;
		}
		
		anim.SetInteger("playerDirection", (int) playerDirection);
	}
}
