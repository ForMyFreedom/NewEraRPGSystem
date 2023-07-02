using Godot;
using System;

public class SkillGUI : BaseGUI
{
    [Export]
    private NodePath mechanicNameLabelPath;
    [Export]
    private NodePath mechanicDescriLabelPath;
    [Export]
    private NodePath mechanicButtonArrayPath;
    [Export]
    private NodePath mechanicImagePath;
    [Export]
    private PackedScene mechanicButtonScene;

    
    private Skill skill;
    private int skillIndex;
    private int workIndex;


    [Signal]
    public delegate void value_changed(int workindex, int skillIndex, int value);

    public override void _Ready()
    {
        base._Ready();
        WindowTitle = skill.GetSkillName();
        GetNode<Label>(descriptionLabelPath).Text = skill.GetSkillDescription();
        GetNode<Label>(mechanicNameLabelPath).Text += skill.GetSkillName();
        GetNode<TextEdit>(mechanicDescriLabelPath).Text = skill.GetMechanicDescription();
        GetNode<TextureRect>(mechanicImagePath).Texture = skill.GetEffectImage();
        CreateAllMechanicButtons();
        ConnectAllMechanicButtons();
    }


    protected override void _OnRollMaded(int result)
    {
        //@
    }

    protected void _OnRelatedAtributeChanged(int index)
    {
        //@
    }

    protected override void _OnValueChanged(int value)
    {
        EmitSignal(nameof(value_changed), workIndex, skillIndex, value);
    }


    public void ConnectAllSignals(WorkTree father)
    {
        Connect(nameof(value_changed), father, nameof(father._OnSkillValueChanged));
    }
    

    private void CreateAllMechanicButtons()
    {
        foreach(String message in skill.GetTextOfMechanicButtons())
        {
            Button newButton = mechanicButtonScene.Instance<Button>();
            newButton.Text = message;
            GetNode(mechanicButtonArrayPath).AddChild(newButton);
        }
    }

    private void ConnectAllMechanicButtons()
    {
        foreach(Control button in GetNode(mechanicButtonArrayPath).GetChildren())
        {
            button.Connect("do_mechanic", this, "_OnDoMechanic");
        }
    }


    
    private void _OnDoMechanic(int actionIndex)
    {
        skill.DoMechanic((MainInterface)GetTree().CurrentScene, actionIndex);
    }



    public void PopupIt()
    {
        PopupCenteredRatio(0.5f);
    }

    public void SetSkill(Skill s)
    {
        skill = s;
        GetNode<RollBox>(rollBoxPath).SetRollValue(s.GetLevel());
    }

    public void SetWork(Work w)
    {
        work = w;
    }

    public void SetSkillIndex(int i)
    {
        skillIndex = i;
    }

    public void SetWorkIndex(int i)
    {
        workIndex = i;
    }
}
