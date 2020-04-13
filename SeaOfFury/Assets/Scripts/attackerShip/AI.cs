using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    //The look radius is how far away the AI ships notice the player.
    public float lookRadius = 10f;
    //The transform of the target is used to get the distance between the ships
    //and to move the AI towards the player.
    Transform target;

    // Start is called before the first frame update.
    void Start()
    {
        //The target is set to the transform of the player ship.
        target = playerManager.instance.player.transform;
    }


    // Update is called once per frame
    void Update()
    {
        //The distance is worked out between the enemy ship and player ship.
        float distance = Vector3.Distance(target.position, transform.position);

        //If the distance is less than the look radius and bigger than 3.
        //3 is the stopping stopping distance.
        if (distance <= lookRadius && distance > 3)
        {
            //The direction the enemy has to go in is calculated.
            Vector3 direction = transform.position + target.position;
            //The enemy ship will then face toward the player ship.
            transform.LookAt(target);
            //The enmy ships is then moved towards the player ship.
            transform.Translate(direction * 0.01f * Time.deltaTime);
        }
        
    }
}
