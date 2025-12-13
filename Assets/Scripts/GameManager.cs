using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance;

	public Action<int, int> OnGameStarted;
	public Action<CardView> onCardSelected;
	public Action cardsGotMatched;

	List<CardView> selectedCards = new List<CardView>();

	private void Awake()
	{
		OnGameStarted += StartTheGame;
		onCardSelected += CardSelected;
	}
	void Start()
	{
		if(Instance != null)
		{
			Instance = null;
		}
		Instance = this;
	}

	private void StartTheGame(int x , int y)
	{

	}

	public void CardSelected(CardView cardView)
	{
		if (selectedCards.Count == 0)
		{
			selectedCards.Add(cardView);
		}
		else
		{
			if (selectedCards[selectedCards.Count - 1].cardId == cardView.cardId)
			{
				//Card matched
				selectedCards.Add(cardView);

				for (int i = 0; i < selectedCards.Count; i++)
				{
					selectedCards[i].gameObject.SetActive(false);
				}
				selectedCards = new List<CardView>();
			}
			else
			{
				//Card not matched
				for (int i = 0; i < selectedCards.Count; i++)
				{
					selectedCards[i].FlipToFake();
				}
				cardView.FlipToFake();
				selectedCards = new List<CardView>();
			}
		}
	}

	public List<CardView> GetSelectedCards()
	{
		return selectedCards;
	}
}
