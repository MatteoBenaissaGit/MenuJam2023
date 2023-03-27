using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using MatteoBenaissaLibrary.SingletonClassBase;
using UnityEngine;

public class CamerasManager : Singleton<CamerasManager>
{
    [SerializeField] private List<CinemachineVirtualCamera> _camerasList = new List<CinemachineVirtualCamera>();

    public void SetCamera(CinemachineVirtualCamera virtualCamera)
    {
        foreach (CinemachineVirtualCamera cam in _camerasList)
        {
            cam.gameObject.SetActive(cam == virtualCamera);
        }
    } 
}
