using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour {
    //sheep velocity
    public float velocity = 0.1f;
    //how quickly the sheep change direction
    float rotation_speed = 4.0f;
    //average direction the sheep are heading in
    Vector3 average_direction;
    Vector3 average_position;
    //if sheep are more than this apart, they will not flock
    float neighbourDistance = 3.0f;

    Vector3 all_zero = new Vector3(0,0,0);

    //is the sheep turning? yes = true
    bool turning = false;

	// Use this for initialization
	void Start () {
        //so the sheep move differently
        velocity = Random.Range(0.5f, 1);
	}
	
	// Update is called once per frame
	void Update () {

        //make the sheep turn if they reach the edge of the plane
        if (Vector3.Distance(transform.position, Vector3.zero) >= 7)
        {

            turning = true;
        }
        else
            turning = false;

        if (turning)
        {
            Vector3 direction = all_zero - transform.position;
            transform.rotation = Quaternion.Slerp(transform.rotation,
                                Quaternion.LookRotation(direction),
                                rotation_speed * Time.deltaTime);
            velocity = Random.Range(0.5f, 1);

        }
        else
        {
            if (Random.Range(0, 5) < 1)
                ApplyLaws();
        }

        transform.Translate(0, 0, Time.deltaTime * velocity);
        
	}

    void ApplyLaws() {

        GameObject[] gos;
        gos = FlockYou.allSheep;

        Vector3 vcentre = all_zero;
        Vector3 vavoid = all_zero;
        float gSpeed = 0.1f;

        Vector3 goalPos = FlockYou.goal_position;
        float dist;

        int groupSize = 0;

        foreach (GameObject go in gos)
        {
            if (go != this.gameObject)
            {
                dist = Vector3.Distance(go.transform.position, this.transform.position);

                if (dist <= neighbourDistance)
                {
                    vcentre += go.transform.position;
                    groupSize++;

                    if (dist < 1.0f)
                    {
                        vavoid = vavoid + (this.transform.position - go.transform.position);

                    }

                    Flock anotherFlock = go.GetComponent<Flock>();
                    gSpeed = gSpeed + anotherFlock.velocity;

                }

            }

        }


        if (groupSize > 0)
        {
            vcentre = vcentre / groupSize + (goalPos - this.transform.position);
            velocity = gSpeed / groupSize;

            Vector3 direction = (vcentre + vavoid) - transform.position;
            if (direction != Vector3.zero)
                transform.rotation = Quaternion.Slerp(transform.rotation,
                                                       Quaternion.LookRotation(direction),
                                                       rotation_speed * Time.deltaTime);

        }

    }


}
