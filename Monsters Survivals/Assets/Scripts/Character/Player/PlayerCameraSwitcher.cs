using UnityEngine;
using System.Collections;

[RequireComponent (typeof(PlayerCamera))]

//Fix bug camera I'dont know how but it works
// Without this skript Player Camera push away when player run about level collider

public class PlayerCameraSwitcher : MonoBehaviour
{
    private PlayerCamera _playerCamera;
    
    void Start()
    {
        _playerCamera = GetComponent<PlayerCamera>();
        _playerCamera.enabled = false;            
        StartCoroutine(SwitchPlayerCamera());
    }

    private IEnumerator SwitchPlayerCamera() 
    {
        yield return new WaitForSeconds(0.15f);
        _playerCamera.enabled = true;    
    }
}
