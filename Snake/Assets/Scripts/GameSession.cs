using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{

    // Configuration
    [Range(0, 10)] [SerializeField] float Speed = 5f;
    [SerializeField] GameObject snakeObject;
    [SerializeField] GameObject foodObject;


    // Initialized variables
    // Game Space: (0, 0) to (35, 19)
    //List<GameObject> snakeList = new List<GameObject>();
    List<Vector3> positionList = new List<Vector3>();
    List<Vector3> obstacleList = new List<Vector3>();

    Vector3 currentPos, newPos, foodPos;
    string currentDirection;
    int counter = 3;
    int numberOfFoodEaten = 0;
    bool foodEaten = true;
    bool canMoveAgain = true;
    int score = 0;
    Text gameOver;
    public string DIFFICULTY_KEY = "difficulty";


    private void Awake()
    {
        gameOver = GameObject.Find("GameOver").GetComponent<Text>();
        gameOver.enabled = false;
        gameOver.text = "Game Over";
        currentDirection = "right";
        positionList.Add(new Vector3(1, 9, 0));
        positionList.Add(new Vector3(2, 9, 0));
        positionList.Add(new Vector3(3, 9, 0));
        GameObject a = Instantiate(snakeObject, new Vector3(1, 9, 0), UnityEngine.Quaternion.identity);
        a.name = "0";
        GameObject b = Instantiate(snakeObject, new Vector3(2, 9, 0), UnityEngine.Quaternion.identity);
        b.name = "1";
        GameObject c = Instantiate(snakeObject, new Vector3(3, 9, 0), UnityEngine.Quaternion.identity);
        c.name = "2";
        Speed = PlayerPrefs.GetFloat(DIFFICULTY_KEY) * 15;
        //snakeList.Add(GameObject.Find("0"));
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Move());
    }

    private void Update()
    {
        FoodGenerator();
        ChangeCurrentDirection();
    }

    IEnumerator Move()
    {
        while (true)
        {
            // Move snake
            currentPos = GetCurrentPos(positionList);
            newPos = GetNewPosition(currentPos, currentDirection);

            // Create obstacleList
            obstacleList = CreateObstacleList();

            // Check for event - Die if hit obstacleList
            if (CheckIfHitBody())
            {
                Die();
            }
            // Die if x < 0, x > 35, y < 0, y > 19
            else if (newPos.x < 0 || newPos.x > 35 || newPos.y < 0 || newPos.y > 19)
            {
                Die();
            }
            else
            {
                // If no die, add new position
                AddPositionList(newPos, positionList);
                CreateNewPosition(newPos);

                // If hit food, do not destroy tail or remove tail position
                if (!TriggerIfHitFood())
                {
                    DestroyTail();
                    RemovePositionList(positionList);
                }
                else { numberOfFoodEaten++; }

            }


            yield return new WaitForSeconds(1/(Speed*3));
        }
        
    }

    private void Die()
    {
        gameOver.enabled = true;
        StartCoroutine(WaitAndLoad());
    }

    IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(0);
    }

    private bool CheckIfHitBody()
    {
        for (int index=0; index < obstacleList.Count ; index++)
        {
            if (Vector3.Distance(newPos, obstacleList[index]) < Mathf.Epsilon)
            {
                return true;
            }
        }
        return false;
    }

    private bool TriggerIfHitFood()
    {
        if (Vector3.Distance(foodPos, newPos) < Mathf.Epsilon)
        {
            Destroy(GameObject.Find("Food"));
            score += 100;
            foodEaten = true;
            return true;
        }
        return false; ;
    }

    private List<Vector3> CreateObstacleList()
    {
        List<Vector3> tempList = new List<Vector3>();
        if (positionList.Count > 1)
        {
            // index starts from 1 so as to avoid gameOver when newPos hits tailPos
            for (int index=0; index < positionList.Count-1; index++)
            {
                tempList.Add(positionList[index]);
            }
        }
        return tempList;
    }


    private void ChangeCurrentDirection()
    {
        if (Input.GetKeyDown(KeyCode.W) && currentDirection != "down") { currentDirection = "up"; }
        else if (Input.GetKeyDown(KeyCode.S) && currentDirection != "up") { currentDirection = "down"; }
        else if (Input.GetKeyDown(KeyCode.A) && currentDirection != "right") { currentDirection = "left"; }
        else if (Input.GetKeyDown(KeyCode.D) && currentDirection != "left") { currentDirection = "right"; }
    }

    private void DestroyTail()
    {
        int deleteCounter = counter - 4 - numberOfFoodEaten;
        Destroy(GameObject.Find(deleteCounter.ToString()));
    }

    private void AddPositionList(Vector3 newPos, List<Vector3> positionList)
    {
        positionList.Add(newPos);
    }

    private void RemovePositionList(List<Vector3> positionList)
    {
        positionList.RemoveAt(0);
    }

    private Vector3 GetCurrentPos(List<Vector3> positionList)
    {
        return positionList[positionList.Count - 1];
    }

    private Vector3 GetNewPosition(Vector3 currentPos, string direction)
    {
        float x = currentPos[0];
        float y = currentPos[1];

        if (direction == "right")
        {
            x++;
        }
        else if (direction == "left")
        {
            x--;
        }
        else if (direction == "up")
        {
            y++;
        }
        else if (direction == "down")
        {
            y--;
        }
        else
        {
            Debug.Log("Error with direction value: " + direction);
        }
        return new Vector3(x, y, 0);
    }

    private void CreateNewPosition(Vector3 position)
    {
        // Instantiate snakeObject, add to list, add counter
        GameObject g = Instantiate(snakeObject, position, Quaternion.identity);
        g.name = counter.ToString();
        //snakeList.Add(GameObject.Find(counter.ToString()));
        counter++;
    }

    
    private void FoodGenerator()
    {
        if (foodEaten)
        {
            foodEaten = false;
            SpawnFood();
        }
    }

    private Vector3 GetNewFoodPos()
    {
        Vector3 pos;
        do
        {
            pos = new Vector3(Random.Range(0, 35), Random.Range(0, 19), 0);
        }
        while (CheckIfHitBody());
        return pos;
    }

    private void SpawnFood()
    {
        foodPos = GetNewFoodPos();
        GameObject food = Instantiate(foodObject, foodPos, Quaternion.identity);
        food.name = "Food";
    }

    public int GetScore()
    {
        return score;
    }


}
