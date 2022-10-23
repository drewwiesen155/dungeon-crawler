using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
	public GameObject projectileSpawn;
	public GameObject projectilePrefab;
	public float shootSpeed = 10f;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("q"))
		{
			GameObject proj = Instantiate(projectilePrefab, projectileSpawn.transform, false);
			Debug.Log(projectileSpawn.transform.position.x + ", " + projectileSpawn.transform.position.y);
			proj.GetComponent<Rigidbody2D>().AddForce(new Vector2(shootSpeed, shootSpeed));
		}
    }
}
