using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Dice : MonoBehaviour
{
    public int numberOfSides = 6; // Typical dice has 6 sides
    private int currentSide;

    public Image diceImage; // Reference to the UI Image component
    public Sprite[] diceFaces; // Array to hold dice face sprites

    void Start()
    {
        gameObject.SetActive(false); // Initially hide the dice
    }

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
            UpdateDiceFace();
            yield return null;
        }

        Debug.Log("Rolled: " + currentSide);
    }

    private void UpdateDiceFace()
    {
        if (diceFaces.Length >= numberOfSides)
        {
            diceImage.sprite = diceFaces[currentSide - 1];
        }
    }

    public int GetCurrentSide()
    {
        return currentSide;
    }
}
