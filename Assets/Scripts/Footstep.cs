using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Footstep : MonoBehaviour
{
    [SerializeField]
    private Transform _soundOrigin;

    [SerializeField]
    private float _raycastDistance = 10f;

    [SerializeField]
    private float _raycastOffset = 1f;

    [SerializeField]
    private LayerMask _layerMask;

   FloorToPatchMap _map;


    private AudioManager _audioManager;

  

  
    private void Awake()
    {
      

    }
    private void Start()
    {
        _audioManager = FindObjectOfType<AudioManager>();

    }

    public void FootStep()
    {
        var rayCastTransform = transform.position + new Vector3(0, _raycastOffset, 0);
        Ray ray = new Ray(rayCastTransform, Vector3.down);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, _raycastDistance,_layerMask))
        {
            // Raycast hit an object
            Debug.Log("Raycast hit: " + hit.collider.gameObject.name);

          var floorMaterial =  hit.collider.gameObject.GetComponent<FloorMaterial>();

            if(floorMaterial != null)
            {
                PlaySound(_map.GetPatch(floorMaterial.FloorMaterialType));

            }
           
        }
        else
        {
            // Raycast did not hit anything
            Debug.Log("Raycast did not hit anything");
        }
    }

   

  
  


    private void PlaySound(Patch patch)
    {
        if(_audioManager != null)
        {
            _audioManager.PlayAudio(_soundOrigin, patch);
        }
        else
        {
            _audioManager = FindObjectOfType<AudioManager>();
            PlaySound( patch);
        }
    }



   

}
