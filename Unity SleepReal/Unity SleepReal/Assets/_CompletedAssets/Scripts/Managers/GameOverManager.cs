using UnityEngine;
using System.Collections;
namespace CompleteProject
{
    public class GameOverManager : MonoBehaviour
    {
        public PlayerHealth playerHealth;       // Reference to the player's health.

	
	 
        Animator anim;                          // Reference to the animator component.
		Renderer rend;

        void Awake ()
        {
            // Set up the reference.
			anim = GetComponent <Animator> ();  
        }


        void Update ()
        {
            // If the player has run out of health...
            if(playerHealth.currentHealth <= 0)
            {
			
				// WaitForSeconds (10);
				//Application.LoadLevel(1);
				StartCoroutine(LoadLevelAfterDelay());
            }
        }
	IEnumerator LoadLevelAfterDelay()
		{
			yield return new WaitForSeconds(3f);
//			Application.LoadLevel(1);
			Application.LoadLevel (Application.loadedLevel);
		}
    }
}