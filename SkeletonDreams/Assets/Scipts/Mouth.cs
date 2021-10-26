using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouth
{
    public List<Vector3> Positions { get; protected set; }

    private int detail;

    private float lineHeight;
    private float lineLength;

    public Mouth(int setDetail)
    {
        Positions = new List<Vector3>();
        detail = setDetail;

        SetValues();

        CreatePositions();
    }

    private void SetValues()
    {
        lineHeight = Random.Range(-0.4f, -0.2f);
        lineLength = Random.Range(0.8f, 1.2f);
    }

    private void CreatePositions()
    {
        // Create upper line
        float t = -lineLength / 2f;
        for (int i = 0; i < detail; i++)
        {
            Vector3 newPos = new Vector3();

            newPos.x = t + 0.05f;
            newPos.y = lineHeight;
            newPos.z = 0;

            Positions.Add(newPos);

            t += lineLength / (float)detail;
        }
    }


}
