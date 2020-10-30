using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContinueButton : MonoBehaviour
{
    Controls Controls

    {
        get { return ControlsManager.instance; }
    }

    private Button continueButton;
    // Start is called before the first frame update
    void Start()
    {
        continueButton = GetComponent<Button>();
        Controls.Dialogue.Continue.performed += Continue_performed;
    }

    private void Continue_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        continueButton.onClick.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        Controls.Dialogue.Continue.performed -= Continue_performed;

    }
}
