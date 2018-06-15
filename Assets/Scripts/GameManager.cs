using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System;
using System.Security.Cryptography;
using System.Threading;



public class GameManager : MonoBehaviour
{

	List<CardContents> CardList = new List<CardContents> ();
	CardContents[] c = new CardContents[150];
	public GameObject Card, EmptyCard, FakeCard;
	public GameObject[] Cards;
	public Sprite cardBack;
	//	public Text cardText;
	//Swipe swipe;
	Vector3 inititalCardPosition;
	Vector3 finalCardPositonRight, finalCardPositionLeft;
	bool isMoveRight, isMoveLeft = false;
	public static bool isRotate = false;
	bool isFlipped = false, isZoom = false;
	Quaternion initRotation;
	RaycastHit hit;
	GameObject LocalCard;
	int CardNumber = 0;
	[SerializeField]
	GameObject EventBlocker;
	int EndingDrama = 0;
	Vector3 orignalScale;
	List<int> openCards = new List<int> ();
	int firstDraw = 0;
	[SerializeField]
	AudioSource restartAudio, passAudio;
	public static bool isRestartWholegame = false;

	void Start ()
	{
		CardNumber = showRandomCard ();
		orignalScale = Card.transform.localScale;
		finalCardPositonRight = new Vector3 (Card.transform.position.x + Screen.width, Card.transform.position.y, Card.transform.position.z);
		finalCardPositionLeft = new Vector3 (Card.transform.position.x - Screen.width, Card.transform.position.y, Card.transform.position.z);
		inititalCardPosition = Card.transform.position;
		initRotation = Card.transform.rotation;

		#if UNITY_IOS
		if (PlayerPrefs.GetInt ("RemoveAds") != 2) {
			StartAppWrapperiOS.unityOrientation (StartAppWrapperiOS.STAUnityOrientation.STALandscape);
			StartAppWrapperiOS.loadAd ();
		}
		#endif   

		   
	}


	void BlockScreen ()
	{
	
		this.GetComponent<SwipeManager> ().enabled = false;
	
	}

