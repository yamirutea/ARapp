using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneCon : MonoBehaviour {

    private Rigidbody rb;
    readonly int power = 100;

    void Start() {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    public void Up() {
        rb.AddForce(new Vector3(0, 1, 0) * power, ForceMode.Impulse);
    }
    public void Down() {
        rb.AddForce(new Vector3(0, -1, 0) * power, ForceMode.Impulse);
    }
    public void Left() {

    }
    public void Right() {

    }
    public void North() {
        rb.AddForce(new Vector3(0, 0, 1) * power, ForceMode.Impulse);
    }
    public void South() {
        rb.AddForce(new Vector3(0, 0, -1) * power, ForceMode.Impulse);
    }
    public void East() {
        rb.AddForce(new Vector3(1, 0, 0) * power, ForceMode.Impulse);
    }
    public void West() {
        rb.AddForce(new Vector3(-1, 0, 0) * power, ForceMode.Impulse);
    }
}
