using UnityEngine;
using System.Collections;
namespace CompleteProject{
public class myHealthSpawn : MonoBehaviour {
		public GameObject Health;
		//public PlayerHealth playerHealth;
		//public EnemyHealth enemyHealth;
		public GameObject zombunny;
		int checks=0;
		//public GameObject SpawnPoint;
		//public GameObject Hellepant;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
			//if (enemyHealth.currentHealth <= 0) {
			if(zombunny.GetComponentInChildren<EnemyHealth>().currentHealth<=0){
			while(checks==0){
				SpawnHealth();
					checks++;
				}
			
			}
	}
		void SpawnHealth(){

			Instantiate (Health,transform.position,transform.rotation);
		}
}

}