	void cardSetup ()
	{
		
		c [0] = new CardContents (false, "is there a Song which mirrors the way which you are feeling today?");
		c [1] = new CardContents (false, "If you could tell me something about hip-hop, what would it be?");
		c [2] = new CardContents (false, "What is your favorite song?"); 
		c [3] = new CardContents (false, "How do you feel when you are listening to your favorite song?");
		c [4] = new CardContents (false, "If your life was a song, what would it be called?");
		c [5] = new CardContents (false, "Which rappers inspire you?");
		c [6] = new CardContents (false, "Do you think rappers actually do all those things they rap about?");
		c [7] = new CardContents (false, "Imagine your best friend became a rapper. What would he/she rap about?");
		c [8] = new CardContents (false, "If you could write a song to/for anyone in the world, who would it be? Why?");
		c [9] = new CardContents (false, "If you could draw a rapper, what would that person look like? What would they wear?");
		c [11] = new CardContents (false, "If you were a rapper, what would be your rap name?");
		c [12] = new CardContents (false, "Why do you think there is violence in rap lyrics?");
		c [13] = new CardContents (false, "What do you think is the best part about hip-hop?");
		c [14] = new CardContents (false, "Have you been inspired by rap songs?");
		c [15] = new CardContents (false, "What do you think is the main difference between rap and other types of music?");
		c [16] = new CardContents (false, "Did you know: There are four main elements of hip-hop culture? (DJ, Rapper, BBoy, Graffiti Artist)");
		c [17] = new CardContents (false, "Did you know: Rappers were and are often called “Emcees”.");
		c [18] = new CardContents (false, "Did you know: Rappers like M.C. Lyte, Queen Latifah, Salt n Pepa and Lauryn Hill all were successful women who respected themselves, their bodies and minds?");
		c [19] = new CardContents (true, "Did you know: Bahamadia and Rapsody and Jean Grae are female rappers who are better than most men? Look them up!");
		c [20] = new CardContents (false, "Would you rather be a DJ, rapper, dancer or graffiti artist? Why?");
		c [21] = new CardContents (false, "Did you know: There was hip-hop culture before there were rappers? (DJs played  records at parties while the bboys danced)");
		c [22] = new CardContents (false, "What do you think rappers mean when they say they are “Keeping it real?”");
		c [24] = new CardContents (false, "What time of day do you most feel like listening to hip-hop?");
		c [23] = new CardContents (false, "Who are your favorite rappers?");
		c [24] = new CardContents (false, "Has listening to a rap song ever made you want to do something you never tried before?");
		c [25] = new CardContents (false, "Is it possible to be a good parent and a rapper at the same time? Why?");
		c [26] = new CardContents (false, "Using a piece of paper and rhyming/drawing/writing, show me how you feel today?");
		c [27] = new CardContents (true, "Why do you think Tupac died? ");
		c [28] = new CardContents (false, "Look at your surroundings. Take in this moment and then create a two line rhyme about what you see or you are feeling.");
		c [29] = new CardContents (false, "If you were a parent, which artists would you want your children to listen to? Why?");
		c [30] = new CardContents (true, "How many rappers can you name that have been shot?");
		c [31] = new CardContents (true, "How many rappers can you name that have been to college?");
		c [32] = new CardContents (false, "Did you know: Hip-hop culture officially began on August 11th, 1973 at 1520 Sedwick Avenue in the South Bronx, New York City?");
		c [33] = new CardContents (false, "If you could not listen to hip-hop, what would you do? What would you listen to?");
		c [34] = new CardContents (false, "Which hip-hop artist reminds you most of yourself?");
		c [35] = new CardContents (false, "If you could BE one hip-hop artist, who would it be?");
		c [36] = new CardContents (false, "Imagine that your favorite artist is making a song about you, which positive words would you give to describe yourself to help them create the song?");
		c [37] = new CardContents (false, "Imagine that your favorite artist is making a song about you and is sitting in your living room asking you about yourself. What would you tell them about yourself?");

		c [38] = new CardContents (false, "Which Jay-Z line is a metaphor and which is a simile? “I’m the Mike Jordan of Rap”\n & “I keep one eye open like CBS”.");
		c [39] = new CardContents (false, "Is there anything about rap that you dislike?");
		c [41] = new CardContents (false, "Many rappers have created songs dedicated to their mothers. If you were to write about your mother, what would you say?");
		c [42] = new CardContents (false, "Many rappers have created songs about their fathers not being there for them. If you were to write about your father, what would you say?");
		c [43] = new CardContents (true, "In the song “Still Got Love For You” Jay Z raps about his relationships with his father. Describe how you feel about your father.");
		c [44] = new CardContents (true, "In the song “Cleaning Out My Closet” Eminem raps about his relationship with his mother. Describe how you feel about your relationship with your mother.");
		c [45] = new CardContents (true, "In the song “Stan” Eminem raps “…sometimes I even cut myself to see how much it bleeds/it's like adrenaline, the pain is such a sudden rush for me…” What does he mean in these lyrics? Has this ever happened to you or anyone you know? Explain. ");
		c [46] = new CardContents (false, "Did you know: Alliteration is when the beginning of word are repeated in neighboring words or at short intervals within a line or verse. Examples of this are “many men made more money than me” and “Peter Piper picked peppers.”");
		c [47] = new CardContents (false, "");

	
	
	
	}

	void Update ()
	{


		if (SwipeManager.Instance.Direction == SwipeDirection.Right && !isMoveLeft) {
			//n	Debug.Log ("I am in the if part here");
			isMoveRight = true;
			isRotate = false;
		 
		} else if (SwipeManager.Instance.Direction == SwipeDirection.Left && !isMoveRight) {
			//n	Debug.Log ("I am in the Else part here");

			isMoveLeft = true;
			isRotate = false;
		}

		if (isMoveRight && !isRotate) {
			//n	BlockPanel.SetActive (true);
			//	moveCardRight ();

			StartCoroutine (moveCardRight ());

		} else if (isMoveLeft && !isRotate) {
			//	moveCardLeft ();

			StartCoroutine (moveCardLeft ());



		}
	
		if (isRotate && !isFlipped) {
			RotateCardClockWise ();
		} else if (isRotate && isFlipped) {
				
			RotateCardAntiClockWise ();


		}
	
		if (isZoom) {
		
		
			StartCoroutine (ZoomEffect ());
		
		}
	
	
	
	}

