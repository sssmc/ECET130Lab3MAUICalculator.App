namespace ECET130Lab3MAUICalculator;
using CalculatorLib;

public partial class MainPage : ContentPage
{

	int easterEggCounter = 0;

    Calculator calculator = new Calculator();

	public MainPage()
	{
		InitializeComponent();
	}

    void calculateButton_Clicked(System.Object sender, System.EventArgs e)
    {
        //resultLabel.Text = calculator.parseOperationString(equationEntry.Text).ToString();
    }

    void equationEntry_TextChanged(System.Object sender, Microsoft.Maui.Controls.TextChangedEventArgs e)
    {
        resultLabel.Text = calculator.parseOperationString(calculator.checkForBracketError(equationEntry.Text)).ToString();
    }
}

