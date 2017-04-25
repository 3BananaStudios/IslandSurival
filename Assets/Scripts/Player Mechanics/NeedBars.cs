using UnityEngine;
using UnityEngine.UI;

public class NeedBars : MonoBehaviour 
{
	public static NeedBars Instance { set; get; }

	#region Variables
	[Header("Health Bar:")]
	public Image healthCurrentValue;
	[Range(0, 100)]
	public float hitDamage = 100f;
	private float maxHealth = 100.0f;
	[Space(20)]
	
	[Header("Food Bar:")]
	public Image foodCurrentValue;
	[Range(0, 100)]
	public float addHunger = 0f;
	private float maximumHunger = 100.0f;
	[Space(20)]

	[Header("Drink Bar:")]
	public Image drinkCurrentValue;
	[Range(0, 100)]
	public float addThirst = 0f;
	private float maximumThirst = 100.0f;
	[Space(20)]

	[Header("Stamina Bar:")]
	public Image staminaCurrentValue;
	[Range(0, 25)]
	public float takeawayStamina = 25f;
	private float maximumStamina = 25.0f;
	#endregion

	private void Awake()
	{
		Instance = this;
	}

	private void Update()
	{
		UpdateHealth();
		UpdateHunger();
		UpdateThirst();
		UpdateStamina();
	}


	private void UpdateHealth()
	{
		float healthChange = hitDamage / maxHealth;
		healthCurrentValue.rectTransform.localScale = new Vector3(healthChange, 1, 1);
		healthCurrentValue.color = Color.Lerp(Color.red, Color.green, healthChange);
	}

	private void UpdateHunger()
	{
		float foodChange = addHunger / maximumHunger;
		foodCurrentValue.rectTransform.localScale = new Vector3(foodChange, 1, 1);
		foodCurrentValue.color = Color.Lerp(Color.green, Color.red, foodChange);
	}

	private void UpdateThirst()
	{
		float thirstChange = addThirst / maximumThirst;
		drinkCurrentValue.rectTransform.localScale = new Vector3(thirstChange, 1, 1);
		drinkCurrentValue.color = Color.Lerp(Color.green, Color.red, thirstChange);
	}

	private void UpdateStamina()
	{
		if (takeawayStamina <= 0.0f)
		{
			vp_FPController.Instance.MotorAcceleration = 0.18f;
		}
		if (vp_FPController.Instance.MotorAcceleration == 0.252f)
			takeawayStamina -= 2 * Time.deltaTime;
		else if (vp_FPController.Instance.MotorAcceleration != 0.252f && takeawayStamina <= 25.0f)
			takeawayStamina += 1 * Time.deltaTime; 
		float staminaChange = takeawayStamina / maximumStamina;
		staminaCurrentValue.rectTransform.localScale = new Vector3(staminaChange, 1, 1);
		staminaCurrentValue.color = Color.Lerp(Color.red, Color.green, staminaChange);
	}
}
