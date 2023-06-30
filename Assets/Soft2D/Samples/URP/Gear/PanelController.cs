using System.Collections.Generic;
using Taichi.Soft2D.Plugin;
using UnityEngine;

public class PanelController : MonoBehaviour
{
    public GameObject movingCube;
    public EEmitter emitter;
    public float movingSpeed;
    public GameObject gate;
    public GameObject platform;
    public List<Rigidbody> prisms;
    public GameObject gear1;
    public GameObject gear2;

    public Transform colliders;
    
    private bool isSet;
    private bool stopEmitting;
    
    private Rigidbody movingCubeRb;
    private ECollider movingCubeColl;

    private void Awake()
    {
        movingCubeRb = movingCube.GetComponent<Rigidbody>();
        movingCubeColl = movingCube.transform.GetChild(0).GetComponent<ECollider>();
    }

    private void Start()
    {
        for (int i = 0; i < 28; i++)
        {
            prisms.Add(colliders.GetChild(i).GetChild(0).GetComponent<Rigidbody>());
        }
    }

    public void Update()
    {
        gear1.transform.Rotate(new Vector3(0,0,-movingSpeed*1f));
        gear2.transform.Rotate(new Vector3(0,0,movingSpeed*1f));
        movingCubeColl.SetSoft2DPosition(movingCube.transform.position);
        if (movingCubeColl.isInitialized && !isSet)
        {
            movingCubeRb.velocity = new Vector3(movingSpeed,0,0);
            movingCubeColl.SetUnityAndSoft2DLinearVelocity(new Vector2(movingSpeed,0));
            emitter.StartEmitting();
            isSet = true;
        }
        if (movingCube.transform.position.x <= 0.19f)
        {
            movingCubeRb.velocity = new Vector3(movingSpeed,0,0);
            movingCubeColl.SetSoft2DLinearVelocity(new Vector2(movingSpeed,0));
        }
        else if(movingCube.transform.position.x >= 0.81f)
        {
            movingCubeRb.velocity = new Vector3(-movingSpeed, 0, 0);
            movingCubeColl.SetSoft2DLinearVelocity(new Vector2(-movingSpeed,0));
        }

        if (Input.GetKeyDown(KeyCode.Space) && !stopEmitting)
        {
            emitter.StopEmitting();
            RemoveCollider(gate);
            RemoveCollider(platform);
            movingCubeRb.velocity = new Vector3(0, 0, movingSpeed / 5);
            movingCubeColl.DestroyCollider();
            stopEmitting = true;
        }
        if (stopEmitting)
        {
            MovePrisms();
        }
    }

    private void MovePrisms()
    {
        foreach (var prism in prisms)
        {
            prism.velocity = prism.transform.position.z <= -0.03f ? Vector3.zero : new Vector3(0, 0, -movingSpeed / 10);
        }
    }

    private void RemoveCollider(GameObject collider)
    {
        collider.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, movingSpeed / 5);
        collider.transform.GetChild(0).GetComponent<ECollider>().DestroyCollider();
    }
}