	void OnEnable ()
	{
	
		isRestartWholegame = false;
	
	}

	IEnumerator  moveCardRight ()
	{
		
		// Move the card Slowly towards the right on the right Swipe.
		EventBlocker.GetComponent<EventSystem> ().enabled = false;
		yield return new WaitForEndOfFrame ();


		Card.transform.position = Vector3.Lerp (Card.transform.position, finalCardPositonRight, 0.005f); 

	
//n		Debug.Log ("original Conidtion" + Card.transform.position.x);
//n		Debug.Log ("Screen Width"+ Screen.width);

		if (Card.transform.position.x + Screen.width >= 1 * (Screen.width + 200f)) {

			isMoveLeft = false;		
			//	Debug.Log ("Resetting occuring");

			ResetCard ();
			//StartCoroutine (ResetCard ());
		}


	
	}

	IEnumerator moveCardLeft ()
	{

		//move Card Slowly towards the Left on Left Swipe
		EventBlocker.GetComponent<EventSystem> ().enabled = false;
		yield return new WaitForEndOfFrame ();



		Card.transform.position = Vector3.Lerp (Card.transform.position, finalCardPositionLeft, 0.005f); 


//		Debug.Log ("Screen Width is" + -1 * (Screen.width + Card.transform.position.x - 650f)); 
//		Debug.Log ("Card.transform.position.x + Screen.width" + 1 * (Card.transform.position.x + Screen.width));
		//n + Card.transform.position.x - 1000f
		//<= -1
		//+ Screen.width
		//if (1 * (Card.transform.position.x + Screen.width) <= -1 * (Screen.width + Card.transform.position.x - 650f))
		
		
		if (Card.transform.position.x + Screen.width <= 1 * (Screen.width - 200f)) {
			//Debug.Log ("Inside the Resetting condition for the left");
			isMoveLeft = false;

			ResetCard ();

			//	StartCoroutine (ResetCard ());
		}
	
	
	
	}





	void RotateCardClockWise ()
	{
		// rotate the card for the first time when clicked
//		Debug.Log ("Rotating the card clockwise XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
		Quaternion initRotation = Card.transform.rotation; 

		Card.transform.rotation *= Quaternion.Euler (0f, 5f, 0f);

		if (Card.transform.rotation == Quaternion.Euler (0f, 90f, 0f)) {
			Card.GetComponent<Image> ().sprite = EmptyCard.GetComponent<Image> ().sprite;
			//CardText.SetActive (true);
			LocalCard	= Instantiate (Cards [CardNumber]) as GameObject;

			LocalCard.transform.SetParent (Card.transform, false);
				


		}
		if (Card.transform.rotation == Quaternion.Euler (0f, 180f, 0f)) {
		
			isRotate = false;
			isFlipped = true; 
			isZoom = true; 
			//	StartCoroutine (ZoomEffect());

		}
	
	

	
	}

	IEnumerator ZoomEffect ()
	{
		// giving the card the zooming kind of effect on turning.
//		Debug.Log("IEnumerator ZoomEffect(){");
		yield return new WaitForEndOfFrame ();
		//	Debug.Log (Camera.main.orthographicSize*2.0*Screen.width/Screen.height);
		//	Debug.Log (Screen.width);
		//Debug.Log (Screen.height);



		Card.transform.localScale = Vector3.Lerp (LocalCard.transform.localScale, new Vector3 ((Camera.main.orthographicSize * 0.3f) * (Screen.width / Screen.height), Camera.main.orthographicSize * 0.31f * (Screen.width / Screen.height), 0f), 1f);
		yield return new WaitForSeconds (0.1f);
		isZoom = false;	
		if (Card.transform.localScale != new Vector3 (1f, 1f, 1f)) {
			//Debug.Log ("Inside of if *********************************************");
			//ZoomEffect ();
		} else {
			

		}

	}



