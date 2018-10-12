using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TouchInputH : MonoBehaviour {


	public LayerMask touchInputMask;
	private List<GameObject> touchList=new List<GameObject> ();
	private GameObject[]touchesOld;
	 
	// Update is called once per frame
	void Update () {

		if (Input.touchCount > 0) {
				
		
			touchesOld=new GameObject[touchList.Count];
	
						foreach (Touch touch in Input.touches) {
								Ray ray = camera.ScreenPointToRay (touch.position);
								RaycastHit hit;

								if (Physics.Raycast (ray, out hit, touchInputMask)) {

										if (touch.phase == TouchPhase.Began) {


										}
										if (touch.phase == TouchPhase.Ended) {


										}
										if (touch.phase == TouchPhase.Stationary) {
					
					
										}

										if (touch.phase == TouchPhase.Canceled) {
					
					
										}

								}
		
						}
				}

	}
}
