﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D _bulletRB;
    private float _startXPosition;
    private float _startYPosition;

    public AudioClip[] AllExp;

    private float _bulletSpeed = 500;
    void Start()
    {
        _startXPosition = transform.position.x;
        _startYPosition = transform.position.y;
        _bulletRB = GetComponent<Rigidbody2D>();

        Shoot();
    }

    private void Shoot()
    {
        Vector2 ShootingVector = GetDirectionForShooting();

        _bulletRB.AddForce(ShootingVector * _bulletSpeed);
    }

    private Vector2 GetDirectionForShooting()
    {
        return new Vector2(Random.Range(-10, 10) - _startXPosition, -_startYPosition);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        int n = Random.Range(0, AllExp.Length);

        SoundManager.PlayExplosion(AllExp[n]);
        SoundManager.StopAudioCLip();

        Destroy(this.gameObject);
    }

}
