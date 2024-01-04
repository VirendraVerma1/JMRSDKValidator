using System;
using System.Collections;
using System.Collections.Generic;
using JMRSDK;
using UnityEngine;

public class JMRDeviceCanvasPosition : MonoBehaviour
{
    [System.Serializable]
    public struct DeviceCanvasPosition
    {
        public JMRRigManager.DeviceType deviceType;
        public Vector3 canvasPosition;
        public Vector3 canvasScale;
    }

    public JMRRigManager.DeviceType setEditorAsDeviceType;
    public bool overrideScale;
    public List<DeviceCanvasPosition> deviceCanvasPositions;

    private void Start()
    {
        int deviceID = JMRRigManager.Instance.getDeviceID();
        JMRRigManager.DeviceType deviceType = (JMRRigManager.DeviceType) deviceID;

        if (Application.isEditor) deviceType = setEditorAsDeviceType;
        
        foreach (DeviceCanvasPosition deviceCanvasPosition in deviceCanvasPositions)
        {
            if (deviceCanvasPosition.deviceType == deviceType)
            {
                transform.localPosition = deviceCanvasPosition.canvasPosition;
                if(overrideScale) transform.localScale = deviceCanvasPosition.canvasScale;
            }
        }
    }
}
