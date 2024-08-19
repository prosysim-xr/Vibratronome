using System;
using UnityEngine;
using UnityEngine.InputSystem;
/// <summary>
/// This script create a metronome but this uses haptics and vibration of the device.
/// </summary>
public class Vibratronome : MonoBehaviour {
    public float bpm = 60.0f;
    public float measure = 4.0f;
    public TimeSignature timeSignature = TimeSignature.FourByFour;

    #region Unity callbacks
    void OnEnable() {
        InputManager.i.onOneShotVibration.performed += Vibrate;
        InputManager.i.onOneShotVibration.performed += Vibrate2;

    }

    void Start() {
    }

    void Update() {

    }
    void OnDisable() {
        InputManager.i.onOneShotVibration.performed -= Vibrate;
        InputManager.i.onOneShotVibration.performed -= Vibrate2;

    }
    #endregion

    #region Public methods
    public void Vibrate(InputAction.CallbackContext context) {
        Debug.Log("Vibrate called");
        // Vibrate the device
        if (Application.platform == RuntimePlatform.Android) {
            AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
            AndroidJavaObject vibrator = currentActivity.Call<AndroidJavaObject>("getSystemService", "vibrator");
            vibrator.Call("vibrate", 1000);// vibrate for miliseconds
        } else {
            Handheld.Vibrate(); // Default vibration for other platforms
        }
    }
    public void Vibrate2(InputAction.CallbackContext context) {
        AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        AndroidJavaObject vibrator = currentActivity.Call<AndroidJavaObject>("getSystemService", "vibrator");
        vibrator.Call("vibrate", 1000);// vibrate for miliseconds
    }
    #endregion
}

public enum TimeSignature {
    FourByFour,
    ThreeByFour,
    SixByEight
}