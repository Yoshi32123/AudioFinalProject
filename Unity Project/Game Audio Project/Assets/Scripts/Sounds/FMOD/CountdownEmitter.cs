using System.Collections;
using System.Collections.Generic;
using FMODUnity;
using UnityEngine;

public class CountdownEmitter : MonoBehaviour
{
    private StudioEventEmitter emitter;

    // Start is called before the first frame update
    void Start()
    {
        emitter = GetComponent<FMODUnity.StudioEventEmitter>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
