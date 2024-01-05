using JMRSDK.InputModule;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JMRBackAction : MonoBehaviour,IBackHandler
{
    void Start()
    {
        JMRInputManager.Instance.AddGlobalListener(gameObject);
    }

    public void OnBackAction()
    {
        SceneManager.LoadScene(1);//master scene
    }

    
}
