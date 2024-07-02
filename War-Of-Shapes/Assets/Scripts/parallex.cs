using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallax : MonoBehaviour
{
    public Transform mainCam;
    public Transform middleBG;
    public Transform sideBG;
    public Transform bottomBG;
    public float length = 1f;

    // Update is called once per frame
    void Update()
    {
        // Check horizontal position and update sideBG
        if (mainCam.position.x > middleBG.position.x + length / 2)
        {
            sideBG.position = middleBG.position + Vector3.right * length;
        }
        else if (mainCam.position.x < middleBG.position.x - length / 2)
        {
            sideBG.position = middleBG.position + Vector3.left * length;
        }

        // Check vertical position and update bottomBG
        if (mainCam.position.y > middleBG.position.y + length / 2)
        {
            bottomBG.position = middleBG.position + Vector3.up * length;
        }
        else if (mainCam.position.y < middleBG.position.y - length / 2)
        {
            bottomBG.position = middleBG.position + Vector3.down * length;
        }

        // Swap middleBG with sideBG if camera passes sideBG
        if (mainCam.position.x > sideBG.position.x || mainCam.position.x < sideBG.position.x)
        {
            Transform temp = middleBG;
            middleBG = sideBG;
            sideBG = temp;
        }

        // Swap middleBG with bottomBG if camera passes bottomBG
        if (mainCam.position.y > bottomBG.position.y || mainCam.position.y < bottomBG.position.y)
        {
            Transform temp = middleBG;
            middleBG = bottomBG;
            bottomBG = temp;
        }
    }
}
