using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nose
{

    public List<Vector3> Positions { get; protected set; }

    private float a;
    private float b;

    private int detail;
    private float noseScale;
    private float upShift;

    public Nose(int setDetail)
    {
        Positions = new List<Vector3>();
        detail = setDetail;

        SetValues();

        CreatePositions();
    }

    private void SetValues()
    {
        noseScale = Random.Range(0.1f, 0.2f);
        upShift = Random.Range(0.3f, 0.8f);
        a = Random.Range(0.5f, 1f);
        b = Random.Range(0.2f, 0.9f);

    }

    private void CreatePositions()
    {
        float t = 0;
        for (int i = 0; i < detail; i++)
        {

            Vector3 newPos = new Vector3
            {
                x = noseScale * a * (1 - b - Mathf.Cos(t)) * Mathf.Sin(t),

                y = noseScale * a * (1 - b - Mathf.Cos(t)) * Mathf.Cos(t),

                z = 0
            };

            // Shift up
            newPos.y += upShift;

            Positions.Add(newPos);

            t += 2 * Mathf.PI / (float)detail;
        }
    }



}