	void RotateCardAntiClockWise ()
	{
		//Rotate the card for the second time once it has been flipped.

		//Debug.Log ("ending Drama Value is" +EndingDrama);

		Card.transform.rotation *= Quaternion.Euler (0f, -5f, 0f);
			

		if (Card.transform.rotation == Quaternion.Euler (0f, 90f, 0f)) {

			//CardText.SetActive (false);
			Destroy (LocalCard);
			Card.GetComponent<Image> ().sprite = cardBack;
			Card.transform.localScale = Vector3.Lerp (Card.transform.localScale, orignalScale, 1f);
		}
			
		if (Card.transform.rotation == Quaternion.Euler (0f, 0f, 0f)) {
			
			//	Debug.Log ("Resetting place found");
		
			isRotate = false;
			if (EndingDrama % 2 == 0)
				isMoveRight = true;
			else {


				isMoveLeft = true;
			
			}    

			isFlipped = false;

		}


	

	
	}

	public void CardClicked ()
	{
		//Debug.Log ("CardClicked****************************************************************");
		isRotate = true;
		if (firstDraw != 0 && isFlipped) {
			EndingDrama++; 	 	

		}


	
	}

	void ResetCard ()
	{
		CardNumber = showRandomCard ();

		//REsetting th card coordinates,rotation , and 
		//	yield return new WaitForSeconds (0.1f);
		Card.transform.rotation = initRotation;
		Card.transform.position = inititalCardPosition;	
		if (isFlipped) {
//			Debug.Log ("Reaching the inside of the if condition");
			Destroy (LocalCard);
			Card.GetComponent<Image> ().sprite = cardBack;
			isFlipped = false;

		}
		isZoom = false;	
		isRotate = false;
		isMoveRight = false;
		//n	BlockPanel.SetActive (false);
		Card.transform.localScale = Vector3.Lerp (Card.transform.localScale, orignalScale, 1f);
		EventBlocker.GetComponent<EventSystem> ().enabled = true;
	
		// Check if the cards have finished or not
		if (CardNumber == Cards.Length) {

			//Cards have finished now




		}
		isRestartWholegame = false;

	}


	public void ReStartGame ()
	{
		// restart the game sby setting the cardnumber;
		restartAudio.Play ();	
		openCards.Clear ();
		//Debug.Log (openCards.Count);
		firstDraw = 0;
	}

	public void RetartWholeGame ()
	{
		isRestartWholegame = true;
		SwipeManager.Instance.startSwipe = false;

		openCards.Clear ();
		//Debug.Log (openCards.Count);
		firstDraw = 0;
		ResetCard ();
		//	StartCoroutine (ResetCard ());
		if (PlayerPrefs.GetInt ("RemoveAds") != 2) {
			if (StartAppWrapperiOS.isAdReady ())
				StartAppWrapperiOS.showAd ();
			else
				StartAppWrapperiOS.loadAd ();
		}
	
	}

	int showRandomCard ()
	{    
		// for giving random values to the drawn card each time.......... 

		reAssign:
		int cardIndex = UnityEngine.Random.Range (0, Cards.Length);
		if (!openCards.Contains (cardIndex)) {
		
//			Debug.Log ("open Card Number is" + cardIndex);
			openCards.Add (cardIndex);
		
		}
		if (firstDraw != 0) {
			
			//Debug.Log ("Checking for Repitions ***************************");
			for (int i = 0; i < openCards.Count - 1; i++) {

				if (openCards [i] == cardIndex) {
					//	Debug.Log ("Duplicate Index found");
					goto reAssign; 			
			
			
			
				}


			}

		}

	
		//	Debug.Log ("Current Card number is"+ cardIndex);
	
		firstDraw++;
	
		return cardIndex;

	}


	public void OnPointerEnter ()
	{
		if (Card.transform.GetChild (0).gameObject.tag == "hasLink") {
			Debug.Log ("working inside");	

			//	Card.GetComponent<Button> ().enabled = false;
		
		}
	
	}

	public void OnPointerExit ()
	{
		Debug.Log ("OnPointerExit");
		if (Card.GetComponent<Button> ().enabled == false) {
			//	Card.GetComponent<Button> ().enabled = true;



		}
	}

	public void OnPointerUp ()
	{
		Debug.Log ("OnPointerUp");

	
	
	}



}
