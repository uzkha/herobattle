using UnityEngine;
using System.Collections;

public class Example : MonoBehaviour
{
    void OnGUI()
    {
        if (GUILayout.Button("Disconnect first player"))
            if (Network.connections.Length > 0)
            {
                Debug.Log("Disconnecting: " + Network.connections[0].ipAddress + ":" + Network.connections[0].port);
                Network.CloseConnection(Network.connections[0], true);
            }

    }
}