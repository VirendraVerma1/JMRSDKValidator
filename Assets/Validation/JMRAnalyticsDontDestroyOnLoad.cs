using UnityEngine;
using JMRSDK;
[DefaultExecutionOrder(-50)]
public class JMRAnalyticsDontDestroyOnLoad : JMRAnalyticsManager
{
    void Start()
    {
        transform.parent = null;
        DontDestroyOnLoad(gameObject);
    }
}