using UnityEngine;
using Application = UnityEngine.Device.Application;

public class ExitManager : MonoBehaviour
{
        public void ExitGame()
        {
                Debug.Log("Exit");
                #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
                #endif
                Application.Quit();
        }
}