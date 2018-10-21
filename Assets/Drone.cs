using GoogleARCore.Examples.HelloAR;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : MonoBehaviour {

    public GameObject exp;

    private void OnTriggerEnter(Collider other) {
        StartCoroutine("Dead");
    }

    IEnumerator Dead() {
        yield return new WaitForSeconds(1);
        HelloARController.score += 1;
        exp = Instantiate(exp, GetComponent<Transform>().position, Quaternion.identity);
        Destroy(exp, 1.0f);
        Destroy(gameObject);
    }
}
