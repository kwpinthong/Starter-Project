using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;

public class PlayerIdle : MonoBehaviour
{
    public NavMeshAgent NavMeshAgent;
    public Transform PointA;
    public Transform PointB;
    public WorkingTable WorkingTable;
    public bool IsWorking = false;
    public float WorkingTime = 0;
    public bool IsWalking = false;
    public bool IsAtPointA = false;
    public bool IsAtPointB = false;

    private void Start()
    {
        NavMeshAgent.updateUpAxis = false;
        NavMeshAgent.updateRotation = false;
    }

    void Update()
    {
        if (!IsWorking)
        {
            IsWorking = true;
            NavMeshAgent.SetDestination(WorkingTable.StayPosition.position);
        }
        else
        {
            IsWalking = NavMeshAgent.remainingDistance > 0;

            if (IsWalking == false)
            {
                if (IsAtPointB)
                {
                    IsAtPointB = false;
                    IsWorking = false;
                    WorkingTime = 0f;
                }
                else
                {
                    WorkingTime += Time.deltaTime;

                    if (WorkingTime >= 3f)
                    {
                        IsAtPointB = true;
                        NavMeshAgent.SetDestination(PointB.position);
                    }
                }
            }
        }

        //IsWalking = NavMeshAgent.remainingDistance > 0;

        //if (IsWalking == false)
        //{
        //    if (IsAtPointA == false)
        //    {
        //        IsWalking = true;
        //        IsAtPointA = true;
        //        IsAtPointB = false;
        //        NavMeshAgent.SetDestination(PointA.position);
        //    }
        //    else if (IsAtPointB == false)
        //    {
        //        IsWalking = true;
        //        IsAtPointA = false;
        //        IsAtPointB = true;
        //        NavMeshAgent.SetDestination(PointB.position);
        //    }
        //}
    }
}
