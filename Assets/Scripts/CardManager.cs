using UnityEngine;
using UnityEngine.UI;

public class CardManager : MonoBehaviour
{
    public Button cardButton1;
    public Button cardButton2;
    public Button cardButton3;
    public Sprite[] cardSprites;

    private string[] cardEffects = { "ExtraTurn", "MoveDouble", "BlockOpponent" };
    private bool isCardSelected = false;
    private string selectedCardEffect;

    private void Start()
    {
        HideCardButtons();

        // Add listeners to buttons
        cardButton1.onClick.AddListener(() => OnCardSelected(cardButton1));
        cardButton2.onClick.AddListener(() => OnCardSelected(cardButton2));
        cardButton3.onClick.AddListener(() => OnCardSelected(cardButton3));
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
        selectedCardEffect = cardEffects[System.Array.IndexOf(cardSprites, selectedCard.image.sprite)];
        isCardSelected = true;
        HideCardButtons();
    }

    public bool IsCardSelected
    {
        get { return isCardSelected; }
    }

    public string GetSelectedCardEffect()
    {
        return selectedCardEffect;
    }

    public void ResetCardSelection()
    {
        isCardSelected = false;
    }
}
