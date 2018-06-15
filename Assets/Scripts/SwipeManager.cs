using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum SwipeDirection
{

	None = 0,
	Left = 1,
	Right = 2,
	Up = 4,
	Down = 8,
}

public class SwipeManager : MonoBehaviour
{
	public SwipeDirection Direction{ set; get; }

	private static SwipeManager instance;

	public static SwipeManager Instance{ get { return instance; } }
	//public Text text;
	public bool startSwipe = false;
	private Vector3 touchPosition;

	private float swipeResistanceX = 150.0f;
	private float swipeResistanceY = 100;
	[SerializeField]
	AudioSource passAudio;


	private void Start ()
	{

		instance = this;


	}

	private void Update ()
	{
		if (!startSwipe)
			return;

		if (GameManager.isRotate)
			return;
		Direction = SwipeDirection.None;


		if (Input.GetMouseButtonDown (0)) {
			touchPosition = Input.mousePosition;



		}
		if (Input.GetMouseButtonUp (0)) {

			Vector2 deltaSwipe = touchPosition - Input.mousePosition;
			if (Mathf.Abs (deltaSwipe.x) > swipeResistanceX) {

				// swipe

				Direction |= (deltaSwipe.x < 0) ? SwipeDirection.Right : SwipeDirection.Left;
				if (!GameManager.isRestartWholegame && startSwipe)
					passAudio.Play ();
//				Debug.Log (Direction);
				//text.text = Direction.ToString ();
			}

			if (Mathf.Abs (deltaSwipe.y) > swipeResistanceY) {

				// swipe
				Direction |= (deltaSwipe.y < 0) ? SwipeDirection.Up : SwipeDirection.Down;
//				Debug.Log (Direction);
				//text.text = Direction.ToString ();
			}

		}
	}

}
