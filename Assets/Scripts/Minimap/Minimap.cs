using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{
    public Transform CarTransf; 

    void LateUpdate()
    {
        UpdateCamPosition();
    }

    
    void UpdateCamPosition()
    {
        Vector3 NewPosition = CarTransf.position;
        NewPosition.y = CarTransf.position.y;
        transform.position = NewPosition;

        transform.rotation = Quaternion.Euler(90, CarTransf.eulerAngles.y, 0);
    }
}
