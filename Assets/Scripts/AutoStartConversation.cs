using UnityEngine;
using DialogueEditor;
using System.Collections;

public class AutoStartConversation : MonoBehaviour
{
    public NPCConversation startConvo;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartConvo());
    }

    private IEnumerator StartConvo()
    {
        yield return new WaitForSeconds(2);
        ConversationManager.Instance.StartConversation(startConvo);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
