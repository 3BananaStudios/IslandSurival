using UnityEngine;

public class Rock : MonoBehaviour 
{
	private GameObject thisRock;
	public int rockDurability = 8;

	void Awake () 
	{
		thisRock = transform.gameObject;
	}
	
	void Update () 
	{
		if (rockDurability <= 0)
		{
			Destroy(thisRock);
		}
	}
}
