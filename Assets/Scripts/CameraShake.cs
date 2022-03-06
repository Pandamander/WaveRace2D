using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Events;

public class CameraShake : MonoBehaviour
{

    public float ShakeDuration;          // Time the Camera Shake effect will last
    public float ShakeAmplitude;         // Cinemachine Noise Profile Parameter
    public float ShakeFrequency;         // Cinemachine Noise Profile Parameter

    private float originalShakeDuration;
    private float originalShakeAmplitude;
    private float originalShakeFrequency;

    private float ShakeElapsedTime = 0f;

    // Cinemachine Shake
    public CinemachineVirtualCamera VirtualCamera;
    private CinemachineBasicMultiChannelPerlin virtualCameraNoise;

    // Use this for initialization
    void Start()
    {
        // set these values so we can reset the camera shake values when shaking is done
        originalShakeDuration = ShakeDuration;
        originalShakeAmplitude = ShakeAmplitude;
        originalShakeFrequency = ShakeFrequency;

        // Get Virtual Camera Noise Profile
        if (VirtualCamera != null)
            virtualCameraNoise = VirtualCamera.GetCinemachineComponent<Cinemachine.CinemachineBasicMultiChannelPerlin>();
    }

    public void ShakeCamera(float duration, float amplitude)
    {
        ShakeDuration = duration;
        ShakeAmplitude = amplitude;

        StopAllCoroutines();
        StartCoroutine(ShakeCameraCoroutine());
    }

    public IEnumerator ShakeCameraCoroutine()
    {
        // If the Cinemachine componet is not set, avoid update
        if (VirtualCamera != null && virtualCameraNoise != null)
        {
            ShakeElapsedTime = 0;
            
            while (ShakeElapsedTime < ShakeDuration)
            {
                // Update Shake Timer
                ShakeElapsedTime += Time.deltaTime;
                // Set Cinemachine Camera Noise parameters
                virtualCameraNoise.m_AmplitudeGain = ShakeAmplitude;
                virtualCameraNoise.m_FrequencyGain = ShakeFrequency;

                yield return null;
            }
           
            // If Camera Shake effect is over, reset variables
            virtualCameraNoise.m_AmplitudeGain = 0;
            virtualCameraNoise.m_FrequencyGain = 0;
            ShakeDuration = 0;

        }
        yield return 0;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
