using UnityEngine;
using UnityEngine.InputSystem;
/// <summary>
/// Use this script to test the haptics and vibration of the device.
/// </summary>
public class HapticsTest : MonoBehaviour
{
    //References
    public float duration = 1.0f;

    void Start()
    {
        
    }

    void Update()
    {
    }
}
public enum VibrationType {
    OneShot,
    Continuous,
}