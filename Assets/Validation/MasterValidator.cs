using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using JMRSDK;
using JMRSDK.InputModule;
using TMPro;
using UnityEngine;

public class MasterValidator : MonoBehaviour, IDwellHandler
{
    public TextMeshProUGUI logText;

    private void Start()
    {
        RecenterTest();
        InvokeRepeating(nameof(CheckForDeviceInfo), 3f, 3f);
    }

    void CheckForDeviceInfo()
    {
        StartCoroutine(WaitTilFindController());
    }

    private void Update()
    {
        TrackerManagerMethodsUpdateLoop();
        DeviceUpdate();
        GetHeadOrientationUpdate();
        GetControllerOrientationUpdate();
        hitInfoNameUpdate();
        getcurrentFocusedObjectUpdate();
        getCursorInfoUpdate();
        getCursorCurrentRayUpdate();
        getCursorTransformUpdate();
    }

    private void OnEnable()
    {
        TrackerManagerSubscribe();
        VoiceSubscribe();
        DeviceSubscribe();
    }

    private void OnDisable()
    {
        TrackerManagerUnSubscribe();
        VoiceUnsubscribe();
        DeviceUnscbscribe();
    }

    public void LogMessage(string message, TextMeshProUGUI tempTMP = null, bool alsoinlogs = true)
    {
        if (tempTMP != null)
        {
            tempTMP.text = $"{message}\n";
            if (alsoinlogs)
                logText.text += $"{message}\n";
        }
        else
        {
            logText.text += $"{message}\n";
        }
        logText.text = logText.text.Substring(Mathf.Max(0, logText.text.Length - 1000));
    }

    #region Clear Logs

    public void ClearLogs(TextMeshProUGUI pro)
    {
        pro.text = "";
    }

    #endregion

    #region Interaction Pointer

    [Header("Pointers")] public TextMeshProUGUI rayHitInfoName;
    public TextMeshProUGUI rayHitFocusedInfo;
    public TextMeshProUGUI rayHitGetCursor;
    public TextMeshProUGUI rayHitCurrentRay;
    public TextMeshProUGUI rayHitCurrenttransform;

    private void hitInfoNameUpdate()
    {
        var ray = JMRPointerManager.Instance.GetCurrentRay();
        if (Physics.Raycast(ray, out var hit)) LogMessage(hit.transform.name, rayHitInfoName);
    }

    private void getcurrentFocusedObjectUpdate()
    {
        var go = JMRPointerManager.Instance.GetCurrentFocusedObject();
        //LogMessage(go.name,rayHitFocusedInfo,false);
    }

    private void getCursorInfoUpdate()
    {
        var cursor = JMRPointerManager.Instance.GetCursor();
        LogMessage(cursor.name, rayHitGetCursor, false);
    }

    private void getCursorCurrentRayUpdate()
    {
        var ray = JMRPointerManager.Instance.GetCurrentRay();
        LogMessage(ray.ToString(), rayHitCurrentRay, false);
    }

    private void getCursorTransformUpdate()
    {
        var cursorTransform = JMRPointerManager.Instance.GetCursorTransform();
        LogMessage(cursorTransform.eulerAngles.ToString(), rayHitCurrenttransform, false);
    }

    #endregion

    #region Actions

    [Header("Actions")] public TextMeshProUGUI actionsHeadOrientationText;
    public TextMeshProUGUI actionsControllerText;

    //ray is tested on the pointer manager area
    private void GetHeadOrientationUpdate()
    {
        var head = JMRTrackerManager.Instance.GetHeadTransform();
        LogMessage("Head t=" + head.eulerAngles, actionsHeadOrientationText, false);
    }

    private void GetControllerOrientationUpdate()
    {
        var source = JMRInteractionManager.Instance.GetCurrentSource();
        Quaternion controllerOrientation;
        try
        {
            source.TryGetPointerRotation(out controllerOrientation);
            LogMessage("C t=" + controllerOrientation.eulerAngles, actionsControllerText, false);
        }catch{ }
    }

    #endregion

    #region Gaze and Dwell

    [Header("Gaze and Dwell")] public TextMeshProUGUI gazeanddwellStarted;

    public void OnDwellStart()
    {
        LogMessage("Dwell Started", gazeanddwellStarted);
    }

    public void OnDwellCancel()
    {
        LogMessage("Dwell Cancel", gazeanddwellStarted);
    }

    public void OnDwellCompleted()
    {
        LogMessage("Dwell Completed", gazeanddwellStarted);
    }

    #endregion

    #region Device State

