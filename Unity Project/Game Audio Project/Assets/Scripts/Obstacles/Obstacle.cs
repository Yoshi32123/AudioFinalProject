using System.Collections;
using UnityEngine;
using FMODUnity;

/// <summary>
/// This script is the base class for implemented obstacles.
/// Derived classes should take care of spawning any object needed for the obstacles.
/// </summary>
[RequireComponent(typeof(AudioSource))]
public abstract class Obstacle : MonoBehaviour
{
	public AudioClip impactedSound;
	public StudioEventEmitter impactEmitter;

    public virtual void Setup() {}

    public abstract IEnumerator Spawn(TrackSegment segment, float t);

	public virtual void Impacted()
	{
		Animation anim = GetComponentInChildren<Animation>();
		//AudioSource audioSource = GetComponent<AudioSource>();
		//StudioEventEmitter audioSource = GetComponent

		if (anim != null)
		{
			anim.Play();
		}

		impactEmitter.Play();
	}
}
