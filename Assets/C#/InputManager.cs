using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static Vector3 Direction()
    {
        return new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
    }

    public static bool TakeInput()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
