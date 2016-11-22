using UnityEngine;
using System.Collections;

public class targetController2 : MonoBehaviour
{

    public int speed = 20;
    void Update()
    {
        float x = 0, y = 0;
        if (Input.GetKey(KeyCode.J)) x -= Time.deltaTime;
        else if (Input.GetKey(KeyCode.L)) x += Time.deltaTime;
        if (Input.GetKey(KeyCode.I)) y+= Time.deltaTime;
        else if (Input.GetKey(KeyCode.K)) y -= Time.deltaTime;
        transform.Translate(new Vector3(x * speed, y * speed, 0));
    }
}
