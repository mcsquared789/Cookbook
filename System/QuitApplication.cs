using UnityEngine;
using UnityEngine.InputSystem; // INPUT

public class QuitApplication : MonoBehaviour
{
    void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            Debug.Log("Quitting Game");
            Application.Quit();
        }
    }
}
