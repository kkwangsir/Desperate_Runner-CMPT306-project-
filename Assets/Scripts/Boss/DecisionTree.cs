using UnityEngine;
using System.Collections;

public class DecisionTree {

	public delegate bool Decision();
	public delegate void Action();

	//    int tmp;

	DecisionTree left;
	DecisionTree right;
	Decision myDecision;
	Action myAction;

	// Constructor
	public DecisionTree()
	{
		left = null;
		right = null;
		myDecision = null;
		myAction = null;
	}

	public void SetDecision(Decision dec)
	{
		myDecision = dec;
	}

	public void SetAction(Action act)
	{
		myAction = act;
	}

	public void SetLeft(DecisionTree t)
	{
		left = t;
	}

	public void SetRight(DecisionTree t)
	{
		right = t;
	}

	/****** Make Decisions *******/

	public bool Decide()
	{
		return myDecision();
	}

	public void goLeft()
	{
		if (!(left == null))
			left.Search();
	}

	public void goRight()
	{
		if (!(right == null))
			right.Search();
	}

	public void Search()
	{
		// recursive base case
		if(myAction != null)
		{
			myAction();
		}			
		else if(Decide())
		{
			goLeft();
		}	
		else
		{
			goRight();
		}
	}
}
