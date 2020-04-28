﻿using UnityEngine;
using FMODUnity;

public class CountdownSound : MonoBehaviour
{
	protected AudioSource m_Source;
	public StudioEventEmitter source;
	protected float m_TimeToDisable;

    protected const float k_StartDelay = 0.5f;
	
	void OnEnable()
	{
		source.Play();
		m_Source = GetComponent<AudioSource>();
		m_TimeToDisable = m_Source.clip.length;
        m_Source.PlayDelayed(k_StartDelay);
	}

	void Update()
	{
		m_TimeToDisable -= Time.deltaTime;

		if (m_TimeToDisable < 0)
			gameObject.SetActive(false);
	}
}
