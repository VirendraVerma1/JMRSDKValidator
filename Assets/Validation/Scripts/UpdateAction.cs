using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdateAction : MonoBehaviour
{
    public TextMeshProUGUI actionsText;

    private void Update()
    {
        actionsText.text = $"{JMRInteraction.GetTouch()}\n\n";
        bool swipe;
        swipe = JMRInteraction.GetSwipeUp(out float val);
        actionsText.text += $"Swipe up: {swipe}\n";
        swipe = JMRInteraction.GetSwipeDown(out val);
        actionsText.text += $"Swipe down: {swipe}\n";
        swipe = JMRInteraction.GetSwipeLeft(out val);
        actionsText.text += $"Swipe left: {swipe}\n";
        swipe = JMRInteraction.GetSwipeRight(out val);
        actionsText.text += $"Swipe right: {swipe}\n\n";
        actionsText.text += $"GetSelect {JMRInteraction.GetSelect()}\n";
        actionsText.text += $"GetSourceDown Back {JMRInteraction.GetSourceDown(JMRSDK.InputModule.JMRInteractionSourceInfo.Back)}\n";
        actionsText.text += $"GetSourceDown Home {JMRInteraction.GetSourceDown(JMRSDK.InputModule.JMRInteractionSourceInfo.Home)}\n";
        actionsText.text += $"GetSourceDown Fn {JMRInteraction.GetSourceDown(JMRSDK.InputModule.JMRInteractionSourceInfo.Function)}\n";
    }
}
