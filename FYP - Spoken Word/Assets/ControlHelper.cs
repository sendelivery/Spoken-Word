using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Control;

public class ControlHelper : MonoBehaviour
{
    private State _state;
    private Settings _settings;
    private static VoiceCommands voiceCommands;

    // Start is called before the first frame update
    void Awake()
    {
        PlayerControls controls = new PlayerControls();

        SetUpVoiceCommands();

        _settings = new Settings(Camera.main, controls, ref voiceCommands);
        _state = new TiltShrine(ref _settings);
        _state.Initialise();
        //_state.Enable();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _state.HandleInput();
    }

    // Need to attach voice commands to an object because
    // coroutines can only be called if attached to an object, 
    private void SetUpVoiceCommands()
    {
        GameObject obj = new GameObject("Voice Commands");
        obj.AddComponent<VoiceCommands>();
        voiceCommands = obj.GetComponent<VoiceCommands>();
    }
}
