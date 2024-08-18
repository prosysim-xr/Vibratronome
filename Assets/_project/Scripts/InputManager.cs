using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager i;
    //References
    public InputActionAsset inputActionAsset;
    public InputActionMap inputActionMap;

    public InputAction onOneShotVibration;

    private void Awake() {
        if (i == null) {
            i = this; 
        } 
        else {
            Destroy(this);
        }
        inputActionMap = inputActionAsset.FindActionMap("Haptics");
        onOneShotVibration = inputActionMap.FindAction("onOneShotVibration");
    }
    private void Start() {
        
    }
}
