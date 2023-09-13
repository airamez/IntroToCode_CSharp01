public class MyArray {
    public static int[] Clone (int[] inputArray) {
        int[] clonedArray = new int[inputArray.Length];
        for (int i = 0; i < clonedArray.Length; i++)
        {
            clonedArray[i] = inputArray[i];
        }
        return clonedArray;
    }
}