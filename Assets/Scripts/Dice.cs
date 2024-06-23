using System.Collections;
using UnityEngine;

public class Dice : MonoBehaviour
{
    private Sprite[] diceSides;
    private SpriteRenderer rend;
    private bool isRolled = false;
    private int diceValue;

    private void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        diceSides = Resources.LoadAll<Sprite>("DiceSides/");
    }

    public void RollDice()
    {
        StartCoroutine(RollTheDice());
    }

    private IEnumerator RollTheDice()
    {
        isRolled = false;
        int randomDiceSide = 0;

        for (int i = 0; i < 20; i++)
        {
            randomDiceSide = Random.Range(0, diceSides.Length);
            rend.sprite = diceSides[randomDiceSide];
            yield return new WaitForSeconds(0.05f);
        }

        diceValue = GetDiceSideNumber(diceSides[randomDiceSide].name);
        Debug.Log("Dice rolled: " + diceValue);
        isRolled = true;
        GameManager.instance.OnDiceRolled(diceValue);
    }

    private int GetDiceSideNumber(string spriteName)
    {
        switch (spriteName)
        {
            case "one":
                return 1;
            case "two":
                return 2;
            case "three":
                return 3;
            case "four":
                return 4;
            case "five":
                return 5;
            case "six":
                return 6;
            default:
                Debug.LogError("Unknown sprite name: " + spriteName);
                return -1;
        }
    }

    public bool IsRolled
    {
        get { return isRolled; }
    }

    public int GetDiceValue()
    {
        return diceValue;
    }
}
