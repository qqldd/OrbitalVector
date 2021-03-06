﻿using UnityEngine;
using System.Collections;
using System;

public class OrbitData : MonoBehaviour {

    public VectorD rv;
    public VectorD params_;
    OrbitalTools.OrbitalElements oe;

    static double r = 4;
    static double m = 7e10;
    static double G = 6.673e-11;
    public static double parentGM = m * G;
    public static class Global
    {
        public static double[] vel = new double[] { .1d, 0, Math.Sqrt(parentGM / r) };
        public static double[] pos = new double[] { r+.2d, 0, .1d};
    }
    public Vector3 getVel()
    {
        return new Vector3((float)rv[3], 
                           (float)rv[4], (float)rv[5]);
    }

    void Start()
    {
        rv = new VectorD();
        rv.Resize(6);

        Debug.Log("position " + transform.position);
        rv[0] = transform.position.x;
        rv[1] = transform.position.y;
        rv[2] = transform.position.z;
        //comput velocity assuming pos is in the origin
        var vel = Vector3.Cross(transform.position, Vector3.up).normalized;
        vel *= Mathf.Sqrt((float)parentGM / transform.position.magnitude);
        rv[3] = vel.x;
        rv[4] = vel.y;
        rv[5] = vel.z;


        params_ = new VectorD();
        params_.Resize(7);
        params_[0] = 0;
        params_[1] = 0;
        params_[2] = 0;
        params_[3] = parentGM;
        params_[4] = 0;
        params_[5] = 0;
        params_[6] = 0;
    }

    void Update()
    {
        transform.position = new Vector3((float)rv[0], 
                                         (float)rv[1], (float)rv[2]);
    }
}
