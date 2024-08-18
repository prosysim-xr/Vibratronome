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

    }

    void Start() {
    }

    void Update() {

    }
    void OnDisable() {
        InputManager.i.onOneShotVibration.performed -= Vibrate;

    }
    #endregion

    #region Public methods
    public void Vibrate(InputAction.CallbackContext context) {
        Debug.Log("Vibrate called");
    }
    #endregion
}

public enum TimeSignature {
    FourByFour,
    ThreeByFour,
    SixByEight
}