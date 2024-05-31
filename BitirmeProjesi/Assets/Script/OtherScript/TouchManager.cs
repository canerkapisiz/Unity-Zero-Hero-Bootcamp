using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManager : MonoBehaviour
{
    private Vector3 ilkElPozisyon;

    private void Start()
    {
        ilkElPozisyon = Vector3.zero;
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                ilkElPozisyon = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                Vector3 currentTouchPosition = touch.position;float distance = Vector2.Distance(ilkElPozisyon, currentTouchPosition);

                float maxDistance = 1f; // Değişebilir, istediğiniz maksimum mesafeyi ayarlayabilirsiniz.
                float normalizedDistance = Mathf.Clamp01(distance / maxDistance);

                if (currentTouchPosition.magnitude > ilkElPozisyon.magnitude)
                {
                    PlayerPrefs.SetFloat("yonVerme", -normalizedDistance);
                }
                else
                {
                    PlayerPrefs.SetFloat("yonVerme", normalizedDistance);
                }
            }
            else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                PlayerPrefs.SetFloat("yonVerme", 0);
            }
        }
    }
}
