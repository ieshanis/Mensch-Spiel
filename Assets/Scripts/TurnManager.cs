using System.Collections;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public Dice dice;
    public CardManager cardManager;

    private GameManager gameManager;
    private int currentPlayerIndex = 0;
    private int diceValue;

    private void Start()
    {
        gameManager = GameManager.instance;
        if (gameManager == null)
        {
            Debug.LogError("GameManager not found in the scene.");
        }
    }

    public void StartTurn()
    {
        StartCoroutine(TurnSequence());
    }

    private IEnumerator TurnSequence()
    {
        // Reset dice roll status
        dice.ResetRoll();

        // Wait until the dice is rolled
        yield return new WaitUntil(() => dice.IsRolled);

        // Get the rolled value
        diceValue = dice.GetDiceValue();

        // Step 2: Show cards and let player choose one
        cardManager.ShowCards();
        // Wait until the card is selected
        yield return new WaitUntil(() => cardManager.IsCardSelected);

        // Step 3: Apply card effect
        string cardEffect = cardManager.GetSelectedCardEffect();
        ApplyCardEffect(cardEffect);

        // Step 4: Move the player based on dice value
        gameManager.OnDiceRolled(diceValue);

        // Proceed to the next player
        currentPlayerIndex++;
    }

    private void ApplyCardEffect(string effect)
    {
        switch (effect)
        {
            case "ExtraTurn":
                Debug.Log("Player gets an extra turn!");
                // Logic for extra turn
                currentPlayerIndex--; // To give an extra turn
                break;
            case "MoveDouble":
                Debug.Log("Player moves double the dice value!");
                diceValue *= 2;
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
}
