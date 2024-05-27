﻿using Fight_or_Die.Abstractions;
using Fight_or_Die.GeometryElements;
using Fight_or_Die.Model.HealthModel;

namespace Fight_or_Die.Model.CharacterModel;

public class Character : IDamagable, IHealable, IPlaced
{
    public Character(int maxHealth, Size size)
    {
        Health = new Health(maxHealth);
        Size = size;
        Position = Vector.Zero;
    }

    public Character(int maxHealth, Size size, Vector position) : this(maxHealth, size)
    {
        Position = position;
    }


    public Health Health { get; }

    public Vector Position { get; private set; }
    public Size Size { get; }

    public event Action? Died
    {
        add => Health.Died += value;
        remove => Health.Died -= value;
    }

    public event Action<int>? HealthChanged
    {
        add => Health.HealthChanged += value;
        remove => Health.HealthChanged -= value;
    }

    public void TakeDamage(int points)
    {
        Health.AddHealth(-points);
    }

    public void Heal(int points)
    {
        Health.AddHealth(points);
    }

    public void SetPosition(Vector position)
    {
        Position = position;
    }
}