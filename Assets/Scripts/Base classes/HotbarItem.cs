using UnityEngine;

public class HotbarItem : MonoBehaviour
{
	[SerializeField]private string itemName;
	[SerializeField]private GameObject item;
	[SerializeField]private Sprite itemIcon;
	
	public string ItemName
	{
		get { return itemName; }
		set { itemName = value; }
	}

	public GameObject Item
	{
		get { return item; }
		set { item = value; }
	}

	public Sprite ItemIcon
	{
		get { return itemIcon; }
		set { itemIcon = value; }
	}
}
