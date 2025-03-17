using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
namespace UnityTransport_Issue_Server_Crash_On_Client_Disconnection
{
    public class ConnectionManager : MonoBehaviour
    {
        [SerializeField] private bool _editorAsHost;
        private void Start()
        {
            NetworkManager.Singleton.OnServerStarted += OnServerStarted;
            NetworkManager.Singleton.OnClientConnectedCallback += OnClientConnectedCallback;
            NetworkManager.Singleton.OnClientDisconnectCallback += OnClientDisconnectCallback;
#if UNITY_EDITOR
            if (_editorAsHost)
            {
                NetworkManager.Singleton.StartHost();
            }
            else
            {
                NetworkManager.Singleton.StartServer();
            }
#else
        NetworkManager.Singleton.StartClient();
#endif
        }

        private void OnServerStarted()
        {
            Debug.Log("OnServerStarted");
        }

        private void OnClientConnectedCallback(ulong obj)
        {
            Debug.Log("OnClientConnectedCallback");
        }

        private void OnClientDisconnectCallback(ulong obj)
        {
            Debug.Log("OnClientDisconnectCallback");
        }
    }
}