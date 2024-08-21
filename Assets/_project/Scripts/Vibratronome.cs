using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
/// <summary>
/// This script create a metronome but this uses haptics and vibration of the device.
/// </summary>
public class Vibratronome : MonoBehaviour {
    public float bpm = 60.0f;
    public float measure = 4.0f;
    public TimeSignature timeSignature = TimeSignature.FourByFour;

    //Debug
    public TMP_InputField debugTextIF;
    public TextMeshProUGUI debugText;


    #region Unity callbacks
    void OnEnable() {
        //InputManager.i.onOneShotVibration.performed += Vibrate;
        InputManager.i.onOneShotVibration.performed += Vibrate2;
        debugTextIF.onValueChanged.AddListener(HandleDebugIF);
    }

    void Start() {
        debugText.text = "";
    }

    void Update() {

    }
    void OnDisable() {
        //InputManager.i.onOneShotVibration.performed -= Vibrate;
        InputManager.i.onOneShotVibration.performed -= Vibrate2;
        

    }
    #endregion

    #region Public methods
    public void Vibrate(InputAction.CallbackContext context) {
        Debug("Vibrate called");
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
        Vibrate2();
    }
    void Vibrate2() {
        Debug("Vibrate2 called start");
        AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        AndroidJavaObject vibrator = currentActivity.Call<AndroidJavaObject>("getSystemService", "vibrator");
        vibrator.Call("vibrate", 1000);// vibrate for miliseconds
        Debug("Vibrate2 called end");
    }

    void Debug(string message) {
        debugText.text += message + "\n";
    }

    void HandleDebugIF(string str) {
        if(str == "h" || str =="H") {
            Vibrate2();
        }
    }
    #endregion
}

public enum TimeSignature {
    FourByFour,
    ThreeByFour,
    SixByEight
}