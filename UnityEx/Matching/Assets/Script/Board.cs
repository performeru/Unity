using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField]
    private GameObject cardPrefad;

    [SerializeField]
    private Sprite[] cardSprites;

    private List<int> cardIDList = new List<int>();
    private List<Card> cardList = new List<Card>();

    void Start()
    {
        GenerateCardID();
        ShuffleCardID();
        InitBoard();
    }

    void GenerateCardID()
    {
        for(int i = 0; i < cardSprites.Length; i++)
        {
            cardIDList.Add(i);
            cardIDList.Add(i);
            cardIDList.Add(i);
            cardIDList.Add(i);
        }
    }

    void ShuffleCardID()
    {
        int cardCount = cardIDList.Count;

        for(int i = 0; i < cardCount; i++)
        {
            int randomIndex = Random.Range(i, cardCount);
            int temp = cardIDList[randomIndex];
            cardIDList[randomIndex] = cardIDList[i];
            cardIDList[i] = temp;
        }
    }

    void InitBoard()
    {
        float spaceY = 1.7f;
        float spaceX = 1.4f;

        int rowCount = 6;
        int colCount = 4;

        int cardIndex = 0; 

        for(int row = 0;  row < rowCount; row++)
        {
            for(int col = 0; col < colCount; col++)
            {
                float posX = (col - (colCount / 2)) * spaceX + (spaceX / 2);
                float posY = (row - (int)(rowCount / 2)) * spaceY + (spaceY / 2);
                Vector3 pos = new Vector3(posX, posY, 0f);
                GameObject cardObject = Instantiate(cardPrefad, pos, Quaternion.identity);
                Card card = cardObject.GetComponent<Card>();

                int cardID = cardIDList[cardIndex];
                card.SetCardID(cardID);
                card.SetAnimalSprite(cardSprites[cardID]);
                cardIndex++;
                cardList.Add(card);
            }
        }
    }    

    public List<Card> GetCards()
    {
        return cardList;
    }
}