    [Header("Device State")] public TextMeshProUGUI deviceTypeText;
    public TextMeshProUGUI deviceOnConnectText;
    public TextMeshProUGUI deviceOnDisConnectText;
    public TextMeshProUGUI devicebatteryperUpdateText;
    public TextMeshProUGUI devicebatteryforscanningText;
    public TextMeshProUGUI devicebatterypercentageText;
    public TextMeshProUGUI deviceindexText;

    private void DeviceSubscribe()
    {
        JMRInteractionManager.OnConnected += OnConnect;
        JMRInteractionManager.OnDisconnected += OnDisconnect;
        JMRInteractionManager.OnBatteryUpdate += OnBatteryUpdate;
        JMRInteractionManager.OnStartScanning += OnStartScan;
        isInitialized = false;
        Controllers = new List<IInputSource>();
        StartCoroutine(WaitTilFindController());
    }

    private void DeviceUnscbscribe()
    {
        JMRInteractionManager.OnConnected -= OnConnect;
        JMRInteractionManager.OnDisconnected -= OnDisconnect;
        JMRInteractionManager.OnBatteryUpdate -= OnBatteryUpdate;
        JMRInteractionManager.OnStartScanning -= OnStartScan;
        isInitialized = false;
        Controllers = new List<IInputSource>();
    }

    private void DeviceUpdate()
    {
        if (!isInitialized) return;
        try{
        float batterPercentage = JMRInteractionManager.Instance.GetBatteryPercentage(Controllers[0].inputIndex);
        devicebatterypercentageText.text = batterPercentage.ToString();
        }catch{}
    }

    private void OnConnect(JMRInteractionManager.InteractionDeviceType devType, int index, string val)
    {
        //do something when connected
        var deviceType = devType;
        var deviceIndex = index;
        var deviceName = val;
        LogMessage(index + "|" + val, deviceOnConnectText);
    }

    private void OnDisconnect(JMRInteractionManager.InteractionDeviceType devType, int index, string val)
    {
        //do something when connected
        var deviceType = devType;
        var deviceIndex = index;
        var DeviceName = val;
        LogMessage(index + "|" + val, deviceOnDisConnectText);
    }

    private void OnBatteryUpdate(JMRInteractionManager.InteractionDeviceType devType, int index, int percentage)
    {
        //do something when battery updated
        var deviceType = devType;
        var deviceIndex = index;
        var batteryPercentage = percentage;
        LogMessage(index.ToString(), deviceindexText);
        LogMessage(index + "|" + batteryPercentage, devicebatteryperUpdateText);
    }

    private void OnStartScan(JMRInteractionManager.InteractionDeviceType devType, int index)
    {
        var deviceType = devType;
        var deviceIndex = index;
        LogMessage(index.ToString(), devicebatteryforscanningText);
    }

    private List<IInputSource> Controllers = new List<IInputSource>();
    private bool isInitialized;

    private IEnumerator WaitTilFindController()
    {
        isInitialized = true;
        LogMessage("device connected");
        var deviceType = JMRInteractionManager.Instance.GetSupportedInteractionDeviceType();
        deviceTypeText.text = deviceType.ToString();
        LogMessage("Device Type = " + deviceType);
        do
        {
            Controllers = JMRInteractionManager.Instance.GetSources();
            yield return null;
        } while (Controllers.Count == 0);

    }

    #endregion

    #region Voice

    [Header("Voice")] public TextMeshProUGUI voiceEventText;
    public TextMeshProUGUI voiceResultTimeText;
    public TextMeshProUGUI voiceResultSpeechText;
    public TextMeshProUGUI voiceSpeechErrorText;
    public TextMeshProUGUI voiceSpeechSessionEndText;
    public TextMeshProUGUI voiceSpeechCancledText;

    private void VoiceSubscribe()
    {
        JMRVoiceManager.OnSpeechEvent += SpeechEvent;
        JMRVoiceManager.OnSpeechResults += SpeachResult;
        JMRVoiceManager.OnSpeechPartialResults += SpeechPartialResult;
        JMRVoiceManager.OnSpeechError += SpeechError;
        JMRVoiceManager.OnSpeechSessionEnd += OnSpeechSessionEnd;
        JMRVoiceManager.OnSpeechCancelled += SpeechCancelled;
    }

    private void VoiceUnsubscribe()
    {
        JMRVoiceManager.OnSpeechEvent -= SpeechEvent;
        JMRVoiceManager.OnSpeechResults -= SpeachResult;
        JMRVoiceManager.OnSpeechPartialResults -= SpeechPartialResult;
        JMRVoiceManager.OnSpeechError -= SpeechError;
        JMRVoiceManager.OnSpeechSessionEnd -= OnSpeechSessionEnd;
        JMRVoiceManager.OnSpeechCancelled -= SpeechCancelled;
    }

