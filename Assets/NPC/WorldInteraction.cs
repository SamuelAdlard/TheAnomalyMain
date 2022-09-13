using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;

public class WorldInteraction : MonoBehaviour
{
    public TextMeshProUGUI NPCText;
    public TextMeshProUGUI PlayerResponse;
    public TextMeshProUGUI name;
    public int corruptionLevel = 1;
    bool startedConversation = false;
    int index = 0;
    void Update()
    {
        RaycastHit interactionInfo;        

        
        if (Physics.Raycast(transform.position, transform.forward, out interactionInfo, 2f))
        {
            GameObject interactedObject = interactionInfo.collider.gameObject;
            if (!startedConversation)
            {
                corruptionLevel = 
                if (interactedObject.tag == "InteractableObject")
                {
                    name.text = interactedObject.GetComponent<NPC>().name;

                    NPCText.text = "Press F";
                    PlayerResponse.text = "";
                    if (Input.GetKey(KeyCode.F))
                    {

                        startedConversation = true;
                        
                    }
                }
                else
                {
                    NPCText.text = "";
                    PlayerResponse.text = "";
                }

            }

        }
        else if(!startedConversation)
        {
            NPCText.text = "";
            PlayerResponse.text = "";
            name.text = "";
        }
        else
        {
            startedConversation = false;
            index = 0;
        }


        if (Input.GetKeyDown(KeyCode.F) && startedConversation)
        {


            if (Talk(index, interactionInfo))
            {
                index++;
            }
            else
            {
                startedConversation = false;
                index = 0;
            }
            
           
        }
    }

    bool Talk(int indexForConversation, RaycastHit hit)
    {
        
        if (index < hit.transform.GetComponent<NPC>().conversations[corruptionLevel].NPCSentence.Count)
        {
            
            NPCText.text = hit.transform.GetComponent<NPC>().conversations[corruptionLevel].NPCSentence[index];
            PlayerResponse.text = hit.transform.GetComponent<NPC>().conversations[corruptionLevel].playerSentence[index];
            print(index);
            return true;
        }
        else
        {
            print("End");
            PlayerResponse.text = "";
            
            return false;
        }
        
    }
}
