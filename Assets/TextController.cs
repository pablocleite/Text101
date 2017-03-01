using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour {

    private enum State {
        cell,
        mirror,
        sheets_0,
        lock_0,
        cell_mirror,
        sheets_1,
        lock_1,
        freedom
    }

    public Text text;
    private State currentState;

    // Use this for initialization
    void Start() {
        currentState = State.cell;
    }

    // Update is called once per frame
    void Update() {
        print(currentState);
        switch (currentState) {
            case State.cell:
                stateCell();
                break;
            case State.sheets_0:
                stateSheets0();
                break;
            case State.mirror:
                stateMirror();
                break;
            case State.lock_0:
                stateLock0();
                break;
            case State.cell_mirror:
                stateCellMirror();
                break;
            case State.sheets_1:
                stateSheets1();
                break;
            case State.lock_1:
                stateLock1();
                break;
            case State.freedom:
                stateFreedom();
                break;
        }
    }
    
    private void stateCell() {
        text.text = "I woke up in this filthy cell again, this is a mistake. I'm not guilty! I must get out of this hell.\n" +
                    "There are some dirty sheets on the bed, an old mirror on the wall. Door is locked from outside.\n\n" +

                    "Press S to view sheets, M to view mirror and L to view door lock.";

        if (Input.GetKeyDown(KeyCode.S)) {
            currentState = State.sheets_0;
        } else if (Input.GetKeyDown(KeyCode.M)) {
            currentState = State.mirror;
        } else if (Input.GetKeyDown(KeyCode.L)) {
            currentState = State.lock_0;
        }
    }

    private void stateSheets0() {
        text.text = "I can't believe I've been sleeping in these things, they look like they haven't being changed in ages. What a nightmare!\n\n" +
                    "Press R to return to roaming your cell.";

        if (Input.GetKeyDown(KeyCode.R)) {
            currentState = State.cell;
        }
    }

    private void stateMirror() {
        text.text = "Humm, this old mirror shows how I'm growing old, unshaved with a messy hair. What is this prison doing to me?\n\n" + 
                    "Press T to take the mirror, R to return to roaming your cell.";

        if (Input.GetKeyDown(KeyCode.R)) {
            currentState = State.cell;
        } else if (Input.GetKeyDown(KeyCode.T)) {
            currentState = State.cell_mirror;
        }
    }

    private void stateLock0() {
        text.text = "Locked from the outside, there's nothing I can do for now.\n\n" +
                    "Press R to return to roaming your cell.";

        if (Input.GetKeyDown(KeyCode.R)) {
            currentState = State.cell;
        }
    }

    private void stateCellMirror() {
        text.text = "Humm... Great now I have a mirror with me. Can I do something with it?\n\n" +
            "Press S to view sheets, L to view Lock"; 

        if (Input.GetKeyDown(KeyCode.S)) {
            currentState = State.sheets_1;
        } else if (Input.GetKeyDown(KeyCode.L)) {
            currentState = State.lock_1;
        }
    }

    private void stateSheets1() {
        text.text = "A mirror won't clean these sheets.\n\n" +
                    "Press R to return to roaming your cell.";

        if (Input.GetKeyDown(KeyCode.R)) {
            currentState = State.cell_mirror;
        }
    }

    private void stateLock1() {
        text.text = "Let's see what's behind this lock, There's a keypad... I'll try to hit the dirtier buttons.\n" +
                     "[Clunk noise] looks like it worked, cell is unlocked.\n\n" +
                     "Press O to open the door.";

        if (Input.GetKeyDown(KeyCode.O)) {
            currentState = State.freedom;
        }
    }

    private void stateFreedom() {
        text.text = "Freedom at last!\n\n" +
            "Press P to play again.";

        if (Input.GetKeyDown(KeyCode.P)) {
            currentState = State.cell;
        }
    }
}
