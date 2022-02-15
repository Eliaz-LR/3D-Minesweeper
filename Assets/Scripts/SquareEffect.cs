using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareEffect : MonoBehaviour
{

    [SerializeField] ParticleSystem collectParticle = null;

    public void MakeEffectLose()
    {
        collectParticle.play();
    }

}
