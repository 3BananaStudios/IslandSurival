using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour 
{

	private static AudioSource source;

	void Start () 
	{
		source = GetComponent<AudioSource>();
	}
	
	void Update () 
	{
		
	}

	public static void PlaySound(AudioClip clip)
	{
		source.PlayOneShot(clip);
	}
}
