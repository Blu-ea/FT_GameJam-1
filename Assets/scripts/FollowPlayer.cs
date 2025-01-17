using System;
using Unity.Mathematics.Geometry;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    
    [SerializeField] private float speed = 1.5f;
    
    private GameObject player;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        Vector3 target = player.transform.transform.position;
        target.y = 0.5f;
        float distance = MathF.Abs(Vector3.Distance(target, transform.position));
        if (distance > player.transform.localScale.x)
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }
}
