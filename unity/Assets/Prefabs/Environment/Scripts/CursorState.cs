using UnityEngine;

public class CursorState : MonoBehaviour
{
    new public bool enabled;
   void Update()
    {
        Cursor.visible = enabled;
        Cursor.lockState = enabled? CursorLockMode.None : CursorLockMode.Locked;
    }
}
