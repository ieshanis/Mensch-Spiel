using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public Dice dice;
    public CardManager cardManager;
    public Player[] players; // Array of players in the game
    private int currentPlayerIndex = 0;

    private void Start()
    {
        StartTurn();
    }

    private void StartTurn()
    {
        Player currentPlayer = players[currentPlayerIndex];
        Debug.Log("It's " + currentPlayer.playerName + "'s turn!");

        // Enable dice rolling for the current player
        dice.gameObject.SetActive(true);
    }

    public void OnDiceRolled(int diceValue)
    {
        Debug.Log("Dice rolled: " + diceValue);

        // Move the current player's figure
        players[currentPlayerIndex].figures[0].Move(diceValue); // For now, just move the first figure

        // Show cards for the player to choose
        cardManager.ShowCards();
    }

    public void OnCardSelected(string effect)
    {
        // Apply the selected card effect to the current player
        ApplyCardEffect(effect);

        // Proceed to the next player's turn
        EndTurn();
    }

    private void ApplyCardEffect(string effect)
    {
        switch (effect)
        {
            case "ExtraTurn":
                Debug.Log("Player gets an extra turn!");
                // Logic for extra turn
                break;
            case "MoveDouble":
                Debug.Log("Player moves double the dice value!");
                // Logic for moving double the dice value
                break;
            case "BlockOpponent":
                Debug.Log("Player blocks an opponent!");
                // Logic for blocking an opponent
                break;
            default:
                Debug.Log("Unknown card effect!");
                break;
        }
    }

    private void EndTurn()
    {
        // Disable dice rolling
        dice.gameObject.SetActive(false);

        // Move to the next player
        currentPlayerIndex = (currentPlayerIndex + 1) % players.Length;

        // Start the next player's turn
        StartTurn();
    }
}
