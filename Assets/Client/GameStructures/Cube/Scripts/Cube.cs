using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private Coroutine movement;
    public void Move(Vector3 dirrection, float speed, float lifeTime)
    {
        if(movement == null)
            movement = StartCoroutine(MoveRoutine(dirrection, speed, lifeTime));
    }

    private  IEnumerator MoveRoutine(Vector3 dirrection,float speed, float lifeTime)
    {
        float time = 0;
        while(lifeTime > time)
        {
            yield return null;
            time += Time.deltaTime;
            transform.Translate(dirrection * speed);
        }
        movement = null;
        gameObject.SetActive(false);
    }
}
