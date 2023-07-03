using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catscene : MonoBehaviour
{

    [SerializeField] GameObject moveTarget;
    [SerializeField] GameObject GG;
    [SerializeField] GameObject path;
    [SerializeField] GameObject virtualCamera;
    [SerializeField] GameObject camera;
    bool isTrue = true;
    void Start()
    {
        
    }

  
    void Update()
    {
        if (isTrue)
        {
            if (moveTarget.GetComponent<CinemachineDollyCart>().m_Position == path.GetComponent<CinemachineSmoothPath>().PathLength)
            {
                Destroy(path);
                Destroy(moveTarget);
                Destroy(virtualCamera);
                GG.GetComponent<RotatePlayers>().enabled = true;
                camera.GetComponent<CameraContrroller1>().enabled = true;
                
               
                isTrue = false;
            }
        }
    }
}
