using UnityEngine;
using System.Collections;
namespace CompleteProject
{
    public class GameOverManager : MonoBehaviour
    {
        public PlayerHealth playerHealth;       // Reference to the player's health.
		//11
		public float restartDelay = 5f;         // Time to wait before restarting the level
	
	 
        Animator anim;                          // Reference to the animator component.
		//11
		float restartTimer;                     // Timer to count up to restarting the level
		Renderer rend;

        void Awake ()
        {
            // Set up the reference.
			anim = GetComponent <Animator> ();  
        }


        void Update ()
        {
			//11
			if (playerHealth.currentHealth <= 0) {

								// ... tell the animator the game is over.
								anim.SetTrigger ("GameOver");
			
								// .. increment a timer to count up to restarting.
								restartTimer += Time.deltaTime;
			
								// .. if it reaches the restart delay...
								if (restartTimer >= restartDelay) {
										// .. then reload the currently loaded level.
										Application.LoadLevel(Application.loadedLevel);
								}
						}
			//11
            // If the player has run out of health...
           /* if(playerHealth.currentHealth <= 0)
            {
			
				// WaitForSeconds (10);
				//Application.LoadLevel(1);
				StartCoroutine(LoadLevelAfterDelay());
            }
            */
        }
	/*IEnumerator LoadLevelAfterDelay()
		{
			yield return new WaitForSeconds(3f);
//			Application.LoadLevel(1);
			Application.LoadLevel (Application.loadedLevel);
		}
		*/
    }
}