using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseOnClick : MonoBehaviour {

	public void CloseProgram()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
