namespace ECET130Lab3MAUICalculator;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
	}

	private string doOperation(string firstNumber, string secondNumber, char operation)
	{
		double result = double.NaN;

		double firstNumberDouble;
        double secondNumberDouble;

        if (firstNumber == "")
		{
			firstNumberDouble = 0;
		}
		else
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
		}
		
		return $"{firstNumberDouble} {operation} {secondNumberDouble} = {result}";
	}

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

	private void toggleAllButtonEnabled(bool isEnabled)
	{
		addButton.IsEnabled = isEnabled;
        subtractButton.IsEnabled = isEnabled;
        multiplyButton.IsEnabled = isEnabled;
        divideButton.IsEnabled = isEnabled;
    }

    void addButton_Clicked(System.Object sender, System.EventArgs e)
    {

		resultLabel.Text = doOperation(firstNumberEntry.Text, secondNumberEntry.Text, '+');
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

    void firstNumberEntry_TextChanged(System.Object sender, Microsoft.Maui.Controls.TextChangedEventArgs e)
    {
		if (!checkIfInputIsValid(firstNumberEntry.Text)){
			firstNumberEntry.BackgroundColor = Color.FromRgb(255, 0, 0);
			toggleAllButtonEnabled(false);
		}
        else
        {
            firstNumberEntry.BackgroundColor = Color.FromRgb(0, 0, 0);
			toggleAllButtonEnabled(true);
        }
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

