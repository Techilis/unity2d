using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Use for text
using UnityEngine.UI;

public class AdventureGame : MonoBehaviour
{
    // SerializeField to make variable available in Unity Inspector
    [SerializeField] Text textComponent;
    [SerializeField] State startingState;
    

    State state;

    // Press Ctrl + R + R to rename all instances of this
    int[] specialArray = { 1, 3, 5, 7, 9 };

    // Start is called before the first frame update
    void Start()
    {
        state = startingState;
        textComponent.text = state.GetStateStory();
    }

    // Update is called once per frame
    void Update()
    {
        ManageState();
    }

    private void ManageState()
    {
        // var can be used if we assign a value on initialisation
        var nextState = state.getNextStates();
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            state = nextState[0];
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            state = nextState[1];
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            state = nextState[2];
        }
        textComponent.text = state.GetStateStory();
    }
}
