using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public PlayerShooting playerShooting;

    // Queue untuk menyimpan list command
    private readonly Queue<Command> _commands = new();

    private void FixedUpdate()
    {
        // Menghandle input movement
        var moveCommand = InputMovementHandling();
        if (moveCommand == null) return;
        
        _commands.Enqueue(moveCommand);
        
        // ReSharper disable once Unity.PerformanceCriticalCodeInvocation
        moveCommand.Execute();
    }

    private void Update()
    {
        // Menghandle shoot
        var shootCommand = InputShootHandling();
        
        // ReSharper disable once Unity.PerformanceCriticalCodeInvocation
        shootCommand?.Execute();
    }

    private Command InputMovementHandling()
    {
        // Check jika movement sesuai dengan key
        if (Input.GetKey(KeyCode.D))
        {
            return new MoveCommand(playerMovement, 1, 0);
        }

        if (Input.GetKey(KeyCode.A))
        {
            return new MoveCommand(playerMovement, -1, 0);
        }

        if (Input.GetKey(KeyCode.W))
        {
            return new MoveCommand(playerMovement, 0, 1);
        }

        if (Input.GetKey(KeyCode.S))
        {
            return new MoveCommand(playerMovement, 0, -1);
        }

        // ReSharper disable once ConvertIfStatementToReturnStatement
        if (Input.GetKey(KeyCode.Z))
        {
            return Undo();
        }

        return new MoveCommand(playerMovement, 0, 0);
    }

    private Command Undo()
    {
        // Jika Queue command tidak kosong, lakukan perintah undo
        if (_commands.Count <= 0) return null;
        
        var undoCommand = _commands.Dequeue();
        undoCommand.UnExecute();
        
        return null;
    }
    
    private Command InputShootHandling()
    {
        // Jika menembak trigger shoot command
        return Input.GetButtonDown("Fire1") ? new ShootCommand(playerShooting) : null;
    }
}