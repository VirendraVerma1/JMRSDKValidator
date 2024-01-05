using JMRSDK;
using JMRSDK.InputModule;
using TMPro;
using UnityEngine;
// ReSharper disable InconsistentNaming

public class APIValidator : MonoBehaviour
{
	public TextMeshProUGUI statusText;
	public TextMeshProUGUI debugText;
	public GameObject orientWithController;
	string apiResult = "";
	string debugResult = "";
		
	bool? isDockVisible = null;
	public void ToggleDockVisibility()
	{
		isDockVisible = isDockVisible == null ? true : !isDockVisible;
		JMRSystemDockManager.Instance.ToggleDockVisiblity(isDockVisible.Value);
	}
	private void Update()
	{
		apiResult = "API Validator\n";
		apiResult += $"JMRSystemDockManager.Instance.isDockEnabled(): {JMRSystemDockManager.Instance.isDockEnabled()}\n";
		apiResult += $"IsDockVisible in script: {isDockVisible}\n";
		statusText.text = apiResult;
		
		debugResult = "Debug Validator\n";
		debugResult += $"JMRInteraction.GetTouch() {JMRInteraction.GetTouch()}\n";
		debugResult += $"JMRRigManager.Instance.GetHeadObject(): {JMRRigManager.Instance.GetHeadObject()}\n";
		debugResult += $"JMRTrackerManager.Instance.GetHeadPosition(): {JMRTrackerManager.Instance.GetHeadPosition()}\n";
		debugResult += $"JMRTrackerManager.Instance.GetHeadTransform(): {JMRTrackerManager.Instance.GetHeadTransform()}\n";
		debugResult += $"JMRPointerManager.Instance.PreferredPointingSource: {JMRPointerManager.Instance.PrefferedPointingSource}\n";
		debugResult += $"JMRInteractionManager.Instance.GetSupportedInteractionDeviceType(): {JMRInteractionManager.Instance.GetSupportedInteractionDeviceType()}\n";
		debugResult += $"JMRRigManager.Instance.getDeviceID(): {JMRRigManager.Instance.getDeviceID()}->{(JMRRigManager.DeviceType)JMRRigManager.Instance.getDeviceID()} \n";
		debugResult += $"JMRPointerManager.Instance.GetCurrentRay(): {JMRPointerManager.Instance.GetCurrentRay()}\n";
		debugResult += $"JMRPointerManager.Instance.GetCurrentFocusedObject(): {JMRPointerManager.Instance.GetCurrentFocusedObject()}\n";
		debugResult += $"JMRPointerManager.Instance.GetCursor(): {JMRPointerManager.Instance.GetCursor()}\n";
		debugResult += $"JMRPointerManager.Instance.GetCurrentRay(): {JMRPointerManager.Instance.GetCurrentRay()}\n";
		debugResult += $"JMRPointerManager.Instance.GetCursorTransform(): {JMRPointerManager.Instance.GetCursorTransform()}\n";
		debugText.text = debugResult;

		try
		{
			IInputSource source = JMRInteractionManager.Instance.GetCurrentSource();
			Quaternion controllerOrientation;
			source.TryGetPointerRotation(out controllerOrientation);
			orientWithController.transform.rotation = controllerOrientation;
		}
		catch { }
	}
}
