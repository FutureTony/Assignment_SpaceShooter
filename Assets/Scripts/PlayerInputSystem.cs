using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;
using UnityEngine.InputSystem;

[UpdateInGroup(typeof(InitializationSystemGroup),OrderLast = true)]
public partial class PlayerInputSystem : SystemBase
{
    private GameInput inputActions;
    private Entity Player;
    protected override void OnCreate()
    {
        RequireForUpdate<PlayerTag>();
        RequireForUpdate<PlayerMoveInput>();
        inputActions = new GameInput();
    }
    protected override void OnStartRunning()
    {
        inputActions.Enable();
        inputActions.GamePlay.Shoot.performed += OnShoot;
        Player = SystemAPI.GetSingletonEntity<PlayerTag>();
    }

    private void OnShoot(InputAction.CallbackContext context)
    {
        if (!SystemAPI.Exists(Player)) return;
           
        SystemAPI.SetComponentEnabled<FireProjectileTag>(Player, true);
    }

    protected override void OnUpdate()
    {
        var moveInput = inputActions.GamePlay.Move.ReadValue<Vector2>();

        SystemAPI.SetSingleton(new PlayerMoveInput { Value = moveInput });
       
    }
    protected override void OnStopRunning()
    {
        inputActions.Disable();
        Player = Entity.Null;
    }
}

