using System.Collections.Generic;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class GridManager : MonoBehaviour
{
    public CardManager cardManager;
    public GameObject gridContent;
    public GridLayoutGroup gridLayout;

    public int gridx = 0;
    public int gridy =4;

    public int minOffsetSize = 140;
    public int maxgridSize = 6;
    public float minScaleoffset = 0.25f;

    private void Awake()
    {
        GameManager.Instance.OnGameStarted += ArrangeGridSize;
    }

    public void ArrangeGridSize(int x , int y)
    {
        gridLayout.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
        gridLayout.constraintCount = y;

        float gridSize = minOffsetSize * (1 + (maxgridSize - y) * minScaleoffset);
        
        gridLayout.cellSize = new Vector2(gridSize , gridSize);

        GenerateCards(x , y);
    }

    protected void GenerateCards(int x , int y)
    {
        int totalCardsCount = x * y;
        int totalCardsInOneGroup = 2;
        int cardPair = totalCardsCount / totalCardsInOneGroup;
        List<int> uniqueCards = GenrateUniqueIds(cardPair);
        
        Shuffle(uniqueCards);
        
        for (int i = 0; i < uniqueCards.Count; i++)
        {
            for (int j = 0; j < totalCardsInOneGroup; j++)
            {
                CardView card = cardManager.GetCardById(uniqueCards[i]);
                card.transform.SetParent(gridContent.transform, false);
                card.transform.localScale = Vector3.one;
                card.gameObject.SetActive(true);
                card.WaitForFake(1.5f);
            }
        }
    }

    protected List<int> GenrateUniqueIds(int uniquePair)
    {
        if(uniquePair > cardManager.cardViews.Count)
        {
            Debug.LogError("Cards can be repeat as you have low count");
        }
        
        List<int> uniqueIds = new List<int>();

        for (int i = 0; i < uniquePair; i++)
        {
            uniqueIds.Add(genrateRandomIds(uniqueIds));
        }

        return uniqueIds;
    }

    protected int genrateRandomIds(List<int> ids)
    {
        int id = Random.Range(0, cardManager.cardViews.Count);
        if (ids.Contains(id))
        {
            return genrateRandomIds(ids);
        }
        return id;
    }

    public void Shuffle(List<int> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0 , n + 1);
            int value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}
