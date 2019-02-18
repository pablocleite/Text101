using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextAdventureGame : MonoBehaviour {

    [SerializeField] public Text text;
    [SerializeField] public State startingState;

    private State currentState;

    // Use this for initialization
    void Start()
    {
        currentState = startingState;
        text.text = currentState.GetStateStory();
    }

    // Update is called once per frame
    void Update() {
        ManageState();
    }

    private void ManageState() {
        var nextStates = currentState.GetNextStates();

        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            currentState = nextStates[0];
        } else if (Input.GetKeyDown(KeyCode.Alpha2)) {
            currentState = nextStates[1];
        } else if (Input.GetKeyDown(KeyCode.Alpha3)) {
            currentState = nextStates[2];
        }

        text.text = currentState.GetStateStory();
    }
}
