namespace ECET130Lab3MAUICalculator;

public partial class MainPage : ContentPage
{

	int easterEggCounter = 0;

	public MainPage()
	{
		InitializeComponent();
	}

	//Converts the two numbers to doubles and returns the result of the requested operation formatted in a string
	//If an erro eccurred, NaN will be retured
	private string doOperation(string firstNumber, string secondNumber, char operation)
	{
		//Inits results and numbers as NaN so if the operation/conversion is sucessfully completed, NaN is returned
		double result = double.NaN;
		double firstNumberDouble = double.NaN;
        double secondNumberDouble = double.NaN;

		//If either othe input numbers is empty, set number to zero
        if (firstNumber == "")
		{
			firstNumberDouble = 0;
		}
		else//Try string to double conversion
		{
			double.TryParse(firstNumber, out firstNumberDouble);
		}

		if(secondNumber == "")
		{
			secondNumberDouble = 0;
		}
		else
		{
            double.TryParse(secondNumber, out secondNumberDouble);
        }

		//Perfrom the requested operation
        switch (operation)
		{
			case '+':
				result = firstNumberDouble + secondNumberDouble;
				break;
			case '-':
				result = firstNumberDouble - secondNumberDouble;
				break;
			case '*':
				result = firstNumberDouble * secondNumberDouble;
				break;
			case '/':
				result = firstNumberDouble / secondNumberDouble;
				break;
			case '^':
				result = Math.Pow(firstNumberDouble, secondNumberDouble);
				break;
		}

		//Return the string with the operation and result
		return $"{firstNumberDouble} {operation} {secondNumberDouble} = {result}";
	}

	//Check is the string is a valid doule input(true if string is empty)
	private bool checkIfInputIsValid(string input)
	{
		double output;
		if(input == "")
		{
			return true;
		}
		else
		{
            return double.TryParse(input, out output);
        }
		
	}

	//Sets isEnabled on all operation buttons to the selected state
	private void toggleAllButtonEnabled(bool isEnabled)
	{
		addButton.IsEnabled = isEnabled;
        subtractButton.IsEnabled = isEnabled;
        multiplyButton.IsEnabled = isEnabled;
        divideButton.IsEnabled = isEnabled;
		exponentButton.IsEnabled = isEnabled;
    }

	//Button on click event handlers for the operation buttons
    void addButton_Clicked(System.Object sender, System.EventArgs e)
    {
		resultLabel.Text = doOperation(firstNumberEntry.Text, secondNumberEntry.Text, '+');
		easterEggCounter++;
		//Easter Eggs
		if(easterEggCounter >= 9)
		{
			easterEggCounter = 0;
			titleLabel.Text = "Sebastien's Calculator";
		}
		else
		{
            titleLabel.Text = "Calculator";
        }
    }

    void subtractButton_Clicked(System.Object sender, System.EventArgs e)
    {
        resultLabel.Text = doOperation(firstNumberEntry.Text, secondNumberEntry.Text, '-');
    }

    void multiplyButton_Clicked(System.Object sender, System.EventArgs e)
    {
        resultLabel.Text = doOperation(firstNumberEntry.Text, secondNumberEntry.Text, '*');
    }

    void divideButton_Clicked(System.Object sender, System.EventArgs e)
    {
        resultLabel.Text = doOperation(firstNumberEntry.Text, secondNumberEntry.Text, '/');
    }

    void exponentButton_Clicked(System.Object sender, System.EventArgs e)
    {
		resultLabel.Text = doOperation(firstNumberEntry.Text, secondNumberEntry.Text, '^');
    }


	//On text changed event handler for the number inputs
    void firstNumberEntry_TextChanged(System.Object sender, Microsoft.Maui.Controls.TextChangedEventArgs e)
    {
		//If the entry current text is not a valid double
		if (!checkIfInputIsValid(firstNumberEntry.Text)){
			//Set entry background to red and disable all operation buttons
			firstNumberEntry.BackgroundColor = Color.FromRgb(255, 0, 0);
			toggleAllButtonEnabled(false);
		}
        else
        {
            //Set entry background to black and enable all operation buttons
            firstNumberEntry.BackgroundColor = Color.FromRgb(0, 0, 0);
			toggleAllButtonEnabled(true);
        }

		//Disable the buttons if either of the input fields is invalid
        if (!checkIfInputIsValid(firstNumberEntry.Text) || !checkIfInputIsValid(secondNumberEntry.Text))
        {
            toggleAllButtonEnabled(false);
        }
    }

    void secondNumberEntry_TextChanged(System.Object sender, Microsoft.Maui.Controls.TextChangedEventArgs e)
    {
        if (!checkIfInputIsValid(secondNumberEntry.Text)){
            secondNumberEntry.BackgroundColor = Color.FromRgb(255, 0, 0);
            toggleAllButtonEnabled(false);
        }
		else
		{
            secondNumberEntry.BackgroundColor = Color.FromRgb(0, 0, 0);
            toggleAllButtonEnabled(true);
        }
		if(!checkIfInputIsValid(firstNumberEntry.Text) || !checkIfInputIsValid(secondNumberEntry.Text))
		{
            toggleAllButtonEnabled(false);
        }
    }
}

