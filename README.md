# 🔍 Linear Search and Binary Search in C#

## 📌 Overview

This project demonstrates two fundamental searching algorithms:

* **Linear Search**
* **Binary Search**

Both algorithms are implemented in C# to search for an element in an array.

---

## 🚀 Algorithms Explained

### 1️⃣ Linear Search

Linear Search checks each element one by one until the target element is found.

**Time Complexity:**

* Best Case: O(1)
* Worst Case: O(n)

**Use Case:**

* Works on both sorted and unsorted data

---

### 2️⃣ Binary Search

Binary Search works on **sorted arrays** by repeatedly dividing the search space into half.

**Time Complexity:**

* Best Case: O(1)
* Worst Case: O(log n)

**Use Case:**

* Efficient for large, sorted datasets

---

## 🛠️ Technologies Used

* C#
* .NET

---

## 📂 Project Structure

```
Sorting_algorithm/
 ├── Program.cs
 ├── BinarySearchClass.cs
 ├── Sorting_algorithm.csproj
```

---

## ▶️ How to Run

1. Clone the repository:

```
git clone <your-repo-link>
```

2. Open in Visual Studio

3. Build and Run the project

---

## 📌 Sample Input

```
Array: 10, 20, 30, 40, 50
Search Element: 30
```

## ✅ Sample Output

```
Linear Search: Element found at index 2
Binary Search: Element found at index 2
```

---

## ⚠️ Important Notes

* Binary Search requires the array to be **sorted**
* Linear Search works on any dataset

---

## 📈 Comparison

| Feature         | Linear Search | Binary Search |
| --------------- | ------------- | ------------- |
| Data Required   | Unsorted      | Sorted        |
| Time Complexity | O(n)          | O(log n)      |
| Efficiency      | Slower        | Faster        |

---

## 💡 Conclusion

Binary Search is more efficient than Linear Search for large datasets, but it requires sorted data. Linear Search is simple and works in all cases.

---

## 👨‍💻 Author

Sagar
