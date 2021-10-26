using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SkullGenerator : MonoBehaviour
{
    private Skull currentSkull;
    private List<GameObject> currentGOs;

    // Start is called before the first frame update
    void Start()
    {
        currentGOs = new List<GameObject>();
        GenerateSkull();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            DeleteSkull();
            GenerateSkull();
            DrawSkull();
        }
    }

    private void DrawSkull()
    {
        for (int i = 0; i < currentSkull.Positions.Count; i++)
        {
            GameObject newGO = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            newGO.transform.position = currentSkull.Positions[i];
            currentGOs.Add(newGO);
        }
    }

    private void GenerateSkull()
    {
        currentSkull = new Skull(setDetail: 10);
    }

    private void DeleteSkull()
    {
        for (int i = 0; i < currentGOs.Count; i++)
        {
            Destroy(currentGOs[i]);
        }
        currentGOs.Clear();
    }



}
