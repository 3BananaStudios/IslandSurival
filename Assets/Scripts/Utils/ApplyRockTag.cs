using System.Linq;
using UnityEngine;

public class ApplyRockTag : MonoBehaviour 
{
	void Awake () 
	{
		Transform[] rocks = GetComponentsInChildren<Transform>();

		foreach(Transform rock in rocks)
		{
			rock.tag = "rock";
		}
	}
}
