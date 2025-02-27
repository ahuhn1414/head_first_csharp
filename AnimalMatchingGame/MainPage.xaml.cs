namespace AnimalMatchingGame;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
	}

	private void PlayAgainButton_Clicked(object sender, EventArgs e)
	{
		AnimalButtons.IsVisible = true;
		PlayAgainButton.IsVisible = false;

		List<string> animalEmoji = [
		"🦒","🦒",
		"🦔","🦔",
		"🐻‍❄️","🐻‍❄️",
		"🫎","🫎",
		"🐗","🐗",
		"🦤","🦤",
		"🐘","🐘",
		"🦬","🦬",
		];

		foreach (var button in AnimalButtons.Children.OfType<Button>())
		{
			int index = Random.Shared.Next(animalEmoji.Count);
			string nextEmoji = animalEmoji[index];
			button.Text = nextEmoji;
			animalEmoji.RemoveAt(index);
		}
		Dispatcher.StartTimer(TimeSpan.FromSeconds(.1), TimerTick);
	}
	int tenthsOfSecondsElapsed = 0;
	private bool TimerTick()
	{
			if (!this.IsLoaded) return false;
			tenthsOfSecondsElapsed++;
			TimeElapsed.Text = "Time elapsed: " + (tenthsOfSecondsElapsed / 10F).ToString("0.0s");
			
			if (PlayAgainButton.IsVisible)
			{
				tenthsOfSecondsElapsed = 0;
				return false;
			}
			return true;
	}
	// Before the first click, the fining of the match is false
	Button lastClicked;
	bool findingMatch = false;
	int matchesFound;

	private void Button_Clicked(object sender, EventArgs e)
	{
		if (sender is Button buttonClicked)
		{
			// If not a Null button clicked and our first click. 
			if (!string.IsNullOrWhiteSpace(buttonClicked.Text) && (findingMatch == false))
			{
				// Make the button red and set the last clicked to the button
				// first click so we are now finding the match
				buttonClicked.BackgroundColor = Colors.Red;
				lastClicked = buttonClicked;
				findingMatch = true;
			}
			else
			{   //If the button clicked is not the first time
				// and the emojis match
				if ((buttonClicked != lastClicked) && (buttonClicked.Text == lastClicked.Text) && (!String.IsNullOrWhiteSpace(buttonClicked.Text)))
				{   // Match was found and emoji disappears
					matchesFound++;
					lastClicked.Text = " ";
					buttonClicked.Text = " ";
				}
				// Sets the background color to blue again. 
				// Resets finding match
				lastClicked.BackgroundColor = Colors.LightBlue;
				buttonClicked.BackgroundColor = Colors.LightBlue;
				findingMatch = false;
			}
		}
		// When all 8 matches are found, reset game.
		if (matchesFound == 8)
		{
			matchesFound = 0;
			AnimalButtons.IsVisible = false;
			PlayAgainButton.IsVisible = true;
		}
	}

}

