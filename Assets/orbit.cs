using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Rufus31415.WebXR;

public class orbit : MonoBehaviour
{
    public TextMeshPro orbitText;
    public SphereCollider sphereCollider;
    public Transform orbitTextTransform;
    public GameObject collisonGameObject;
    public TrailRenderer trailRenderer;

    public void SetName(string name)
    {
        orbitText.text = name;
    }

    void LateUpdate() 
    {
         #if UNITY_EDITOR

                return;

        #endif

        //Debug.Log( Camera.current.transform.position );
        if(orbitTextTransform != null)
        {
           orbitTextTransform.LookAt(Camera.current.transform.position, -Vector3.up);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        var xr = SimpleWebXR.GetInstance();

        if(!xr.satelliteTriggered)
        {
            Time.timeScale = 0.77f;
            collisonGameObject.SetActive(true);
            xr.ProgressStory();
            xr.satelliteTriggered = true;
        }
   
    }

    private void OnTriggerExit(Collider other)
    {
		Time.timeScale = 10;
        collisonGameObject.SetActive(false);

        //CreateOrbits.ResetOrbits();
        var xr = SimpleWebXR.GetInstance();

        if(!xr.satelliteTriggeredOut)
        {
            xr.ProgressStory();
            xr.satelliteTriggeredOut = true;
        }
    }

    void Start() 
    {    
        
		Time.timeScale = 10;
        collisonGameObject.SetActive(false);   
    }
}
