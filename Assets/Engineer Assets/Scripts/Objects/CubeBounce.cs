using UnityEngine;
using System.Collections;

public class CubeBounce : MonoBehaviour {

    float speed = 10;
    float chance = 0;
	
	// Update is called once per frame
	void FixedUpdate () {
        chance += Random.value * 50 * Time.deltaTime;
	    if (chance >= 10 || GetComponent<Rigidbody>().velocity.magnitude == 0)
        {
            chance = 0;
            float x = Random.value - 0.5f;
            float y = Random.value - 0.5f;
            float z = Random.value - 0.5f;
            Vector3 velocity = new Vector3(x, y, z);
            GetComponent<Rigidbody>().velocity = Random.value * speed * Vector3.Normalize(velocity);
        }
	}
}
