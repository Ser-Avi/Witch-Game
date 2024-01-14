using System.Collections;
using System.Collections.Generic;
using DialogueEditor;
using UnityEngine;

public class ToggleSpeechScrolling : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ConversationManager.Instance.ScrollText = !ConversationManager.Instance.ScrollText;
        }
    }
}
