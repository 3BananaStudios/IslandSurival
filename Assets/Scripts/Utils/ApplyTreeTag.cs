using System.Linq;
using UnityEngine;

public class ApplyTreeTag : MonoBehaviour 
{
	void Awake () 
	{
		Transform[] trees = GetComponentsInChildren<Transform>();

		foreach(Transform tree in trees)
		{
			tree.tag = "tree";
		}
	}
}
