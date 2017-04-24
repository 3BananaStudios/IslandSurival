using UnityEngine;

public class Item
{
	private string itemName;
	private int itemWeight;
	private Sprite itemIcon;

	public string ItemName
	{
		get { return itemName; }
		set { itemName = value; }
	}

	public int ItemWeight
	{
		get { return itemWeight; }
		set { itemWeight = value; }
	}

	public Sprite ItemIcon
	{
		get { return itemIcon; }
		set { itemIcon = value; }
	}
}
