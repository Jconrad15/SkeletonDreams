using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SkullGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject pointPrefab;

    private SkullOutLine currentSkullOutLine;
    private Eyes currentEyes;
    private Nose currentNose;
    private Mouth currentMouth;

    private List<GameObject> currentGOs;

    // Start is called before the first frame update
    void Start()
    {
        currentGOs = new List<GameObject>();
        GenerateSkull();
        DrawSkull();
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
        // Draw outline
        GameObject skullOutlineParent = new GameObject("skullOutlineParent");
        currentGOs.Add(skullOutlineParent);
        for (int i = 0; i < currentSkullOutLine.Positions.Count; i++)
        {
            CreatePoint(skullOutlineParent, currentSkullOutLine.Positions[i]);
        }

        // Draw eyes
        GameObject leftEyeParent = new GameObject("leftEyeParent");
        currentGOs.Add(leftEyeParent);
        for (int i = 0; i < currentEyes.LeftPositions.Count; i++)
        {
            CreatePoint(leftEyeParent, currentEyes.LeftPositions[i]);
        }

        GameObject rightEyeParent = new GameObject("rightEyeParent");
        currentGOs.Add(rightEyeParent);
        for (int i = 0; i < currentEyes.RightPositions.Count; i++)
        {
            CreatePoint(rightEyeParent, currentEyes.RightPositions[i]);
        }

        GameObject noseParent = new GameObject("noseParent");
        currentGOs.Add(noseParent);
        for (int i = 0; i < currentNose.Positions.Count; i++)
        {
            CreatePoint(noseParent, currentNose.Positions[i]);
        }

        GameObject mouthParent = new GameObject("mouthParent");
        currentGOs.Add(mouthParent);
        for (int i = 0; i < currentMouth.Positions.Count; i++)
        {
            CreatePoint(mouthParent, currentMouth.Positions[i]);
        }

    }

    private void CreatePoint(GameObject parent, Vector3 position)
    {
        GameObject newGO = Instantiate(pointPrefab);
        newGO.transform.position = position;
        newGO.transform.SetParent(parent.transform);
        currentGOs.Add(newGO);
    }

    private void GenerateSkull()
    {
        currentSkullOutLine = new SkullOutLine(setDetail: 50);
        currentEyes = new Eyes(setDetail: Random.Range(10, 20));
        currentNose = new Nose(setDetail: Random.Range(6, 12));
        currentMouth = new Mouth(setDetail: 11);
    }

    private void DeleteSkull()
    {
        for (int i = 0; i < currentGOs.Count; i++)
        {
            Destroy(currentGOs[i]);
        }
        currentGOs.Clear();

        currentEyes = null;
        currentSkullOutLine = null;
    }



}
