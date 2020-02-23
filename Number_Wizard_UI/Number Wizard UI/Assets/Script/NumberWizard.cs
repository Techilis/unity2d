using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NumberWizard : MonoBehaviour
{
    [SerializeField] int max;
    [SerializeField] int min;
    [SerializeField] TextMeshProUGUI guessText;
    int guess;
    // Start is called before the first frame update
    void Start()
    {
        StartGame();
    }

    void StartGame()
    {
        guess = Random.Range(min, max + 1);
        guessText.text = guess.ToString();
        max = max + 1;
    }

    public void OnPressHigher()
    {
        min = guess+1;
        NextGuess();
        guessText.text = guess.ToString();
    }

    public void OnPressLower()
    {
        max = guess-1;
        NextGuess();
        guessText.text = guess.ToString();
    }


    void NextGuess()
    {
        guess = (max + min) / 2;
    }
}
