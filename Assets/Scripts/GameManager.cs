using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Transform[] boardPositions;

    private PlayerFigure[] bluePlayers;
    private PlayerFigure[] greenPlayers;
    private int currentPlayerIndex = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
            return;
        }

        bluePlayers = GameObject.FindGameObjectsWithTag("BluePlayer").Select(go => go.GetComponent<PlayerFigure>()).ToArray();
        greenPlayers = GameObject.FindGameObjectsWithTag("GreenPlayer").Select(go => go.GetComponent<PlayerFigure>()).ToArray();

        foreach (var player in bluePlayers)
        {
            player.startIndex = 26;
        }

        foreach (var player in greenPlayers)
        {
            player.startIndex = 0;
        }
    }

    public void OnDiceRolled(int diceValue)
    {
        if (currentPlayerIndex % 2 == 0)
        {
            MoveNextPlayer("BluePlayer", diceValue);
        }
        else
        {
            MoveNextPlayer("GreenPlayer", diceValue);
        }

        currentPlayerIndex++;
    }

    public void MoveNextPlayer(string tag, int diceValue)
    {
        PlayerFigure[] players = tag == "BluePlayer" ? bluePlayers : greenPlayers;
        if (players.Length == 0)
        {
            Debug.LogWarning("No players found for tag: " + tag);
            return;
        }

        PlayerFigure playerToMove = players[Random.Range(0, players.Length)];
        playerToMove.Move(diceValue);
    }
}
