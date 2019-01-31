using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class InteractablePlayTimeline : MonoBehaviour
{

	public float lookAtTime = 2.0f;
	public GameObject lookAtEnable;

	public PlayableDirector timelineObject;

	private float lookAtCounter = 0.0f;


	public virtual void OnSelectEnter()
    {
    	if (timelineObject.state != PlayState.Playing)
            lookAtCounter += Time.deltaTime;
    	lookAtEnable.SetActive(true);
    	if (lookAtCounter>lookAtTime)
    	{
    	   timelineObject.Play();
           lookAtCounter = 0.0f;
    	}
    }

    public virtual void OnSelectExit()
    {   
    	lookAtEnable.SetActive(false);
    	lookAtCounter = 0.0f;
    }
}
