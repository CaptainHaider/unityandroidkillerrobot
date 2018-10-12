using UnityEngine;
using System.Collections;
namespace CompleteProject{
public class myHealthTest : MonoBehaviour {
	public PlayerHealth playerHealth;
		//GameObject gameobj;
	// Use this for initialization
	void Start () {
			//GetComponentInChildren<EnemyHealth>()
			//gameobj= GameObject.Find("office drone003");
			//PlayerHealth = GetComponentsInChildren<playerHealth> ();
 
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag=="Player"){
				//PlayerHealth = other.gameObject.GetComponentsInChildren<playerHealth> ();
				//	other.GetComponentInChildren<playerHealth>().AddHealth(10);
			playerHealth.AddHealth(10);
			Destroy(gameObject);
		}

	}	

}

}