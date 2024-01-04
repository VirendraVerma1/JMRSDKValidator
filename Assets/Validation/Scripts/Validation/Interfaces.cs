using System;
using JMRSDK.InputModule;
using TMPro;
using UnityEngine;

// ReSharper disable InconsistentNaming

namespace Validation.Scripts.Validation
{
	public class Interfaces : MonoBehaviour, ISelectHandler, ISelectClickHandler, IFocusable, ISwipeHandler, ITouchHandler,
		IBackHandler, IHomeHandler, IMenuHandler, IVoiceHandler, IFn1Handler, IFn2Handler, IManipulationHandler, IScreenTouchHandler 
	{
		public TextMeshProUGUI statusText;
		public bool isGlobalListener;

		public void SetGlobalListener()
		{
			isGlobalListener = true;
			JMRInputManager.Instance.AddGlobalListener(gameObject);
		}
		public void RemoveGlobalListener()
		{
			isGlobalListener = false;
			JMRInputManager.Instance.RemoveGlobalListener(gameObject);
		}

		private void Update() => SetStatus();

		void SetStatus()
		{
			statusText.text = $"isGlobalListener: {isGlobalListener}\n" + 
			                  $"OnSelectDown: {int_OnSelectDown} {string_OnSelectDown}\n" +
			                  $"OnSelectUp: {int_OnSelectUp} {string_OnSelectUp}\n" +
			                  $"OnSelectClicked: {int_OnSelectClicked} {string_OnSelectClicked}\n" +
			                  $"OnFocusEnter: {int_OnFocusEnter}\n" +
			                  $"OnFocusExit: {int_OnFocusExit}\n" +
			                  $"OnSwipeLeft: {int_OnSwipeLeft}\n" +
			                  $"onSwipeRight: {int_OnSwipeRight}\n" +
			                  $"OnSwipeUp: {int_OnSwipeUp}\n" +
			                  $"OnSwipeDown: {int_OnSwipeDown}\n" +
			                  $"OnSwipeStarted: {int_OnSwipeStarted}\n" +
			                  $"OnSwipeUpdated: {int_OnSwipeUpdated}\n" +
			                  $"OnSwipeCompleted: {int_OnSwipeCompleted}\n" +
			                  $"OnSwipeCanceled: {int_OnSwipeCanceled}\n" +
			                  $"OnTouchStart: {int_OnTouchStart}\n" +
			                  $"OnTouchStop: {int_OnTouchStop}\n" +
			                  $"OnTouchUpdated: {int_OnTouchUpdated}\n" +
			                  $"OnBackAction: {int_OnBackAction}\n" +
			                  $"OnHomeAction: {int_OnHomeAction}\n" +
			                  $"OnMenuAction: {int_OnMenuAction}\n" +
			                  $"OnVoiceAction: {int_OnVoiceAction}\n" +
			                  $"OnFn1Action: {int_OnFn1Action}\n" +
			                  $"OnFn2Action: {int_OnFn2Action}\n" +
			                  $"OnManipulationStarted: {int_OnManipulationStarted}\n" +
			                  $"OnManipulationUpdated: {int_OnManipulationUpdated}\n" +
			                  $"OnManipulationCompleted: {int_OnManipulationCompleted}\n" +
			                  $"OnScreenTouchBegan: {int_OnScreenTouchBegan}\n" +
			                  $"OnScreenTouchEnded: {int_OnScreenTouchEnded}\n" +
			                  $"OnScreenTouchClick: {int_OnScreenTouchClick}\n";
		}
	
		string string_OnSelectDown = "OnSelectDown";
		int int_OnSelectDown;
	
		public void OnSelectDown(SelectEventData eventData)
		{
			string_OnSelectDown = eventData.PressType.ToString();
			int_OnSelectDown++;
		}

		string string_OnSelectUp = "OnSelectUp";
		int int_OnSelectUp;
		public void OnSelectUp(SelectEventData eventData)
		{
			string_OnSelectUp = eventData.PressType.ToString();
			int_OnSelectUp++;
		}
		
		string string_OnSelectClicked = "OnSelectClicked";
		int int_OnSelectClicked;
		public void OnSelectClicked(SelectClickEventData eventData)
		{
			string_OnSelectClicked = eventData.PressType.ToString();
			int_OnSelectClicked++;
		}

		int int_OnFocusEnter;
		public void OnFocusEnter()
		{
			int_OnFocusEnter++;
		}
		
		int int_OnFocusExit;
		public void OnFocusExit()
		{
			int_OnFocusExit++;
		}

		int int_OnSwipeLeft;
		public void OnSwipeLeft(SwipeEventData eventData, float value)
		{
			int_OnSwipeLeft++;
		}

		int int_OnSwipeRight;
		public void OnSwipeRight(SwipeEventData eventData, float value)
		{
			int_OnSwipeRight++;
		}

		int int_OnSwipeUp;
		public void OnSwipeUp(SwipeEventData eventData, float value)
		{
			int_OnSwipeUp++;
		}

		int int_OnSwipeDown;
		public void OnSwipeDown(SwipeEventData eventData, float value)
		{
			int_OnSwipeDown++;
		}

		int int_OnSwipeStarted;
		public void OnSwipeStarted(SwipeEventData eventData)
		{
			int_OnSwipeStarted++;
		}

		int	int_OnSwipeUpdated;
		public void OnSwipeUpdated(SwipeEventData eventData, Vector2 swipeData)
		{
			int_OnSwipeUpdated++;
		}
		
		int int_OnSwipeCompleted;
		public void OnSwipeCompleted(SwipeEventData eventData)
		{
			int_OnSwipeCompleted++;
		}

		int int_OnSwipeCanceled;
		public void OnSwipeCanceled(SwipeEventData eventData)
		{
			int_OnSwipeCanceled++;
		}

		int int_OnTouchStart;
		public void OnTouchStart(TouchEventData eventData, Vector2 TouchData)
		{
			int_OnTouchStart++;
		}

		int int_OnTouchStop;
		public void OnTouchStop(TouchEventData eventData, Vector2 TouchData)
		{
			int_OnTouchStop++;
		}

		int int_OnTouchUpdated;
		public void OnTouchUpdated(TouchEventData eventData, Vector2 TouchData)
		{
			int_OnTouchUpdated++;
		}

		int int_OnBackAction;
		public void OnBackAction()
		{
			int_OnBackAction++;
		}
		
		int int_OnHomeAction;
		public void OnHomeAction()
		{
			int_OnHomeAction++;
		}

		int int_OnMenuAction;
		public void OnMenuAction()
		{
			int_OnMenuAction++;
		}

		int int_OnVoiceAction;
		public void OnVoiceAction()
		{
			int_OnVoiceAction++;
		}

		int int_OnFn1Action;
		public void OnFn1Action()
		{
			int_OnFn1Action++;
		}
	
		int int_OnFn2Action;
		public void OnFn2Action()
		{
			int_OnFn2Action++;
		}

		int int_OnManipulationStarted;
		public void OnManipulationStarted(ManipulationEventData eventData)
		{
			int_OnManipulationStarted++;
		}

		int int_OnManipulationUpdated;
		public void OnManipulationUpdated(ManipulationEventData eventData)
		{
			int_OnManipulationUpdated++;
		}

		int int_OnManipulationCompleted;
		public void OnManipulationCompleted(ManipulationEventData eventData)
		{
			int_OnManipulationCompleted++;
		}

		int int_OnScreenTouchBegan;
		public void OnScreenTouchBegan()
		{
			int_OnScreenTouchBegan++;
		}

		int int_OnScreenTouchEnded;
		public void OnScreenTouchEnded()
		{
			int_OnScreenTouchEnded++;
		}

		int int_OnScreenTouchClick;
		public void OnScreenTouchClick()
		{
			int_OnScreenTouchClick++;
		}
	}
}
