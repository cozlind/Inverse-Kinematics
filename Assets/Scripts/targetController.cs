using UnityEngine;
using System.Collections;

public class targetController : MonoBehaviour {

    public int speed = 20;
	void Update () {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        transform.Translate(new Vector3(x*Time.deltaTime*speed, y * Time.deltaTime * speed, 0));
    }
}
