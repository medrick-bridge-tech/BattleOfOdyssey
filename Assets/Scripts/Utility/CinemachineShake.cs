using System;
using Cinemachine;
using UnityEngine;

public class CinemachineShake : MonoBehaviour
{
        private CinemachineVirtualCamera _virtualCamera;
        private float _shakeTimer;
        private void Awake()
        {
                _virtualCamera = GetComponent<CinemachineVirtualCamera>();
        }

        // ReSharper disable Unity.PerformanceAnalysis
        public void ShakeCamera(float intensity,float timer)
        {
                CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin = SetCinemachineBasicMultiChannelPerlin();
                cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = intensity;
                _shakeTimer = timer;
        }

        private void Update()
        {
                if (_shakeTimer > 0f)
                {
                        _shakeTimer -= Time.deltaTime;
                        if (_shakeTimer <= 0f)
                        {
                                CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin =
                                        SetCinemachineBasicMultiChannelPerlin();
                                cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = 0f;
                        }
                }
        }

        private CinemachineBasicMultiChannelPerlin SetCinemachineBasicMultiChannelPerlin()
        {
                return  _virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        }
}

