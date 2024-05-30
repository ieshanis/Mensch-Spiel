using UnityEngine;
using UnityEngine.UI;

public class Dice : MonoBehaviour
{
    public int numberOfSides = 6; // Typical dice has 6 sides
    private int currentSide;

    public Text diceText; // Reference to the UI Text component

    void Start()
    {
        gameObject.SetActive(false); // Initially hide the dice
    }

    /**
    public void RollDice()
    {
        gameObject.SetActive(true); // Show the dice
        StartCoroutine(RollingCoroutine());
    }

    private IEnumerator RollingCoroutine()
    {
        float rollDuration = 1.0f; // duration of the roll in seconds
        float elapsedTime = 0f;

        while (elapsedTime < rollDuration)
        {
            elapsedTime += Time.deltaTime;
            currentSide = Random.Range(1, numberOfSides + 1);
            UpdateDiceText();
            yield return null;
        }

        Debug.Log("Rolled: " + currentSide);
    }

    private void UpdateDiceText()
    {
        diceText.text = currentSide.ToString();
    }

    public int GetCurrentSide()
    {
        return currentSide;
    }
    **/
}
