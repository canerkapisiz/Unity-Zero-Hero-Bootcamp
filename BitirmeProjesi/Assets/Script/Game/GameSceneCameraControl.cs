using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneCameraControl : MonoBehaviour
{
    [SerializeField] private Transform[] followPosition;
    [SerializeField] private Transform[] pivot;

    void LateUpdate()
    {
        transform.position = followPosition[PlayerPrefs.GetInt("hangiMekik")].position;
        transform.LookAt(pivot[PlayerPrefs.GetInt("hangiMekik")].position);
    }
}
