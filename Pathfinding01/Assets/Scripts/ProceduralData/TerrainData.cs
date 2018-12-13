using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class TerrainData : UpdateAbleData {

    public float uniformScale = 1f;
    public bool useFalloff;

    // Mesh
    public float meshHeightMultiplier;
    public AnimationCurve meshHeightCurve;

    public float minHeight
    {
        get
        {
            return uniformScale * meshHeightMultiplier * meshHeightCurve.Evaluate(0);
        }
    }
    public float maxHeight
    {
        get { return uniformScale * meshHeightMultiplier * meshHeightCurve.Evaluate(1); }
    }
}
