using DataStructures.BinarySearchTree;

namespace Tests.BinarySearchTree;

public class BSTTest
{

  [Test]
  public void HBSTTests()
  {
    var bst = new BST();
    bst.Add(50);
    bst.Add(25);
    bst.Add(12);
    bst.Add(35);
    bst.Add(75);
    bst.Add(60);
    bst.Add(90);
    bst.Add(85);
    bst.Add(100);
    bst.Add(35);
    bst.Add(47);
    bst.Add(5);
    bst.Add(6);

    var inOrder = bst.TraverseInOrder();
    var expectedResult = new List<int> { 5, 6, 12, 25, 35, 47, 50, 60, 75, 85, 90, 100 };
    Assert.That(inOrder, Is.EqualTo(expectedResult));

  }
}