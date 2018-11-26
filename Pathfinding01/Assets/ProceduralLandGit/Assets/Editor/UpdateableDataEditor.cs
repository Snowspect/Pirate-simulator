using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomEditor (typeof(UpdateAbleData),true)]
public class UpdateableDataEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        UpdateAbleData data = (UpdateAbleData)target;

        if (GUILayout.Button("Update"))
        {
            data.NotifyOfUpdatedvalues();
        }
    }
}
