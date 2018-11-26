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
}
