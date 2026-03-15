using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class MazeManager : MonoBehaviour
{
    FishGameHook gameHook;
    [SerializeField] TMP_Text timerText;

    const int BLANK = 0;
    const int WALL = 1;
    const int PLAYER = 2;
    const int GOAL = 3;
    float timer = 0;

    [SerializeField] GameObject mazeParentSeedPosition;
    List<GameObject> mazeBlocks = new List<GameObject>();
    [SerializeField] float stepInterval;
    [SerializeField] int mazesPerPlay;
    int mazeIdx = 0;
    const int ROWS = 7;
    const int COLS = 7;
    [SerializeField] GameObject wallPrefab;
    [SerializeField] GameObject goalPrefab;
    [SerializeField] GameObject playerPrefab;
    bool canMove = false;
    GameObject playerInstance;
    int[,] mazeState;
    int[] playerPos = { 0, 0 };

    List<int[,]> mazes = new List<int[,]>();

    void Awake()
    {
        gameHook = FindFirstObjectByType<FishGameHook>();
    }

    void InitializeMazes()
    {
        int[,] maze1 =
        {
            {1,1,1,1,1,1,1},
            {1,2,0,1,0,0,1},
            {1,1,0,0,0,1,1},
            {1,1,0,1,0,1,1},
            {1,0,0,0,0,0,1},
            {1,0,1,1,1,3,1},
            {1,1,1,1,1,1,1}
        };
        int[,] maze2 =
        {
            {1,1,1,1,1,1,1},
            {1,2,0,0,0,0,1},
            {1,0,1,1,0,1,1},
            {1,0,0,0,0,0,1},
            {1,0,1,0,1,1,1},
            {1,0,1,0,0,3,1},
            {1,1,1,1,1,1,1}
        };
        int[,] maze3 =
        {
            {1,1,1,1,1,1,1},
            {1,1,0,0,2,0,1},
            {1,0,0,1,1,0,1},
            {1,0,1,3,1,0,1},
            {1,0,0,0,1,0,1},
            {1,1,1,0,0,0,1},
            {1,1,1,1,1,1,1}
        };
        int[,] maze4 =
        {
            {1,1,1,1,1,1,1},
            {1,0,0,3,0,0,1},
            {1,1,1,1,1,0,1},
            {1,0,0,0,1,0,1},
            {1,0,1,2,1,0,1},
            {1,0,1,0,0,0,1},
            {1,1,1,1,1,1,1}
        };
        int[,] maze5 =
        {
            {1,1,1,1,1,1,1},
            {1,2,0,0,0,0,1},
            {1,0,1,1,0,1,1},
            {1,0,0,1,0,0,1},
            {1,1,0,0,0,0,1},
            {1,1,1,0,1,3,1},
            {1,1,1,1,1,1,1}
        };
        int[,] maze6 =
        {
            {1,1,1,1,1,1,1},
            {1,0,0,0,0,0,1},
            {1,0,0,0,0,0,1},
            {1,0,2,1,3,0,1},
            {1,0,0,0,0,0,1},
            {1,0,0,0,0,0,1},
            {1,1,1,1,1,1,1}
        };

        mazes.Add(maze1);
        mazes.Add(maze2);
        mazes.Add(maze3);
        mazes.Add(maze4);
        mazes.Add(maze5);
        mazes.Add(maze6);
    }

    public void GenerateMaze(int[,] maze)
    {
        for (int i = 0; i < ROWS; i++)
        {
            for (int j = 0; j < COLS; j++)
            {
                Vector3 position = (
                    mazeParentSeedPosition.transform.position
                    + new Vector3(j * stepInterval, 0, 0)
                    + new Vector3(0, i * stepInterval, 0)
                );
                int value = maze[i, j];
                GameObject myPrefab = null;
                if (value == 1) myPrefab = wallPrefab;
                if (value == 2) myPrefab = playerPrefab;
                if (value == 3) myPrefab = goalPrefab;
                if (myPrefab == null)
                {
                    continue;
                }

                GameObject myObj = Instantiate(myPrefab, position, Quaternion.identity);
                myObj.transform.parent = mazeParentSeedPosition.transform;
                if (value == PLAYER)
                {
                    playerInstance = myObj;
                    playerPos[0] = i;
                    playerPos[1] = j;
                }

                mazeBlocks.Add(myObj);
            }
        }
    }
    public void ClearMaze()
    {
        foreach (GameObject obj in mazeBlocks)
        {
            Destroy(obj);
        }
        mazeBlocks.Clear();
    }
    public void GenerateRandomMaze()
    {
        mazeState = (int[,])mazes[Random.Range(0, 6)].Clone();
        GenerateMaze(mazeState);
    }
    public void TryMove(Vector2 inputVector)
    {
        int newY = (int)inputVector.y + playerPos[0];
        if (newY < 0 || newY >= ROWS) return;
        int newX = (int)inputVector.x + playerPos[1];
        if (newX < 0 || newX >= COLS) return;

        if (mazeState[newY, newX] == WALL)
        {
            return;
        }
        if (mazeState[newY, newX] == GOAL)
        {
            HandleMazeCompletion();
            return;
        }
        mazeState[playerPos[0], playerPos[1]] = 0;
        mazeState[newY, newX] = PLAYER;

        playerPos[0] = newY;
        playerPos[1] = newX;

        playerInstance.transform.position = (
            mazeParentSeedPosition.transform.position
            + new Vector3(playerPos[1] * stepInterval, 0, 0)
            + new Vector3(0, playerPos[0] * stepInterval, 0)
        );
    }
    void HandleMazeCompletion()
    {
        mazeIdx++;
        if (mazeIdx < mazesPerPlay)
        {
            ClearMaze();
            GenerateRandomMaze();
        }
        else
        {
            EndGame();
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InitializeMazes();
        GenerateRandomMaze();
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!canMove) return;

        timer += Time.deltaTime;
        timerText.text = timer.ToString("F2");

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            TryMove(Vector2.up);
        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            TryMove(Vector2.left);
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            TryMove(Vector2.down);
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            TryMove(Vector2.right);
        }
    }

    int ComputeScore(float timer)
    {
        if (timer < 4f)
        {
            return 5;
        }
        else if (timer < 5f)
        {
            return 4;
        }
        else if (timer < 8f)
        {
            return 3;
        }
        else if (timer < 12f)
        {
            return 2;
        }
        else
        {
            return 1;
        }
    }
    public void EndGame()
    {
        int score = ComputeScore(timer);
        gameHook.HandleGameEnd(score);
    }
}
