using UnityEngine;

public class PickaxeRaycast : MonoBehaviour
{
	//Variables
	public GameObject pickaxe;

	private bool isEquiped = false;

	private void Update()
	{
		if (!pickaxe.activeSelf && Input.GetKeyDown(KeyCode.Alpha2))
		{
			isEquiped = true;
			pickaxe.SetActive(true);
		}
		else if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			isEquiped = false;
			pickaxe.SetActive(false);
		}

		//Raycast
		Vector3 fwd = transform.TransformDirection(Vector3.forward);
		RaycastHit hit;

		//Origin, Direction, RaycastHit, Length
		if (Physics.Raycast(transform.position, fwd, out hit, 10))
		{
			if (hit.collider.tag == "tree" && Input.GetMouseButtonDown(0) && isEquiped == true)
			{
				Debug.Log("Pickaxe");
			}
		}
	}
}