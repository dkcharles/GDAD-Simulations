using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

// Enum for example game states
[Serializable]  // serializable so it can be viewed in the inspector
public enum GameState
{
    SplashScreen,
    Options,
    Paused,
    Running,
    GameOver
}

// GameManager is a persistent singleton class that manages the game
public sealed class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameState CurrentGameState;  // current game state

    public Player player = new Player("Dyrlingr", 0, 100, 3, 1.5f);  // create a new player
    public NPC NPC_AI_01 = new NPC("Goblin", 100, 10, 1.5f);  // create a new NPC

    public bool GameRunning = false;    // is the game running?  

    #region Standard Unity Methods
    void Awake()
    {
        // Ensure that there is only one instance of GameManager
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        ChangeGameState(GameState.Running);
    }

    void Update()
    {
        // Check the current game state
        switch (CurrentGameState)
        {
            case GameState.SplashScreen:
                SplashScreen();
                break;
            case GameState.Options:
                Options();
                break;
            case GameState.Paused:
                Paused();
                break;
            case GameState.Running:
                Running();
                break;
            case GameState.GameOver:
                GameOver();
                break;
        }
    } // end of update
    #endregion

    private void SplashScreen()
    {
        GameRunning = false;
    }
    private void Options()
    {
        GameRunning = false;
    }
    private void Paused()
    {
        GameRunning = false;
    }
    private void Running()
    {
        if (GameRunning) // game is running
        {
            // Do gameplay stuff here
        }
    }
        private void GameOver()
    {
        GameRunning = false;
    }

    // Method to change the game state
    public void ChangeGameState(GameState newGameState)
    {
        CurrentGameState = newGameState;
    }
}

public class Player 
{
    public string Name { get; set; }
    public int Score { get; set; }
    public int Health { get; set; }
    public int Lives { get; set; }
    public float Speed { get; set; }

    public Player(string name, int score, int health, int lives, float speed)
    {
        Name = name;
        Score = score;
        Health = health;
        Lives = lives;
        Speed = speed;
    }
}

public class NPC
{
    public string Name { get; set; }
    public int Health { get; set; }
    public int Damage { get; set; }
    public float Speed { get; set; }

    public NPC(string name, int health, int damage, float speed)
    {
        Name = name;
        Health = health;
        Damage = damage;
        Speed = speed;
    }
}
