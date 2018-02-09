using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityFlock : MonoBehaviour {

    public float minSpeed = 20.0f;
    public float turnSpeed = 20.0f;
    public float randomFreq = 20.0f;
    public float randomForce = 20.0f;
    public float toOriginForce = 50.0f;
    public float toOriginRange = 100.0f;
    public float gravity = 2.0f;
    public float avoidanceRadius = 50.0f;
    public float avoidanceForce = 20.0f;
    public float followVelocity = 4.0f;
    public float followRadius = 40.0f;

    private Transform origin;
    private Vector3 velocity;
    private Vector3 normalizedVelocity;
    private Vector3 randomPush;
    private Vector3 originPush;
    private Transform[] objects;
    private UnityFlock[] otherFlocks;
    private Transform transformComponet;
    void Start()
    {
        randomFreq = 1.0f / randomFreq;
        origin = transform.parent;
        transformComponet = transform;
        Component[] tempFlaocks = null;

        if (transform.parent)
        {
            tempFlaocks = transform.parent.GetComponentsInChildren<UnityFlock>();
        }

        objects = new Transform[tempFlaocks.Length];
        otherFlocks = new UnityFlock[tempFlaocks.Length];

        for (int i = 0; i < tempFlaocks.Length; i++)
        {
            objects[i] = tempFlaocks[i].transform;
            otherFlocks[i] = (UnityFlock)tempFlaocks[i];
        }
        transform.parent = null;

        StartCoroutine(UpdateRandom());
    }
    IEnumerator UpdateRandom()
    {
        while (true)
        {
            randomPush = Random.insideUnitSphere * randomForce;
            yield return new WaitForSeconds(randomFreq + Random.Range(-randomFreq / 2.0f, randomFreq / 2.0f));
        }
    }


    void Update()
    {
        float speed = velocity.magnitude;
        Vector3 avgVelocity = Vector3.zero;
        Vector3 avgPosition = Vector3.zero;
        float count = 0;
        float f = 0.0f;
        float d = 0.0f;
        Vector3 myPosition = transformComponet.position;
        Vector3 forceV;
        Vector3 toAvg;
        Vector3 wantedVel;

        for (int i = 0; i < objects.Length; i++)
        {
            Transform transform = objects[i];
            if (transform != transformComponet)
            {
                Vector3 otherPosition = transform.position;
                avgPosition += otherPosition;
                count++;
                forceV = myPosition - otherPosition;
                d = forceV.magnitude;
                if (d < followRadius)
                {
                    f = 1.0f - (d / avoidanceRadius);
                    if (d > 0) avgVelocity += (forceV / d) * f * avoidanceForce;
                }
                f = d / followRadius;
                UnityFlock otherSealgull = otherFlocks[i];
                avgVelocity += otherSealgull.normalizedVelocity * f * followVelocity;

                if (count > 0)
                {
                    avgVelocity /= count;
                    toAvg = (avgPosition / count) - myPosition;
                }
                else
                {
                    toAvg = Vector3.zero;
                }
                forceV = origin.position - myPosition;
                d = forceV.magnitude;
                f = d / toOriginRange;
                if (d > 0)
                    originPush = (forceV / d) * f * toOriginForce;
                if(speed < minSpeed && speed > 0)
                {
                    velocity = (velocity / speed) * minSpeed;
                }
                wantedVel = velocity;

                wantedVel -= wantedVel * Time.deltaTime;
                wantedVel += randomPush * Time.deltaTime;
                wantedVel += originPush * Time.deltaTime;
                wantedVel += avgVelocity * Time.deltaTime;
                wantedVel += toAvg.normalized * Time.deltaTime;

                velocity = Vector3.RotateTowards(velocity, wantedVel, turnSpeed * Time.deltaTime, 100.00f);

                transformComponet.rotation = Quaternion.LookRotation(velocity);
                transformComponet.Translate(velocity * Time.deltaTime, Space.World);
                normalizedVelocity = velocity.normalized;
            }
        }
    }           
}
