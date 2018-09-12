using UnityEngine;
using UnityEngine.Events;

public class InputWithAction : MonoBehaviour
{
    public KeyCode keyCode = KeyCode.Space;
    public UnityEvent action;

    public void Update()
    {
        if( Input.GetKeyUp( keyCode ) )
        {
            action.Invoke();
        }
    }
}
