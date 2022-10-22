using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	private Animator anim;
	
	private float dirX = 0;
	private float dirY = 0;
	private int moveSpeed = 5;
	
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
		transform.position = new Vector2(transform.position.x + (dirX * moveSpeed * Time.deltaTime), transform.position.y + (dirY * moveSpeed * Time.deltaTime));
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
