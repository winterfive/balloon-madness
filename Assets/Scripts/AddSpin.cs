using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddSpin : MonoBehaviour {

    private Rigidbody rb;
    private float _minSpin, _maxSpin;
    private BalloonValues _balloonValuesRef;


    private void Awake()
    {
        rb = this.gameObject.GetComponentInChildren<Rigidbody>();

        GameObject balloonValuesObject = GameObject.FindWithTag("ScriptHolder");
        if (balloonValuesObject != null)
        {
            _balloonValuesRef = balloonValuesObject.GetComponent<BalloonValues>();
            _minSpin = _balloonValuesRef.minSpin;
            _maxSpin = _balloonValuesRef.maxSpin;
        }
        else
        {
            Debug.Log("Cannot find BalloonValues script");
        }
    }


    private void Start()
    {
        float spin = Random.Range(_minSpin, _maxSpin);

        if (spin != 0)
        {
            rb.AddTorque(transform.forward * spin);
            rb.AddTorque(transform.right * spin);
        }        
    }


    public void Update()
    {
        rb.AddForce(Vector3.up * 8f);
    }
}
