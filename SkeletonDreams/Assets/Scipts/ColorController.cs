using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;


public class ColorController : MonoBehaviour
{
    private Volume vol;
    private SplitToning splitToning;

    // Start is called before the first frame update
    void Start()
    {
        vol = gameObject.GetComponent<Volume>();
        vol.profile.TryGet<SplitToning>(out splitToning);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            splitToning.active = !splitToning.active;

        }
    }
}
