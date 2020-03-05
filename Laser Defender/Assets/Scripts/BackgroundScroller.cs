using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField] float backgroundScrollSpeed = 0.2f;
    // Material for Mesh Renderer
    Material myMaterial;
    Vector2 offset;


    // Start is called before the first frame update
    void Start()
    {
        // Get Background material
        myMaterial = GetComponent<Renderer>().material;
        offset = new Vector2(0f, backgroundScrollSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        myMaterial.mainTextureOffset += offset * Time.deltaTime;
    }
}
