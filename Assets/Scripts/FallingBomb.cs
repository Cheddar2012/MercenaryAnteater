using UnityEngine;
using System.Collections;

public class FallingBomb : MonoBehaviour 
{
	public int X;

	public int targetY;
	public int landingY;
	
	public int x_range = 30;
	public int y_range = 100;
	
	public GameObject shadow;
	public GameObject explode;

	public int speed = 2;
	// Use this for initialization
	void Start () 
	{
		X = (int)Random.Range(transform.position.x - x_range, transform.position.x + x_range);
		transform.position = new Vector2(X, transform.position.y);

		landingY = (int)Random.Range(targetY - y_range, targetY + y_range);

		shadow = (GameObject)Instantiate(shadow, new Vector2(X, landingY), Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () 
	{

		float fallDist = Vector3.Distance(transform.position, new Vector2(X, landingY) );

		if( (fallDist < 50) && (shadow.transform.localScale.x < 3) )
		{
			shadow.transform.localScale = new Vector2(shadow.transform.localScale.x + 0.1f, shadow.transform.localScale.y);
		}

		if(fallDist < speed)
		{
			speed = (int)fallDist - 1;
		}

		transform.position = new Vector2(transform.position.x, transform.position.y - speed);

		if(fallDist < 2)
		{
			explode = (GameObject)Instantiate(explode, (transform.position), Quaternion.identity);
			explode.transform.localScale = new Vector2(explode.transform.localScale.x * 2, explode.transform.localScale.y *2);
			explode.GetComponent<Explosion>().hero = false;

			Destroy (shadow);
			Destroy (gameObject);
		}
	}
}
