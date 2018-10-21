using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightDirection : MonoBehaviour {

    private double f;
    private double g;
    private double ido;
    private double kdo;
    private double doy;
    private double sit;
    private double del;
    private double eq;
    private double sina;
    private double tang;
    private double arfa;
    private double dire;
    private bool flag = true;

    void Start () {

        Input.compass.enabled = true;
        Input.location.Start();

        f = 35;
        ido = f / 180 * Mathf.PI;
        g = 135;
        kdo = (g - 135) / 180 * Mathf.PI;
        doy = DateTime.Now.DayOfYear;
        sit = 2 * Mathf.PI * (doy - 1) / 365;
        del = 0.006918 - 0.399912 * Math.Cos(sit) + 0.070257 * Math.Sin(sit) - 0.006758 * Math.Cos(2 * sit) + 0.000907 * Math.Sin(2 * sit) - 0.002697 * Math.Cos(3 * sit) + 0.001480 * Math.Sin(3 * sit);
        eq = 0.000075 + 0.001868 * Math.Cos(sit) - 0.032077 * Math.Sin(sit) - 0.014615 * Math.Cos(2 * sit) - 0.040849 * Math.Sin(2 * sit);
        tang = (DateTime.Now.Hour + DateTime.Now.Minute / 60d - 12d) / 12d * Mathf.PI + kdo + eq;
        sina = Math.Sin(ido) * Math.Sin(del) + Math.Cos(ido) * Math.Cos(del) * Math.Cos(tang);
        arfa = Math.Asin(sina) / Mathf.PI * 180;
        dire = Math.Atan2(Math.Cos(ido) * Math.Cos(del) * Math.Sin(tang), Math.Sin(ido) * sina - Math.Sin(del)) / Mathf.PI * 180;
        GetComponent<Transform>().rotation = Quaternion.Euler(new Vector3(0, -Input.compass.magneticHeading, 0));
        GetComponent<Transform>().Rotate((float)arfa, (float)dire, 0);
    }
	
	void Update () {
        if (GoogleARCore.Examples.HelloAR.HelloARController.planestart && flag) {
            GetComponent<Transform>().rotation = Quaternion.Euler(new Vector3(0, -Input.compass.magneticHeading, 0));
            GetComponent<Transform>().Rotate((float)arfa, (float)dire, 0);
            flag = false;
        }
    }
}
