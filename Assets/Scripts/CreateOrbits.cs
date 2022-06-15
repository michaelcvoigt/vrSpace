using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rufus31415.WebXR;

public class CreateOrbits : MonoBehaviour
{
    public static CreateOrbits instance = null;

    public GameObject myPlanet;
    public GameObject myOrbitPrefab;
    public string[] myOrbitNames;
    public int numOfOrbits = 2;
    public float[] orbitSMA;
    public Vector3[] orbitScale;
    public float[] orbitRotation;
    public Color[] orbitColors;
    private bool createdOrbits = false;
    private GameObject[] myOrbits;

    void Awake()
    {
        instance = this;
    }

    public void MakeOrbits()
    {
        if(!createdOrbits){


            myOrbits = new GameObject[numOfOrbits];

        for(int i  = 0; i < numOfOrbits; i++)
        {    
           var orbitPrefab = Instantiate(myOrbitPrefab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;

            myOrbits[i] = orbitPrefab;

            myOrbits[i].transform.Rotate(0,0,orbitRotation[i]);
            myOrbits[i].transform.localScale =  orbitScale[i];  //new Vector3(orbitSMA+ (i/22) ,orbitSMA + (i/22),orbitSMA+ (i/22));
            myOrbits[i].transform.parent = myPlanet.transform;
            myOrbits[i].transform.localPosition = new Vector3(0, 0, 0);
            orbit myOrbitScript =  myOrbits[i].GetComponentInChildren<orbit>() as orbit;
            myOrbitScript.SetName(myOrbitNames[i]);
            myOrbitScript.gameObject.transform.localPosition = new Vector3(orbitSMA[i],0,0);
            myOrbitScript.trailRenderer.material.color = orbitColors[i];
            //orbit[i] = myOrbit;
        }

        createdOrbits = true;
        }

    }

    public static void ResetOrbits()
    {
        

        instance.StartCoroutine(instance.ExampleCoroutine());
        
    }

    IEnumerator ExampleCoroutine()
    {


        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(25);

        instance.createdOrbits = false;

        for(int i  = 0; i < instance.numOfOrbits; i++)
        { 
            Destroy(instance.myOrbits[i]);
        }

        instance.MakeOrbits();
    }
}