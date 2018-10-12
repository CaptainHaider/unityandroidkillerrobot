using UnityEngine;
namespace CompleteProject
{
public class dieColor : MonoBehaviour {
	public PlayerHealth playerHealth ;  
	public Material material;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		 if (playerHealth.currentHealth <= 0) {
								material.color = Color.red;
		
						} else
								material.color = Color.blue;
	}
}
}