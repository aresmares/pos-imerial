using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI; 
using UnityEngine;

public class Rewards2 : MonoBehaviour
{
    public float atGoal = 1.0f;
    public float atGoalScaleFactor = 2.0f;
    public float alignmentBonus =  0.001f;
    public float velocityAlignment =  0.001f;
    public float collisions = -0.1f;

    public float VelocityAlignmentReward(Vector3 target, Vector3 position)
    {
        return velocityAlignment * Vector3.Dot(target,position);
    }

    public float CollisionReward()
    {
        return collisions;
    }
    public float EmptyLot()
    {
        return atGoal;
    }
    public float EmptyLotGoal()
    {
        return atGoal * atGoalScaleFactor;
    }


    // FUZZY METHODS

    // public AnimationCurve fuzzyDistance; 

    public AnimationCurve fuzzyDistance_small; 
    public AnimationCurve fuzzyDistance_medium; 
    public AnimationCurve fuzzyDistance_large; 

    public AnimationCurve fuzzyAcceleration_stable; 
    public AnimationCurve fuzzyAlignment; 
    public AnimationCurve fuzzySpeed_small;
    public AnimationCurve fuzzySpeed_medium;


    public float fuzzyScaleFactor;

   

//    RULES:
        // RULE 1: IF distance is small  AND alignment is aligned THEN reward is large
        // RULE 2: IF distance is small  AND speed is small       THEN reward is large
        // RULE 3: IF distance is medium AND alignment is aligned THEN reward is small
    public float FuzzyEvaluate(GameObject agent, GameObject goalPosition)
    {  
        float distance = Vector3.Distance(transform.position, goalPosition.transform.position);
        float acceleration = GetComponent<CarController>().CurrentAcceleration;
        Vector3 velocity = agent.GetComponent<Rigidbody>().velocity;
        float speed = Mathf.Sqrt(velocity[0]*velocity[0] + velocity[2]*velocity[2]);
        float alignment = agent.transform.eulerAngles.y / 360;

        // Evaluate RULE 1:
        float rule1 = fuzzyDistance_small.Evaluate(distance) * fuzzyAlignment.Evaluate(alignment);
        // Debug.Log(distance);

        // Evaluate RULE 2:
        float rule2 = fuzzyDistance_small.Evaluate(distance) * fuzzySpeed_small.Evaluate(speed);

        //Evaluate RULE 3:
        float rule4 = fuzzyDistance_medium.Evaluate(distance) * fuzzyAlignment.Evaluate(alignment);

        // Debug.Log(rule1 + " : " + rule2 + " : " +rule3) ;

        // Defuzzification - Mean Max Membership
        float reward = (rule1 + rule2 + rule4 )/3;
        // Debug.Log(reward);
 
        return reward * fuzzyScaleFactor;
    }
                

}
