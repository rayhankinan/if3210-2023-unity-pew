public abstract class Command
{
    public abstract void Execute();
    public abstract void UnExecute();
}

public class MoveCommand : Command
{
    private readonly PlayerMovement _playerMovement;
    private readonly float _h, _v;

    public MoveCommand(PlayerMovement playerMovement, float h, float v)
    {
        _playerMovement = playerMovement;
        _h = h;
        _v = v;
    }

    // Trigger perintah movement
    public override void Execute()
    {
        _playerMovement.Move(_h, _v);
        
        // Menganimasikan player
        _playerMovement.Animating(_h, _v);
    }

    public override void UnExecute()
    {
        // Inverse arah dari movement player
        _playerMovement.Move(-_h, -_v);
        
        // Menganimasikan player
        _playerMovement.Animating(_h, _v);
    }
}

public class ShootCommand : Command
{

    private readonly PlayerShooting _playerShooting;

    public ShootCommand(PlayerShooting playerShooting)
    {
        _playerShooting = playerShooting;
    }

    public override void Execute()
    {
        //Player menembak
        _playerShooting.Shoot();
    }

    public override void UnExecute()
    {
        
    }
}