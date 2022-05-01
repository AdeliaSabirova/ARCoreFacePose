using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(XRInteractorLineVisual))]
[RequireComponent(typeof(ActionBasedController))]
public class CheckRenderLine : MonoBehaviour
{
    [SerializeField] private Camera _arCamera;

    private ActionBasedController _controller;
    private XRInteractorLineVisual _interactorLine;

    private void Start()
    {
        if (_arCamera.stereoEnabled)
        {
            enabled = false;
        }

        _controller = GetComponent<ActionBasedController>();
        _interactorLine = GetComponent<XRInteractorLineVisual>();
    }

    private void Update()
    {
        HandleLineRenderer();
    }

    private void HandleLineRenderer()
    {
        var state = _controller.currentControllerState;
        if(state != null && (state.inputTrackingState & UnityEngine.XR.InputTrackingState.Position) != 0)
        {
            _interactorLine.enabled = true;
            _interactorLine.reticle.SetActive(true);
        }
        else
        {
            _interactorLine.enabled = false;
            _interactorLine.reticle.SetActive(false);
        }
    }
}
