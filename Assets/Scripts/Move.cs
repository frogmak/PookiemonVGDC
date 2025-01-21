using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] string moveName;
    [SerializeField] [Range(0,100)] int accuracy;
    public Types type;

    public virtual void UseMove(Pookiemon target) { 
        
    }
}
