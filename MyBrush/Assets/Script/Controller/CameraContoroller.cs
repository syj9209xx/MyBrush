using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraContoroller : MonoBehaviour
{
    // Start is called before the first frame update
    
    public Transform pPlayer;    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vCamPos = new Vector3(pPlayer.position.x, pPlayer.position.y, transform.position.z);
        transform.position = vCamPos;
    }

    private void FixedUpdate()
    {
        
    }
}
