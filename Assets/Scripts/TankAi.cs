using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class TankAi : MonoBehaviour
{

    private GameObject player;
    private Animator animator;
    private Ray ray; // 안보이는선
    private RaycastHit hit; // 선에 맞은애
    private float maxDistanceToCheck = 6.0f; //감지할수있는 최장 거리
    private float currentDistance; // current 현재 Distance 거리
    private Vector3 CheckDirection; // 좌표값
    public Transform pointA;
    public Transform pointB;
    public NavMeshAgent navMeshAgent;// navMeshAgent 사용하기 위해서 using UnityEngine.AI;를 입력한다.
    private int currentTarget; // current 현재 타겟
    private float distanceFromTarget; //타겟과의 거리
    private Transform[] watpionts = null; // [] 배열로 선언했다

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");//player를 찾아준다
        animator = gameObject.GetComponent<Animator>();//탱크에 animator를 달아준다
        pointA = GameObject.Find("p1").transform;// p1와 p2 를 찾아서 transform 을 넣어준다
        pointB = GameObject.Find("p2").transform;
        navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
        watpionts = new Transform[2]{pointA,pointB};

        

        currentTarget = 0;
        navMeshAgent.SetDestination(watpionts[currentTarget].position);

    }
    private void FixedUpdate()
    {
        currentDistance = Vector3.Distance(player.transform.position, transform.position);
        animator.SetFloat("distanceFromePalyer", currentDistance);
        CheckDirection = player.transform.position - transform.position;
        ray = new Ray(transform.position, CheckDirection);
        if (Physics.Raycast(ray, out hit, maxDistanceToCheck))
        {
            if (hit.collider.gameObject == player)
            {
                animator.SetBool("isPlayervisivble", true);
            }
            else
            {
                animator.SetBool("isPlayervisivble", false);
            }
        }
        else
        {
            animator.SetBool("isPlayervisivble", false);
        }
        distanceFromTarget = Vector3.Distance(watpionts[currentTarget].position, transform.position);
        animator.SetFloat("distanceFromWaypoint", distanceFromTarget);
    }
    public void SetNextPoint()
    {
        switch (currentTarget)
        {
            case 0:
                currentTarget = 1;
                break;
            case 1:
                currentTarget = 0;
                break;
        }
        navMeshAgent.SetDestination(watpionts[currentTarget].position);
    }
}

