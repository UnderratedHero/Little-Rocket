using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    [SerializeField] float mainThrust = 1000f;
    [SerializeField] float rotationThrust = 100f;
    [SerializeField] AudioClip RocketSound;

    [SerializeField] ParticleSystem BigJetParticles;
    [SerializeField] ParticleSystem SmallJetParticles1;
    [SerializeField] ParticleSystem SmallJetParticles2;
    [SerializeField] ParticleSystem SmallJetParticles3;
    [SerializeField] ParticleSystem SmallJetParticles4;

    Rigidbody rb;
    AudioSource sound;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        sound = GetComponent<AudioSource>();

    }
    void Update()
    {
        ForwardMooving();
        Rotation();
        PlayingFlySound();
    }
    void ForwardMooving()
    {
        bool forward = Input.GetKey(KeyCode.W);
        bool stopForward = Input.GetKeyUp(KeyCode.W);
        if(forward)
        {
            ProcessThrust();
        }
        if(stopForward)
        {
            StopProcessThrust();   
        }
    }
    void ProcessThrust()
    {
            BigJetParticles.Play();
            SmallJetParticles1.Play();
            SmallJetParticles2.Play();
            SmallJetParticles3.Play();
            SmallJetParticles4.Play();
           rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);//даем нашему твердому телу силу 
    }
    void StopProcessThrust()
    {
        BigJetParticles.Stop();
            SmallJetParticles1.Stop();
            SmallJetParticles2.Stop();
            SmallJetParticles3.Stop();
            SmallJetParticles4.Stop();
    }
    void Rotation()
    {
        bool right = Input.GetKey(KeyCode.D);
        bool left = Input.GetKey(KeyCode.A);
        if(right)
        {
            RotationFunc(-rotationThrust);
        }
        else if(left)
        {
            RotationFunc(rotationThrust);
        }

    }
    void RotationFunc(float rotationSign)
    {
        rb.freezeRotation = true;//заморозил вращение для того, чтобы не было бага с конфликтом вращения в разные стороны
        transform.Rotate(Vector3.forward * Time.deltaTime * rotationSign);
        rb.freezeRotation = false;
    }
    void PlayingFlySound()
    {
        bool playSoundOn = Input.GetKeyDown(KeyCode.W);
        bool playSoundOff = Input.GetKeyUp(KeyCode.W);
        if(playSoundOn)
        {
            sound.PlayOneShot(RocketSound);
        }
        if(playSoundOff)
        {
            sound.Stop();
        }
    }
}
