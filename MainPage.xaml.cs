namespace AnimalMatchingGame;


public partial class MainPage : ContentPage
{

    public MainPage()
    {
        InitializeComponent();
    }

    private void PlayAgainButton_Clicked(object sender, EventArgs e)
    {
        // intelliSense window, IntelliCode, giving you sugesstions, AI trained on millions of lines of code
        // Make the FlexLayout with the emoji buttons visible
        AnimalButtons.IsVisible = true; // Add a c# statement to the event handler method
        // Make the play again button invisible
        PlayAgainButton.IsVisible = false; // Add a c# statement to the event handler method

        // create list of 8 pairs of emojis, A list is a Collection that stores a set of values in order
        // [] collection expression
        // win + period (;) opens emojis
        List<string> animalEmoji = [
            "🦕","🦕",
            "👽","👽",
            "🐘","🐘",
            "🐀","🐀",
            "🦁","🦁",
            "🐧","🐧",
            "🦦","🦦",
            "🐙","🐙",    

            ];

        // for each loop iterates through collection(List of emojis)
        // executes a set of statements for each item it finds
        // no break needed, as it stops at last itteration

        foreach (var button in AnimalButtons.Children.OfType<Button>()) // Find every button in the FlexLayout and repeat the statements between the { curly brackets }for each of them 
        {
            int index = Random.Shared.Next(animalEmoji.Count); // Pick a random number between 0 and the number of emoji left in the list and call it "index"
            string nextEmoji = animalEmoji[index]; // Use the random number called "index" to get a random emoji from the list. 
            button.Text = nextEmoji; // Make the button display the selected emoji
            animalEmoji.RemoveAt(index); // Remove chosen emoji form the list 
        }


    }

    private void Button_Clicked(object sender, EventArgs e)
    {

    }
}
