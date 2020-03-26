using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Difficulty : MonoBehaviour
{
    public string DIFFICULTY_KEY = "difficulty";
    float difficultyLevel;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        difficultyLevel = GetComponent<Slider>().value;
        PlayerPrefs.SetFloat(DIFFICULTY_KEY, difficultyLevel);
        Debug.Log(PlayerPrefs.GetFloat(DIFFICULTY_KEY));
    }
}
