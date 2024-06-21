using UnityEngine;
using UnityEngine.UI;

public class CardManager : MonoBehaviour
{
    public Button cardButton1;
    public Button cardButton2;
    public Button cardButton3;
    public Sprite[] cardSprites;
    private TurnManager turnManager;

    private string[] cardEffects = { "ExtraTurn", "MoveDouble", "BlockOpponent" };

    private void Start()
    {
        HideCardButtons();
        turnManager = FindObjectOfType<TurnManager>(); // Find TurnManager in the scene
    }

    public void ShowCards()
    {
        cardButton1.gameObject.SetActive(true);
        cardButton2.gameObject.SetActive(true);
        cardButton3.gameObject.SetActive(true);

        cardButton1.image.sprite = cardSprites[Random.Range(0, cardSprites.Length)];
        cardButton2.image.sprite = cardSprites[Random.Range(0, cardSprites.Length)];
        cardButton3.image.sprite = cardSprites[Random.Range(0, cardSprites.Length)];
    }

    private void HideCardButtons()
    {
        cardButton1.gameObject.SetActive(false);
        cardButton2.gameObject.SetActive(false);
        cardButton3.gameObject.SetActive(false);
    }

    public void OnCardSelected(Button selectedCard)
    {
        string effect = cardEffects[System.Array.IndexOf(cardSprites, selectedCard.image.sprite)];
        turnManager.OnCardSelected(effect); // Notify TurnManager of selected card
        HideCardButtons();
    }
}
