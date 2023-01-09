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
    bulletLineRenderer.enabled = true;
    
    yield return new WaitForSeconds(0.0f);
    
    bulletLineRenderer.enabled = false;
  }
  
  public bool Reload()
  {
    return false;
  }
  
  private IEnumerator ReloadRoutine()
  {
    state = State.Reloading;
    yield return new WaitForSeconds(gunData.reloadTime);
    state = State.Ready;
  }
  
}
