using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skull
{
    public List<Vector3> Positions { get; protected set; }

    private float a;
    private float b;
    private float c;

    private float p;
    private float q;

    private int detail;

    public Skull(int setDetail)
    {
        Positions = new List<Vector3>();
        detail = setDetail;

        SetValues();

        CreatePositions();
    }

    private void SetValues()
    {
        a = 1;
        b = 1;
        c = 1;

        p = 0.998f;
        q = 0.125f;
    }

    private void CreatePositions()
    {
        float t = 0;
        for (int i = 0; i < detail; i++)
        {

            Vector3 newPos = new Vector3
            {
                x =
                Mathf.Cos(t) * (a * Mathf.Sin(t) +
                                b * Mathf.Sqrt(1 - p * Mathf.Cos(t) * Mathf.Cos(t)) +
                                c * Mathf.Sqrt(1 - q * Mathf.Cos(t) * Mathf.Cos(t))),

                y =
                Mathf.Sin(t) * (a * Mathf.Sin(t) +
                                b * Mathf.Sqrt(1 - p * Mathf.Cos(t) * Mathf.Cos(t)) +
                                c * Mathf.Sqrt(1 - q * Mathf.Cos(t) * Mathf.Cos(t))),

                z = 0
            };

            Positions.Add(newPos);

            t += 1 / (float)detail;
        }
    }
}
