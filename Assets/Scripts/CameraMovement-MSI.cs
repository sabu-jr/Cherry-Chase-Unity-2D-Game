using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform playerTransform;

    public GameObject bgImage;
    public GameObject RightBound;
    public GameObject LeftBound;
    public GameObject CherrySpawner;


    // Update is called once per frame
    void Update()
    {
        Transform imagetrans = bgImage.transform;
        Transform rBoundTrans = RightBound.transform;
        Transform lBoundTrans = LeftBound.transform;
        Transform CherryTrans = CherrySpawner.transform;


        transform.position = new Vector3(transform.position.x, playerTransform.position.y + 2, transform.position.z);

        bgImage.transform.position = new Vector3(imagetrans.position.x, playerTransform.position.y + 2, imagetrans.position.z);

        RightBound.transform.position = new Vector3(rBoundTrans.position.x, playerTransform.position.y + 2, rBoundTrans.position.z);
        LeftBound.transform.position = new Vector3(lBoundTrans.position.x, playerTransform.position.y + 2, lBoundTrans.position.z);

        CherrySpawner.transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y + 10, CherryTrans.position.z);
    }
}
