using System.Collections;
using Cinemachine;
using UnityEngine;
using System;

public class CameraChanger : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private float _waitBeforeLaunchCameraDisable = 0.5f;
    [SerializeField] private CinemachineVirtualCamera _launchCamera;
    [SerializeField] private CinemachineVirtualCamera _mainCamera;

    public event Action Showed;

    private void OnEnable()
    {
        _player.Landed += PlayerOnLanded;
        _playerMovement.LastHitInitiated += PlayerMovementOnLastHitInitiated;
        //_playerMovement.FinishReached += PlayerMovementOnFinishReached;
        _player.Died += PlayerOnDied;
    }

    private void OnDisable()
    {
        _player.Landed -= PlayerOnLanded;
        _playerMovement.LastHitInitiated -= PlayerMovementOnLastHitInitiated;
        //_playerMovement.FinishReached -= PlayerMovementOnFinishReached;
        _player.Died -= PlayerOnDied;
    }

    private IEnumerator DisableLaunchCamera()
    {
        yield return new WaitForSeconds(_waitBeforeLaunchCameraDisable);
        _launchCamera.enabled = false;
    }

    private void PlayerMovementOnFinishReached()
    {
        _mainCamera.enabled = true;
        Showed?.Invoke();
    }

    private IEnumerator Waiting()
    {
        yield return new WaitForSecondsRealtime(1f);
        PlayerMovementOnFinishReached();
    }

    private void PlayerMovementOnLastHitInitiated()
    {
        _mainCamera.enabled = false;
        StartCoroutine(Waiting());
    }

    private void PlayerOnDied()
    {
        _mainCamera.enabled = true;
    }

    private void PlayerOnLanded()
    {
        StartCoroutine(DisableLaunchCamera());
    }
}