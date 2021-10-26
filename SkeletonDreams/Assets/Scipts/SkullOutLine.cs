using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullOutLine
{
    public List<Vector3> Positions { get; protected set; }

    private float a;
    private float b;
    private float c;

    private float p;
    private float q;

    private int detail;

    public SkullOutLine(int setDetail)
    {
        Positions = new List<Vector3>();
        detail = setDetail;

        SetValues();

        CreatePositions();
    }

    private void SetValues()
    {
        a = Random.Range(0.7f, 1f);
        b = Random.Range(0.7f, 1f);
        c = Random.Range(0.7f, 1f);

        p = Random.Range(0.9f, 1f); //0.998f;
        q = Random.Range(0.05f, 0.3f); //0.125f;
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

            t += 2*Mathf.PI / (float)detail;
        }
    }
}
