using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class FollowWhenCollide01 : MonoBehaviour
{
    
    public GameObject Target;
    public float Distance;

    void Update()    //update
    {
        
        Distance = Vector2.Distance(transform.position, Target.transform.position);

        if (Distance < 3)
        {

            if (Distance >= 2)
            {
                transform.position = Vector2.MoveTowards(transform.position, Target.transform.position, 70 * Time.deltaTime);

            }
        }
        
    }

}
