using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatScene : MonoBehaviour
{

    [SerializeField] private GameObject GG;
    [SerializeField] private GameObject path;
    [SerializeField] private GameObject moveTarget;
    [SerializeField] private GameObject virtualCamera;
    private bool isOver = true;
    
    void Update()
    {
        if (isOver)
        {
            if (moveTarget.GetComponent<CinemachineDollyCart>().m_Position == path.GetComponent<CinemachineSmoothPath>().PathLength)
            {
                Destroy(path);
                Destroy(moveTarget);
                Destroy(virtualCamera);
                GG.GetComponent<RotatePlayers>().enabled = true;
                isOver = false;
            }
        }
    }
}
