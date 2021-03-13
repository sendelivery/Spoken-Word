using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Control;

public class ControlHelper : MonoBehaviour
{
    private State _state;
    private Settings _settings;

    // Start is called before the first frame update
    void Start()
    {
        PlayerControls controls = new PlayerControls();

        _settings = new Settings(Camera.main, controls);
        _state = new TiltShrine(ref _settings);
        _state.Initialise();
        //_state.Enable();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        _state.HandleInput();
    }
}
