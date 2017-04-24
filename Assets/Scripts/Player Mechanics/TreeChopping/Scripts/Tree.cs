using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
	//Variables
	private GameObject thisTree;
	public GameObject log, logDestination;
    public int treeHealth = 5;
    public bool isFallen = false;

    private void Start()
    {
        thisTree = transform.gameObject;
    }

    private void Update()
    {
        if(treeHealth <= 0 && isFallen == false)
        {
            Rigidbody rb = thisTree.AddComponent<Rigidbody>();
            rb.isKinematic = false;
			rb.mass = 50.0f;
            rb.useGravity = true;
            rb.AddForce(Vector3.forward, ForceMode.Impulse);
            StartCoroutine(destroyTree());
            isFallen = true;
        }
    }

    private IEnumerator destroyTree()
    {
        yield return new WaitForSeconds(15);
		for (int i = 0; i <= 3; i ++)
		{
			Instantiate(log, thisTree.transform.GetComponentInParent<Transform>().position, thisTree.transform.rotation, logDestination.transform);
		}
		Destroy(thisTree);
	}
}
