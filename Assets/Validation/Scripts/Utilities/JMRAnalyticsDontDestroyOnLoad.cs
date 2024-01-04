using JMRSDK;

public class JMRAnalyticsDontDestroyOnLoad : JMRAnalyticsManager
{
    void Start()
    {
        transform.parent = null;
        DontDestroyOnLoad(gameObject);
    }
}