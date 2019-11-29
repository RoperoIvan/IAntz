using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

// TODO 1: Create a simple class to contain one entry in the blackboard
// should at least contain the gameobject, position, timestamp and a bool
// to know if it is in the past memory

public class Knowledge
{
    public GameObject GO;
    public Vector3 position;
    public float timestamp;
    public bool memory_up;
}

public class AIMemory : MonoBehaviour {

	public GameObject Cube;
	public Text Output;
    Dictionary<string, Knowledge> encyclopedia;

    // TODO 2: Declare and allocate a dictionary with a string as a key and
    // your previous class as value


    // TODO 3: Capture perception events and add an entry if the player is detected
    // if the player stop from being seen, the entry should be "in the past memory"
    void PerceptionEvent(PerceptionEvent ev)
    {
        Knowledge thought;
        thought = new Knowledge();
        
        if (ev.type == global::PerceptionEvent.types.NEW)
        {
            thought.GO = ev.go;
            thought.position = ev.go.transform.position;
            thought.timestamp = Time.time;
            thought.memory_up = false;
        }
        if (ev.type == global::PerceptionEvent.types.LOST)
        {
            thought.GO = ev.go;
            thought.position = ev.go.transform.position;
            thought.timestamp = Time.time;
            thought.memory_up = true;
        }

        Knowledge helper;
        helper = new Knowledge();

        if (!encyclopedia.TryGetValue(ev.go.name,out helper))
        {
            encyclopedia.Add(ev.go.name, thought);
        }
        else
            encyclopedia[ev.go.name] = thought;
    }

    // Use this for initialization
    void Start () {
        encyclopedia = new Dictionary<string, Knowledge>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		// TODO 4: Add text output to the bottom-left panel with the information
		// of the elements in the Knowledge base
        foreach (KeyValuePair<string, Knowledge> entry in encyclopedia)
        {
            Output.text = entry.Key + entry.Value.position;
        }
	}

}
