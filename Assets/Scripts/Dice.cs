using System.Collections;
using UnityEngine;

public class Dice : MonoBehaviour
{
    // Array of dice sides sprites to load from Resources folder
    private Sprite[] diceSides;

    // Reference to sprite renderer to change sprites
    private SpriteRenderer rend;

    // Use this for initialization
    private void Start()
    {
        // Assign Renderer component
        rend = GetComponent<SpriteRenderer>();

        // Load dice sides sprites to array from DiceSides subfolder of Resources folder
        diceSides = Resources.LoadAll<Sprite>("DiceSides/");
    }

    // If you left click over the dice then RollTheDice coroutine is started
    private void OnMouseDown()
    {
        StartCoroutine(RollTheDice());
    }

    // Coroutine that rolls the dice
    private IEnumerator RollTheDice()
    {
        // Final side or value that dice reads in the end of coroutine
        int finalSide = 0;

        // Loop to switch dice sides randomly before final side appears. 20 iterations here.
        for (int i = 0; i <= 20; i++)
        {
            // Pick up random value from 0 to 5 (inclusive)
            int randomDiceSide = Random.Range(0, 6); // corrected from 0 to 5 to 0 to 6 to include all 6 sides

            // Set sprite to upper face of dice from array according to random value
            rend.sprite = diceSides[randomDiceSide];

            // Pause before next iteration
            yield return new WaitForSeconds(0.05f);
        }

        // Assigning final side so you can use this value later in your game
        // for player movement for example
        finalSide = Random.Range(1, 7); // rolling a 6-sided dice, so finalSide should be between 1 and 6

        // Show final dice value in Console
        Debug.Log("Dice rolled: " + finalSide);

        
        
        GameManager.instance.OnDiceRolled(finalSide);
    }
}