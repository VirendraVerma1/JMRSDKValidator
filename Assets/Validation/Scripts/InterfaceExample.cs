/*Example to use Interfaces to add interaction of objects/UI*/

using JMRSDK;
using JMRSDK.InputModule;
using TMPro;
using UnityEngine;

public class InterfaceExample : MonoBehaviour, ISelectHandler, ISelectClickHandler, IFocusable, ISwipeHandler, ITouchHandler,
    IBackHandler, IMenuHandler, IVoiceHandler, IFn1Handler, IFn2Handler, IManipulationHandler
{
    public TextMeshProUGUI logText;

    private void Start()
    {
        JMRInputManager.Instance.AddGlobalListener(gameObject);
    }

    private void LogMessage(string message)
    {
        logText.text += $"{message}\n";
        logText.text = logText.text.Substring(Mathf.Max(0, logText.text.Length - 1000));
    }
    
    public void OnBackAction()
    {
        LogMessage("OnBackAction");
    }

    public void OnFn1Action()
    {
        LogMessage("OnFn1Action");
    }

    public void OnFn2Action()
    {
        LogMessage("OnFn2Action");
    }

    public void OnFocusEnter()
    {
       // LogMessage("OnFocusEnter");
    }

    public void OnFocusExit()
    {
        //LogMessage("OnFocusExit");
    }

    public void OnManipulationCompleted(ManipulationEventData eventData)
    {
        //LogMessage("OnManipulationCompleted");
    }

    public void OnManipulationStarted(ManipulationEventData eventData)
    {
        //LogMessage("OnManipulationStarted");
    }

    public void OnManipulationUpdated(ManipulationEventData eventData)
    {
        //LogMessage("OnManipulationUpdated");
    }

    public void OnMenuAction()
    {
        LogMessage("OnMenuAction");
    }

    public void OnSelectClicked(SelectClickEventData eventData)
    {
        LogMessage("OnSelectClicked");
    }

    public void OnSelectDown(SelectEventData eventData)
    {
        LogMessage("ex_OnSelectDown" + this.gameObject);
    }

    public void OnSelectUp(SelectEventData eventData)
    {
        LogMessage("EX_OnSelectUp"+ this.gameObject);
    }

    public void OnSwipeCanceled(SwipeEventData eventData)
    {
        LogMessage("OnSwipeCanceled");
    }

    public void OnSwipeCompleted(SwipeEventData eventData)
    {
        LogMessage("OnSwipeCompleted");
    }

    public void OnSwipeDown(SwipeEventData eventData, float delta)
    {
        LogMessage("OnSwipeDown");
    }

    public void OnSwipeLeft(SwipeEventData eventData, float delta)
    {
        LogMessage("OnSwipeLeft");
    }

    public void OnSwipeRight(SwipeEventData eventData, float delta)
    {
        LogMessage("OnSwipeRight");
    }

    public void OnSwipeStarted(SwipeEventData eventData)
    {
        LogMessage("OnSwipeStarted");
    }

    public void OnSwipeUp(SwipeEventData eventData, float delta)
    {
        LogMessage("OnSwipeUp");
    }

    public void OnSwipeUpdated(SwipeEventData eventData, Vector2 delta)
    {
        LogMessage("OnSwipeUpdated");
    }

    public void OnTouchStart(TouchEventData eventData, Vector2 touchData)
    {
        LogMessage("OnTouchStarted " + touchData);
    }

    public void OnTouchStop(TouchEventData eventData, Vector2 touchData)
    {
        LogMessage("OnTouchStop " + touchData);
    }

    public void OnTouchUpdated(TouchEventData eventData, Vector2 touchData)
    {
        LogMessage("OnTouchUpdated " + touchData);
    }

    public void OnVoiceAction()
    {
        Debug.Log("OnVoiceAction");
    }
}