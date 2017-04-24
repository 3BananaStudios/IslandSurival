using System;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
	public static PlayerInteraction Instance { set; get; }

	[Header("Sound Clips")]
	public AudioClip axeHitSound;

	private void Awake()
	{
		Instance = this;
	}

	private void Update()
	{
		//Raycast
		Vector3 fwd = transform.TransformDirection(Vector3.forward);
		RaycastHit hit;

		//Origin, Direction, RaycastHit, Length
		if ((Physics.Raycast(transform.position, fwd, out hit, 2.5f)) && (Input.GetMouseButtonDown(0)))
		{
			switch (Hotbar.Instance.selectedSlot)
			{
				case 0:
					UseAxe(hit);
					break;

				case 1:
					UsePickaxe(hit);
					break;

				case 2:
					UseKnife(hit);
					break;

				case 3:
					UseHammer(hit);
					break;

				default:
					Debug.Log("Oops, I dont know what to do!");
					break;
			}
		}
	}

	private void UseAxe(RaycastHit hit)
	{
		if (hit.collider.tag == "tree" && Axe.Instance.isAxeSwinging == false && (hit.collider.gameObject.GetComponent<Tree>().isFallen == false))
		{
			Axe.Instance.SwingAxe();
			SoundManager.PlaySound(axeHitSound);
			Tree treeScript = hit.collider.gameObject.GetComponent<Tree>();
			treeScript.treeHealth--;
		}
	}

	private void UsePickaxe(RaycastHit hit)
	{
		if (hit.collider.tag == "rock")
		{
			Rock rockScript = hit.collider.gameObject.GetComponent<Rock>();
			rockScript.rockDurability--;
		}
		
	}

	private void UseKnife(RaycastHit hit)
	{
		throw new NotImplementedException();
	}

	private void UseHammer(RaycastHit hit)
	{
		throw new NotImplementedException();
	}
}