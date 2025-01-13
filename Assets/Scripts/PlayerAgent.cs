using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;

public class PlayerAgent : Agent
{
    [SerializeField] private GameObject goalPrefab;
    [SerializeField] private Material winMaterial;
    [SerializeField] private Material loseMaterial;
    [SerializeField] private MeshRenderer floorMeshRenderer;
    [SerializeField] private Transform environmentTransform;

    private Rigidbody rb;
    private List<GameObject> activeGoals = new List<GameObject>();
    private const int goalCount = 3; 
    private int goalHitCount = 0;

    public override void Initialize()
    {
        rb = GetComponent<Rigidbody>();
        environmentTransform = transform.parent;
    }

    public override void OnEpisodeBegin()
    {
        ResetAgentAndGoals();
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        
        sensor.AddObservation(transform.localPosition);

        
        foreach (var goal in activeGoals)
        {
            sensor.AddObservation(goal.transform.localPosition);
        }
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        float moveX = actions.ContinuousActions[0];
        float moveZ = actions.ContinuousActions[1];

        float moveSpeed = 5f;
        rb.MovePosition(transform.position + transform.forward * moveZ * moveSpeed * Time.deltaTime);
        transform.Rotate(0f, moveX * moveSpeed, 0f, Space.Self);
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        ActionSegment<float> continuousActions = actionsOut.ContinuousActions;
        continuousActions[0] = Input.GetAxisRaw("Horizontal");
        continuousActions[1] = Input.GetAxisRaw("Vertical");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Goal>(out Goal goal))
        {
            SetReward(1f);
            floorMeshRenderer.material = winMaterial;

            
            Destroy(goal.gameObject);
            activeGoals.Remove(goal.gameObject);

            goalHitCount++;

            
            if (goalHitCount == goalCount)
            {
                ResetAgentAndGoals(); 
            }
        }

        if (other.TryGetComponent<Wall>(out Wall wall))
        {
            SetReward(-1f);
            floorMeshRenderer.material = loseMaterial;
            EndEpisode();
        }
    }

    private void ResetAgentAndGoals()
    {
        
        transform.localPosition = new Vector3(Random.Range(-8f, 8f), 0, Random.Range(-8f, 8f));
        transform.rotation = Quaternion.identity;

        
        foreach (var goal in activeGoals)
        {
            Destroy(goal);
        }
        activeGoals.Clear();

        
        for (int i = 0; i < goalCount; i++)
        {
            SpawnGoal();
        }

        
        goalHitCount = 0;
    }

    private void SpawnGoal()
    {
        
        Vector3 randomLocalPosition = new Vector3(Random.Range(-8f, 8f), 0, Random.Range(-8f, 8f));
        GameObject newGoal = Instantiate(goalPrefab, environmentTransform);
        newGoal.transform.localPosition = randomLocalPosition;
        activeGoals.Add(newGoal);
    }
}

