using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Hotbar : MonoBehaviour
{
	#region Variables
	public static Hotbar Instance { set; get; }


	private GameObject[] hotbar = new GameObject[5];
	[HideInInspector]public int selectedSlot = 0;
	private int lastSelectedSlot = 0;

	#endregion Variables

	private void Awake()
	{
		Instance = this;
		// Adds hotbar slots to an array and sorts them by name
		hotbar = GameObject.FindGameObjectsWithTag("Hotbar").OrderBy(go => go.name).ToArray();
		for (int i = 0; i < hotbar.Length; i++)
		{
			hotbar[i].transform.GetChild(0).GetComponent<Image>().sprite = hotbar[i].GetComponent<HotbarItem>().ItemIcon;
		}
	}

	private void Update()
	{
		HotbarSelection();
	}

	private void HotbarScrollWithMouseWheel()
	{
		float w = Input.GetAxis("Mouse ScrollWheel");
		if (w > 0.0f && selectedSlot < 4)
		{
			selectedSlot++;
		}
		if (w < 0.0f && selectedSlot > 0)
		{
			selectedSlot--;
		}
	}

	private void HotbarScrollWithKeys()
	{
		if (Input.GetKeyDown(KeyCode.Alpha1))
			selectedSlot = 0;
		else if (Input.GetKeyDown(KeyCode.Alpha2))
			selectedSlot = 1;
		else if (Input.GetKeyDown(KeyCode.Alpha3))
			selectedSlot = 2;
		else if (Input.GetKeyDown(KeyCode.Alpha4))
			selectedSlot = 3;
		else if (Input.GetKeyDown(KeyCode.Alpha5))
			selectedSlot = 4;
	}

	private void HotbarSelection()
	{
		HotbarScrollWithMouseWheel();
		HotbarScrollWithKeys();
		hotbar[selectedSlot].GetComponent<Image>().color = Color.red;
		hotbar[selectedSlot].GetComponent<HotbarItem>().Item.SetActive(true);
		if (lastSelectedSlot != selectedSlot)
		{
			hotbar[lastSelectedSlot].GetComponent<Image>().color = Color.black;
			hotbar[lastSelectedSlot].GetComponent<HotbarItem>().Item.SetActive(false);
			lastSelectedSlot = selectedSlot;
		}
	}
}