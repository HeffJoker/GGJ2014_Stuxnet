using UnityEngine;
using System.Collections;

public class AudioClipController : UniversalClick 
{
	public bool AutoPlay 		  	 = false;
	public bool Loop 			  	 = false;
	public bool PlayOnClick			 = false;
	public float SecondsBetweenLoops = 5;
	// Use this for initialization
	void Start () 
	{	
		if (AutoPlay) 
		{
			PlayAttachedSound(false);
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		//Plays the attached AudioSource component
		if(Loop && audio.isPlaying==false)
			PlayAttachedSound(true);
	}
	
	public void PlayAttachedSound(bool allowDelay)
	{
		//Check if this
		if(allowDelay && SecondsBetweenLoops > 0)
			audio.PlayDelayed(SecondsBetweenLoops);
		else
			audio.Play();
	}
	
	public void StopSound()
	{
		audio.Stop();
	}
	
	public void Pause()
	{
		audio.Pause();
	}
	
	public override void clickOn()
	{
		if(PlayOnClick)
			audio.Play();
	}
}