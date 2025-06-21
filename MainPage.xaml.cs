
using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Controls;


namespace AnimalMatchingGame;


public partial class MainPage : ContentPage
{
    private bool findingMatch; // Fix for CS0103: Declare the 'findingMatch' field.
    private Button lastClicked = null!; // Fix for CS8618: Initialize 'lastClicked' to a non-null value using null-forgiving operator.

    public MainPage()
    {
        InitializeComponent();
    }

    private void PlayAgainButton_Clicked(object sender, EventArgs e)
    {
        AnimalButtons.IsVisible = true;
        PlayAgainButton.IsVisible = false;

        List<string> animalEmoji = new List<string> // Fix syntax error in list initialization.
        {
            "🦕", "🦕",
            "👽", "👽",
            "🐘", "🐘",
            "🐀", "🐀",
            "🦁", "🦁",
            "🐧", "🐧",
            "🦦", "🦦",
            "🐙", "🐙"
        };

        foreach (var button in AnimalButtons.Children.OfType<Button>())
        {
            int index = Random.Shared.Next(animalEmoji.Count);
            string nextEmoji = animalEmoji[index];
            button.Text = nextEmoji;
            animalEmoji.RemoveAt(index);
        }

        Dispatcher.StartTimer(TimeSpan.FromSeconds(.1), TimerTick); // The line of code that you just added causes your app to start a timer that executes a  method called TimerTick every 0.1 of a second.
    }

    int tenthsOfSecondsElapsed = 0; // Intitialize This is a field. You'll learn more about how fields work in Chapter 3.

    
    private bool TimerTick()
    {
        if (!this.IsLoaded) return false; // If you close your app, the  timer could still tick after the TimeElapsed label disappears, which could cause an error.This statementkeeps that from happening.

        tenthsOfSecondsElapsed++; //  timer could still tick after the TimeElapsed label disappears, which could cause an error.This statement keeps that from happening.

        TimeElapsed.Text = "Time elapsed: " +
            (tenthsOfSecondsElapsed / 10F).ToString("0.0s"); // This statement updates the TimeElapsed label with the latest time, dividing the 10ths of second by 10 to convert it to seconds.

           if (PlayAgainButton.IsVisible) // If the “Play Again?” button is visible again, that means the game is over and the timer can stop running.The if statement runs the next two statements only if the game is running.
            
                 {
            tenthsOfSecondsElapsed = 0; // We need to reset the 10ths of seconds counter so it starts at 0 the next time the game starts.

            return false; // This statement causes the timer to stop, and no other statements in the method get executed.
        }
        return true; // This statement is only executed if the if statement didn’t find the “Play again?” button visible. It tells the timer to keep running.
    }

    private int matchesFound;

    private void Button_Clicked(object sender, EventArgs e)
    {
        if (sender is Button buttonClicked)
        {
            if (!string.IsNullOrWhiteSpace(buttonClicked.Text) && !findingMatch) // Fix for CS0103: Use the declared 'findingMatch' field.
            {
                buttonClicked.BackgroundColor = Colors.Red;
                lastClicked = buttonClicked;
                findingMatch = true;
            }
            else
            {
                if (buttonClicked != lastClicked && (buttonClicked.Text == lastClicked.Text)
                    && (!String.IsNullOrWhiteSpace(buttonClicked.Text))) // checks if button player clicked on is not blank before adding 1 to macthesFound, therby not finsihing the game too early because of miscounted to 8 matches

                {
                    matchesFound++;
                    lastClicked.Text = " ";
                    buttonClicked.Text = " ";
                }
                lastClicked.BackgroundColor = Colors.LightBlue;
                buttonClicked.BackgroundColor = Colors.LightBlue;
                findingMatch = false;
            }
        }

        if (matchesFound == 8)
        {
            matchesFound = 0;
            AnimalButtons.IsVisible = false;
            PlayAgainButton.IsVisible = true;
        }
    }
}


//One last thing about the timer.The timer you used is guaranteed to fire no more than once
//every 10th of a second, but it may fire a little less frequently than that—which means the
//timer in the game may actually run a little slow. For this game, that’s absolutely fine!