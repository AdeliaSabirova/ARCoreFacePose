using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class FaceMaterialSwitcher : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Materials to use for face meshes.")]
    private Material[] _faceMaterials;

    private static int _currentMaterialIndex;

    private void Update()
    {
        if(Input.touchCount > 0)
        {
            GetComponent<MeshRenderer>().material = _faceMaterials[_currentMaterialIndex];
            _currentMaterialIndex = (_currentMaterialIndex + 1) % _faceMaterials.Length;
        }
    }

}
