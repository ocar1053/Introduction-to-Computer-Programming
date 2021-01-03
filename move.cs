using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public Transform pos1, pos2; //平台來回移動的兩點
    public float speed; //平台移動的速度
    public Transform starpos; //平台第一次移動的點


    Vector3 nextPosion;
    // Start is called before the first frame update
    void Start()
    {
        nextPosion = starpos.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == pos1.position) //到點1後移到點2
        {
            nextPosion = pos2.position;
        }
        if (transform.position == pos2.position) //到點2後移到點1
        {
            nextPosion = pos1.position;
        }

        transform.position = Vector3.MoveTowards(transform.position, nextPosion, speed * Time.deltaTime); //使平台移動
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(pos1.position, pos2.position); //
    }
}
