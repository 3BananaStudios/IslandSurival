using UnityEngine;

public class Axe : MonoBehaviour 
{
	public static Axe Instance { set; get; }	

	private Animation swingAnimation;
	public bool isAxeSwinging;

	void Start () 
	{
		Instance = this;
		swingAnimation = GetComponent<Animation>();
		swingAnimation.wrapMode = WrapMode.Once;
	}
	
	void Update () 
	{
		if(swingAnimation.isPlaying)
		{
			isAxeSwinging = true;
		}else {
			isAxeSwinging = false;
		}
	}

	public void SwingAxe()
	{
		swingAnimation.Play();
	}
}
