/**
* Copyright 2019 IBM Corp. All Rights Reserved.
*
* Licensed under the Apache License, Version 2.0 (the "License");
* you may not use this file except in compliance with the License.
* You may obtain a copy of the License at
*
*      http://www.apache.org/licenses/LICENSE-2.0
*
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an "AS IS" BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
*
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IBM.Watson.Assistant.V1;
using IBM.Cloud.SDK;
using IBM.Cloud.SDK.Authentication;
using IBM.Cloud.SDK.Authentication.Iam;
using IBM.Cloud.SDK.Utilities;
using IBM.Watson.Assistant.V1.Model;
using System;

namespace SpokenWord.IBM
{
    public class Assistant : MonoBehaviour
    {
        private AssistantService service;
        private string workspaceId;
        private string createdWorkspaceId;
        private string inputString = "Hello";
        private string conversationString0 = "unlock the door";
        private string conversationString1 = "turn on the ac";
        private string conversationString2 = "turn down the radio";

        private static string createdWorkspaceName = "unity-sdk-example-workspace-delete";
        private static string createdWorkspaceDescription = "A Workspace created by the Unity SDK Assistant example script. Please delete this.";
        private static string createdWorkspaceLanguage = "en";
        private static string createdEntity = "unityEntity";
        private static string createdEntityDescription = "Entity created by the Unity SDK Assistant example script.";
        private static string createdValue = "unityunityalue";
        private static string createdIntent = "unityIntent";
        private static string createdIntentDescription = "Intent created by the Unity SDK Assistant example script.";
        private static string createdCounterExampleText = "unityExample text";
        private static string createdSynonym = "unitySynonym";
        private static string createdExample = "unityExample";
        private static string dialogNodeName = "unityDialognode";
        private static string dialogNodeDesc = "Unity SDK Integration test dialog node";
        private Dictionary<string, object> context = null;

        private bool listWorkspacesTested = false;
        private bool createWorkspaceTested = false;
        private bool getWorkspaceTested = false;
        private bool updateWorkspaceTested = false;
        private bool messageTested = false;
        private bool listIntentsTested = false;
        private bool createIntentTested = false;
        private bool getIntentTested = false;
        private bool updateIntentTested = false;
        private bool listExamplesTested = false;
        private bool createExampleTested = false;
        private bool getExampleTested = false;
        private bool updateExampleTested = false;
        private bool listEntitiesTested = false;
        private bool createEntityTested = false;
        private bool getEntityTested = false;
        private bool deleteWorkspaceTested = false;

        private void Start()
        {
            LogSystem.InstallDefaultReactors();
            Runnable.Run(CreateService());
        }

        private IEnumerator CreateService()
        {

            IamAuthenticator authenticator = new IamAuthenticator(apikey: "9Az7c6aj2kKhH31OROZ_cIlaYXo8HT8ut248Q8CXx_qq");

            //  Wait for tokendata
            while (!authenticator.CanAuthenticate())
                yield return null;

            service = new AssistantService("2019-02-18", authenticator);
            service.SetServiceUrl("https://api.eu-gb.assistant.watson.cloud.ibm.com/instances/f53fde36-02ed-4410-a49b-d18c6566f0bc");

            workspaceId = "00235722-3eeb-4034-bca8-ba3b2d78045e"; // Environment.GetEnvironmentVariable("CONVERSATION_WORKSPACE_ID");
            Runnable.Run(Examples());
        }

        private IEnumerator Examples()
        {
            //  List Workspaces
            Log.Debug("ExampleAssistantV1", "Attempting to ListWorkspaces...");
            service.ListWorkspaces(callback: OnListWorkspaces, pageLimit: 1, sort: "-name", includeAudit: true);
            while (!listWorkspacesTested)
                yield return null;

            //  Get Workspace
            Log.Debug("ExampleAssistantV1", "Attempting to GetWorkspace...");
            service.GetWorkspace(callback: OnGetWorkspace, workspaceId: "00235722-3eeb-4034-bca8-ba3b2d78045e");
            while (!getWorkspaceTested)
                yield return null;

            //  Message
            Dictionary<string, object> input = new Dictionary<string, object>();
            input.Add("text", inputString);
            //InputData input = new InputData()
            //{
            //    Text = inputString
            //};
            //Log.Debug("ExampleAssistantV1", "Attempting to Message...");
            //service.Message(callback: OnMessage, workspaceId: workspaceId, input: input);
            //while (!messageTested)
            //    yield return null;
            //messageTested = false;

            //input = new InputData()
            //{
            //    Text = conversationString0
            //};
            //Log.Debug("ExampleAssistantV1", "Attempting to Message...");
            //service.Message(callback: OnMessage, workspaceId: workspaceId, input: input, context: context);
            //while (!messageTested)
            //    yield return null;
            //messageTested = false;

            //input = new InputData()
            //{
            //    Text = conversationString1
            //};
            //Log.Debug("ExampleAssistantV1", "Attempting to Message...");
            //service.Message(callback: OnMessage, workspaceId: workspaceId, input: input, context: context);
            //while (!messageTested)
            //    yield return null;
            //messageTested = false;

            //input = new InputData()
            //{
            //    Text = conversationString2
            //};
            //Log.Debug("ExampleAssistantV1", "Attempting to Message...");
            //service.Message(callback: OnMessage, workspaceId: workspaceId, input: input, context: context);
            //while (!messageTested)
            //    yield return null;

            //  List Intents
            Log.Debug("ExampleAssistantV1", "Attempting to ListIntents...");
            service.ListIntents(callback: OnListIntents, workspaceId: "00235722-3eeb-4034-bca8-ba3b2d78045e");
            while (!listIntentsTested)
                yield return null;

            //  List Examples
            service.ListExamples(callback: OnListExamples, workspaceId: createdWorkspaceId, intent: "move");
            while (!listExamplesTested)
                yield return null;

            //  List Entities
            service.ListEntities(callback: OnListEntities, workspaceId: createdWorkspaceId);
            while (!listEntitiesTested)
                yield return null;

            //  Get Entity
            service.GetEntity(callback: OnGetEntity, workspaceId: createdWorkspaceId, entity: createdEntity);
            while (!getEntityTested)
                yield return null;

            //  List Synonyms
            //service.ListSynonyms(callback: OnListSynonyms, workspaceId: createdWorkspaceId, entity: updatedEntity, value: updatedValue);
            //while (!listSynonymsTested)
            //    yield return null;

            //  Get Synonym
            //service.GetSynonym(callback: OnGetSynonym, workspaceId: createdWorkspaceId, entity: updatedEntity, value: updatedValue, synonym: createdSynonym);
            //while (!getSynonymTested)
            //    yield return null;

            /* Logging
            //  List Logs In Workspace
            service.ListLogs(callback: OnListLogs, workspaceId: createdWorkspaceId);
            while (!listLogsInWorkspaceTested)
                yield return null;
            //  List All Logs
            var filter = "(language::en,request.context.metadata.deployment::deployment_1)";
            service.ListAllLogs(callback: OnListAllLogs, filter: filter);
            while (!listAllLogsTested)
                yield return null;
            */

            Log.Debug("ExampleAssistantV1.RunTest()", "Assistant examples complete.");

            yield break;
        }

        private void OnGetEntity(DetailedResponse<Entity> response, IBMError error)
        {
            Log.Debug("ExampleAssistantV1.OnGetEntity()", "Response: {0}", response.Response);
            getEntityTested = true;
        }

        private void OnListEntities(DetailedResponse<EntityCollection> response, IBMError error)
        {
            Log.Debug("ExampleAssistantV1.OnListEntities()", "Response: {0}", response.Response);
            listEntitiesTested = true;
        }

        private void OnListExamples(DetailedResponse<ExampleCollection> response, IBMError error)
        {
            Log.Debug("ExampleAssistantV1.OnListExamples()", "Response: {0}", response.Response);
            listExamplesTested = true;
        }

        private void OnListIntents(DetailedResponse<IntentCollection> response, IBMError error)
        {
            Log.Debug("ExampleAssistantV1.OnListIntents()", "Response: {0}", response.Response);
            listIntentsTested = true;
        }

        private void OnMessage(DetailedResponse<Dictionary<string, object>> response, IBMError error)
        {
            Log.Debug("ExampleAssistantV1.OnMessage()", "Response: {0}", response.Response);

            context = response.Result["context"] as Dictionary<string, object>;
            ////  Convert resp to fsdata
            //fsData fsdata = null;
            //fsResult r = _serializer.TrySerialize(response.GetType(), response, out fsdata);
            //if (!r.Succeeded)
            //    throw new WatsonException(r.FormattedMessages);

            ////  Convert fsdata to MessageResponse
            //MessageResponse messageResponse = new MessageResponse();
            //object obj = messageResponse;
            //r = _serializer.TryDeserialize(fsdata, obj.GetType(), ref obj);
            //if (!r.Succeeded)
            //    throw new WatsonException(r.FormattedMessages);

            ////  Set context for next round of messaging
            //object _tempContext = null;
            //(response as Dictionary<string, object>).TryGetValue("context", out _tempContext);

            //if (_tempContext != null)
            //    context = _tempContext as Dictionary<string, object>;
            //else
            //    Log.Debug("ExampleAssistantV1.OnMessage()", "Failed to get context");

            ////  Get intent
            //object tempIntentsObj = null;
            //(response as Dictionary<string, object>).TryGetValue("intents", out tempIntentsObj);
            //object tempIntentObj = (tempIntentsObj as List<object>)[0];
            //object tempIntent = null;
            //(tempIntentObj as Dictionary<string, object>).TryGetValue("intent", out tempIntent);
            //string intent = tempIntent.ToString();

            //Log.Debug("ExampleAssistantV1.OnMessage()", "intent: {0}", intent);

            messageTested = true;
        }

        private void OnGetWorkspace(DetailedResponse<Workspace> response, IBMError error)
        {
            Log.Debug("ExampleAssistantV1.OnGetWorkspace()", "Response: {0}", response.Response);
            getWorkspaceTested = true;
        }

        private void OnListWorkspaces(DetailedResponse<WorkspaceCollection> response, IBMError error)
        {
            Log.Debug("ExampleAssistantV1.OnListWorkspaces()", "Response: {0}", response.Response);

            /*foreach (Workspace workspace in response.Result.Workspaces)
            {
                if (workspace.Name.Contains("unity"))
                    service.DeleteWorkspace(callback: OnDeleteWorkspace, workspaceId: workspace.WorkspaceId);
            }*/

            listWorkspacesTested = true;
        }
    }
}