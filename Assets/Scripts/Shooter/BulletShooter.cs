﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShooter : MonoBehaviour
{
    public GameObject BulletPrefab;
    [Header("Shooter")]
    [Range(0, 10)]
    public float TimeBetweenShoot = 1;

    private float TimeLeft;
    private float _sphereRadius;

    SoundManager riffs;

    public AudioClip Riff1;
    public AudioClip Riff2;

    public int audioCount = 0;


    private void Start()
    {
        _sphereRadius = GetComponent<CircleCollider2D>().radius;
        TimeLeft = TimeBetweenShoot;
        riffs = GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }

    void Update()
    {
        TimerForShoot();
    }

    private void TimerForShoot()
    {
        TimeLeft -= Time.deltaTime;
        if (TimeLeft < 0)
        {
            ShootNewBullet();
            TimeLeft = TimeBetweenShoot;
        }
    }

    private void ShootNewBullet()
    {
        Vector3 positionToSpown = GetPositionToSpawn();
        Instantiate(BulletPrefab, positionToSpown, Quaternion.identity);
        PlayOneRiff();



    }

    private Vector3 GetPositionToSpawn()
    {
        float x = Random.Range(-_sphereRadius, _sphereRadius);

        return new Vector3(x, GetYValue(x), 0);
    }

    private float GetYValue(float x)
    {
        return Mathf.Sqrt(Mathf.Pow(_sphereRadius, 2) - Mathf.Pow(x, 2)) + transform.position.y;
    }

    private void PlayOneRiff()
    {
        if (audioCount < 2)
        {
            SoundManager.PlayRiff1(Riff1);
            audioCount += 1;
        }

        else
        {
            SoundManager.PlayRiff2(Riff2);
            audioCount = 0;
        }
    }



}
