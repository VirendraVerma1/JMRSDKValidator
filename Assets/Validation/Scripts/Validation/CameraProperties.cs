using System;
using System.Collections;
using UnityEngine;
using System.Reflection;
using TMPro;
using Object = UnityEngine.Object;

public class CameraProperties : MonoBehaviour
{
    public Camera cam;
    public string gameobjectPath;
    public TextMeshProUGUI debugText;
    string output = "";
    
    IEnumerator Start()
    {
        if (cam == null)
        {
            cam = GameObject.Find(gameobjectPath).GetComponent<Camera>();
        }
        while (true)
        {
            yield return new WaitForSeconds(1f);
            PrintPropertiesAndValues(cam);
            yield return null;
        }
    }

    private void Update()
    {
        
        debugText.text = output;
    }

    public void PrintPropertiesAndValues(Object obj)
    {
        PropertyInfo[] properties = obj.GetType().GetProperties();
        output = cam.gameObject.name + "\n";
        output += cam.transform.localPosition + "\n";
        output += cam.transform.localEulerAngles + "\n";
        output += cam.transform.localScale + "\n";
        
        output += $"Clear Flags: {cam.clearFlags}\n";
        output += $"Background Color: {cam.backgroundColor}\n";
        output += $"=====Culling Mask: {cam.cullingMask}=====\n";
        for (int i = 0; i < 32; i++)
        {
            int layerMask = 1 << i;
            if ((cam.cullingMask & layerMask) != 0)
            {
                string layerName = LayerMask.LayerToName(i);
                output += $"{i}.{layerName}, ";
            }
        }
        output += $"\n=============\n";
        output += $"Projection: {cam.projectionMatrix}\n";
        output += $"Viewport Rect: {cam.rect}\n";
        output += $"Field of View: {cam.fieldOfView}\n";
        output += $"Near Clipping Plane: {cam.nearClipPlane}\n";
        output += $"Far Clipping Plane: {cam.farClipPlane}\n";
        
        output += $"Depth: {cam.depth}\n";
        output += $"Rendering Path: {cam.renderingPath}\n";
        output += $"Target Texture: {cam.targetTexture}\n";
        output += $"Occlusion Culling: {cam.useOcclusionCulling}\n";
        output += $"HDR: {cam.allowHDR}\n";
        output += $"MSAA: {cam.allowMSAA}\n";
        output += $"Dynamic Resolution: {cam.allowDynamicResolution}\n";
        
        // foreach (PropertyInfo property in properties)
        // {
        //     output += ($"{property.Name} = {property.GetValue(obj, null)}\n");
        // }
    }
}