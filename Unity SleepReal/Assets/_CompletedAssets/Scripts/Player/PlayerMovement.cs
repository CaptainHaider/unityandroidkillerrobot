using UnityEngine;
using UnitySampleAssets.CrossPlatformInput;

namespace CompleteProject
{
    public class PlayerMovement : MonoBehaviour
    {
		//11
		//public Joystick j1;
		//11
        public float speed = 6f;            // The speed that the player will move at.
         Vector3 movement;                   // The vector to store the direction of the player's movement.
        Animator anim;                      // Reference to the animator component.
        Rigidbody playerRigidbody;          // Reference to the player's rigidbody.
#if !MOBILE_INPUT
        int floorMask;                      // A layer mask so that a ray can be cast just at gameobjects on the floor layer.
        float camRayLength = 100f;          // The length of the ray from the camera into the scene.
#endif
		//55 bhai jub bi mobile par run karna ki koishi ka is ko open kardena
 int floorMask;                      // A layer mask so that a ray can be cast just at gameobjects on the floor layer.
	float camRayLength = 100f;          // The length of the ray from the camera into the scene.
		//55
        void Awake ()
        {
#if !MOBILE_INPUT
            // Create a layer mask for the floor layer.
            floorMask = LayerMask.GetMask ("Floor");
#endif

            // Set up references.
            anim = GetComponent <Animator> ();
            playerRigidbody = GetComponent <Rigidbody> ();
			//55
			floorMask = LayerMask.GetMask ("Floor");
			//55
        }


        void FixedUpdate ()
        {
            // Store the input axes.
			// float h = Input.acceleration.x;
			// float v = Input.acceleration.y;
             
			//Joystick.position.x=CrossPlatformInputManager.GetAxisRaw("Horizontal");;
			 float h = CrossPlatformInputManager.GetAxisRaw("Horizontal");
			 float v = CrossPlatformInputManager.GetAxisRaw("Vertical");

		//	 bool fire = Input.GetButton ("Fire1");
		//	 anim.SetBool ("shoot", fire);


            // Move the player around the scene.
            Move (h, v);

            // Turn the player to face the mouse cursor.
			//22
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if ((Physics.Raycast (ray, out hit))) {
								//	if(Physics.Raycast(ray,hit)){
								if (hit.collider.tag != "ignorey") {
										//Debug.Log ("it hot");
										Turning ();
					bool fire = Input.GetButton ("Fire1");
						 anim.SetBool ("shoot", fire);

								}
						}

			//22
           

            // Animate the player.
            Animating (h, v);
        }


      public  void Move (float h, float v)
        {
			//speed = 6f;
            // Set the movement vector based on the axis input.
			int hh =(int)Mathf.Floor( h);
			int vv =(int)Mathf.Floor( v);
			movement.Set (hh, 0f, vv);

			
            // Normalise the movement vector and make it proportional to the speed per second.
            movement = movement.normalized * speed * Time.deltaTime;

            // Move the player to it's current position plus the movement.
            playerRigidbody.MovePosition (transform.position + movement);
        }
		public	void Animating (float h, float v)
		{
			// Create a boolean that is true if either of the input axes is non-zero.
			bool walking = h != 0f || v != 0f;
			
			// Tell the animator whether or not the player is walking.
			anim.SetBool ("IsWalking", walking);
			
			
		}

        void Turning ()
        {
#if !MOBILE_INPUT
						// Create a ray from the mouse cursor on screen in the direction of the camera.
			 
						  Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);
						//11
					/*	if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began) {
								Ray camRay = Camera.main.ScreenPointToRay (Input.GetTouch (0).position);
								//11
								*/
								// Create a RaycastHit variable to store information about what was hit by the ray.
								RaycastHit floorHit;

								// Perform the raycast and if it hits something on the floor layer...
			if ((Physics.Raycast (camRay, out floorHit, camRayLength, floorMask))) {
				// Create a vector from the player to the point on the floor the raycast from the mouse hit.
										Vector3 playerToMouse = floorHit.point - transform.position;

										// Ensure the vector is entirely along the floor plane.
										playerToMouse.y = 0f;

										// Create a quaternion (rotation) based on looking down the vector from the player to the mouse.
										Quaternion newRotatation = Quaternion.LookRotation (playerToMouse);

										// Set the player's rotation to this new rotation.
										playerRigidbody.MoveRotation (newRotatation);
				}
			//				 
#else
			/*	 
					 Vector3 turnDir = new Vector3(CrossPlatformInputManager.GetAxisRaw("Mouse X") , 0f , CrossPlatformInputManager.GetAxisRaw("Mouse Y"));

          if (turnDir != Vector3.zero)
            {
                // Create a vector from the player to the point on the floor the raycast from the mouse hit.
                Vector3 playerToMouse = (transform.position + turnDir) - transform.position;

                // Ensure the vector is entirely along the floor plane.
                playerToMouse.y = 0f;

                // Create a quaternion (rotation) based on looking down the vector from the player to the mouse.
                Quaternion newRotatation = Quaternion.LookRotation(playerToMouse);

                // Set the player's rotation to this new rotation.
                playerRigidbody.MoveRotation(newRotatation);
            }
 */
	 
		//55
		// Create a ray from the mouse cursor on screen in the direction of the camera.
		
		Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);
		//11
			//if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began) {
							//	Ray camRay = Camera.main.ScreenPointToRay (Input.GetTouch (0).position);
								//11
								
		// Create a RaycastHit variable to store information about what was hit by the ray.
		RaycastHit floorHit;
		
		// Perform the raycast and if it hits something on the floor layer...
		if ((Physics.Raycast (camRay, out floorHit, camRayLength, floorMask))) {
			// Create a vector from the player to the point on the floor the raycast from the mouse hit.
			Vector3 playerToMouse = floorHit.point - transform.position;
			
			// Ensure the vector is entirely along the floor plane.
			playerToMouse.y = 0f;
			
			// Create a quaternion (rotation) based on looking down the vector from the player to the mouse.
			Quaternion newRotatation = Quaternion.LookRotation (playerToMouse);
			
			// Set the player's rotation to this new rotation.
			playerRigidbody.MoveRotation (newRotatation);
		}
		}

		//55
		 
#endif
						
		//11//}


        
    }
}

//}//mobile par run karna sa phela is ko off kardena