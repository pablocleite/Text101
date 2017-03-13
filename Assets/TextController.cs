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
        corridor_0,
        stairs_0,
        floor,
        closet_door,
        stairs_1,
        corridor_1,
        in_closet,
        stairs_2,
        corridor_2,
        courtyard,
        corridor_3
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
            case State.corridor_0:
                stateCorridor0();
                break;
            case State.stairs_0:
                stateStairs0();
                break;
            case State.floor:
                stateFloor();
                break;
            case State.closet_door:
                stateClosetDoor();
                break;
            case State.stairs_1:
                stateStairs1();
                break;
            case State.corridor_1:
                stateCorridor1();
                break;
            case State.in_closet:
                stateInCloset();
                break;
            case State.stairs_2:
                stateStairs2();
                break;
            case State.corridor_2:
                stateCorridor2();
                break;
            case State.courtyard:
                stateCoutyard();
                break;
            case State.corridor_3:
                stateCorridor3();
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
            currentState = State.corridor_0;
        }
    }

    private void stateCorridor0() {
        text.text = "Humm, a big corridor\n" +
                    "I gotta find a way out. I wonder where those stairs can take me. There's also a closet door here.\n\n" + 
                    "Press S to climb the stairs, F to look on the floor and C to open the closed";

        if (Input.GetKeyDown(KeyCode.S)) {
            currentState = State.stairs_0;
        } else if (Input.GetKeyDown(KeyCode.F)) {
            currentState = State.floor;
        } else if (Input.GetKeyDown(KeyCode.C)) {
            currentState = State.closet_door;
        }
    }

    private void stateStairs0() {
        text.text = "Oops! There are guards over here. Maybe during their break things get easier.\n" +
                    "I'll quickly hide myself so they won't see me. Phew I'm safe for now!\n\n" +
                    "Press R To return to the corridor.";

        if (Input.GetKeyDown(KeyCode.R)) {
            currentState = State.corridor_0;
        }
    }

    private void stateFloor() {
        text.text = "There's nothing but dirty and a shiny thing.\n" +
                    "What's a hairclip doing in this dirty prison corridor? Who knowns. It might be useful\n\n"+
                    "Press H to get the hairclip, R to return to corridor.";

        if (Input.GetKeyDown(KeyCode.H)) {
            currentState = State.corridor_1;
        } else if (Input.GetKeyDown(KeyCode.R)) {
            currentState = State.corridor_0;
        }
    }

    private void stateClosetDoor() {
        text.text = "Locked!\n" +                    
                    "Press R to return to corridor.";

        if (Input.GetKeyDown(KeyCode.R)) {
            currentState = State.corridor_0;
        }
    }

    private void stateStairs1() {
        text.text = "I don't think this hairclip will neither be a good gun against those guards nor be used as a cloaking device!\n\n" +
                    "Press R to return to corridor before they got you.";

        if (Input.GetKeyDown(KeyCode.R)) {
            currentState = State.corridor_1;
        }
    }

    private void stateCorridor1() {
        text.text = "Still in this corridor. Now at least I have a hairclip, bored as hell I can wait forever until the guards die.\n" +
                    "Or try to pick the closet door, at least that would be fun.\n\n" +
                    "Press S to climb the stairs, P to pick the closed door with your hairclip.";

        if (Input.GetKeyDown(KeyCode.S)) {
            currentState = State.stairs_1;
        } else if(Input.GetKeyDown(KeyCode.P)) {
            currentState = State.in_closet;
        }
    }

    private void stateInCloset() {
        text.text = "Humm. I know how to lock pick :D I'm feeling great now.\n" +
                    "Let's see what's in this closet! Good I could disguise me with this cleaner uniform.\n\n" +
                    "Press D to dress the uniform, R to return to the corridor";

        if (Input.GetKeyDown(KeyCode.D)) {
            currentState = State.corridor_3;
        } else if (Input.GetKeyDown(KeyCode.R)) {
            currentState = State.corridor_2;
        }
    } 
    
    private void stateCorridor2() {
        text.text = "Back in the corridor. Still wearing my old filthy prisoner clothing.\n\n" +
                    "Press S to climb the stairs, R to revist the closet.";

        if (Input.GetKeyDown(KeyCode.S)) {
            currentState = State.stairs_2;
        } else if (Input.GetKeyDown(KeyCode.R)) {
            currentState = State.in_closet;
        }
    }

    private void stateStairs2() {
        text.text = "Guards are still there, my single weapon, the hairclip, is now badly bent. Who do I think I am? Rambo?.\n\n" +
                    "Press R to return to your corridor.";

        if (Input.GetKeyDown(KeyCode.R)) {
            currentState = State.corridor_2;
        }
    }

    private void stateCorridor3() {
        text.text = "Humm not bad! This is definetly cleaner than my previous clothing and I think those guards won't notice me.\n" +
                    "At least, this my best chance.\n\n" +
                    "Press U to undress, S to climb the stairs and face those guards!";

        if (Input.GetKeyDown(KeyCode.U)) {
            currentState = State.in_closet;
        } else if (Input.GetKeyDown(KeyCode.S)) {
            currentState = State.courtyard;
        }
    }

    private void stateCoutyard() {
        text.text = "I walked right past those guards, no one noticed I wasn't the cleaner.\n" +
                    "I thought I was gonna have a heart attack. Looks like I'm still alive and free.\n" +
                    "I can finally admire a great sunset while walking home.\n\n" +
                    "Press P to play again.";

        if (Input.GetKeyDown(KeyCode.P)) {
            currentState = State.cell;
        }
    }












}
