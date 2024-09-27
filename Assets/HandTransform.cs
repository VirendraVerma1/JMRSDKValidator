using System;
using JMRSDK.InputModule;
using UnityEngine;

public class HandTransform : MonoBehaviour
{
    public Vector3 offset;

    [SerializeField] private bool controlOrientation = true;
    [SerializeField] private Vector3 additionalOffset;
    
    private Vector3 _orientation;
    [SerializeField] int _zRotation;

    private void LateUpdate()
    {
        var controllerRay = JMRPointerManager.Instance.GetCurrentRay();
        transform.position = controllerRay.GetPoint(offset.magnitude) + additionalOffset;
        
        transform.LookAt(controllerRay.GetPoint(5));

        if (controlOrientation)
        {
            var source = JMRInteractionManager.Instance.GetCurrentSource();
            
            var controllerOrientation = Quaternion.identity;

            if (JMRInteractionManager.Instance.GetSupportedInteractionDeviceType() !=
                JMRInteractionManager.InteractionDeviceType.GAZE_AND_CLICK &&
                JMRInteractionManager.Instance.GetSupportedInteractionDeviceType() !=
                JMRInteractionManager.InteractionDeviceType.GAZE_AND_DWELL)
            {
                try
                {
                    source.TryGetPointerRotation(out controllerOrientation);
                }
                // ReSharper disable once EmptyGeneralCatchClause
                catch (Exception) { }
            }

            Transform transform1 = transform;
            _orientation = transform1.rotation.eulerAngles;
            _orientation.z = controllerOrientation.eulerAngles.z - _zRotation + 90f;
            transform1.eulerAngles = _orientation;
        }
    }
}