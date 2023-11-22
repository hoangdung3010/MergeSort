// See https://aka.ms/new-console-template for more information
using System.Text;

Console.OutputEncoding = Encoding.UTF8;
//mảng ban đầu
int[] arr = { 38, 27, 43, 3, 9, 82, 10 };
Console.WriteLine("Mảng chưa sắp xếp:");
PrintArray(arr);

MergeSortAlgorithm(arr, 0, arr.Length - 1);
Console.WriteLine("\nMảng đã sắp xếp:");
PrintArray(arr);

/// <summary>
/// MergeSortAlgorithm
/// Createdby: HVDUNG (22/11/2023)
/// </summary>
/// <returns>
/// hàm đệ quy thực hiện thuật toán chia để trị
/// </returns>
static void MergeSortAlgorithm(int[] arr, int left, int right)
{
    if (left < right)
    {
        int mid = left + (right - left) / 2;

        MergeSortAlgorithm(arr, left, mid);      // Đệ quy cho nửa bên trái
        MergeSortAlgorithm(arr, mid + 1, right); // Đệ quy cho nửa bên phải

        Merge(arr, left, mid, right);            // Gộp hai nửa đã sắp xếp
    }
}

/// <summary>
/// Merge
/// Createdby: HVDUNG (22/11/2023)
/// </summary>
/// <returns>
/// hàm thực hiện quá trình gộp hai mảng đã sắp xếp
/// </returns>
static void Merge(int[] arr, int left, int mid, int right)
{
    int n1 = mid - left + 1;
    int n2 = right - mid;

    int[] leftHalf = new int[n1];
    int[] rightHalf = new int[n2];

    // Sao chép dữ liệu vào các mảng tạm
    for (int i = 0; i < n1; i++)
        leftHalf[i] = arr[left + i];
    for (int j = 0; j < n2; j++)
        rightHalf[j] = arr[mid + 1 + j];

    // Gộp hai mảng tạm vào mảng chính
    int x = 0, y = 0;
    int k = left;

    while (x < n1 && y < n2)
    {
        if (leftHalf[x] <= rightHalf[y])
        {
            arr[k] = leftHalf[x];
            x++;
        }
        else
        {
            arr[k] = rightHalf[y];
            y++;
        }
        k++;
    }

    // Sao chép các phần tử còn lại của leftHalf (nếu có)
    while (x < n1)
    {
        arr[k] = leftHalf[x];
        x++;
        k++;
    }

    // Sao chép các phần tử còn lại của rightHalf (nếu có)
    while (y < n2)
    {
        arr[k] = rightHalf[y];
        y++;
        k++;
    }
}

/// <summary>
/// PrintArray
/// Createdby: HVDUNG (22/11/2023)
/// </summary>
/// <returns>
/// in mảng ra màn hình để kiểm tra
/// </returns>
static void PrintArray(int[] arr)
{
    foreach (var item in arr)
    {
        Console.Write(item + " ");
    }
    Console.WriteLine();
}
