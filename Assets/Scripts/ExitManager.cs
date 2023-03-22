using UnityEngine;
using Application = UnityEngine.Device.Application;

public class ExitManager : MonoBehaviour
{
        public void ExitGame()
        {
                Debug.Log("Exit");
                UnityEditor.EditorApplication.isPlaying = false;
                Application.Quit();
        }
}