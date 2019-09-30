using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour {

	[SerializeField]
	private GameObject spawnPosition;

	[SerializeField]
	private GameObject enemy;

	[SerializeField]
	private int numberOfEnemy = 3;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

	private void OnCollisionEnter2D(Collision2D collision){
		// turn off collider so player can go through object
		GetComponent<CapsuleCollider2D> ().enabled = false;

		StartCoroutine (SpawnEnemies ());
	}

	private IEnumerator SpawnEnemies(){
		while (numberOfEnemy > 0) {
			Instantiate (enemy, spawnPosition.transform.position, Quaternion.identity);
			numberOfEnemy--;
			yield return new WaitForSeconds(2);
		}
	}
}
