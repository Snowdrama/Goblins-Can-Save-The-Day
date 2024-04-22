using Godot;

public partial class GameDataNode : Node
{
    [Export] CanvasLayer consoleCanvas;
    public GameData gameData;
    public override void _Ready()
    {
        base._Ready();
        consoleCanvas.Hide();
    }

    public override void _Input(InputEvent @event)
    {
        base._Input(@event);
        if (Input.IsActionJustPressed("OpenGameData"))
        {
            if (consoleCanvas.Visible)
            {
                consoleCanvas.Hide();
            }
            else
            {
                consoleCanvas.Show();
            }
        }
    }

    public override void _EnterTree()
    {
        base._EnterTree();
        gameData = new GameData();
    }
    public override void _ExitTree()
    {
        base._ExitTree();
    }

    private void GameDataNode_VisibilityChanged()
    {

    }
}
