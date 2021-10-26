using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eyes
{
    public List<Vector3> LeftPositions { get; protected set; }
    public List<Vector3> RightPositions { get; protected set; }

    private float a;
    private float b;
    private float c;

    private float p;
    private float q;

    private int detail;

    private float eyeScale;
    private float upShift;
    private float outShift;

    public Eyes(int setDetail)
    {
        LeftPositions = new List<Vector3>();
        RightPositions = new List<Vector3>();
        detail = setDetail;

        SetValues();

        CreatePositions();
    }

    private void SetValues()
    {
        eyeScale = Random.Range(0.08f, 0.24f);
        upShift = Random.Range(0.5f, 1f);
        outShift = Random.Range(0.3f, 0.8f);

        a = Random.Range(0.7f, 1f);
        b = Random.Range(0.9f, 1f);
        c = Random.Range(0.15f, 0.9f);

        p = Random.Range(0f, 1f);
        q = Random.Range(0f, 1f);
    }

    private void CreatePositions()
    {
        float t = 0;
        for (int i = 0; i < detail; i++)
        {

            Vector3 newPos = new Vector3
            {
                x = eyeScale *
                Mathf.Cos(t) * (a * Mathf.Sin(t) +
                                b * Mathf.Sqrt(1 - p * Mathf.Cos(t) * Mathf.Cos(t)) +
                                c * Mathf.Sqrt(1 - q * Mathf.Cos(t) * Mathf.Cos(t))),

                y = eyeScale *
                Mathf.Sin(t) * (a * Mathf.Sin(t) +
                                b * Mathf.Sqrt(1 - p * Mathf.Cos(t) * Mathf.Cos(t)) +
                                c * Mathf.Sqrt(1 - q * Mathf.Cos(t) * Mathf.Cos(t))),

                z = 0
            };

            // Shift up
            newPos.y += upShift;

            // Shift left
            newPos.x -= outShift;
            LeftPositions.Add(newPos);

            // Shift right
            newPos.x += 2 * outShift;
            RightPositions.Add(newPos);

            t += 2 * Mathf.PI / (float)detail;
        }
    }

}
