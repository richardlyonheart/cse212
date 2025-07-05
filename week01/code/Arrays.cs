public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.
        // Step 1: Create an array to hold the multiples. Its size is defined by 'length'.
        // Step 2: Use a loop that runs from 0 to length - 1.
        // Step 3: In each iteration, multiply 'number' by the current loop index + 1.
        // Step 4: Store the result in the corresponding index of the array.
        // Step 5: After the loop, return the array with the computed multiples.

        double[] result = new double[length];
        for (int i = 0; i < length; i++)
        {
           result[i] = number * (i + 1);
        }

         return result;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    /// 
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.
        //  Step 1: Create a list fot the values
        //  Step 2: loop through each index to calulate position
        //  Step 3: use modelo to wrap end of list
        //  Step 3: place in new rotated position
        // 
        var rotated = new int[data.Count];
        for (int i = 0; i < data.Count; i++)
        {
            int newIndex = (i + amount) % data.Count;
            rotated[newIndex] =  data[i];
        }
        for (int i = 0; i < data.Count; i++)
        {
            data[i] = rotated[i];
        }
    }
}

