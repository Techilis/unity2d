using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// CreateAssetMenu to create a new asset template for Unity editor,
// When we right click assets manager, we can add "State"
[CreateAssetMenu(menuName = "State")]
public class State : ScriptableObject
{
    // Reusable script
    [TextArea(14, 10)] [SerializeField] string storyText;
    [SerializeField] State[] nextStates;

    public State[] getNextStates()
    {
        return nextStates;
    }

    // Method within State class
    public string GetStateStory() 
    {
        return storyText;
    }

}
