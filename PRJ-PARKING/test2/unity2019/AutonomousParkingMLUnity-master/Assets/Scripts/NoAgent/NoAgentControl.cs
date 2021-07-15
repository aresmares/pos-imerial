using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NoAgentControl : MonoBehaviour
{
    public GameObject endPosition;
    private NavMeshAgent navAgent;
    public GameObject agent;

    // Start is called before the first frame update
    void Start()
    {
        navAgent = this.GetComponent<NavMeshAgent>();
        // agent = this.GetComponent<AutoParkAgent>();

    }

    // Update is called once per frame
    void Update()
    {
        // endPosition = GameObject.FindGameObjectWithTag("Finish");
        navAgent.SetDestination(new Vector3(-2.4f,0, endPosition.transform.position.z+1.5f ));
        // Debug.Log(navAgent.remainingDistance);

        if (navAgent.remainingDistance < 0.6f && navAgent.remainingDistance != 0)
        {

            agent.transform.position = this.gameObject.transform.position;
            agent.GetComponent<Rigidbody>().velocity = Vector3.zero;
            agent.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            agent.GetComponent<CarController>().CurrentSteeringAngle = 0f;
            agent.GetComponent<CarController>().CurrentAcceleration = 0f;
            agent.GetComponent<CarController>().CurrentBrakeTorque = 0f;
            agent.transform.rotation = Quaternion.Euler(0,180,0);

            
            // agent.transform.position = this.gameObject.transform.position;
            // agent.GetComponent<Rigidbody>().velocity =        this.gameObject.GetComponent<Rigidbody>().velocity;
            // agent.GetComponent<Rigidbody>().angularVelocity = this.gameObject.GetComponent<Rigidbody>().angularVelocity;
            // agent.GetComponent<CarController>().CurrentSteeringAngle =  this.gameObject.GetComponent<CarController>().CurrentSteeringAngle;
            // agent.GetComponent<CarController>().CurrentAcceleration =   this.gameObject.GetComponent<CarController>().CurrentAcceleration;
            // agent.GetComponent<CarController>().CurrentBrakeTorque =    this.gameObject.GetComponent<CarController>().CurrentBrakeTorque;
            // agent.transform.rotation = this.gameObject.transform.rotation;

            Destroy(this.gameObject);
        }
    }
}
