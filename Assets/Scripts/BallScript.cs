using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public Material greenMaterial;
    public Material redMaterial;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GetComponent<Rigidbody>().AddForce(Physics.gravity, ForceMode.Acceleration);
    }

    private void OnTriggerEnter(Collider other)
    {
        MeshRenderer finishRenderer = other.GetComponentInParent<MeshRenderer>();

        finishRenderer.material = greenMaterial;
    }

    private void OnTriggerExit(Collider other)
    {
        MeshRenderer finishRenderer = other.GetComponentInParent<MeshRenderer>();

        finishRenderer.material = redMaterial;
    }
}
