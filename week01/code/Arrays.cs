public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number'
    /// followed by multiples of 'number'.
    /// Example: MultiplesOf(7, 5) → {7, 14, 21, 28, 35}
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // Step 1: Create a new array of doubles with size equal to length.
        double[] result = new double[length];

        // Step 2: Loop through the array using an index from 0 to length - 1.
        for (int i = 0; i < length; i++)
        {
            // Step 3: Multiply the number by (index + 1).
            result[i] = number * (i + 1);
        }

        // Step 4: Return the completed array.
        return result;
    }

    /// <summary>
    /// Rotate the 'data' list to the right by the given 'amount'.
    /// Example: {1,2,3,4,5,6,7,8,9} rotated by 3 →
    /// {7,8,9,1,2,3,4,5,6}
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // Step 1: Adjust the rotation amount using modulo so it stays within the list size.
        amount = amount % data.Count;

        // Step 2: Find the starting index of elements to move to the front.
        int startIndex = data.Count - amount;

        // Step 3: Copy the elements that will be moved into a temporary list.
        List<int> temp = data.GetRange(startIndex, amount);

        // Step 4: Remove those elements from the end of the original list.
        data.RemoveRange(startIndex, amount);

        // Step 5: Insert the copied elements at the beginning of the list.
        data.InsertRange(0, temp);
    }
}