    private void SpeechEvent(JMRVoiceManager.SpeechEvent obj, long ts)
    {
        var spEvents = obj.ToString();
        LogMessage(spEvents, voiceEventText);
    }

    private void SpeachResult(string obj, long ts)
    {
        var timeStamp = ts;
        var spResult = obj;
        LogMessage(timeStamp.ToString(), voiceResultTimeText);
        LogMessage(spResult, voiceResultSpeechText);
    }

    private void SpeechPartialResult(string obj, long ts)
    {
        var timeStamp = ts;
        var spResult = obj;
        LogMessage(timeStamp.ToString(), voiceResultTimeText);
        LogMessage(spResult, voiceResultSpeechText);
    }

    private void SpeechError(string err)
    {
        var spError = err;
        LogMessage(spError, voiceSpeechErrorText);
    }

    private void OnSpeechSessionEnd(long ts)
    {
        var spEndTime = ts.ToString();
        LogMessage(spEndTime, voiceSpeechSessionEndText);
    }

    private void SpeechCancelled(string reason, long ts)
    {
        var spCancelReason = reason;
        var timeStamp = ts;
        LogMessage(spCancelReason, voiceResultTimeText);
        LogMessage(timeStamp.ToString(), voiceSpeechCancledText);
    }

    #endregion

    #region Listening

    public void StartListening()
    {
        // added editor check as this can’t feature can’t tested in editor
        if (!Application.isEditor)
            JMRVoiceManager.Instance.StartListening();
    }

    public void CancelListening()
    {
        if (!Application.isEditor)
            JMRVoiceManager.Instance.CancelListening();
    }

    public void StopListening()
    {
        // added editor check as this can’t feature can’t be tested in	editor
        if (!Application.isEditor)
            JMRVoiceManager.Instance.StopListening();
    }

    #endregion

    #region TrackerMangerActions

    [Header("Tracker Manager Actions")] public TextMeshProUGUI trackerMangerActionspos;

    public TextMeshProUGUI trackerMangerActionsrot;

    //public TextMeshProUGUI trackerMangerActionstransform;
    private void TrackerManagerSubscribe()
    {
        JMRTrackerManager.OnHeadPosition += onHeadPositionLocal;
        JMRTrackerManager.OnHeadRotation += onHeadRotationLocal;
        JMRTrackerManager.OnHeadTransform += onHeadTranform;
    }

    private void TrackerManagerUnSubscribe()
    {
        JMRTrackerManager.OnHeadPosition -= onHeadPositionLocal;
        JMRTrackerManager.OnHeadRotation -= onHeadRotationLocal;
        JMRTrackerManager.OnHeadTransform -= onHeadTranform;
    }

    public void onHeadPositionLocal(Vector3 position)
    {
        var Pos = position;
        trackerMangerActionspos.text = Pos.ToString();
    }

    public void onHeadRotationLocal(Quaternion rotation)
    {
        var Rot = rotation;
        trackerMangerActionsrot.text = Rot.eulerAngles.ToString();
    }

    public void onHeadTranform(Transform t)
    {
        var _transform = t;
        //trackerMangerActionstransform.text=_transform.ToString();
    }

    #endregion

    #region Tracking Framework

    [Header("TrackerMangerMethods")] public TextMeshProUGUI trackerManagerMethodsposition;
    public TextMeshProUGUI trackerManagerMethodsrotation;

    private void TrackerManagerMethodsUpdateLoop()
    {
        var position = JMRTrackerManager.Instance.GetHeadPosition();
        var rotation = JMRTrackerManager.Instance.GetHeadRotation();
        var headTransform = JMRTrackerManager.Instance.GetHeadTransform();
        trackerManagerMethodsposition.text = position.ToString();
        trackerManagerMethodsrotation.text = rotation.eulerAngles.ToString();
    }

    #endregion

    #region Recenter Test

    [Header("Recenter")] public TextMeshProUGUI recenterText;

    private void RecenterTest()
    {
        JMRSystemActions.Instance.OnRecenterStart.AddListener(() => { recenterText.text = "On Recenter Start"; });
        JMRSystemActions.Instance.OnRecenterCancelled.AddListener(() => { recenterText.text = "On Recenter Start"; });
        JMRSystemActions.Instance.OnRecenterEnd.AddListener(() => { recenterText.text = "On Recenter Start"; });
    }

    public void RecenterButton()
    {
        print("Recenter");
        JMRTrackerManager.Instance.Recenter();
        recenterText.text = "Recenter done";
    }

    #endregion

    #region Ipd

    [Header("IPD")] public TextMeshProUGUI GetIPDText;

    public void GetIPD()
    {
        GetIPDText.text = JMRRigManager.Instance.GetIPD().ToString(CultureInfo.InvariantCulture);
    }

    #endregion
}