using Godot;
using GodotInk;

public partial class InkQuickStartGuide : VBoxContainer
{
	[Export]
	InkStory story;

	public override void _Ready()
	{
		ContinueStory();
	}

	void ContinueStory()
	{
		foreach (Node child in GetChildren())
			child.QueueFree();

		Label content = new() { Text = story.ContinueMaximally() };
		AddChild(content);

		foreach (InkChoice choice in story.CurrentChoices)
		{
			var button = new Button { Text = choice.Text };
			button.Pressed += () =>
			{
				story.ChooseChoiceIndex(choice.Index);
				ContinueStory();
			};

			AddChild(button);
		}
	}
}
