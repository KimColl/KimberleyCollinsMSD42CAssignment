using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    [SerializeField] float backgroundScrollingSpeed = 1.0f;

    //the Material from the texture background
    Material myMaterialBackground;

    //movement offSet x = 0; y = 0
    Vector2 offSet;

    // Start is called before the first frame update
    void Start()
    {
        //get the Material of the background from Renderer component
        myMaterialBackground = GetComponent<Renderer>().material;

        //move in the y-axis at the given speed 
        offSet = new Vector2(0f, backgroundScrollingSpeed);
    }

    // Update is called once per frame
     void Update()
    {
        //to update at that offset
        //move the texture of the material by offset every frame
        myMaterialBackground.mainTextureOffset += offSet * Time.deltaTime;
    }
}
