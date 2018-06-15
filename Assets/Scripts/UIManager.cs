using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

	public static bool canPressEscape = false;
	public GameObject[] GameScreens;




	void Awake ()
	{
		

	
	}

	void Start ()
	{
		
	
	
	
	}

	void Update ()
	{
		if (canPressEscape) {
		
			if (Input.GetKeyDown (KeyCode.Escape)) {
			
				for (int i = 0; i < GameScreens.Length; i++) {
					if (GameScreens [i].activeSelf) {
						GameScreens [i].SetActive (false);
						GameScreens [0].SetActive (true);
						canPressEscape = false;
					}

				}
			
			
			
			}
		
		
		
		}	
	
	
	}


	#region Buttons

	public void Play ()
	{
		StartCoroutine (BeginGame ());
	
	}


	IEnumerator BeginGame ()
	{
		yield return new WaitForSeconds (0.01f);
		SwipeManager.Instance.startSwipe = true;

	
	}

	public void HomeButton ()
	{
	
		canPressEscape = true;
	
	}

	public void AboutButton ()
	{
	
		canPressEscape = true;
	
	}

	public void RestartButton ()
	{
	

	}

	#endregion





}
