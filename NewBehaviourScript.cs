using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

	//physics and movemnt
	Vector3 velocity;
	Vector3 gravity = new Vector3(0, -9.81f, 0);

	static int num_particles = 275;
	public GameObject[] particles;
 	public bool alive;

	Vector3[] velocity1 = new Vector3[num_particles];		 
	GameObject particleObject;
	public int death_timer;



	// Use this for initialization
	void Start () 
	{
        //set timer to 0 at the start of the simulation
		death_timer = 0;
        //array of particles
		particles = new GameObject[num_particles];

        for (int p = 0; p < num_particles; p++)
        {
            particleObject = Instantiate(Resources.Load ("Particapsule")) as GameObject;
            //all particles explode from the same point
			particleObject.transform.position = new Vector3(0,0,0);

			particles[p] = particleObject;
			
			velocity1[p] = new Vector3(Random.Range(-150.0f, 155.0f),Random.Range(-150.0f, 150.0f),Random.Range(-150.0f, 150.0f));
			
            
        }
	}
	
	void Update () {
		//empty
	}


	void FixedUpdate(){
		
		//if particles are alive
		if (alive){
            //increase timer
			death_timer++;
			for(int p=0; p < num_particles; p++){
						
					velocity1[p] = velocity1[p] + gravity * Time.fixedDeltaTime;
					particles[i].transform.Translate(velocity1[i] * Time.fixedDeltaTime);


			}
		}

        //delete all particles when timer = 80
		if (death_timer == 80){
			alive = false;
			for(int p=0; p < num_particles; p++){
				Destroy(particles[p]);
			}
		}

	}
}