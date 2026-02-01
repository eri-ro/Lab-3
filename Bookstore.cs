using UnityEngine;

public class Bookstore : MonoBehaviour
{
    [Header("INPUT")]
    [Tooltip("Cover price per book.")]
    [Min(0)] // doesn't allow input below zero for the next Inspector field
    public float coverPrice; // input in Inspector

    [Tooltip("Number of copies sold.")]
    [Min(0)] // doesn't allow input below zero for the next Inspector field
    public int copies; // input in Inspector

    private const float discountRate = 0.40f; // 40% discount
    private const float firstShipping = 3.00f; // $3 for first copy
    private const float additionalShipping = 0.75f; // $0.75 each additional copy

    void Start()
    {
         if (!IsValidInput(coverPrice, copies)) // error check to make sure both inputs are 
        {
            Debug.LogError("Cover price and copies need to be positive values.");
        }

        float cost = CalculateCost(coverPrice, copies);
        float revenue = CalculateRevenue(coverPrice, copies);
        float profit = CalculateProfit(revenue, cost);

        Debug.Log($"Cost = ${cost:F2} Profit = ${profit:F2}");
    }

    private float CalculateCost(float coverPrice, int copies)
    {
        float booksCost = CalculateUnitPrice(coverPrice) * copies; // book cost after discount * number of copies
        float shippingCost = CalculateShipping(copies);
        return booksCost + shippingCost;
    }

    private float CalculateUnitPrice(float coverPrice)
    {
        return coverPrice * (1f - discountRate); // 1 - discountRate = rate paid
    }

    private float CalculateShipping(int copies)
    {
        if (copies <= 0) return 0f;

        return firstShipping + ((copies - 1) * additionalShipping); // only 1 copy sold causes additionalShipping to be zero.
    }

    private float CalculateRevenue(float coverPrice, int copies)
    {
        return coverPrice * copies; // total revenue customer price * copies 
    }

    private float CalculateProfit(float revenue, float cost)
    {
        return revenue - cost; // profit = revenue - cost
    }

    private bool IsValidInput(float coverPrice, int copies)
    {
        return coverPrice >= 0 && copies >= 0; // returns true if coverPrice and Copies are both greater than or equal to zero
    }
}
