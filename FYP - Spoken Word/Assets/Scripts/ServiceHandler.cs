using IBM.Cloud.SDK;
using IBM.Cloud.SDK.Authentication.Iam;
using IBM.Cloud.SDK.DataTypes;
using IBM.Cloud.SDK.Utilities;
using IBM.Watson.Assistant.V1;
using IBM.Watson.Assistant.V1.Model;
using IBM.Watson.SpeechToText.V1;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace SpokenWord.IBM
{
    public class ServiceHandler : MonoBehaviour
    {
        GameObject player;

        [Tooltip("Text field to display the results of streaming.")]
        public TextMeshProUGUI resultsField;

        private SpeechToTextService _speechToTextService;
        private AssistantService _assistantService;

        #region PLEASE SET THESE VARIABLES IN THE INSPECTOR
        [Header("Speech To Text")]
        [Tooltip("The service URL (optional). This defaults to \"https://stream.watsonplatform.net/speech-to-text/api\"")]
        [SerializeField]
        private string _speechToTextServiceUrl;
        [Tooltip("The IAM apikey.")]
        [SerializeField]
        private string _speechToTextIamApikey;
        [Header("Speech To Text Parameters")]
        // https://www.ibm.com/watson/developercloud/speech-to-text/api/v1/curl.html?curl#get-model
        [Tooltip("The Model to use. This defaults to en-US_BroadbandModel")]
        [SerializeField]
        private string _recognizeModel;
        [Tooltip("Speech to text confidence threshold, will only send a message to the assistant if above this value")]
        [Range(0f,0.9f)]
        [SerializeField]
        private float _sttConfidence;

        [Header("Watson Assistant")]
        [Tooltip("The service URL (optional). This defaults to \"https://gateway.watsonplatform.net/assistant/api\"")]
        [SerializeField]
        private string _assistantServiceUrl;
        [Tooltip("The Workspace ID to run the example.")]
        [SerializeField]
        private string _workspaceId;
        [Tooltip("The version date with which you would like to use the service in the form YYYY-MM-DD. Current is 2019-02-18")]
        [SerializeField]
        private string _assistantVersionDate;
        [Tooltip("The IAM apikey.")]
        [SerializeField]
        private string _assistantIamApikey;
        [Tooltip("The IAM url used to authenticate the apikey (optional). This defaults to \"https://iam.bluemix.net/identity/token\".")]
        [SerializeField]
        private string _assistantIamUrl;
        [Header("Speech To Text Parameters")]
        [Tooltip("Intent confidence threshold, used to execute actions that are above threshold and disambiguation between high confidence intents.")]
        [Range(0f, 0.9f)]
        [SerializeField]
        private float _intentConfidence;

        #endregion

        private int _recordingRoutine = 0;
        private string _microphoneID = null;
        private AudioClip _recording = null;
        private int _recordingBufferSize = 1;
        private int _recordingHZ = 22050;

        void Start()
        {
            player = GameObject.Find("Player w Pathfind");

            LogSystem.InstallDefaultReactors();
            Runnable.Run(CreateServices());
        }

        private IEnumerator CreateServices()
        {
            // Creating STT Service ---------------------------------------------------------------------------------------------------------------------------
            if (string.IsNullOrEmpty(_speechToTextIamApikey))
            {
                throw new IBMException("Please provide IAM ApiKey for the STT service.");
            }

            IamAuthenticator sttAuthenticator = new IamAuthenticator(apikey: _speechToTextIamApikey);

            //  Wait for token data
            while (!sttAuthenticator.CanAuthenticate())
                yield return null;

            _speechToTextService = new SpeechToTextService(sttAuthenticator);
            if (!string.IsNullOrEmpty(_speechToTextServiceUrl))
            {
                _speechToTextService.SetServiceUrl(_speechToTextServiceUrl);
            }
            _speechToTextService.StreamMultipart = true;

            Active = true;

            // Creating Assistant Service ---------------------------------------------------------------------------------------------------------------------
            IamAuthenticator assistantAuthenticator = new IamAuthenticator(apikey: "9Az7c6aj2kKhH31OROZ_cIlaYXo8HT8ut248Q8CXx_qq");

            //  Wait for tokendata
            while (!assistantAuthenticator.CanAuthenticate())
                yield return null;

            _assistantService = new AssistantService("2019-02-18", assistantAuthenticator);
            _assistantService.SetServiceUrl("https://api.eu-gb.assistant.watson.cloud.ibm.com/instances/f53fde36-02ed-4410-a49b-d18c6566f0bc");

            // ------------------------------------------------------------------------------------------------------------------------------------------------

            StartRecording();
        }

        private void StartRecording()
        {
            if (_recordingRoutine == 0)
            {
                UnityObjectUtil.StartDestroyQueue();
                _recordingRoutine = Runnable.Run(RecordingHandler());
            }
        }

        private void StopRecording()
        {
            if (_recordingRoutine != 0)
            {
                Microphone.End(_microphoneID);
                Runnable.Stop(_recordingRoutine);
                _recordingRoutine = 0;
            }
        }

        private void OnError(string error)
        {
            Active = false;

            Log.Debug("ExampleStreaming.OnError()", "Error! {0}", error);
        }

        private IEnumerator RecordingHandler()
        {
            Log.Debug("ExampleStreaming.RecordingHandler()", "devices: {0}", Microphone.devices);
            _recording = Microphone.Start(_microphoneID, true, _recordingBufferSize, _recordingHZ);
            yield return null;      // let _recordingRoutine get set..

            if (_recording == null)
            {
                StopRecording();
                yield break;
            }

            bool bFirstBlock = true;
            int midPoint = _recording.samples / 2;
            float[] samples = null;

            while (_recordingRoutine != 0 && _recording != null)
            {
                int writePos = Microphone.GetPosition(_microphoneID);
                if (writePos > _recording.samples || !Microphone.IsRecording(_microphoneID))
                {
                    Log.Error("ExampleStreaming.RecordingHandler()", "Microphone disconnected.");

                    StopRecording();
                    yield break;
                }

                if ((bFirstBlock && writePos >= midPoint)
                  || (!bFirstBlock && writePos < midPoint))
                {
                    // front block is recorded, make a RecordClip and pass it onto our callback.
                    samples = new float[midPoint];
                    _recording.GetData(samples, bFirstBlock ? 0 : midPoint);

                    AudioData record = new AudioData();
                    record.MaxLevel = Mathf.Max(Mathf.Abs(Mathf.Min(samples)), Mathf.Max(samples));
                    record.Clip = AudioClip.Create("Recording", midPoint, _recording.channels, _recordingHZ, false);
                    record.Clip.SetData(samples, 0);

                    _speechToTextService.OnListen(record);

                    bFirstBlock = !bFirstBlock;
                }
                else
                {
                    // calculate the number of samples remaining until we ready for a block of audio, 
                    // and wait that amount of time it will take to record.
                    int remaining = bFirstBlock ? (midPoint - writePos) : (_recording.samples - writePos);
                    float timeRemaining = (float)remaining / (float)_recordingHZ;

                    yield return new WaitForSeconds(timeRemaining);
                }
            }
            yield break;
        }

        private void OnRecognize(SpeechRecognitionEvent result)
        {
            if (result != null && result.results.Length > 0)
            {
                foreach (var res in result.results)
                {
                    foreach (var alt in res.alternatives)
                    {
                        string text = string.Format("{0} ({1}, {2:0.00})\n", alt.transcript, res.final ? "Final" : "Interim", alt.confidence);
                        Log.Debug("ExampleStreaming.OnRecognize()", text);
                        resultsField.GetComponent<AutoScroll>().ChangeScrollState();
                        resultsField.text = text;

                        // Send message if stt confidence is above a certain threshold
                        if (res.final && alt.confidence >= _sttConfidence)
                        {
                            string utterance = alt.transcript;
                            Debug.Log("Sending message: " + utterance + " with confidence: " + alt.confidence);

                            MessageInput input = new MessageInput()
                            {
                                Text = utterance
                            };

                            _assistantService.Message(OnMessage, _workspaceId, input);
                        }
                    }

                    if (res.keywords_result != null && res.keywords_result.keyword != null)
                    {
                        foreach (var keyword in res.keywords_result.keyword)
                        {
                            Log.Debug("ExampleStreaming.OnRecognize()", "keyword: {0}, confidence: {1}, start time: {2}, end time: {3}", keyword.normalized_text, keyword.confidence, keyword.start_time, keyword.end_time);
                        }
                    }

                    if (res.word_alternatives != null)
                    {
                        foreach (var wordAlternative in res.word_alternatives)
                        {
                            Log.Debug("ExampleStreaming.OnRecognize()", "Word alternatives found. Start time: {0} | EndTime: {1}", wordAlternative.start_time, wordAlternative.end_time);
                            foreach (var alternative in wordAlternative.alternatives)
                                Log.Debug("ExampleStreaming.OnRecognize()", "\t word: {0} | confidence: {1}", alternative.word, alternative.confidence);
                        }
                    }
                }
            }
        }

        private void OnRecognizeSpeaker(SpeakerRecognitionEvent result)
        {
            if (result != null)
            {
                foreach (SpeakerLabelsResult labelResult in result.speaker_labels)
                {
                    Log.Debug("ExampleStreaming.OnRecognizeSpeaker()", string.Format("speaker result: {0} | confidence: {3} | from: {1} | to: {2}", labelResult.speaker, labelResult.from, labelResult.to, labelResult.confidence));
                }
            }
        }

        void OnMessage(DetailedResponse<MessageResponse> resp, IBMError error)
        {
            // Going to have to rework this completely if I want to handle multiple intents and entities
            // think about intents that may have multiple entities attached:
            //  - how will I know that the first 2 entities correspond to the first intent in a case where i receive
            //    two intents and two entities for example
            // at the moment all i'm doing is iterating through the intents and printing out the intent and entity that
            // is at the same index as that intent if there is one.
            if (resp != null && resp.Result.Intents.Count != 0)
            {
                for (int i = 0; i < resp.Result.Intents.Count; i++)
				{
                    Debug.Log("Received Intent: " + resp.Result.Intents[i].Intent);
                    if (resp.Result.Entities.Count > 0)
					{
                        Debug.Log("Received Entities: " + resp.Result.Entities[i].Entity);
                        Debug.Log("Received Entiites Value: " + resp.Result.Entities[i].Value);
                    } else
					{
                        Debug.Log("No entities received");
					}
                }

                player.GetComponent<Control.ControlHandler>().HandleIntent
                    (
                        resp.Result.Intents,
                        resp.Result.Entities,
                        resp.Result.Input.Text,
                        _intentConfidence
                    );
                
            }
            else
            {
                Debug.Log("Failed to invoke OnMessage();");
            }
        }

        public bool Active
        {
            get { return _speechToTextService.IsListening; }
            set
            {
                if (value && !_speechToTextService.IsListening)
                {
                    _speechToTextService.RecognizeModel = (string.IsNullOrEmpty(_recognizeModel) ? "en-US_BroadbandModel" : _recognizeModel);
                    _speechToTextService.DetectSilence = true;
                    _speechToTextService.EnableWordConfidence = true;
                    _speechToTextService.EnableTimestamps = true;
                    _speechToTextService.SilenceThreshold = 0.01f;
                    _speechToTextService.MaxAlternatives = 1;
                    _speechToTextService.EnableInterimResults = true;
                    _speechToTextService.OnError = OnError;
                    _speechToTextService.InactivityTimeout = -1;
                    _speechToTextService.ProfanityFilter = false;
                    _speechToTextService.SmartFormatting = true;
                    _speechToTextService.SpeakerLabels = false;
                    _speechToTextService.WordAlternativesThreshold = null;
                    _speechToTextService.EndOfPhraseSilenceTime = null;
                    _speechToTextService.StartListening(OnRecognize, OnRecognizeSpeaker);
                }
                else if (!value && _speechToTextService.IsListening)
                {
                    _speechToTextService.StopListening();
                }
            }
        }

        [ContextMenu("Autofill Fields")]
        void AutofillFields()
        {
            resultsField = GameObject.Find("Incoming Speech").GetComponent<TextMeshProUGUI>();

            // Speech to Text Service Credentials
            _speechToTextServiceUrl = "https://api.eu-gb.speech-to-text.watson.cloud.ibm.com/instances/6ea3ab50-9420-476c-a7bd-d7fefa31f4b3";
            _speechToTextIamApikey = "pABoHA5QFyGO6ZCZpB9p96eEEQf5xMv3bkH5HvPfqODT";

            // https://cloud.ibm.com/docs/speech-to-text?topic=speech-to-text-models#models
            // Smart formatting only works with the en-US model, not en-GB
            _recognizeModel = "en-US_BroadbandModel";

            // Assistant Credentials
            _workspaceId = "00235722-3eeb-4034-bca8-ba3b2d78045e";
            _assistantVersionDate = "2019-02-18";
            _assistantIamApikey = "9Az7c6aj2kKhH31OROZ_cIlaYXo8HT8ut248Q8CXx_qq";
        }
    }
}
