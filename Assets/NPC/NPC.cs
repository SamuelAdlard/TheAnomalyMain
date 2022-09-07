using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{

    public string name;
    [SerializeField] public List<Conversation> conversations = new List<Conversation>();

}

[System.Serializable]
 public class Conversation
{
    public List<string> NPCSentence = new List<string>();
    public List<string> playerSentence = new List<string>();
}