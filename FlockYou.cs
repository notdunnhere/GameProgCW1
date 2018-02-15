using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockYou : MonoBehaviour {

    //prefab of sheep
    public GameObject sheep_prefab;
    //prefab of goal
	public GameObject goal_prefab;
    //number of sheep
    static int num_sheep = 5;
    //array of sheep
    public static GameObject[] sheep_array = new GameObject[num_sheep];
    //position of goal
	public static Vector3 goal_position = new Vector3(0,0,0);

	// Use this for initialization
	void Start () {

        //set position of sheep to a random position (but y position is always y - don't want any floating sheep!)
        for (int s = 0; s < num_sheep; s++) {
            Vector3 pos = new Vector3(Random.Range(-7, 7),
                                      Random.Range(0, 0),
                                       Random.Range(-7, 7));
            
            sheep_array[i] = (GameObject)Instantiate(sheep_prefab, pos, Quaternion.identity);
            
        }
	}
	
	// Update is called once per frame
	void Update () {

		if (Random.Range (0, 100000) < 50) {
		//change the position of the goal randomly
			goal_position = new Vector3 (Random.Range (-7, 7),
			                        	Random.Range (0, 0),
				                        Random.Range (-7, 7));	
		
			goal_prefab.transform.position = goal_position;
		
		}
	}
}
