using UnityEngine;
using System.Text;

public class DollarBills : MonoBehaviour
{
    [Header("INPUT")]
    [Tooltip("Total dollars owed in whole dollars.")]
    [Min(0)] // doesn't allow input below zero for the next Inspector field
    public int totalDollars; // input in Inspector

    private int[] bills = { 100, 50, 20, 10, 5, 1 }; // denomination of bills

    private StringBuilder outputText; // output text. allows easy appending in functions/loops

    void Start()
    {
        if (!IsValidInput(totalDollars)) // error check to make sure totalDollars is 0 or greater
        {
            Debug.LogError("Total dollars needs to be a positive value.");
            return;
        }

        outputText = new StringBuilder();
        outputText.Append($"Total: ${totalDollars}: ");

        Change(totalDollars, 0); // calls the Change funtion with the total dollar amount and the first index of bills[]

        Debug.Log(outputText.ToString());
    }
    
    void Change(int totalDollars, int n)
    {
        if (n >= bills.Length)  // checks to see if n is out of range of bills array
            return;
        
        if (totalDollars >= bills[n])   // check to see if the current bill can be skipped
        {
            int billCount = Count(totalDollars, bills[n]);     // gives the interger number of bills
            totalDollars = Remaining(totalDollars, bills[n]);  // gives the remaining dollars
            outputText.Append($"{billCount} x ${bills[n]}, "); // appends the outputText with count of the bill
        }
        
        Change(totalDollars, n+1); // call function with remaining dollars and next bill
    }

    private int Count(int totalDollars, int bill)
    {
        return totalDollars / bill; // returns the count of current bill
    }

    private int Remaining(int totalDOllars, int bill)
    {
        return totalDollars % bill; // returns the remaining dollars after removing all of current bill
    }
    private bool IsValidInput(int totalDollars)
    {
        return totalDollars >= 0; // returns true if greater than or equal to zero
    }
}