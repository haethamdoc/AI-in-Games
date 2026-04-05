using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class DialogueManager : MonoBehaviour
{

    public Flowchart flowchart;

    private void Awake()
    {
        if(flowchart == null) 
            flowchart = FindObjectOfType<Flowchart>(); 
    }

    public void StartDialogue(string blockName)
    { 
        flowchart.ExecuteIfHasBlock(blockName); 
    }

}
