using UnityEngine;
using UnityEngine.UI;

public class NeedBars : MonoBehaviour 
{
	[Header("Health Bar:")]
	public Image currentValue;
	[Range(0, 100)]
	public float hitDamage = 0.0f;
	private float maxHealth = 100.0f;

	private void Update()
	{
		UpdateHealth();
	}


	private void UpdateHealth()
	{
		float ratio = hitDamage / maxHealth;
		currentValue.rectTransform.localScale = new Vector3(ratio, 1, 1);
		currentValue.color = Color.Lerp(Color.red, Color.green, ratio);
	}

	
}
