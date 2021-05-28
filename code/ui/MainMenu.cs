
using Sandbox;
using Sandbox.UI;
using Sandbox.UI.Construct;

public class MainMenu : Panel
{
	private bool IsOpen = false;
	private float LastToggleTime = 0;

	private Label SkillPoints;

	public MainMenu()
	{
		StyleSheet.Load( "/ui/MainMenu.scss" );

		Panel navBar = Add.Panel( "navBar" );
		navBar.Add.Label( "ARMOURY", "navButton" );
		navBar.Add.Label( "STATISTICS", "navButton" );
		navBar.Add.Label( "SOCIAL", "navButton" );

		Panel pageArea = Add.Panel( "pageArea" );

		Panel armouryPage = pageArea.Add.Panel( "armouryPage" );

		Panel slot1 = armouryPage.Add.Panel( "armourySlot" );
		Panel slot2 = armouryPage.Add.Panel( "armourySlot" );
		slot2.Style.MarginTop = Length.Percent( 4f );

		SkillPoints = slot2.Add.Label( "Skill Points: 0", "skillPoints" );
	}

	public override void Tick()
	{
		base.Tick();

		if( Local.Client.Input.Pressed( InputButton.Menu ) && Time.Now >= LastToggleTime+.1f )
		{
			LastToggleTime = Time.Now;
			IsOpen = !IsOpen;

			Parent.SetClass( "mainmenuopen", IsOpen );
		}

		DeathmatchPlayer ply = Local.Pawn as DeathmatchPlayer;
		if( ply == null ) { return; }

		SkillPoints.Text = $"Skill Points: {ply.SkillPoints}";
	}
}
