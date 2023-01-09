using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
  public enum State
  {
    Ready,
    Empty,
    Reloading
  }
  
  public State state {get; private set;}
  
  public Transform fireTransform;
  
  public ParticleSystem muzzleFlashEffect;
  public ParticleSystem shellEjectEffect;
  
  private LineRenderer bulletLineRenderer;
  private AudioSource gunAudioPlayer;
  
  public GunData gunData;
  
  private float fireDistance = 50;
  
  public int ammoRemain = 100;
  public int magAmmo;
  
  private float lastFireTime;
  
  private void Awake()
  {
  }
  
  private void OnEnable()
  {
  }
  
  public void Fire()
  {
  }
  
  private void Shot()
  {
  }
  
  private Ienumerator ShotEffect(Vector3 hitPosition)
  {
  }
  
  public bool Reload()
  {
  }
  
  private IEnumerator ReloadRoutine()
  {
  }
  
}
